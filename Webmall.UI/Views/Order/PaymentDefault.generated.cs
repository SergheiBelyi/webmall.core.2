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
    using Webmall.UI.Core.Localization;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Order/PaymentDefault.cshtml")]
    public partial class _Views_Order_PaymentDefault_cshtml : System.Web.Mvc.WebViewPage<Webmall.Model.Entities.Cms.Order.OrderPayment>
    {
        public _Views_Order_PaymentDefault_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\Order\PaymentDefault.cshtml"
  
    Layout = null;

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 6 "..\..\Views\Order\PaymentDefault.cshtml"
 if (!String.IsNullOrEmpty(Model.Description))
{

            
            #line default
            #line hidden
WriteLiteral("    <p>");

            
            #line 8 "..\..\Views\Order\PaymentDefault.cshtml"
  Write(Model.Description);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");

            
            #line 9 "..\..\Views\Order\PaymentDefault.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"payment-terms\"");

WriteLiteral(">\r\n");

            
            #line 12 "..\..\Views\Order\PaymentDefault.cshtml"
    
            
            #line default
            #line hidden
            
            #line 12 "..\..\Views\Order\PaymentDefault.cshtml"
     foreach (var check in Model.Checkbox.ToLObjectGeneric())
    {

            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\"payment-terms__term\"");

WriteLiteral(" bis_skin_checked=\"1\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"payment-terms__checkbox checkbox-label\"");

WriteLiteral(" bis_skin_checked=\"1\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" class=\"checkbox-label__input js-paymentCheckbox-active\"");

WriteLiteral(" type=\"checkbox\"");

WriteAttribute("name", Tuple.Create(" name=\"", 514), Tuple.Create("\"", 580)
, Tuple.Create(Tuple.Create("", 521), Tuple.Create("is_accept-", 521), true)
            
            #line 16 "..\..\Views\Order\PaymentDefault.cshtml"
                                , Tuple.Create(Tuple.Create("", 531), Tuple.Create<System.Object, System.Int32>(Model.Checkbox.ToLObjectGeneric().IndexOf(check)
            
            #line default
            #line hidden
, 531), false)
);

WriteAttribute("id", Tuple.Create(" id=\"", 581), Tuple.Create("\"", 645)
, Tuple.Create(Tuple.Create("", 586), Tuple.Create("is-accept-", 586), true)
            
            #line 16 "..\..\Views\Order\PaymentDefault.cshtml"
                                                                                                 , Tuple.Create(Tuple.Create("", 596), Tuple.Create<System.Object, System.Int32>(Model.Checkbox.ToLObjectGeneric().IndexOf(check)
            
            #line default
            #line hidden
, 596), false)
);

WriteLiteral(">\r\n                <label");

WriteLiteral(" class=\"checkbox-label__main\"");

WriteAttribute("for", Tuple.Create(" for=\"", 700), Tuple.Create("\"", 765)
, Tuple.Create(Tuple.Create("", 706), Tuple.Create("is-accept-", 706), true)
            
            #line 17 "..\..\Views\Order\PaymentDefault.cshtml"
, Tuple.Create(Tuple.Create("", 716), Tuple.Create<System.Object, System.Int32>(Model.Checkbox.ToLObjectGeneric().IndexOf(check)
            
            #line default
            #line hidden
, 716), false)
);

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 18 "..\..\Views\Order\PaymentDefault.cshtml"
                Write(new HtmlString(@check.Name));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </label>\r\n            </div>\r\n        </div>\r\n");

            
            #line 22 "..\..\Views\Order\PaymentDefault.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n\r\n");

        }
    }
}
#pragma warning restore 1591
