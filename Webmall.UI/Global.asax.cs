using System;
using System.Web;
using log4net;
using log4net.Config;
using Webmall.UI.Core;
using Webmall.UI.Core.AccessStatistics;

namespace Webmall.UI
{
    public class MvcApplication : HttpApplication
    {
        #region Logger

        public static readonly ILog Log = LogManager.GetLogger(typeof(MvcApplication));

        #endregion

        //private static IScheduler _scheduler;

        #region AccessStatistics

        public static AccessStatistic AccessStatistics => MVCApplicationHandlers.AccessStatistics;

        #endregion


        static MvcApplication()
        {
            XmlConfigurator.Configure();
        }

        protected void Application_Start()
        {
            MVCApplicationHandlers.Application_Start(this);
        }

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            MVCApplicationHandlers.Application_BeginRequest(this, sender, e);
        }

        /// <summary>
        /// Обработчик ошибок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Error(object sender, EventArgs e)
        {
            MVCApplicationHandlers.Application_Error(this, sender, e);
        }

        protected void Application_AuthorizeRequest()
        {
            MVCApplicationHandlers.Application_AuthorizeRequest(this);
        }

        protected void Application_PostAuthorizeRequest()
        {
            MVCApplicationHandlers.Application_PostAuthorizeRequest(this);
        }

        protected void Application_EndRequest()
        {
            MVCApplicationHandlers.Application_EndRequest(this);
        }

        //static void InitScheduleJobs()
        //{
        //    // Job для рассылки уведомлений учебного центра
        //    var period = ConfigHelper.SubscribeProcessSchedule;
        //    try
        //    {
        //        Log.DebugFormat("Creating job for Subscribe sending with period '{0}'", period);
        //        var job = JobBuilder.Create<SubscribeProcessJob>().Build();

        //        var trigger = TriggerBuilder.Create()
        //            .StartNow()
        //            .WithCronSchedule(period)
        //            .Build();

        //        _scheduler.ScheduleJob(job, trigger);
        //        Log.DebugFormat("Created job for Subscribe sending with period '{0}'", period);
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.ErrorFormat("Creating job for Subscribe sending with period '{0}' failed. Trace: {1}", period, ex);
        //    }

        //    //// Job для закрытия банковского дня
        //    //period = ConfigHelper.CloseBankDaySchedule;
        //    //try
        //    //{
        //    //    Log.DebugFormat("Creating job for Closing Bank Day with period '{0}'", period);
        //    //    var job = JobBuilder.Create<CloseBankDayJob>().Build();

        //    //    var trigger = TriggerBuilder.Create()
        //    //        .StartNow()
        //    //        .WithCronSchedule(period)
        //    //        .Build();

        //    //    _scheduler.ScheduleJob(job, trigger);
        //    //    Log.DebugFormat("Created job for Closing Bank Day with period '{0}'", period);
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    Log.ErrorFormat("Creating job for Closing Bank Day failed. Trace: {0}", ex);
        //    //}

        //    // Job для фиксации победителей акций
        //    period = ConfigHelper.GetActionWinnerProcessSchedule;
        //    try
        //    {
        //        Log.DebugFormat("Creating job for GetActionWinners with period '{0}'", period);
        //        var job = JobBuilder.Create<GetActionWinnerProcessJob>().Build();

        //        var trigger = TriggerBuilder.Create()
        //            .StartNow()
        //            .WithCronSchedule(period)
        //            .Build();

        //        _scheduler.ScheduleJob(job, trigger);
        //        Log.DebugFormat("Created job for GetActionWinners with period '{0}'", period);
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.ErrorFormat("Creating job for GetActionWinners with period '{0}' failed. Trace: {1}", period, ex);
        //    }
        //}

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

        protected void Application_PreSendRequestHeaders(Object sender, EventArgs e)
        {
          //  using (MiniProfiler.Current.Step("Application_PreSendRequestHeaders")) { }
        }

        protected void Application_PreSendRequestContent(Object sender, EventArgs e)
        {
           // using (MiniProfiler.Current.Step("Application_PreSendRequestContent")) { }
        }

        protected void Application_AcquireRequestState(Object sender, EventArgs e)
        {
            MVCApplicationHandlers.Application_AcquireRequestState(this, sender, e);
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
