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
    
    #line 1 "..\..\Views\CatalogService\Properties.cshtml"
    using ViewRes;
    
    #line default
    #line hidden
    using Webmall.UI;
    using Webmall.UI.Core.Localization;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/CatalogService/Properties.cshtml")]
    public partial class _Views_CatalogService_Properties_cshtml : System.Web.Mvc.WebViewPage<List<Webmall.Model.Entities.Catalog.WareProperty>>
    {
        public _Views_CatalogService_Properties_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\CatalogService\Properties.cshtml"
  
    Layout = null;

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 6 "..\..\Views\CatalogService\Properties.cshtml"
 if (Model.Any())
{
    foreach (var el in Model)
    {

            
            #line default
            #line hidden
WriteLiteral("        <dl");

WriteLiteral(" class=\"manual-params__param\"");

WriteLiteral(">\r\n            <dt");

WriteLiteral(" class=\"manual-params__value\"");

WriteLiteral(">");

            
            #line 11 "..\..\Views\CatalogService\Properties.cshtml"
                                        Write(el.Name);

            
            #line default
            #line hidden
WriteLiteral("</dt>\r\n            <dd");

WriteLiteral(" class=\"manual-params__property\"");

WriteLiteral(">");

            
            #line 12 "..\..\Views\CatalogService\Properties.cshtml"
                                           Write(el.Value);

            
            #line default
            #line hidden
WriteLiteral("</dd>\r\n        </dl>\r\n");

            
            #line 14 "..\..\Views\CatalogService\Properties.cshtml"
    }
}
else
{

            
            #line default
            #line hidden
WriteLiteral("    <div>");

            
            #line 18 "..\..\Views\CatalogService\Properties.cshtml"
    Write(SharedResources.NoData);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");

            
            #line 19 "..\..\Views\CatalogService\Properties.cshtml"
}

            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
