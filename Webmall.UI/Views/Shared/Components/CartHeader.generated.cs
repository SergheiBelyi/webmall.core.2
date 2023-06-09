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
    
    #line 1 "..\..\Views\Shared\Components\CartHeader.cshtml"
    using Webmall.UI.Core;
    
    #line default
    #line hidden
    using Webmall.UI.Core.Localization;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/Components/CartHeader.cshtml")]
    public partial class _Views_Shared_Components_CartHeader_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_Shared_Components_CartHeader_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 3 "..\..\Views\Shared\Components\CartHeader.cshtml"
   
    var count = 0;
    decimal price = 0;
    if (SessionHelper.CurrentUser != null) {
        count = SessionHelper.Cart.Count;
        foreach(var item in SessionHelper.Cart) {
            price += item.ClientPrice * item.WareQnt;
        }
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteLiteral(" class=\"header-utilities\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"header-utility\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"header-utility__main\"");

WriteLiteral(">\r\n            <a");

WriteLiteral(" class=\"header-utility__link\"");

WriteAttribute("href", Tuple.Create(" href=\"", 446), Tuple.Create("\"", 481)
            
            #line 17 "..\..\Views\Shared\Components\CartHeader.cshtml"
, Tuple.Create(Tuple.Create("", 453), Tuple.Create<System.Object, System.Int32>(Url.Action("Index", "Cart")
            
            #line default
            #line hidden
, 453), false)
);

WriteLiteral(">\r\n                <svg");

WriteLiteral(" class=\"icon icon-shopping-cart-main header-utility__icon\"");

WriteLiteral(">\r\n                    <use");

WriteAttribute("href", Tuple.Create(" href=\"", 590), Tuple.Create("\"", 653)
, Tuple.Create(Tuple.Create("", 597), Tuple.Create<System.Object, System.Int32>(Href("~/assets/images/svg/symbol/sprite.svg#shopping-cart-main")
, 597), false)
);

WriteLiteral("></use>\r\n                </svg>\r\n                <span");

WriteLiteral(" class=\"header-utility__count cart-counter\"");

WriteLiteral(">");

            
            #line 21 "..\..\Views\Shared\Components\CartHeader.cshtml"
                                                            Write(count);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                <span");

WriteLiteral(" class=\"header-utility__text cart-text\"");

WriteLiteral(">");

            
            #line 22 "..\..\Views\Shared\Components\CartHeader.cshtml"
                                                         Write(price == 0 ? "0" : SessionHelper.PriceFormat(price));

            
            #line default
            #line hidden
WriteLiteral(" ");

            
            #line 22 "..\..\Views\Shared\Components\CartHeader.cshtml"
                                                                                                               Write(SessionHelper.CurrentValute.Code);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n            </a>\r\n        </div>\r\n    </div>\r\n</div>\r\n");

        }
    }
}
#pragma warning restore 1591
