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
    
    #line 1 "..\..\Views\Order\ListItemProperties.cshtml"
    using ViewRes;
    
    #line default
    #line hidden
    using Webmall.UI;
    using Webmall.UI.Core.Localization;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Order/ListItemProperties.cshtml")]
    public partial class _Views_Order_ListItemProperties_cshtml : System.Web.Mvc.WebViewPage<List<Webmall.Model.Entities.Order.OrderPosition>>
    {
        public _Views_Order_ListItemProperties_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 4 "..\..\Views\Order\ListItemProperties.cshtml"
  
    Layout = null;

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 8 "..\..\Views\Order\ListItemProperties.cshtml"
 if (Model.Any()) {

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"stock-table js-checked-all scrollbar is-detail is-dark\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"stock-table__header\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"stock-table__row\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"stock-table__cell text-center\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"stock-table__checkbox checkbox-label\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" class=\"checkbox-label__input js-checked-all-trigger\"");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" name=\"is-opt-0a\"");

WriteLiteral(" id=\"opt-0a\"");

WriteLiteral(">\r\n                        <label");

WriteLiteral(" class=\"checkbox-label__main\"");

WriteLiteral(" for=\"opt-0a\"");

WriteLiteral("></label>\r\n                    </div>\r\n                </div>\r\n                <d" +
"iv");

WriteLiteral(" class=\"stock-table__cell\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"stock-table__caption\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 20 "..\..\Views\Order\ListItemProperties.cshtml"
                   Write(SharedResources.WareNumber);

            
            #line default
            #line hidden
WriteLiteral(", ");

            
            #line 20 "..\..\Views\Order\ListItemProperties.cshtml"
                                                Write(SharedResources._brand);

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"stock-table__cell\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"stock-table__caption\"");

WriteLiteral(">");

            
            #line 24 "..\..\Views\Order\ListItemProperties.cshtml"
                                                 Write(SharedResources.Name);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"stock-table__cell text-center\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"stock-table__caption\"");

WriteLiteral(">");

            
            #line 27 "..\..\Views\Order\ListItemProperties.cshtml"
                                                 Write(SharedResources.PricePerOne);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"stock-table__cell text-center\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"stock-table__caption\"");

WriteLiteral(">");

            
            #line 30 "..\..\Views\Order\ListItemProperties.cshtml"
                                                 Write(SharedResources.Amount);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"stock-table__cell text-center\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"stock-table__caption\"");

WriteLiteral(">");

            
            #line 33 "..\..\Views\Order\ListItemProperties.cshtml"
                                                 Write(SharedResources.Sum);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"stock-table__cell text-center\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"stock-table__caption\"");

WriteLiteral(">");

            
            #line 36 "..\..\Views\Order\ListItemProperties.cshtml"
                                                 Write(SharedResources.Status);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"stock-table__cell text-center\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"stock-table__caption\"");

WriteLiteral(">");

            
            #line 39 "..\..\Views\Order\ListItemProperties.cshtml"
                                                 Write(SharedResources.DeliveryDate);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"stock-table__cell text-center\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"stock-table__caption\"");

WriteLiteral(">");

            
            #line 42 "..\..\Views\Order\ListItemProperties.cshtml"
                                                 Write(SharedResources.Note);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n\r\n        <di" +
"v");

WriteLiteral(" class=\"stock-table__main\"");

WriteLiteral(">\r\n");

            
            #line 48 "..\..\Views\Order\ListItemProperties.cshtml"
            
            
            #line default
            #line hidden
            
            #line 48 "..\..\Views\Order\ListItemProperties.cshtml"
             foreach (var item in Model)
            {
                var wareUrl = Url.Action("WareCard", "Catalog")?.Replace("WareCard", "") + $"{item.ProducerName}/{item.WareNumber}";


            
            #line default
            #line hidden
WriteLiteral("                <div");

WriteLiteral(" class=\"stock-table__row\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"stock-table__cell text-center\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"stock-table__checkbox checkbox-label\"");

WriteLiteral(">\r\n                            <input");

WriteLiteral(" class=\"checkbox-label__input js-checked-all-item\"");

WriteLiteral(" type=\"checkbox\"");

WriteAttribute("name", Tuple.Create(" name=\"", 2663), Tuple.Create("\"", 2685)
, Tuple.Create(Tuple.Create("", 2670), Tuple.Create("is-opt-", 2670), true)
            
            #line 55 "..\..\Views\Order\ListItemProperties.cshtml"
                                  , Tuple.Create(Tuple.Create("", 2677), Tuple.Create<System.Object, System.Int32>(item.Id
            
            #line default
            #line hidden
, 2677), false)
);

WriteAttribute("id", Tuple.Create(" id=\"", 2686), Tuple.Create("\"", 2703)
, Tuple.Create(Tuple.Create("", 2691), Tuple.Create("opt-", 2691), true)
            
            #line 55 "..\..\Views\Order\ListItemProperties.cshtml"
                                                    , Tuple.Create(Tuple.Create("", 2695), Tuple.Create<System.Object, System.Int32>(item.Id
            
            #line default
            #line hidden
, 2695), false)
);

WriteLiteral(">\r\n                            <label");

WriteLiteral(" class=\"checkbox-label__main\"");

WriteAttribute("for", Tuple.Create(" for=\"", 2770), Tuple.Create("\"", 2788)
, Tuple.Create(Tuple.Create("", 2776), Tuple.Create("opt-", 2776), true)
            
            #line 56 "..\..\Views\Order\ListItemProperties.cshtml"
, Tuple.Create(Tuple.Create("", 2780), Tuple.Create<System.Object, System.Int32>(item.Id
            
            #line default
            #line hidden
, 2780), false)
);

WriteLiteral("></label>\r\n                        </div>\r\n                    </div>\r\n          " +
"          <div");

WriteLiteral(" class=\"stock-table__cell\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"stock-table__meta\"");

WriteLiteral(">\r\n                            <a");

WriteLiteral(" class=\"stock-table__articul\"");

WriteAttribute("href", Tuple.Create(" href=\"", 3029), Tuple.Create("\"", 3044)
            
            #line 61 "..\..\Views\Order\ListItemProperties.cshtml"
, Tuple.Create(Tuple.Create("", 3036), Tuple.Create<System.Object, System.Int32>(wareUrl
            
            #line default
            #line hidden
, 3036), false)
);

WriteLiteral(">");

            
            #line 61 "..\..\Views\Order\ListItemProperties.cshtml"
                                                                       Write(item.WareNumber);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                            <a");

WriteLiteral(" class=\"stock-table__brand\"");

WriteAttribute("href", Tuple.Create(" href=\"", 3125), Tuple.Create("\"", 3140)
            
            #line 62 "..\..\Views\Order\ListItemProperties.cshtml"
, Tuple.Create(Tuple.Create("", 3132), Tuple.Create<System.Object, System.Int32>(wareUrl
            
            #line default
            #line hidden
, 3132), false)
);

WriteLiteral(">");

            
            #line 62 "..\..\Views\Order\ListItemProperties.cshtml"
                                                                     Write(item.ProducerName);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                        </div>\r\n                    </div>\r\n               " +
"     <div");

WriteLiteral(" class=\"stock-table__cell\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"stock-table__heading\"");

WriteLiteral(">\r\n                            <a");

WriteLiteral(" class=\"stock-table__heading-link\"");

WriteAttribute("href", Tuple.Create(" href=\"", 3403), Tuple.Create("\"", 3418)
            
            #line 67 "..\..\Views\Order\ListItemProperties.cshtml"
, Tuple.Create(Tuple.Create("", 3410), Tuple.Create<System.Object, System.Int32>(wareUrl
            
            #line default
            #line hidden
, 3410), false)
);

WriteLiteral(">");

            
            #line 67 "..\..\Views\Order\ListItemProperties.cshtml"
                                                                            Write(item.WareName);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                        </div>\r\n                    </div>\r\n               " +
"     <div");

WriteLiteral(" class=\"stock-table__cell text-center\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"stock-table__text\"");

WriteLiteral(" data-tippy-gray-content=\"");

            
            #line 71 "..\..\Views\Order\ListItemProperties.cshtml"
                                                                           Write(SharedResources.PurchasePriceForOneUnit);

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(">");

            
            #line 71 "..\..\Views\Order\ListItemProperties.cshtml"
                                                                                                                     Write(item.Price);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                    </div>\r\n                    <div");

WriteLiteral(" class=\"stock-table__cell text-center\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"stock-table__text\"");

WriteLiteral(">");

            
            #line 74 "..\..\Views\Order\ListItemProperties.cshtml"
                                                  Write(item.WareQnt);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                    </div>\r\n                    <div");

WriteLiteral(" class=\"stock-table__cell text-center\"");

WriteLiteral(">\r\n                        <strong");

WriteLiteral(" class=\"stock-table__text\"");

WriteLiteral(">");

            
            #line 77 "..\..\Views\Order\ListItemProperties.cshtml"
                                                     Write(item.Sum);

            
            #line default
            #line hidden
WriteLiteral("</strong>\r\n                    </div>\r\n                    <div");

WriteLiteral(" class=\"stock-table__cell text-center\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"stock-table__badge status-badge is-processing\"");

WriteLiteral(">");

            
            #line 80 "..\..\Views\Order\ListItemProperties.cshtml"
                                                                              Write(item.StatusName);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                    </div>\r\n                    <div");

WriteLiteral(" class=\"stock-table__cell text-center\"");

WriteLiteral(">\r\n                        <time");

WriteLiteral(" class=\"stock-table__accent\"");

WriteLiteral(" datetime=\"2022\"");

WriteLiteral(" data-tippy-gray-content=\"");

            
            #line 83 "..\..\Views\Order\ListItemProperties.cshtml"
                                                                                              Write(SharedResources.TermDays);

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(">");

            
            #line 83 "..\..\Views\Order\ListItemProperties.cshtml"
                                                                                                                         Write(item.DeliveryPresentation);

            
            #line default
            #line hidden
WriteLiteral("</time>\r\n                    </div>\r\n                    <div");

WriteLiteral(" class=\"stock-table__cell\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"stock-table__comment custom-comment\"");

WriteLiteral(" data-modal-win-trigger=\"comment-add\"");

WriteLiteral(">\r\n                            <label");

WriteLiteral(" class=\"user-note__caption\"");

WriteAttribute("for", Tuple.Create(" for=\"", 4754), Tuple.Create("\"", 4771)
, Tuple.Create(Tuple.Create("", 4760), Tuple.Create("un-", 4760), true)
            
            #line 87 "..\..\Views\Order\ListItemProperties.cshtml"
, Tuple.Create(Tuple.Create("", 4763), Tuple.Create<System.Object, System.Int32>(item.Id
            
            #line default
            #line hidden
, 4763), false)
);

WriteLiteral(">");

            
            #line 87 "..\..\Views\Order\ListItemProperties.cshtml"
                                                                           Write(item.Comment);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n                        </div>\r\n                    </div>\r\n           " +
"     </div>\r\n");

            
            #line 91 "..\..\Views\Order\ListItemProperties.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n\r\n        </div>\r\n\r\n    </div>\r\n");

            
            #line 98 "..\..\Views\Order\ListItemProperties.cshtml"
}
else { 

            
            #line default
            #line hidden
WriteLiteral("<div>");

            
            #line 100 "..\..\Views\Order\ListItemProperties.cshtml"
Write(SharedResources.NoData);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");

            
            #line 101 "..\..\Views\Order\ListItemProperties.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\r\n");

        }
    }
}
#pragma warning restore 1591
