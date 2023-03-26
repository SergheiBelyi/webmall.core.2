using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web.Mvc;

namespace Webmall.UI.Core.Localization
{
    public class LocalizationAttribute : ActionFilterAttribute
    {
        private static string _defaultLanguage;

        public static string DefaultLanguage => _defaultLanguage;

        public LocalizationAttribute(string defaultLanguage)
        {
            _defaultLanguage = defaultLanguage;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (_defaultLanguage == null)
                _defaultLanguage = CmsHelper.Languages.FirstOrDefault(i => i.IsDefault)?.Culture ?? CmsHelper.Languages.FirstOrDefault()?.Culture ?? "ru";
            var lang = (string)filterContext.RouteData.Values["lang"] ?? _defaultLanguage;
            if (lang == _defaultLanguage)
            {
                ChangePath(filterContext);
            }

            CultureInfo culture;
            try
            {
                culture = new CultureInfo(lang);
            }
            catch (Exception)
            {
                // throw new NotSupportedException($"ERROR: Invalid language code '{lang}'.", e);
                culture = new CultureInfo(_defaultLanguage);
            }
            CultureInfo.CurrentCulture = CultureInfo.CurrentUICulture = Thread.CurrentThread.CurrentCulture =
                Thread.CurrentThread.CurrentUICulture = culture;
        }

        private void ChangePath(ActionExecutingContext filterContext)
        {
            var langPath = $"/{_defaultLanguage}/";
            if (filterContext.HttpContext.Request.RawUrl.Contains(langPath))
            {
                filterContext.Result =
                    new RedirectResult(filterContext.HttpContext.Request.RawUrl.Replace(langPath, "/"));
            }
            else
            {
                langPath = $"/{_defaultLanguage}";
                if (filterContext.HttpContext.Request.Url?.LocalPath == langPath)
                {
                    filterContext.Result =
                        new RedirectResult(filterContext.HttpContext.Request.RawUrl.Replace(langPath, "/"));
                }
            }
        }
    }
}