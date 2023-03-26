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
    
    #line 1 "..\..\Views\Catalog\CatalogBottomControls.cshtml"
    using ViewRes;
    
    #line default
    #line hidden
    using Webmall.UI;
    using Webmall.UI.Core.Localization;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Catalog/CatalogBottomControls.cshtml")]
    public partial class _Views_Catalog_CatalogBottomControls_cshtml : System.Web.Mvc.WebViewPage<Webmall.UI.Models.Catalog.CatalogWaresModel>
    {
        public _Views_Catalog_CatalogBottomControls_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\Catalog\CatalogBottomControls.cshtml"
  
    var pageSizes = new [] { 12, 24, 36, 50 };

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteLiteral(" class=\"catalog__bottom-controls header-controls\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"header-control\"");

WriteLiteral(">\r\n");

            
            #line 9 "..\..\Views\Catalog\CatalogBottomControls.cshtml"
        
            
            #line default
            #line hidden
            
            #line 9 "..\..\Views\Catalog\CatalogBottomControls.cshtml"
         if (Model.Wares.AllowPagging && Model.Wares.AllowPageSizeSelection)
        {
            Html.RenderPartial("Components/Pagination", Model.Wares);
        }

            
            #line default
            #line hidden
WriteLiteral("    </div>\r\n    <div");

WriteLiteral(" class=\"header-control\"");

WriteLiteral(">\r\n");

            
            #line 15 "..\..\Views\Catalog\CatalogBottomControls.cshtml"
        
            
            #line default
            #line hidden
            
            #line 15 "..\..\Views\Catalog\CatalogBottomControls.cshtml"
         if (Model.Wares.AllowPagging && Model.Wares.AllowPageSizeSelection)
        {

            
            #line default
            #line hidden
WriteLiteral("            <div");

WriteLiteral(" class=\"header-control__dropdown\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"header-control__dropdown-main custom-dropdown js-dropdown\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"custom-dropdown__header js-dropdown-toggle\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"custom-dropdown__heading\"");

WriteLiteral(">");

            
            #line 20 "..\..\Views\Catalog\CatalogBottomControls.cshtml"
                                                         Write(Model.Wares.PageSize);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                    </div>\r\n                    <ul");

WriteLiteral(" class=\"custom-dropdown__items\"");

WriteLiteral(">\r\n");

            
            #line 23 "..\..\Views\Catalog\CatalogBottomControls.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 23 "..\..\Views\Catalog\CatalogBottomControls.cshtml"
                         foreach (var item in pageSizes)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <li");

WriteLiteral(" class=\"custom-dropdown__item\"");

WriteLiteral(">\r\n                                <a");

WriteLiteral(" class=\"custom-dropdown__link\"");

WriteLiteral(" href=\"#\"");

WriteLiteral(">");

            
            #line 26 "..\..\Views\Catalog\CatalogBottomControls.cshtml"
                                                                     Write(item);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                            </li>\r\n");

            
            #line 28 "..\..\Views\Catalog\CatalogBottomControls.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </ul>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"header-control__dropdown-text\"");

WriteLiteral(">");

            
            #line 31 "..\..\Views\Catalog\CatalogBottomControls.cshtml"
                                                      Write(SharedResources.ProductsPerPage);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n            </div>\r\n");

            
            #line 33 "..\..\Views\Catalog\CatalogBottomControls.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("    </div>\r\n    <div");

WriteLiteral(" class=\"header-control\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"header-control__progress\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 37 "..\..\Views\Catalog\CatalogBottomControls.cshtml"
       Write(SharedResources.Products);

            
            #line default
            #line hidden
WriteLiteral(" <strong>");

            
            #line 37 "..\..\Views\Catalog\CatalogBottomControls.cshtml"
                                          Write(Model.Wares.Skip+1);

            
            #line default
            #line hidden
WriteLiteral(" - ");

            
            #line 37 "..\..\Views\Catalog\CatalogBottomControls.cshtml"
                                                                  Write(Model.Wares.Skip+Model.Wares.List.Count);

            
            #line default
            #line hidden
WriteLiteral("</strong> ");

            
            #line 37 "..\..\Views\Catalog\CatalogBottomControls.cshtml"
                                                                                                                     Write(SharedResources.of);

            
            #line default
            #line hidden
WriteLiteral(" <strong>");

            
            #line 37 "..\..\Views\Catalog\CatalogBottomControls.cshtml"
                                                                                                                                                 Write(Model.TotalAmountWares);

            
            #line default
            #line hidden
WriteLiteral("</strong>\r\n        </div>\r\n    </div>\r\n</div>");

        }
    }
}
#pragma warning restore 1591
