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
    
    #line 1 "..\..\Views\CatalogService\ShortPropertiesForTile.cshtml"
    using ViewRes;
    
    #line default
    #line hidden
    using Webmall.UI;
    using Webmall.UI.Core.Localization;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/CatalogService/ShortPropertiesForTile.cshtml")]
    public partial class _Views_CatalogService_ShortPropertiesForTile_cshtml : System.Web.Mvc.WebViewPage<List<Webmall.Model.Entities.Catalog.WareProperty>>
    {
        public _Views_CatalogService_ShortPropertiesForTile_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\CatalogService\ShortPropertiesForTile.cshtml"
  
    Layout = null;

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<dl");

WriteLiteral(" class=\"product-card__params\"");

WriteLiteral(">\r\n");

            
            #line 8 "..\..\Views\CatalogService\ShortPropertiesForTile.cshtml"
    
            
            #line default
            #line hidden
            
            #line 8 "..\..\Views\CatalogService\ShortPropertiesForTile.cshtml"
     if (Model.Any())
    {
        foreach (var el in Model)
        {

            
            #line default
            #line hidden
WriteLiteral("            <div");

WriteLiteral(" class=\"product-card__param\"");

WriteLiteral(">\r\n                <dt");

WriteLiteral(" class=\"product-card__property\"");

WriteLiteral(">");

            
            #line 13 "..\..\Views\CatalogService\ShortPropertiesForTile.cshtml"
                                              Write(el.Name);

            
            #line default
            #line hidden
WriteLiteral("</dt>\r\n                <dd");

WriteLiteral(" class=\"product-card__value\"");

WriteLiteral(">");

            
            #line 14 "..\..\Views\CatalogService\ShortPropertiesForTile.cshtml"
                                           Write(el.Value);

            
            #line default
            #line hidden
WriteLiteral("</dd>\r\n            </div>\r\n");

            
            #line 16 "..\..\Views\CatalogService\ShortPropertiesForTile.cshtml"
        }
    }
    else
    {

            
            #line default
            #line hidden
WriteLiteral("        <div>");

            
            #line 20 "..\..\Views\CatalogService\ShortPropertiesForTile.cshtml"
        Write(SharedResources.NoData);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");

            
            #line 21 "..\..\Views\CatalogService\ShortPropertiesForTile.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("</dl>\r\n");

        }
    }
}
#pragma warning restore 1591