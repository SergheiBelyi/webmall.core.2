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
    
    #line 1 "..\..\Views\CatalogService\Related.cshtml"
    using ViewRes;
    
    #line default
    #line hidden
    using Webmall.UI;
    using Webmall.UI.Core.Localization;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/CatalogService/Related.cshtml")]
    public partial class _Views_CatalogService_Related_cshtml : System.Web.Mvc.WebViewPage<List<Webmall.Model.Entities.Catalog.WareListItem>>
    {
        public _Views_CatalogService_Related_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 4 "..\..\Views\CatalogService\Related.cshtml"
  
    Layout = null;

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 8 "..\..\Views\CatalogService\Related.cshtml"
 if (Model.Any())
{

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"js-section-carousel swiper\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"swiper-wrapper\"");

WriteLiteral(">\r\n");

            
            #line 12 "..\..\Views\CatalogService\Related.cshtml"
            
            
            #line default
            #line hidden
            
            #line 12 "..\..\Views\CatalogService\Related.cshtml"
             foreach (var item in Model)
            {

            
            #line default
            #line hidden
WriteLiteral("                <div");

WriteLiteral(" class=\"swiper-slide\"");

WriteLiteral(">\r\n");

            
            #line 15 "..\..\Views\CatalogService\Related.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 15 "..\..\Views\CatalogService\Related.cshtml"
                       Html.RenderPartial("Components/Product", item); 
            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n");

            
            #line 17 "..\..\Views\CatalogService\Related.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"js-section-carousel-pagination\"");

WriteLiteral("></div>\r\n    </div>\r\n");

            
            #line 22 "..\..\Views\CatalogService\Related.cshtml"
}
else
{

            
            #line default
            #line hidden
WriteLiteral("    <div>");

            
            #line 25 "..\..\Views\CatalogService\Related.cshtml"
    Write(SharedResources.NoData);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");

            
            #line 26 "..\..\Views\CatalogService\Related.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

        }
    }
}
#pragma warning restore 1591
