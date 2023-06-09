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
    
    #line 1 "..\..\Views\Shared\Components\CatalogNav.cshtml"
    using ViewRes;
    
    #line default
    #line hidden
    using Webmall.UI;
    
    #line 2 "..\..\Views\Shared\Components\CatalogNav.cshtml"
    using Webmall.UI.Core;
    
    #line default
    #line hidden
    using Webmall.UI.Core.Localization;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/Components/CatalogNav.cshtml")]
    public partial class _Views_Shared_Components_CatalogNav_cshtml : System.Web.Mvc.WebViewPage<List<Webmall.Model.Entities.Catalog.Group>>
    {
        public _Views_Shared_Components_CatalogNav_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 5 "..\..\Views\Shared\Components\CatalogNav.cshtml"
  
    Layout = null;
    var currentParentLink = UserPreferences.CurrentCultureLink + "/catalog/";

            
            #line default
            #line hidden
WriteLiteral("\r\n<button");

WriteLiteral(" class=\"catalog-nav-toggle d-md-none btn btn--primary\"");

WriteLiteral(">\r\n    <svg");

WriteLiteral(" class=\"icon icon-burger catalog-nav-toggle__icon\"");

WriteLiteral(">\r\n        <use");

WriteAttribute("href", Tuple.Create(" href=\"", 336), Tuple.Create("\"", 403)
            
            #line 11 "..\..\Views\Shared\Components\CatalogNav.cshtml"
, Tuple.Create(Tuple.Create("", 343), Tuple.Create<System.Object, System.Int32>(Url.Content("~/assets/images/svg/symbol/sprite.svg#burger")
            
            #line default
            #line hidden
, 343), false)
);

WriteLiteral("></use>\r\n    </svg>\r\n    <svg");

WriteLiteral(" class=\"icon icon-close catalog-nav-toggle__icon\"");

WriteLiteral(">\r\n        <use");

WriteAttribute("href", Tuple.Create(" href=\"", 497), Tuple.Create("\"", 563)
            
            #line 14 "..\..\Views\Shared\Components\CatalogNav.cshtml"
, Tuple.Create(Tuple.Create("", 504), Tuple.Create<System.Object, System.Int32>(Url.Content("~/assets/images/svg/symbol/sprite.svg#close")
            
            #line default
            #line hidden
, 504), false)
);

WriteLiteral("></use>\r\n    </svg>\r\n</button>\r\n\r\n<nav");

WriteLiteral(" class=\"main-nav\"");

WriteLiteral(">\r\n    <ul");

WriteLiteral(" class=\"main-nav__point-container\"");

WriteLiteral(">\r\n        <li");

WriteLiteral(" class=\"main-nav__point-item js-dropdown\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"main-nav__point-link btn btn--primary js-dropdown-toggle\"");

WriteLiteral(">\r\n                <svg");

WriteLiteral(" class=\"icon icon-burger main-nav__icon\"");

WriteLiteral(">\r\n                    <use");

WriteAttribute("href", Tuple.Create(" href=\"", 892), Tuple.Create("\"", 959)
            
            #line 23 "..\..\Views\Shared\Components\CatalogNav.cshtml"
, Tuple.Create(Tuple.Create("", 899), Tuple.Create<System.Object, System.Int32>(Url.Content("~/assets/images/svg/symbol/sprite.svg#burger")
            
            #line default
            #line hidden
, 899), false)
);

WriteLiteral("></use>\r\n                </svg><span");

WriteLiteral(" class=\"main-nav__point-link-text\"");

WriteLiteral(">");

            
            #line 24 "..\..\Views\Shared\Components\CatalogNav.cshtml"
                                                         Write(SharedResources.AllWareCategories);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                <div");

WriteLiteral(" class=\"main-nav__close-nav-wrap\"");

WriteLiteral(">\r\n                    <svg");

WriteLiteral(" class=\"icon icon-close main-nav__close-nav\"");

WriteLiteral(">\r\n                        <use");

WriteAttribute("href", Tuple.Create(" href=\"", 1229), Tuple.Create("\"", 1295)
            
            #line 27 "..\..\Views\Shared\Components\CatalogNav.cshtml"
, Tuple.Create(Tuple.Create("", 1236), Tuple.Create<System.Object, System.Int32>(Url.Content("~/assets/images/svg/symbol/sprite.svg#close")
            
            #line default
            #line hidden
, 1236), false)
);

WriteLiteral("></use>\r\n                    </svg>\r\n                </div>\r\n            </div>\r\n" +
"            <div");

WriteLiteral(" class=\"main-nav__container\"");

WriteLiteral(">\r\n                <ul");

WriteLiteral(" class=\"main-nav__list\"");

WriteLiteral(">\r\n");

            
            #line 33 "..\..\Views\Shared\Components\CatalogNav.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 33 "..\..\Views\Shared\Components\CatalogNav.cshtml"
                       Html.RenderPartial("Components/CustomTopCatalogMenu"); 
            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                    ");

            
            #line 34 "..\..\Views\Shared\Components\CatalogNav.cshtml"
               Write(Html.GroupMenuElements(Model, currentParentLink, this, 1));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </ul>\r\n            </div>\r\n           \r\n        </li>\r\n    </ul" +
">\r\n</nav>\r\n");

        }
    }
}
#pragma warning restore 1591
