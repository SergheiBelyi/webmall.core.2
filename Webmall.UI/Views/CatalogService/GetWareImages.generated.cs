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
    
    #line 1 "..\..\Views\CatalogService\GetWareImages.cshtml"
    using Webmall.UI.Core.HtmlHelpers;
    
    #line default
    #line hidden
    using Webmall.UI.Core.Localization;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/CatalogService/GetWareImages.cshtml")]
    public partial class _Views_CatalogService_GetWareImages_cshtml : System.Web.Mvc.WebViewPage<System.Collections.Generic.List<string>>
    {
        public _Views_CatalogService_GetWareImages_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 4 "..\..\Views\CatalogService\GetWareImages.cshtml"
  
    Layout = null;

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 8 "..\..\Views\CatalogService\GetWareImages.cshtml"
 foreach (var item in Model)
{
    var imgUrl = Url.WareImage(item); //Url.Action("GetImage", "Images", new {imageId = item});

            
            #line default
            #line hidden
WriteLiteral("    <a");

WriteLiteral(" class=\"stock-table__product-img-wrap\"");

WriteAttribute("href", Tuple.Create(" href=\"", 289), Tuple.Create("\"", 303)
            
            #line 11 "..\..\Views\CatalogService\GetWareImages.cshtml"
, Tuple.Create(Tuple.Create("", 296), Tuple.Create<System.Object, System.Int32>(imgUrl
            
            #line default
            #line hidden
, 296), false)
);

WriteLiteral(">\r\n        <img");

WriteLiteral(" class=\"stock-table__product-img\"");

WriteLiteral(" data-imageId=\"");

            
            #line 12 "..\..\Views\CatalogService\GetWareImages.cshtml"
                                                       Write(item);

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteAttribute("src", Tuple.Create(" src=\"", 373), Tuple.Create("\"", 386)
            
            #line 12 "..\..\Views\CatalogService\GetWareImages.cshtml"
, Tuple.Create(Tuple.Create("", 379), Tuple.Create<System.Object, System.Int32>(imgUrl
            
            #line default
            #line hidden
, 379), false)
);

WriteLiteral(" alt=\"Image\"");

WriteLiteral(">\r\n    </a>\r\n");

            
            #line 14 "..\..\Views\CatalogService\GetWareImages.cshtml"
}
            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
