using System;
using System.Web;

namespace Webmall.UI.Core.Helpers
{
    public static class CookieHelper
    {
        public static string GetCookieValue(string key)
        {
            try
            {
                var cookie = HttpContext.Current?.Request?.Cookies[key];
                return cookie?.Value;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static void SetCookie(string key, string value)
        {
            var hc = new HttpCookie(key, value) { Path = "/", Expires = DateTime.MaxValue };
            HttpContext.Current.Response.Cookies.Add(hc);
        }
    }
}