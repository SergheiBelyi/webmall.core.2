﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using HtmlHelpers.BeginCollectionItem;
    
    #line 2 "..\..\Views\News\Show.cshtml"
    using ViewRes;
    
    #line default
    #line hidden
    
    #line 1 "..\..\Views\News\Show.cshtml"
    using Webmall.Model;
    
    #line default
    #line hidden
    using Webmall.UI;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/News/Show.cshtml")]
    public partial class _Views_News_Show_cshtml : System.Web.Mvc.WebViewPage<Webmall.UI.ViewModel.News.NewsArticleViewModel>
    {
        public _Views_News_Show_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 5 "..\..\Views\News\Show.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";
    ViewBag.Title = Model.Article.Header;
    var article = Model.Article;

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteLiteral(" class=\"container-fluid\"");

WriteLiteral(">\r\n");

            
            #line 12 "..\..\Views\News\Show.cshtml"
    
            
            #line default
            #line hidden
            
            #line 12 "..\..\Views\News\Show.cshtml"
      Html.RenderPartial("Components/BreadCrumbsRender", Model.BreadCrumbs);
            
            #line default
            #line hidden
WriteLiteral("\r\n    <main");

WriteLiteral(" class=\"content\"");

WriteLiteral(">\r\n        <!-- page-intro-->\r\n        <div");

WriteLiteral(" class=\"page-intro is-blog\"");

WriteLiteral(">\r\n            <h1");

WriteLiteral(" class=\"page-intro__heading main-heading\"");

WriteLiteral(">");

            
            #line 16 "..\..\Views\News\Show.cshtml"
                                                    Write(SharedResources.News);

            
            #line default
            #line hidden
WriteLiteral("</h1>\r\n            <div");

WriteLiteral(" class=\"page-intro__categories categories-dropdown js-dropdown has-overlay is-des" +
"ktop-hidden\"");

WriteLiteral(">\r\n                <button");

WriteLiteral(" class=\"categories-dropdown__btn js-dropdown-toggle btn btn--primary\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(">\r\n                    <span");

WriteLiteral(" class=\"btn__text\"");

WriteLiteral(">");

            
            #line 19 "..\..\Views\News\Show.cshtml"
                                       Write(SharedResources.Categories);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                    <svg");

WriteLiteral(" class=\"icon icon-chevron-down btn__icon\"");

WriteLiteral(" width=\"25\"");

WriteLiteral(" height=\"25\"");

WriteLiteral(">\r\n                        <use");

WriteLiteral(" href=\"assets/images/svg/symbol/sprite.svg#chevron-down\"");

WriteLiteral("></use>\r\n                    </svg>\r\n                </button>\r\n                <" +
"div");

WriteLiteral(" class=\"categories-dropdown__body\"");

WriteLiteral(">\r\n                    <ul");

WriteLiteral(" class=\"categories-dropdown__list\"");

WriteLiteral(">\r\n");

            
            #line 26 "..\..\Views\News\Show.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 26 "..\..\Views\News\Show.cshtml"
                         foreach (var item in Model.Categories)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <li");

WriteAttribute("class", Tuple.Create(" class=\"", 1301), Tuple.Create("\"", 1379)
, Tuple.Create(Tuple.Create("", 1309), Tuple.Create("categories-dropdown__item", 1309), true)
            
            #line 28 "..\..\Views\News\Show.cshtml"
, Tuple.Create(Tuple.Create(" ", 1334), Tuple.Create<System.Object, System.Int32>(Model.Category == item ? "is-active" : ""
            
            #line default
            #line hidden
, 1335), false)
);

WriteLiteral(">\r\n                                <a");

WriteLiteral(" class=\"categories-dropdown__link\"");

WriteAttribute("href", Tuple.Create(" href=\"", 1451), Tuple.Create("\"", 1513)
            
            #line 29 "..\..\Views\News\Show.cshtml"
, Tuple.Create(Tuple.Create("", 1458), Tuple.Create<System.Object, System.Int32>(Url.Action("Index", "News", new { category=item.Slug})
            
            #line default
            #line hidden
, 1458), false)
);

WriteLiteral(">");

            
            #line 29 "..\..\Views\News\Show.cshtml"
                                                                                                                               Write(item.Name);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                            </li>\r\n");

            
            #line 31 "..\..\Views\News\Show.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </ul>\r\n                </div>\r\n            </div>\r\n        </" +
"div><!-- /page-intro-->\r\n        <div");

WriteLiteral(" class=\"primary\"");

WriteLiteral(">\r\n            <aside");

WriteLiteral(" class=\"primary__sidebar is-mob-hidden\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"primary__sidebar-main\"");

WriteLiteral(">\r\n                    <!-- category-nav-->\r\n                    <nav");

WriteLiteral(" class=\"category-nav is-gray\"");

WriteLiteral(">\r\n                        <ul");

WriteLiteral(" class=\"category-nav__list\"");

WriteLiteral(">\r\n");

            
            #line 42 "..\..\Views\News\Show.cshtml"
                            
            
            #line default
            #line hidden
            
            #line 42 "..\..\Views\News\Show.cshtml"
                             foreach (var item in Model.Categories)
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <li");

WriteAttribute("class", Tuple.Create(" class=\"", 2133), Tuple.Create("\"", 2204)
, Tuple.Create(Tuple.Create("", 2141), Tuple.Create("category-nav__item", 2141), true)
            
            #line 44 "..\..\Views\News\Show.cshtml"
, Tuple.Create(Tuple.Create(" ", 2159), Tuple.Create<System.Object, System.Int32>(Model.Category == item ? "is-active" : ""
            
            #line default
            #line hidden
, 2160), false)
);

WriteLiteral(">\r\n                                    <a");

WriteLiteral(" class=\"category-nav__link\"");

WriteAttribute("href", Tuple.Create(" href=\"", 2273), Tuple.Create("\"", 2335)
            
            #line 45 "..\..\Views\News\Show.cshtml"
, Tuple.Create(Tuple.Create("", 2280), Tuple.Create<System.Object, System.Int32>(Url.Action("Index", "News", new { category=item.Slug})
            
            #line default
            #line hidden
, 2280), false)
);

WriteLiteral("><span");

WriteLiteral(" class=\"category-nav__link-text\"");

WriteLiteral(">");

            
            #line 45 "..\..\Views\News\Show.cshtml"
                                                                                                                                                                  Write(item.Name);

            
            #line default
            #line hidden
WriteLiteral("</span></a>\r\n                                </li>\r\n");

            
            #line 47 "..\..\Views\News\Show.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("                        </ul>\r\n                    </nav><!-- /category-nav-->\r\n " +
"               </div>\r\n            </aside>\r\n            <main");

WriteLiteral(" class=\"primary__main\"");

WriteLiteral(">\r\n                <!-- article-->\r\n                <article");

WriteLiteral(" class=\"article\"");

WriteLiteral(">\r\n                    <header");

WriteLiteral(" class=\"article__header\"");

WriteLiteral(">\r\n                        <time");

WriteLiteral(" class=\"article__date\"");

WriteAttribute("datetime", Tuple.Create(" datetime=\"", 2817), Tuple.Create("\"", 2861)
            
            #line 56 "..\..\Views\News\Show.cshtml"
, Tuple.Create(Tuple.Create("", 2828), Tuple.Create<System.Object, System.Int32>(article.Date.ToShortDateString()
            
            #line default
            #line hidden
, 2828), false)
);

WriteLiteral(">");

            
            #line 56 "..\..\Views\News\Show.cshtml"
                                                                                            Write(article.Date.ToShortDateString());

            
            #line default
            #line hidden
WriteLiteral("</time>\r\n                        <div");

WriteLiteral(" class=\"article__cover-wrap\"");

WriteLiteral(">\r\n                            <img");

WriteLiteral(" class=\"article__cover\"");

WriteAttribute("src", Tuple.Create(" src=\"", 3019), Tuple.Create("\"", 3042)
            
            #line 58 "..\..\Views\News\Show.cshtml"
, Tuple.Create(Tuple.Create("", 3025), Tuple.Create<System.Object, System.Int32>(article.ImageUrl
            
            #line default
            #line hidden
, 3025), false)
);

WriteAttribute("srcset", Tuple.Create(" srcset=\"", 3043), Tuple.Create("\"", 3072)
            
            #line 58 "..\..\Views\News\Show.cshtml"
        , Tuple.Create(Tuple.Create("", 3052), Tuple.Create<System.Object, System.Int32>(article.ImageUrl
            
            #line default
            #line hidden
, 3052), false)
, Tuple.Create(Tuple.Create(" ", 3069), Tuple.Create("2x", 3070), true)
);

WriteLiteral(" alt=\"\"");

WriteLiteral(" width=\"800\"");

WriteLiteral(" height=\"300\"");

WriteLiteral(">\r\n                        </div>\r\n                        <h1");

WriteLiteral(" class=\"article__heading\"");

WriteLiteral(">");

            
            #line 60 "..\..\Views\News\Show.cshtml"
                                                Write(article.Header);

            
            #line default
            #line hidden
WriteLiteral("</h1>\r\n                    </header>\r\n                    <div");

WriteLiteral(" class=\"article__main\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"article__content post-entry\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 64 "..\..\Views\News\Show.cshtml"
                       Write(Html.Raw(article.FullText));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </div>\r\n");

            
            #line 66 "..\..\Views\News\Show.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 66 "..\..\Views\News\Show.cshtml"
                         if (ConfigHelper.AllowSocialShare)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <div");

WriteLiteral(" class=\"article__share\"");

WriteLiteral(">\r\n                                <a");

WriteLiteral(" class=\"article__share-link share-link\"");

WriteLiteral(" href=\"\"");

WriteLiteral(">\r\n                                    <script");

WriteLiteral(" src=\"https://yastatic.net/share2/share.js\"");

WriteLiteral("></script>\r\n                                    <div");

WriteLiteral(" class=\"ya-share2\"");

WriteLiteral(" data-curtain");

WriteLiteral(" data-size=\"m\"");

WriteLiteral(" data-shape=\"round\"");

WriteLiteral(" data-services=\"facebook,telegram,twitter\"");

WriteLiteral("></div>\r\n                                    ");

WriteLiteral("\r\n                                    ");

WriteLiteral("\r\n                                    <span");

WriteLiteral(" class=\"share-link__text\"");

WriteLiteral(">&nbsp; ");

            
            #line 77 "..\..\Views\News\Show.cshtml"
                                                                     Write(SharedResources.DoYouLikeShare);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                                </a>\r\n                            </div>" +
"\r\n");

            
            #line 80 "..\..\Views\News\Show.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n                    <footer");

WriteLiteral(" class=\"article__bottom\"");

WriteLiteral(">\r\n");

            
            #line 84 "..\..\Views\News\Show.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 84 "..\..\Views\News\Show.cshtml"
                         if (article.PrevId != null)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <a");

WriteLiteral(" class=\"article__btn btn btn--white\"");

WriteAttribute("href", Tuple.Create(" href=\"", 4979), Tuple.Create("\"", 5076)
            
            #line 86 "..\..\Views\News\Show.cshtml"
, Tuple.Create(Tuple.Create("", 4986), Tuple.Create<System.Object, System.Int32>(Url.Action("Index", "News", new { category = Model.Category?.Slug, id = article.PrevId })
            
            #line default
            #line hidden
, 4986), false)
);

WriteLiteral(">\r\n                                <svg");

WriteLiteral(" class=\"icon icon-prev btn__icon\"");

WriteLiteral(" width=\"25\"");

WriteLiteral(" height=\"25\"");

WriteLiteral(">\r\n                                    <use");

WriteLiteral(" href=\"assets/images/svg/symbol/sprite.svg#prev\"");

WriteLiteral("></use>\r\n                                </svg>\r\n                                " +
"<span");

WriteLiteral(" class=\"btn__text\"");

WriteLiteral(">");

            
            #line 90 "..\..\Views\News\Show.cshtml"
                                                   Write(SharedResources.PrevNews);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                            </a>\r\n");

            
            #line 92 "..\..\Views\News\Show.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                        ");

            
            #line 93 "..\..\Views\News\Show.cshtml"
                         if (article.NextId != null)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <a");

WriteLiteral(" class=\"article__btn btn btn--white\"");

WriteAttribute("href", Tuple.Create(" href=\"", 5610), Tuple.Create("\"", 5707)
            
            #line 95 "..\..\Views\News\Show.cshtml"
, Tuple.Create(Tuple.Create("", 5617), Tuple.Create<System.Object, System.Int32>(Url.Action("Index", "News", new { category = Model.Category?.Slug, id = article.NextId })
            
            #line default
            #line hidden
, 5617), false)
);

WriteLiteral(">\r\n                                <span");

WriteLiteral(" class=\"btn__text\"");

WriteLiteral(">");

            
            #line 96 "..\..\Views\News\Show.cshtml"
                                                   Write(SharedResources.NextNews);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                                <svg");

WriteLiteral(" class=\"icon icon-next btn__icon\"");

WriteLiteral(" width=\"25\"");

WriteLiteral(" height=\"25\"");

WriteLiteral(">\r\n                                    <use");

WriteLiteral(" href=\"assets/images/svg/symbol/sprite.svg#next\"");

WriteLiteral("></use>\r\n                                </svg>\r\n                            </a>" +
"\r\n");

            
            #line 101 "..\..\Views\News\Show.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </footer>\r\n                </article><!-- /article-->\r\n      " +
"      </main>\r\n        </div>\r\n    </main>\r\n</div>\r\n");

DefineSection("styles", () => {

WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 109 "..\..\Views\News\Show.cshtml"
Write(Styles.Render("~/Content/fancybox/fancy"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

});

WriteLiteral("\r\n");

DefineSection("scripts", () => {

WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 114 "..\..\Views\News\Show.cshtml"
Write(Scripts.Render("~/bundles/fancy"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

});

        }
    }
}
#pragma warning restore 1591
