using log4net;
using log4net.Config;
using Quartz;
using Quartz.Impl;
using StackExchange.Profiling;
using StackExchange.Profiling.EntityFramework6;
using System;
using System.Configuration;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Webmall.UI.Controllers;
using Webmall.UI.Core.AccessStatistics;
using Webmall.UI.Core.MiniProfiler;
using System.Web.Http;
using System.Web.SessionState;
using Webmall.Model;

namespace Webmall.UI.Core
{
    // ReSharper disable once InconsistentNaming
    public static class MVCApplicationHandlers
    {
        #region Logger

        public static readonly ILog Log = LogManager.GetLogger(typeof(MVCApplicationHandlers));

        #endregion

        #region AccessStatistics

        public static readonly AccessStatistic AccessStatistics = new AccessStatistic();

        #endregion

        private const string WebApiPrefix = "api";
        private static readonly string WebApiExecutionPath = $"~/{WebApiPrefix}";

        private static IScheduler _scheduler;
        public static IScheduler Scheduler => _scheduler;
        
        static MVCApplicationHandlers()
        {
            XmlConfigurator.Configure();
        }

        public static void Application_Start (HttpApplication app)
        {
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            //ControllerBuilder.Current.SetControllerFactory(new DefaultControllerFactory(new MultiLanguageControllerActivator()));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            GlobalConfiguration.Configure(WebApiConfig.Register);
            
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutofacConfig.DependencyInjectionInit();
            VirtualPathConfig.RegisterVirtualPaths();

            AccessStatistics.Clear();
            AccessStatistic.StartPublishing();

            InitScheduler();
            ConfigHelper.Init(DependencyResolver.Current);
            CmsHelper.Init(DependencyResolver.Current);
            MiniProfilerEF6.Initialize();
        }

        public static void Application_PostAuthorizeRequest(HttpApplication app)
        {
            if (IsWebApiRequest())
            {
                HttpContext.Current.SetSessionStateBehavior(SessionStateBehavior.Required);
            }
        }

        private static bool IsWebApiRequest()
        {
            return HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath != null && HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath.StartsWith(WebApiExecutionPath);
        }


        public static async void InitScheduler()
        {
            if (_scheduler == null)
            {
                var schedulerFactory = new StdSchedulerFactory();
                _scheduler = await schedulerFactory.GetScheduler();
                InitScheduleJobs();
                await _scheduler?.Start();
            }
        }

        public static void Application_BeginRequest(HttpApplication app, object sender, EventArgs e)
        {
            //if (HttpContext.Current.Request.Url.AbsoluteUri.Contains("/Btclr?"))
            //{
            //    HttpContext.Current.Response.StatusCode = 404;
            //    app.CompleteRequest();
            //    return;
            //}

            //HttpApplication application = (HttpApplication)sender;
            //HttpContext context = application.Context;
            if (HttpContext.Current.Request.Url.AbsoluteUri.Contains("/Payment"))
            {
                Log.Debug($"Payment request detected: {HttpContext.Current.Request.Url.AbsoluteUri}");
            }

            string culture = UserPreferences.CurrentCulture;

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

            if (ConfigHelper.CacheOff)
            {
                foreach (System.Collections.DictionaryEntry entry in HttpRuntime.Cache)
                {
                    HttpRuntime.Cache.Remove((string)entry.Key);
                }
            }

            HttpContext.Current.Items.Add(SessionHelper.IIS_TIME, DateTime.Now);
            HttpContext.Current.Items.Add(SessionHelper.DB_TIME, null);
            if (ConfigHelper.AllowProfiler)
            {
                StackExchange.Profiling.MiniProfiler.StartNew();
                if (StackExchange.Profiling.MiniProfiler.Current != null)
                    StackExchange.Profiling.MiniProfiler.Current.Name = "started";
            }
        }

        public static void Application_PreRequestHandlerExecute(HttpApplication app, object sender, EventArgs e)
        {
        }

        // ReSharper disable once InconsistentNaming
        public static bool IsUserAllowedToSeeMiniProfilerUI()
        {
            var context = HttpContext.Current;
            if (context.User == null)
                return false;
            if (!context.User.Identity.IsAuthenticated)
                return false;
            if (context.Session == null)
                return false;
            return SessionHelper.CurrentUser != null && SessionHelper.CurrentUser.IsAdmin;
        }

        /// <summary>
        /// Обработчик ошибок
        /// </summary>
        /// <param name="app"></param>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void Application_Error(HttpApplication app, object sender, EventArgs e)
        {
            var lastErrorWrapper = app.Server.GetLastError();
            Log.FatalFormat("(Request: {2}) Error message: {0}. Trace: {1}", lastErrorWrapper.Message, lastErrorWrapper.StackTrace, HttpContext.Current.Request.GetHashCode());
            if (lastErrorWrapper.InnerException != null)
                Log.FatalFormat("Inner Exception: {0}. Trace: {1}", lastErrorWrapper.InnerException.Message, lastErrorWrapper.InnerException.StackTrace);

            var httpContext = ((HttpApplication)sender).Context;

            // Получить конфигурацию
            const string customErrorsSettingsKey = "system.web/customErrors";
            // Проверить на необходимость спец. обработки
            if (!(ConfigurationManager.GetSection(customErrorsSettingsKey) is CustomErrorsSection customErrorSection) || customErrorSection.Mode == CustomErrorsMode.Off ||
                 (customErrorSection.Mode == CustomErrorsMode.RemoteOnly && httpContext.Request.IsLocal)) return;

            var currentController = " ";
            var currentAction = " ";
            var currentRouteData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));

            if (currentRouteData != null)
            {
                if (!string.IsNullOrEmpty(currentRouteData.Values["controller"]?.ToString()))
                {
                    currentController = currentRouteData.Values["controller"].ToString();
                }

                if (!string.IsNullOrEmpty(currentRouteData.Values["action"]?.ToString()))
                {
                    currentAction = currentRouteData.Values["action"].ToString();
                }
            }

            var routeData = new RouteData();
            var controller = new ErrorController();


            httpContext.ClearError();
            httpContext.Response.Clear();
            httpContext.Response.StatusCode = lastErrorWrapper is HttpException exception
                                                 ? exception.GetHttpCode()
                                                 : 500;
            httpContext.Response.TrySkipIisCustomErrors = true;
            routeData.Values["controller"] = "Error";
            routeData.Values["action"] = httpContext.Response.StatusCode == 404 ? "Error404" : "Error500";

            controller.ViewData.Model = new HandleErrorInfo(lastErrorWrapper, currentController, currentAction);
            ((IController)controller).Execute(new RequestContext(new HttpContextWrapper(httpContext), routeData));
        }

        public static void Application_AuthorizeRequest(HttpApplication app)
        {
            //AccessStatistics.AddRecord(app.Request);
        }

        public static void Application_EndRequest(HttpApplication app)
        {
            StackExchange.Profiling.MiniProfiler.Current?.Stop();
            if (StackExchange.Profiling.MiniProfiler.Current != null)
            {
                var logText = StackExchange.Profiling.MiniProfiler.Current.RenderPlainTextEx();
                if (!string.IsNullOrEmpty(logText))
                {
                    var prevReqTime = (string)HttpContext.Current.Items[SessionHelper.PREV_REQ_TIMES];
                    Log.Debug(logText + (string.IsNullOrEmpty(prevReqTime) ? "" : "PrevReqTime: " + prevReqTime));
                }
            }
            if ((AccessStatistics.IsCurrentUserBlocked)
                && app.Request.HttpMethod == "GET"
                && !app.Request.Url.AbsoluteUri.Contains("BotDetected")
                && !app.Request.Url.AbsoluteUri.Contains("Content")
                && !app.Request.Url.AbsoluteUri.Contains("Image")
                && !app.Request.Url.AbsoluteUri.Contains("Scripts")
                && !app.Request.Url.AbsoluteUri.Contains("captcha")
                && !app.Request.Url.AbsoluteUri.Contains("api")
                && !app.Request.Url.AbsoluteUri.Contains("Authorize")
                )
            {
                app.Response.RedirectToRoute("IsBlocked");
            }
        }

        static void InitScheduleJobs()
        {
            // Job для рассылки уведомлений учебного центра
            //var period = ConfigHelper.SubscribeProcessSchedule;
            //try
            //{
            //    Log.DebugFormat("Creating job for Subscribe sending with period '{0}'", period);
            //    var job = JobBuilder.Create<SubscribeProcessJob>().Build();

            //    var trigger = TriggerBuilder.Create()
            //        .StartNow()
            //        .WithCronSchedule(period)
            //        .Build();

            //    _scheduler.ScheduleJob(job, trigger);
            //    Log.DebugFormat("Created job for Subscribe sending with period '{0}'", period);
            //}
            //catch (Exception ex)
            //{
            //    Log.ErrorFormat("Creating job for Subscribe sending with period '{0}' failed. Trace: {1}", period, ex);
            //}

            //// Job для закрытия банковского дня
            //period = ConfigHelper.CloseBankDaySchedule;
            //try
            //{
            //    Log.DebugFormat("Creating job for Closing Bank Day with period '{0}'", period);
            //    var job = JobBuilder.Create<CloseBankDayJob>().Build();

            //    var trigger = TriggerBuilder.Create()
            //        .StartNow()
            //        .WithCronSchedule(period)
            //        .Build();

            //    _scheduler.ScheduleJob(job, trigger);
            //    Log.DebugFormat("Created job for Closing Bank Day with period '{0}'", period);
            //}
            //catch (Exception ex)
            //{
            //    Log.ErrorFormat("Creating job for Closing Bank Day failed. Trace: {0}", ex);
            //}

            // Job для фиксации победителей акций
            //period = ConfigHelper.GetActionWinnerProcessSchedule;
            //try
            //{
            //    Log.DebugFormat("Creating job for GetActionWinners with period '{0}'", period);
            //    var job = JobBuilder.Create<GetActionWinnerProcessJob>().Build();

            //    var trigger = TriggerBuilder.Create()
            //        .StartNow()
            //        .WithCronSchedule(period)
            //        .Build();

            //    _scheduler.ScheduleJob(job, trigger);
            //    Log.DebugFormat("Created job for GetActionWinners with period '{0}'", period);
            //}
            //catch (Exception ex)
            //{
            //    Log.ErrorFormat("Creating job for GetActionWinners with period '{0}' failed. Trace: {1}", period, ex);
            //}
        }

        //protected void Application_End(Object sender, EventArgs e)
        //{
        //    Debug.WriteLine("protected void Application_End();");
        //}

        //protected void Application_Disposed(Object sender, EventArgs e)
        //{
        //    Debug.WriteLine("protected void Application_Disposed();");
        //}

        //protected void Application_BeginRequest(Object sender, EventArgs e)
        //{
        //    using (MiniProfiler.Current.Step("Application_BeginRequest")) { }
        //}

        //protected void Application_EndRequest(Object sender, EventArgs e)
        //{
        //    Debug.WriteLine("protected void Application_EndRequest();");
        //}

        //protected void Application_PostRequestHandlerExecute(Object sender, EventArgs e)
        //{
        //    Debug.WriteLine("protected void Application_PostRequestHandlerExecute();");
        //}

        public static void Application_PreSendRequestHeaders(HttpApplication app, object sender, EventArgs e)
        {
            //  using (MiniProfiler.Current.Step("Application_PreSendRequestHeaders")) { }
        }

        public static void Application_PreSendRequestContent(HttpApplication app, object sender, EventArgs e)
        {
            // using (MiniProfiler.Current.Step("Application_PreSendRequestContent")) { }
        }

        public static void Application_AcquireRequestState(HttpApplication app, object sender, EventArgs e)
        {
            if (!ConfigHelper.AllowProfiler)
                return;

            if (IsUserAllowedToSeeMiniProfilerUI())
            {
                var profiler = StackExchange.Profiling.MiniProfiler.Current;
                var session = HttpContext.Current.Session;
                var user = SessionHelper.CurrentUser;

                using (profiler.Step("Application_AcquireRequestState: sId:" + (session != null ? session.SessionID : "") + ", user:" + (user != null ? user.Email : ""))) { }
            }
            else
            {
                if (StackExchange.Profiling.MiniProfiler.Current != null)
                    StackExchange.Profiling.MiniProfiler.Current.Name = null;
                //MiniProfiler.Stop(true);
            }
        }
        /*
        protected void Application_MapRequestHandler(Object sender, EventArgs e)
        {
           // using (MiniProfiler.Current.Step("Application_MapRequestHandler")) { }
        }

        protected void Application_PostMapRequestHandler(Object sender, EventArgs e)
        {
           // using (MiniProfiler.Current.Step("Application_PostMapRequestHandler")) { }
        }

        protected void Application_ResolveRequestCache(Object sender, EventArgs e)
        {
          //  using (MiniProfiler.Current.Step("Application_ResolveRequestCache")) { }
        }

        protected void Application_UpdateRequestCache(Object sender, EventArgs e)
        {
          //  using (MiniProfiler.Current.Step("Application_UpdateRequestCache")) { }
        }

        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
          //  using (MiniProfiler.Current.Step("Application_AuthenticateRequest")) { }
        }

        protected void Application_AuthorizeRequest(Object sender, EventArgs e)
        {
          //  using (MiniProfiler.Current.Step("Application_AuthorizeRequest")) { }
        }

        protected void Session_Start(Object sender, EventArgs e)
        {
          //  using (MiniProfiler.Current.Step("Session_Start")) { }
        }
        */

    }
}