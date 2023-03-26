using System;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using StackExchange.Profiling;

namespace Webmall.UI.Core.RouteHandlers
{
    public class CatalogHttpRootHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            using (StackExchange.Profiling.MiniProfiler.Current.Step("CatalogHttpRootHandler_GetHttpHandler"))
            {
                RouteData routeData = requestContext.RouteData;

                //var culture = CmsData.GetLanguages().First(i => i.Display.ToLower() == ((string) routeData.Values["lang"]).ToLower());
                //UserPreferences.CurrentCulture = culture.Culture;
                //CultureInfo.CurrentCulture = new CultureInfo(culture.Culture, false);
                //CultureInfo.CurrentUICulture = new CultureInfo(culture.Culture, false);

                //var path = (string)routeData.Values["path"];
                //if (!string.IsNullOrEmpty(path))
                //{
                    routeData.Values["controller"] = "Catalog";
                    routeData.Values["action"] = "ShowCatalog";
                //}
                //if (string.IsNullOrEmpty(group))
                //{
                //    if (string.Compare((string) routeData.Values["trend"], "Auto", StringComparison.OrdinalIgnoreCase) == 0)
                //    {
                //        routeData.Values["controller"] = "Catalog";
                //        routeData.Values["action"] = "AllCategories";
                //    }
                //    else
                //    {
                //        routeData.Values["controller"] = "Home";
                //        routeData.Values["action"] = "Index";
                //    }
                //}
                //else // Есть группа
                //{
                //    var brand = (string) routeData.Values["brand"];
                //    var number = (string) routeData.Values["number"];

                //    if (string.IsNullOrEmpty(brand) || string.IsNullOrEmpty(number))
                //    {
                //        // Только группа
                //        routeData.Values["controller"] = "Catalog";
                //        routeData.Values["action"] = "ShowCatalog";
                //    }
                //    else
                //    {
                //        // Карточка товара
                //        routeData.Values["controller"] = "Ware";
                //        routeData.Values["action"] = "Index2";
                //        routeData.Values["brand"] = brand;
                //        routeData.Values["number"] = number;
                //    }
                //}
                return new MvcHandler(requestContext);
            }
        }
    }

    public class CheckCatalogHttpRoute : IRouteConstraint
    {
        static readonly Regex LangRegex = new Regex("^[a-zA-Z][a-zA-Z]-[a-zA-Z][a-zA-Z]$", RegexOptions.IgnoreCase);

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values,
            RouteDirection routeDirection)
        {

            try
            {
                using (StackExchange.Profiling.MiniProfiler.Current.Step("CheckCatalogHttpRoute_Match"))
                {
                    bool result = false;
                    var l = ((values[parameterName] ?? "").ToString()).ToLower();
                    switch (parameterName)
                    {
                        case "lang":
                            result = l.Length == 2 || LangRegex.IsMatch(l);
                            //result = true;
                            break;
                        case "catalog":
                            result = l == "catalog" || l == "";
                            break;
                    }

                    return result;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}