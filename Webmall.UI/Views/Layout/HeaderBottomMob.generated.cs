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
    
    #line 1 "..\..\Views\Layout\HeaderBottomMob.cshtml"
    using ViewRes;
    
    #line default
    #line hidden
    using Webmall.UI;
    using Webmall.UI.Core.Localization;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Layout/HeaderBottomMob.cshtml")]
    public partial class _Views_Layout_HeaderBottomMob_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_Layout_HeaderBottomMob_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 3 "..\..\Views\Layout\HeaderBottomMob.cshtml"
  
    Layout = null;

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteLiteral(" class=\"header__mob-area-main\"");

WriteLiteral(">\r\n    <button");

WriteLiteral(" class=\"header__mob-area-toggle catalog-toggle js-catalog-mob-toggle\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(">\r\n        <svg");

WriteLiteral(" class=\"icon icon-menu catalog-toggle__icon\"");

WriteLiteral(" width=\"25\"");

WriteLiteral(" height=\"25\"");

WriteLiteral(">\r\n            <use");

WriteAttribute("href", Tuple.Create(" href=\"", 279), Tuple.Create("\"", 344)
            
            #line 10 "..\..\Views\Layout\HeaderBottomMob.cshtml"
, Tuple.Create(Tuple.Create("", 286), Tuple.Create<System.Object, System.Int32>(Url.Content("~/assets/images/svg/symbol/sprite.svg#menu")
            
            #line default
            #line hidden
, 286), false)
);

WriteLiteral("></use>\r\n        </svg>\r\n        <svg");

WriteLiteral(" class=\"icon icon-close catalog-toggle__icon\"");

WriteLiteral(" width=\"25\"");

WriteLiteral(" height=\"25\"");

WriteLiteral(">\r\n            <use");

WriteAttribute("href", Tuple.Create(" href=\"", 469), Tuple.Create("\"", 535)
            
            #line 13 "..\..\Views\Layout\HeaderBottomMob.cshtml"
, Tuple.Create(Tuple.Create("", 476), Tuple.Create<System.Object, System.Int32>(Url.Content("~/assets/images/svg/symbol/sprite.svg#close")
            
            #line default
            #line hidden
, 476), false)
);

WriteLiteral("></use>\r\n        </svg>\r\n    </button>\r\n");

            
            #line 16 "..\..\Views\Layout\HeaderBottomMob.cshtml"
    
            
            #line default
            #line hidden
            
            #line 16 "..\..\Views\Layout\HeaderBottomMob.cshtml"
     using (Html.BeginForm("Search", "Catalog", FormMethod.Get, new { id = "search-form", name = "search-form", @class = "search header__mob-area-search" }))
    {

            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\"search__field\"");

WriteLiteral(">\r\n            <input");

WriteLiteral(" class=\"search__input input\"");

WriteLiteral(" type=\"search\"");

WriteLiteral(" name=\"query\"");

WriteAttribute("placeholder", Tuple.Create(" placeholder=\"", 852), Tuple.Create("\"", 907)
            
            #line 19 "..\..\Views\Layout\HeaderBottomMob.cshtml"
        , Tuple.Create(Tuple.Create("", 866), Tuple.Create<System.Object, System.Int32>(SharedResources.SearchPlaceholderArticle
            
            #line default
            #line hidden
, 866), false)
);

WriteAttribute("value", Tuple.Create(" value=\"", 908), Tuple.Create("\"", 937)
            
            #line 19 "..\..\Views\Layout\HeaderBottomMob.cshtml"
                                                          , Tuple.Create(Tuple.Create("", 916), Tuple.Create<System.Object, System.Int32>(ViewBag.SearchString
            
            #line default
            #line hidden
, 916), false)
);

WriteLiteral(">\r\n            <button");

WriteLiteral(" class=\"search__submit\"");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" name=\"send\"");

WriteLiteral(">\r\n                <svg");

WriteLiteral(" class=\"icon icon-search-glass search__submit-icon\"");

WriteLiteral(" width=\"25\"");

WriteLiteral(" height=\"25\"");

WriteLiteral(">\r\n                    <use");

WriteAttribute("href", Tuple.Create(" href=\"", 1133), Tuple.Create("\"", 1206)
            
            #line 22 "..\..\Views\Layout\HeaderBottomMob.cshtml"
, Tuple.Create(Tuple.Create("", 1140), Tuple.Create<System.Object, System.Int32>(Url.Content("~/assets/images/svg/symbol/sprite.svg#search-glass")
            
            #line default
            #line hidden
, 1140), false)
);

WriteLiteral("></use>\r\n                </svg>\r\n            </button>\r\n        </div>\r\n");

            
            #line 26 "..\..\Views\Layout\HeaderBottomMob.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 28 "..\..\Views\Layout\HeaderBottomMob.cshtml"
    
            
            #line default
            #line hidden
            
            #line 28 "..\..\Views\Layout\HeaderBottomMob.cshtml"
      Html.RenderAction("GroupMenuMobile", "Catalog");
            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n</div>\r\n<div");

WriteLiteral(" class=\"header__mob-area-bottom\"");

WriteLiteral(">\r\n    <ul");

WriteLiteral(" class=\"header__mob-area-items mob-categories\"");

WriteLiteral(">\r\n");

            
            #line 33 "..\..\Views\Layout\HeaderBottomMob.cshtml"
        
            
            #line default
            #line hidden
            
            #line 33 "..\..\Views\Layout\HeaderBottomMob.cshtml"
          Html.RenderAction("HeaderNav", "Layout", new { mobile = true });
            
            #line default
            #line hidden
WriteLiteral("\r\n    </ul>\r\n</div>");

        }
    }
}
#pragma warning restore 1591
