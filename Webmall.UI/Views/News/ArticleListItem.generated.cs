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
    using System.Globalization;
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
    using Webmall.UI;
    using Webmall.UI.Core.Localization;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/News/ArticleListItem.cshtml")]
    public partial class _Views_News_ArticleListItem_cshtml : System.Web.Mvc.WebViewPage<Webmall.UI.ViewModel.News.NewsArticleViewModel>
    {
        public _Views_News_ArticleListItem_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\News\ArticleListItem.cshtml"
  
    var article = Model.Article;
    var newsUrl = Url.Action("Index", "News", new {category = Model.Category?.Slug, id=article.Url});

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<article");

WriteLiteral(" class=\"blog__news news\"");

WriteLiteral(">\r\n    <a");

WriteLiteral(" class=\"news__img-wrap\"");

WriteAttribute("href", Tuple.Create(" href=\"", 265), Tuple.Create("\"", 280)
            
            #line 8 "..\..\Views\News\ArticleListItem.cshtml"
, Tuple.Create(Tuple.Create("", 272), Tuple.Create<System.Object, System.Int32>(newsUrl
            
            #line default
            #line hidden
, 272), false)
);

WriteLiteral(">\r\n        <img");

WriteLiteral(" class=\"news__img\"");

WriteAttribute("src", Tuple.Create(" src=\"", 314), Tuple.Create("\"", 337)
            
            #line 9 "..\..\Views\News\ArticleListItem.cshtml"
, Tuple.Create(Tuple.Create("", 320), Tuple.Create<System.Object, System.Int32>(article.ImageUrl
            
            #line default
            #line hidden
, 320), false)
);

WriteAttribute("srcset", Tuple.Create(" srcset=\"", 338), Tuple.Create("\"", 367)
            
            #line 9 "..\..\Views\News\ArticleListItem.cshtml"
, Tuple.Create(Tuple.Create("", 347), Tuple.Create<System.Object, System.Int32>(article.ImageUrl
            
            #line default
            #line hidden
, 347), false)
, Tuple.Create(Tuple.Create(" ", 364), Tuple.Create("2x", 365), true)
);

WriteLiteral(" alt=\"\"");

WriteLiteral(" width=\"410\"");

WriteLiteral(" height=\"190\"");

WriteLiteral(">\r\n    </a>\r\n    <div");

WriteLiteral(" class=\"news__main\"");

WriteLiteral(">\r\n        <time");

WriteLiteral(" class=\"news__date\"");

WriteAttribute("datetime", Tuple.Create(" datetime=\"", 475), Tuple.Create("\"", 519)
            
            #line 12 "..\..\Views\News\ArticleListItem.cshtml"
, Tuple.Create(Tuple.Create("", 486), Tuple.Create<System.Object, System.Int32>(article.Date.ToShortDateString()
            
            #line default
            #line hidden
, 486), false)
);

WriteLiteral(">");

            
            #line 12 "..\..\Views\News\ArticleListItem.cshtml"
                                                                         Write(article.Date.ToShortDateString());

            
            #line default
            #line hidden
WriteLiteral("</time>\r\n        <h3");

WriteLiteral(" class=\"news__heading\"");

WriteLiteral(">\r\n            <a");

WriteLiteral(" class=\"news__heading-link\"");

WriteAttribute("href", Tuple.Create(" href=\"", 640), Tuple.Create("\"", 655)
            
            #line 14 "..\..\Views\News\ArticleListItem.cshtml"
, Tuple.Create(Tuple.Create("", 647), Tuple.Create<System.Object, System.Int32>(newsUrl
            
            #line default
            #line hidden
, 647), false)
);

WriteLiteral(">");

            
            #line 14 "..\..\Views\News\ArticleListItem.cshtml"
                                                     Write(article.Header);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n        </h3>\r\n        <p");

WriteLiteral(" class=\"news__excerpt\"");

WriteLiteral(">");

            
            #line 16 "..\..\Views\News\ArticleListItem.cshtml"
                            Write(article.ShortText);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n    </div>\r\n</article>");

        }
    }
}
#pragma warning restore 1591
