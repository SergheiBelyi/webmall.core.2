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
    
    #line 1 "..\..\Views\CatalogService\GetWarePropsListTable.cshtml"
    using ViewRes;
    
    #line default
    #line hidden
    using Webmall.UI;
    using Webmall.UI.Core.Localization;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/CatalogService/GetWarePropsListTable.cshtml")]
    public partial class _Views_CatalogService_GetWarePropsListTable_cshtml : System.Web.Mvc.WebViewPage<List<Webmall.Model.Entities.Catalog.WareProperty>>
    {
        public _Views_CatalogService_GetWarePropsListTable_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\CatalogService\GetWarePropsListTable.cshtml"
  
    Layout = null;

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 6 "..\..\Views\CatalogService\GetWarePropsListTable.cshtml"
 if (Model.Any())
{

    foreach (var el in Model)
    {

            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\"spec-table__specifications-item\"");

WriteLiteral(">\r\n        <dt");

WriteLiteral(" class=\"spec-table__specifications-property\"");

WriteLiteral(">");

            
            #line 12 "..\..\Views\CatalogService\GetWarePropsListTable.cshtml"
                                                   Write(el.Name);

            
            #line default
            #line hidden
WriteLiteral("</dt>\r\n        <dd");

WriteLiteral(" class=\"spec-table__specifications-value\"");

WriteLiteral(">");

            
            #line 13 "..\..\Views\CatalogService\GetWarePropsListTable.cshtml"
                                                Write(el.Value);

            
            #line default
            #line hidden
WriteLiteral("</dd>\r\n        </div>\r\n");

            
            #line 15 "..\..\Views\CatalogService\GetWarePropsListTable.cshtml"
    }
}
else
{

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"spec-table__specifications-item\"");

WriteLiteral(">");

            
            #line 19 "..\..\Views\CatalogService\GetWarePropsListTable.cshtml"
                                            Write(SharedResources.NoData);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");

            
            #line 20 "..\..\Views\CatalogService\GetWarePropsListTable.cshtml"
}

            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
