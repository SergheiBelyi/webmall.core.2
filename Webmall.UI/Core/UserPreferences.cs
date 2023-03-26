using System.Globalization;
using System.Web;
using Webmall.Model;
using Webmall.UI.Core.Helpers;
using Webmall.UI.Core.Localization;

namespace Webmall.UI.Core
{
    public static class UserPreferences
    {
        private static readonly string CurrentCultureKey = ConfigHelper.CultureCookieName;

        public static string CurrentCultureLink => CultureInfo.CurrentCulture.Name != LocalizationAttribute.DefaultLanguage ? CultureInfo.CurrentCulture.Name+"/" : "";

        public static string CurrentCulture
        {
            get => CultureInfo.CurrentCulture.Name;
            set
            {
                var cookie = HttpContext.Current.Request.Cookies[CurrentCultureKey];
                if (cookie != null)
                {
                    cookie.Value = value;
                    HttpContext.Current.Request.Cookies.Set(cookie);
                }
                CookieHelper.SetCookie(CurrentCultureKey, value);
            }
        }

        public static string CurrentCultureUnderScore => CurrentCulture.Replace('-', '_');
    }
}
