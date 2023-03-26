using System.Web.Mvc;
using System.Web.Routing;
using Webmall.UI.Core.RouteHandlers;

namespace Webmall.UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.MapRoute(
            //    null, "ShowImage.ashx/{*pathInfo}",
            //    new {controller = "Images", action = "CmsImage"}
            //    );

            routes.IgnoreRoute("{handler}.ashx");
            routes.IgnoreRoute("{resource}.css/{*pathInfo}");
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{resource}.ico/{*pathInfo}");
            routes.IgnoreRoute("{resource}.ttf/{*pathInfo}");
            routes.IgnoreRoute("{resource}.woff/{*pathInfo}");
            routes.IgnoreRoute("{resource}.eot/{*pathInfo}");
            routes.IgnoreRoute("Video/{*pathInfo}");
            //routes.IgnoreRoute("Umbraco/{*pathInfo}");
            routes.IgnoreRoute(".well-known/acme-challenge/{*pathInfo}");
            //routes.IgnoreRoute("UserFiles/{*pathInfo}");
            routes.IgnoreRoute("ExtContent/{*pathInfo}");
            //routes.IgnoreRoute("Views/SandBox/Content/{*pathInfo}");

            routes.MapRoute(null, "Error404/{*pathInfo}", new { controller = "Error", action = "Error404" });

            routes.MapRoute("IsBlocked", "Message/BotDetected", new { controller = "Message", action = "BotDetected" });

            #region Search

            routes.MapRoute(
                name: "SearchLocalized",
                url: "{lang}/Search",
                constraints: new { lang = @"(\w{2})|(\w{2}-\w{2})" },   // en or en-US
                defaults: new { controller = "Catalog", action = "Search" }
            );

            routes.MapRoute(
                name: "Search",
                url: "Search",
                defaults: new { controller = "Catalog", action = "Search" }
            );

            routes.MapRoute(
                name: "SearchOemLocalized",
                url: "{lang}/SearchOem",
                constraints: new { lang = @"(\w{2})|(\w{2}-\w{2})" },   // en or en-US
                defaults: new { controller = "Catalog", action = "SearchOem" }
            );

            routes.MapRoute(
                name: "SearchOem",
                url: "SearchOem",
                defaults: new { controller = "Catalog", action = "SearchOem" }
            );

            #endregion

            #region Catalog

            routes.Add("CatalogLanguage", new Route(
                url: "{lang}/catalog/{*path}",
                defaults: new RouteValueDictionary(new { action = "Index", alias = "", controller = "RouteHandler", catalog = (string)null }),
                constraints: new RouteValueDictionary(new { lang = new CheckCatalogHttpRoute(), catalog = new CheckCatalogHttpRoute() }),
                routeHandler: new CatalogHttpRootHandler()
            ));

            routes.Add("Catalog", new Route(
                url: "catalog/{*path}",
                defaults: new RouteValueDictionary(new { action = "Index", alias = "", controller = "RouteHandler", catalog = (string)null }),
                constraints: new RouteValueDictionary(new { catalog = new CheckCatalogHttpRoute() }),
                routeHandler: new CatalogHttpRootHandler()
            ));

            #endregion

            routes.MapRoute("SelectionByAuto", "Auto",
                new {controller = "SelectionByAuto", action = "Selection"});

            routes.MapRoute("AutoMarksModels", "Auto/{markaName}/{modelName}/{modifName}",
                new { controller = "SelectionByAuto", action = "IndexByName", markaName = UrlParameter.Optional, modelName = UrlParameter.Optional, modifName = UrlParameter.Optional });

            #region Article routes

            routes.MapRoute(
                name: "ArticleLocalized",
                url: "{lang}/Article/{id}",
                constraints: new { lang = @"(\w{2})|(\w{2}-\w{2})" },   // en or en-US
                defaults: new { controller = "Article", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Article",
                url: "Article/{id}",
                defaults: new { controller = "Article", action = "Index", id = UrlParameter.Optional }
            );
            #endregion Article routes

            #region News routes

            routes.MapRoute(
                name: "NewsLocalized",
                url: "{lang}/news/{category}/{id}",
                constraints: new { lang = @"(\w{2})|(\w{2}-\w{2})" },   // en or en-US
                defaults: new { controller = "News", action = "Index", category = UrlParameter.Optional, id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "News",
                url: "news/{category}/{id}",
                defaults: new { controller = "News", action = "Index", category = UrlParameter.Optional, id = UrlParameter.Optional }
            );
            #endregion News routes

            #region Review routes

            routes.MapRoute(
                name: "ReviewLocalized",
                url: "{lang}/Review/{id}",
                constraints: new { lang = @"(\w{2})|(\w{2}-\w{2})" },   // en or en-US
                defaults: new { controller = "Review", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Review",
                url: "Review/{id}",
                defaults: new { controller = "Review", action = "Index", id = UrlParameter.Optional }
            );
            #endregion Review routes

            #region Brand routes

            routes.MapRoute(
                name: "BrandLocalized",
                url: "{lang}/Brand/{id}",
                constraints: new { lang = @"(\w{2})|(\w{2}-\w{2})" },   // en or en-US
                defaults: new { controller = "Brands", action = "Info", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Brand",
                url: "Brand/{id}",
                defaults: new { controller = "Brands", action = "Info", id = UrlParameter.Optional }
            );

            #endregion Article routes

            routes.MapRoute(
                name: "DefaultLocalized",
                url: "{lang}/{controller}/{action}/{id}",
                constraints: new { lang = @"(\w{2})|(\w{2}-\w{2})" },   // en or en-US
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Webmall.UI.Controllers" }
            );

            routes.MapRoute(
                name: "default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
               // namespaces: new[] { "Webmall.UI.Controllers" }
            );

        }
    }
}
