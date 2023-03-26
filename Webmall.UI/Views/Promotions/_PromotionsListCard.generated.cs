﻿using Webmall.Model.Entities.Cms.NewsData;

#pragma warning disable 1591
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
    
    #line 1 "..\..\Views\Promotions\_PromotionsListCard.cshtml"
    using System.Globalization;
    
    #line default
    #line hidden
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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Promotions/_PromotionsListCard.cshtml")]
    public partial class _Views_Promotions__PromotionsListCard_cshtml : System.Web.Mvc.WebViewPage<NewsArticle>
    {
        public _Views_Promotions__PromotionsListCard_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 4 "..\..\Views\Promotions\_PromotionsListCard.cshtml"
  
    var newsId = string.IsNullOrEmpty(Model.Url) ? Model.Id.ToString(CultureInfo.InvariantCulture) : Model.Url;

            
            #line default
            #line hidden
WriteLiteral("\n<article");

WriteLiteral(" class=\"news\"");

WriteLiteral(">\n    <a");

WriteAttribute("href", Tuple.Create(" href=\"", 233), Tuple.Create("\"", 294)
            
            #line 8 "..\..\Views\Promotions\_PromotionsListCard.cshtml"
, Tuple.Create(Tuple.Create("", 240), Tuple.Create<System.Object, System.Int32>(Url.Action("Show", "Promotions", new { id = newsId })
            
            #line default
            #line hidden
, 240), false)
);

WriteLiteral("><img");

WriteAttribute("src", Tuple.Create(" src=\"", 300), Tuple.Create("\"", 341)
            
            #line 8 "..\..\Views\Promotions\_PromotionsListCard.cshtml"
, Tuple.Create(Tuple.Create("", 306), Tuple.Create<System.Object, System.Int32>(Url.Content("~/" + Model.ImageUrl)
            
            #line default
            #line hidden
, 306), false)
);

WriteLiteral(" alt=\"Img-News\"");

WriteLiteral(" /></a>\n    <div");

WriteLiteral(" class=\"news-description\"");

WriteLiteral(">\n        <h3>");

            
            #line 10 "..\..\Views\Promotions\_PromotionsListCard.cshtml"
       Write(Html.ActionLink(Model.Header, "Show", "Promotions", new { id = newsId }, null));

            
            #line default
            #line hidden
WriteLiteral("</h3>\n        <p>");

            
            #line 11 "..\..\Views\Promotions\_PromotionsListCard.cshtml"
       Write(new HtmlString(Model.ShortText));

            
            #line default
            #line hidden
WriteLiteral("</p>\n        <time");

WriteAttribute("datetime", Tuple.Create(" datetime=\"", 560), Tuple.Create("\"", 605)
            
            #line 12 "..\..\Views\Promotions\_PromotionsListCard.cshtml"
, Tuple.Create(Tuple.Create("", 571), Tuple.Create<System.Object, System.Int32>(Model.Date.ToString("yyyy-MM-dd")
            
            #line default
            #line hidden
, 571), false)
);

WriteLiteral(">");

            
            #line 12 "..\..\Views\Promotions\_PromotionsListCard.cshtml"
                                                        Write(Model.Date.ToShortDateString());

            
            #line default
            #line hidden
WriteLiteral("</time>\n    </div>\n</article>\n\n");

        }
    }
}
#pragma warning restore 1591