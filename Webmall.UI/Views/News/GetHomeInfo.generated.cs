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
    
    #line 1 "..\..\Views\News\GetHomeInfo.cshtml"
    using ViewRes;
    
    #line default
    #line hidden
    using Webmall.UI;
    using Webmall.UI.Core.Localization;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/News/GetHomeInfo.cshtml")]
    public partial class _Views_News_GetHomeInfo_cshtml : System.Web.Mvc.WebViewPage<Webmall.Model.Entities.Cms.NewsData.NewsCategory>
    {
        public _Views_News_GetHomeInfo_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 5 "..\..\Views\News\GetHomeInfo.cshtml"
  
    Layout = null;
    var i = 0;

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 9 "..\..\Views\News\GetHomeInfo.cshtml"
 if (Model != null)
{

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"section__body news-section__main\"");

WriteLiteral(" data-news-id=\"");

            
            #line 11 "..\..\Views\News\GetHomeInfo.cshtml"
                                                           Write(Model.Id);

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(">\r\n");

            
            #line 12 "..\..\Views\News\GetHomeInfo.cshtml"
        
            
            #line default
            #line hidden
            
            #line 12 "..\..\Views\News\GetHomeInfo.cshtml"
         foreach (var article in Model.Items)
        {
            { i++; }
            if (i > 3) { break; }
            Html.RenderPartial("Components/NewsArticle", article);
        }

            
            #line default
            #line hidden
WriteLiteral("    </div>\r\n");

            
            #line 19 "..\..\Views\News\GetHomeInfo.cshtml"
}
            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591