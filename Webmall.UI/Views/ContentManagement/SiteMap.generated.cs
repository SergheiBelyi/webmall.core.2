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
    using Webmall.UI;
    
    #line 1 "..\..\Views\ContentManagement\SiteMap.cshtml"
    using Webmall.UI.Core;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/ContentManagement/SiteMap.cshtml")]
    public partial class _Views_ContentManagement_SiteMap_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_ContentManagement_SiteMap_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\ContentManagement\SiteMap.cshtml"
  
    //ViewBag.Title = "Index";
    Layout = "~/Views/Shared/_PersonalLayout.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\n\n<aside");

WriteLiteral(" id=\"catalog-content\"");

WriteLiteral(">\n");

            
            #line 8 "..\..\Views\ContentManagement\SiteMap.cshtml"
    
            
            #line default
            #line hidden
            
            #line 8 "..\..\Views\ContentManagement\SiteMap.cshtml"
     using (Html.BeginForm("SiteMapGenerate", "ContentManagement", FormMethod.Post))
    {
        
            
            #line default
            #line hidden
            
            #line 10 "..\..\Views\ContentManagement\SiteMap.cshtml"
   Write(Html.SubmitButton("OK"));

            
            #line default
            #line hidden
            
            #line 10 "..\..\Views\ContentManagement\SiteMap.cshtml"
                                
    }

            
            #line default
            #line hidden
WriteLiteral("</aside>");

        }
    }
}
#pragma warning restore 1591
