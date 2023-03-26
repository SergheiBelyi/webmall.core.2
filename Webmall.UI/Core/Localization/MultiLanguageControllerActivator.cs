using System;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;
using System.Web.Routing;

namespace Webmall.UI.Core.Localization
{
    public class MultiLanguageControllerActivator : IControllerActivator
    {
        private string _fallBackLanguage = "ru-RU";
        public IController Create(RequestContext requestContext, Type controllerType)
        {
            if (requestContext.HttpContext.Request.UserLanguages != null)
            {
                _fallBackLanguage = requestContext.HttpContext.Request.UserLanguages[0] ?? _fallBackLanguage;
            }

            Thread.CurrentThread.CurrentCulture = new CultureInfo(_fallBackLanguage);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(_fallBackLanguage);

            return DependencyResolver.Current.GetService(controllerType) as IController;
        }
    }
}
