using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading;
using System.Web;
using Data.DataTier;

namespace Data.Config
{
    public class ApplicationSettings
    {
        private const string LangCookieName = "Automall_CurrentCulture";

        public static string SessionId
        {
            get
            {
                var httpCookie = HttpContext.Current.Request.Cookies["ASP.NET_SessionId"];
                if (httpCookie != null)
                    return httpCookie.Value;
                return null;
            }
        }
        public static string ServerName => ConfigurationManager.AppSettings["ServerName"];

        public static string SiteRoot => ConfigurationManager.AppSettings["SiteRoot"];

        public static int CacheTimeHours => Convert.ToInt32(ConfigurationManager.AppSettings["CacheTimeHours"], 10);

        //public static string EmailServerAddress => ConfigurationManager.AppSettings["EmailServerAddress"];
        //public static string EmailSMTPSPort => ConfigurationManager.AppSettings["EmailSMTPSPort"];
        //public static string EmailServerSSL => ConfigurationManager.AppSettings["EmailServerSSL"];
        //public static string EmailUserName => ConfigurationManager.AppSettings["EmailUserName"];
        //public static string EmailPassword => ConfigurationManager.AppSettings["EmailPassword"];

        public static string SiteName => ConfigurationManager.AppSettings["SiteName"];

        public static string SiteUrl => ConfigurationManager.AppSettings["SiteUrl"];

        public static string Email => ConfigurationManager.AppSettings["Email"];

        public static string SearchSite => ConfigurationManager.AppSettings["SearchSite"];

        /// <summary>
        /// Объект-соединение с базой
        /// </summary>
        public static SqlConnection _Connection
        {
            get
            {
                if (HttpContext.Current.Session["Connection"] is SqlConnection cn)
                {
                    return cn;
                }
                cn = new SqlConnection(ConnectionString);
                cn.Open();
                HttpContext.Current.Session["Connection"] = cn;
                return cn;
            }
        }

        private static Dictionary<string, int> langs;

        public static string ConnectionString => ConfigurationManager.ConnectionStrings["SqlLocalDB"].ConnectionString;
        public static int LanguagesCount => Languages.Count;
        public static Dictionary<string, int> Languages
        {
            get
            {
                if (langs == null)
                {
                    langs = new Dictionary<string, int>();
                    foreach (var lngNode in Node.GetFromDBbyClass("Language"))
                    {
                        var culture = Node.fnGetValueFromField0(lngNode, "CultureInfo");
                        if (int.TryParse(Node.fnGetValueFromField0(lngNode, "LanguageId"), out var languageId))
                        {
                            langs.Add(culture, languageId);
                        }

                    }
                }
                return langs;
            }
        }

        public static void SetCultureRu()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("ru-RU");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-RU");
        }
        public static int Language
        {
            get
            {
                string culture = HttpContext.Current?.Request.Cookies[LangCookieName]?.Value ?? "ru-RU";
                if (Languages.ContainsKey(culture))
                    return Languages[culture];
                //foreach (Node lngNode in Languages)
                //{
                //    if (string.Compare(Node.fnGetValueFromField0(lngNode, "CultureInfo"), culture, StringComparison.OrdinalIgnoreCase) == 0)
                //    {
                //        if (int.TryParse(Node.fnGetValueFromField0(lngNode, "LanguageId"), out var languageId))
                //        {
                //            return languageId;
                //        }
                //    }
                //}
                return 0;
                ////if (HttpContext.Current == null) return 0;
                ////if ((HttpContext.Current.Session != null) && (HttpContext.Current.Session["CurrentLanguage"] != null))
                ////{
                ////    try
                ////    {

                ////        return Convert.ToInt32(HttpContext.Current.Session["CurrentLanguage"]);
                ////    }
                ////    catch { return 0; }
                ////}
                //var cookLang = HttpContext.Current.Request.Cookies[LangCookieName];
                //if (cookLang == null)
                //{
                //    HttpContext.Current.Response.Cookies.Add(new HttpCookie(LangCookieName, "0") { Path = "/", Expires = DateTime.MaxValue });
                //    return 0;
                //}
                //return int.TryParse(cookLang.Value, out var result) ? result : 0;
            }
            set
            {
                //var cookLang = HttpContext.Current.Request.Cookies[LangCookieName];
                //if (cookLang == null)
                //{
                //    cookLang = new HttpCookie(LangCookieName, "0") {Path = "/", Expires = DateTime.MaxValue};
                //    HttpContext.Current.Response.Cookies.Add(cookLang);
                //  //  return 0;
                //}
                ////HttpCookie cookLang = cookies[LangCookieName] ?? new HttpCookie(LangCookieName);
                //cookLang.Value = value.ToString();
                //var cookies = HttpContext.Current.Request.Cookies;
                //if (cookies[LangCookieName] != null)
                //{
                //    cookies.Set(cookLang);
                //}
                //else
                //    cookies.Add(cookLang);
                //if (HttpContext.Current.Session != null)
                //    HttpContext.Current.Session["CurrentLanguage"] = value;
            }
        }
    }
}
