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
    
    #line 1 "..\..\Views\Shared\Layouts\CatalogHeaderControlsMob.cshtml"
    using ViewRes;
    
    #line default
    #line hidden
    using Webmall.UI;
    using Webmall.UI.Core.Localization;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/Layouts/CatalogHeaderControlsMob.cshtml")]
    public partial class _Views_Shared_Layouts_CatalogHeaderControlsMob_cshtml : System.Web.Mvc.WebViewPage<Webmall.UI.Models.Catalog.CatalogWaresModel>
    {
        public _Views_Shared_Layouts_CatalogHeaderControlsMob_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\Shared\Layouts\CatalogHeaderControlsMob.cshtml"
  
    var view = ViewBag.ViewMode;

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteLiteral(" class=\"header-controls d-md-none\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"header-control\"");

WriteLiteral(">\r\n        <a");

WriteLiteral(" class=\"filter-toggle\"");

WriteLiteral(" href=\"#\"");

WriteLiteral(">\r\n            <svg");

WriteLiteral(" class=\"icon icon-funnel filter-toggle__icon\"");

WriteLiteral(">\r\n                <use");

WriteLiteral(" href=\"/assets/images/svg/symbol/sprite.svg#funnel\"");

WriteLiteral("></use>\r\n            </svg>\r\n        </a>\r\n    </div>\r\n");

            
            #line 15 "..\..\Views\Shared\Layouts\CatalogHeaderControlsMob.cshtml"
    
            
            #line default
            #line hidden
            
            #line 15 "..\..\Views\Shared\Layouts\CatalogHeaderControlsMob.cshtml"
     if (Model.TotalAmountWares > 0)
    {

            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\"header-control\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"header-control__progress\"");

WriteLiteral(">товары <strong>");

            
            #line 18 "..\..\Views\Shared\Layouts\CatalogHeaderControlsMob.cshtml"
                                                            Write(Model.Wares.PageSize);

            
            #line default
            #line hidden
WriteLiteral("</strong> ");

            
            #line 18 "..\..\Views\Shared\Layouts\CatalogHeaderControlsMob.cshtml"
                                                                                           Write(SharedResources.of);

            
            #line default
            #line hidden
WriteLiteral(" <strong>");

            
            #line 18 "..\..\Views\Shared\Layouts\CatalogHeaderControlsMob.cshtml"
                                                                                                                       Write(Model.TotalAmountWares);

            
            #line default
            #line hidden
WriteLiteral("</strong></div>\r\n        </div>\r\n");

            
            #line 20 "..\..\Views\Shared\Layouts\CatalogHeaderControlsMob.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("   \r\n    <div");

WriteLiteral(" class=\"header-control\"");

WriteLiteral(">\r\n        <ul");

WriteLiteral(" class=\"view-mode\"");

WriteLiteral(">\r\n            <li");

WriteAttribute("class", Tuple.Create(" class=\"", 776), Tuple.Create("\"", 824)
, Tuple.Create(Tuple.Create("", 784), Tuple.Create("view-mode__item", 784), true)
            
            #line 24 "..\..\Views\Shared\Layouts\CatalogHeaderControlsMob.cshtml"
, Tuple.Create(Tuple.Create(" ", 799), Tuple.Create<System.Object, System.Int32>(view==1 ? "active":""
            
            #line default
            #line hidden
, 800), false)
);

WriteLiteral(">\r\n                <a");

WriteLiteral(" class=\"view-mode__link\"");

WriteLiteral(" href=\"#\"");

WriteLiteral(" ");

            
            #line 25 "..\..\Views\Shared\Layouts\CatalogHeaderControlsMob.cshtml"
                                                     if (view == 0) {
            
            #line default
            #line hidden
WriteLiteral(" ");

WriteLiteral(" onclick=\"setview(1); return false;\" ");

WriteLiteral(" ");

            
            #line 25 "..\..\Views\Shared\Layouts\CatalogHeaderControlsMob.cshtml"
                                                                                                                         }
            
            #line default
            #line hidden
WriteLiteral(">\r\n                    <svg");

WriteLiteral(" class=\"icon icon-th view-mode__icon\"");

WriteLiteral(">\r\n                        <use");

WriteLiteral(" href=\"/assets/images/svg/symbol/sprite.svg#th\"");

WriteLiteral("></use>\r\n                    </svg>\r\n                </a>\r\n            </li>\r\n   " +
"         <li");

WriteAttribute("class", Tuple.Create(" class=\"", 1185), Tuple.Create("\"", 1233)
, Tuple.Create(Tuple.Create("", 1193), Tuple.Create("view-mode__item", 1193), true)
            
            #line 31 "..\..\Views\Shared\Layouts\CatalogHeaderControlsMob.cshtml"
, Tuple.Create(Tuple.Create(" ", 1208), Tuple.Create<System.Object, System.Int32>(view==0 ? "active":""
            
            #line default
            #line hidden
, 1209), false)
);

WriteLiteral(">\r\n                <a");

WriteLiteral(" class=\"view-mode__link\"");

WriteLiteral(" href=\"#\"");

WriteLiteral(" ");

            
            #line 32 "..\..\Views\Shared\Layouts\CatalogHeaderControlsMob.cshtml"
                                                     if (view == 1) {
            
            #line default
            #line hidden
WriteLiteral(" ");

WriteLiteral(" onclick=\"setview(0); return false;\" ");

WriteLiteral(" ");

            
            #line 32 "..\..\Views\Shared\Layouts\CatalogHeaderControlsMob.cshtml"
                                                                                                                         }
            
            #line default
            #line hidden
WriteLiteral(">\r\n                    <svg");

WriteLiteral(" class=\"icon icon-th-list view-mode__icon\"");

WriteLiteral(">\r\n                        <use");

WriteLiteral(" href=\"/assets/images/svg/symbol/sprite.svg#th-list\"");

WriteLiteral("></use>\r\n                    </svg>\r\n                </a>\r\n            </li>\r\n   " +
"     </ul>\r\n    </div>\r\n</div>");

        }
    }
}
#pragma warning restore 1591
