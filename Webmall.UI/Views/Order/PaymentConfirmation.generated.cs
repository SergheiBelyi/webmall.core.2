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
    
    #line 1 "..\..\Views\Order\PaymentConfirmation.cshtml"
    using ValmiStore.Model.Entities.Order;
    
    #line default
    #line hidden
    
    #line 2 "..\..\Views\Order\PaymentConfirmation.cshtml"
    using ViewRes;
    
    #line default
    #line hidden
    using Webmall.UI;
    using Webmall.UI.Core.Localization;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Order/PaymentConfirmation.cshtml")]
    public partial class _Views_Order_PaymentConfirmation_cshtml : System.Web.Mvc.WebViewPage<Webmall.UI.Models.Payments.PaymentModel>
    {
        public _Views_Order_PaymentConfirmation_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 5 "..\..\Views\Order\PaymentConfirmation.cshtml"
  
    ViewBag.Title = SharedResources.PaymentAccepted;
    Layout = "~/Views/Shared/_PersonalLayout.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<aside");

WriteLiteral(" id=\"catalog-content\"");

WriteLiteral(">\r\n");

            
            #line 11 "..\..\Views\Order\PaymentConfirmation.cshtml"
    
            
            #line default
            #line hidden
            
            #line 11 "..\..\Views\Order\PaymentConfirmation.cshtml"
       Html.RenderPartial("OrderHeaderPartial", Model.Order); 
            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n    <ul");

WriteLiteral(" class=\"breadcrumbs\"");

WriteLiteral(" id=\"pageBreadscrumbs\"");

WriteLiteral(">\r\n        <li><span");

WriteLiteral(" id=\"bs1\"");

WriteLiteral(">");

            
            #line 14 "..\..\Views\Order\PaymentConfirmation.cshtml"
                      Write(SharedResources.WareSelection);

            
            #line default
            #line hidden
WriteLiteral("</span></li>\r\n        <li>&#8250;</li>\r\n        <li><span");

WriteLiteral(" id=\"bs2\"");

WriteLiteral(">");

            
            #line 16 "..\..\Views\Order\PaymentConfirmation.cshtml"
                      Write(SharedResources.PaymentForm);

            
            #line default
            #line hidden
WriteLiteral("</span></li>\r\n        <li>&#8250;</li>\r\n        <li><span");

WriteLiteral(" id=\"bs3\"");

WriteLiteral(">");

            
            #line 18 "..\..\Views\Order\PaymentConfirmation.cshtml"
                      Write(SharedResources.Delivery);

            
            #line default
            #line hidden
WriteLiteral("</span></li>\r\n        <li>&#8250;</li>\r\n        <li><span");

WriteLiteral(" id=\"bs4\"");

WriteLiteral(" class=\"current\"");

WriteLiteral(">");

            
            #line 20 "..\..\Views\Order\PaymentConfirmation.cshtml"
                                      Write(SharedResources.OrderCompleting);

            
            #line default
            #line hidden
WriteLiteral("</span></li>\r\n    </ul>\r\n\r\n    <div");

WriteLiteral(" class=\"clear-div\"");

WriteLiteral("> </div>\r\n    <div");

WriteLiteral(" class=\"invoice-wrapper\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"invoice\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"invoice-border\"");

WriteLiteral(">\r\n                <a");

WriteLiteral(" id=\"logo-small\"");

WriteLiteral("><img");

WriteAttribute("src", Tuple.Create(" src=\"", 942), Tuple.Create("\"", 1000)
            
            #line 27 "..\..\Views\Order\PaymentConfirmation.cshtml"
, Tuple.Create(Tuple.Create("", 948), Tuple.Create<System.Object, System.Int32>(Url.Content("~/ExtContent/images/logo-invoice.png")
            
            #line default
            #line hidden
, 948), false)
);

WriteLiteral(" alt=\"\"");

WriteLiteral("> </a>\r\n                <h2>");

            
            #line 28 "..\..\Views\Order\PaymentConfirmation.cshtml"
               Write(SharedResources.OrderPayment);

            
            #line default
            #line hidden
WriteLiteral("</h2>\r\n                <div");

WriteLiteral(" class=\"clear-div\"");

WriteLiteral("> </div>\r\n                <div");

WriteLiteral(" class=\"payment-confirmation\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 31 "..\..\Views\Order\PaymentConfirmation.cshtml"
                Write(new HtmlString(string.Format(SharedResources.PaymentAcceptedMessage, Model.OrderId, Model.Amount)));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n");

            
            #line 33 "..\..\Views\Order\PaymentConfirmation.cshtml"
                
            
            #line default
            #line hidden
            
            #line 33 "..\..\Views\Order\PaymentConfirmation.cshtml"
                   Html.RenderPartial("_SummaryOrderInfo", Model.Order); 
            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n                <div");

WriteLiteral(" class=\"clear-div\"");

WriteLiteral("> </div>\r\n\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"right\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"button-submit\"");

WriteAttribute("value", Tuple.Create(" value=\"", 1558), Tuple.Create("\"", 1587)
            
            #line 39 "..\..\Views\Order\PaymentConfirmation.cshtml"
, Tuple.Create(Tuple.Create("", 1566), Tuple.Create<System.Object, System.Int32>(SharedResources.Next
            
            #line default
            #line hidden
, 1566), false)
);

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 1588), Tuple.Create("\"", 1719)
, Tuple.Create(Tuple.Create("", 1598), Tuple.Create("window.location", 1598), true)
, Tuple.Create(Tuple.Create(" ", 1613), Tuple.Create("=", 1614), true)
, Tuple.Create(Tuple.Create(" ", 1615), Tuple.Create("\'", 1616), true)
            
            #line 39 "..\..\Views\Order\PaymentConfirmation.cshtml"
                                     , Tuple.Create(Tuple.Create("", 1617), Tuple.Create<System.Object, System.Int32>(Url.Action("Summary", "Order", new { orderId = Model.OrderId, paymentId = (int) PaymentTypes.Visa })
            
            #line default
            #line hidden
, 1617), false)
, Tuple.Create(Tuple.Create("", 1718), Tuple.Create("\'", 1718), true)
);

WriteLiteral(">\r\n            </div>\r\n        </div>\r\n");

            
            #line 42 "..\..\Views\Order\PaymentConfirmation.cshtml"
        
            
            #line default
            #line hidden
            
            #line 42 "..\..\Views\Order\PaymentConfirmation.cshtml"
           Html.RenderPartial("_SummaryVidgets"); 
            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n</aside>\r\n\r\n");

        }
    }
}
#pragma warning restore 1591
