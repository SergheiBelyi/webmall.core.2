using System;
using System.Configuration;
using System.Web;
using System.Web.Mvc;

namespace Webmall.UI.Core.Attributes
{
    public class ReferrerFilterAttribute : ActionFilterAttribute
    {
        private string _referrer;

        public string Referrer
        {
            get
            {
                return !string.IsNullOrWhiteSpace(_referrer) ? _referrer : (FromAppSettings ? ConfigurationManager.AppSettings[AppSettingsKey] : string.Empty);
            }
            set
            {
                _referrer = value;
            }
        }

        public bool FromAppSettings
        {
            get; 
            set;
        }

        public string AppSettingsKey
        {
            get; 
            set;
        }

        public ReferrerFilterAttribute()
        {
            if (HttpContext.Current != null)
                Referrer = GetReferrer(HttpContext.Current.Request.Url);
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var referrer = GetReferrer(HttpContext.Current.Request.UrlReferrer);

            if (Referrer != referrer)
            {
                SecurityHelper.AccessDenied(filterContext);
                return;
            }

            base.OnActionExecuting(filterContext);
        }

        private static string GetReferrer(Uri url)
        {
            if (url == null)
            {
                return string.Empty;
            }

            var referrer = string.Format("{0}{1}{2}{3}", url.Scheme, Uri.SchemeDelimiter, url.Host, url.IsDefaultPort ? string.Empty : ":" + url.Port);

            return referrer;
        }
    }
}