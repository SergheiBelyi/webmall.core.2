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
    
    #line 1 "..\..\Views\Shared\Components\TableOrderPosition.cshtml"
    using ViewRes;
    
    #line default
    #line hidden
    using Webmall.UI;
    
    #line 2 "..\..\Views\Shared\Components\TableOrderPosition.cshtml"
    using Webmall.UI.Core;
    
    #line default
    #line hidden
    using Webmall.UI.Core.Localization;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/Components/TableOrderPosition.cshtml")]
    public partial class _Views_Shared_Components_TableOrderPosition_cshtml : System.Web.Mvc.WebViewPage<List<Webmall.Model.Entities.Order.OrderPosition>>
    {
        public _Views_Shared_Components_TableOrderPosition_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 6 "..\..\Views\Shared\Components\TableOrderPosition.cshtml"
  
    Layout = null;
    var rate = 1;

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n\r\n<div");

WriteLiteral(" class=\"stock-table__header\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"stock-table__row\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"stock-table__cell\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"stock-table__caption\"");

WriteLiteral(">");

            
            #line 15 "..\..\Views\Shared\Components\TableOrderPosition.cshtml"
                                         Write(SharedResources.WareNumber);

            
            #line default
            #line hidden
WriteLiteral(", ");

            
            #line 15 "..\..\Views\Shared\Components\TableOrderPosition.cshtml"
                                                                      Write(SharedResources._brand);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"stock-table__cell\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"stock-table__caption\"");

WriteLiteral(">");

            
            #line 18 "..\..\Views\Shared\Components\TableOrderPosition.cshtml"
                                         Write(SharedResources.WareName);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"stock-table__cell text-center\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"stock-table__caption\"");

WriteLiteral(">");

            
            #line 21 "..\..\Views\Shared\Components\TableOrderPosition.cshtml"
                                         Write(SharedResources.Note);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"stock-table__cell text-center\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"stock-table__caption\"");

WriteLiteral(">");

            
            #line 24 "..\..\Views\Shared\Components\TableOrderPosition.cshtml"
                                         Write(SharedResources.DeliveryDate);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"stock-table__cell text-center\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"stock-table__caption\"");

WriteLiteral(">");

            
            #line 27 "..\..\Views\Shared\Components\TableOrderPosition.cshtml"
                                         Write(SharedResources.ReturnPeriod);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"stock-table__cell text-center\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"stock-table__caption\"");

WriteLiteral(">");

            
            #line 30 "..\..\Views\Shared\Components\TableOrderPosition.cshtml"
                                         Write(SharedResources.UnitPrice);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"stock-table__cell text-center\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"stock-table__caption\"");

WriteLiteral(">");

            
            #line 33 "..\..\Views\Shared\Components\TableOrderPosition.cshtml"
                                         Write(SharedResources.Amount);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"stock-table__cell text-center\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"stock-table__caption\"");

WriteLiteral(">");

            
            #line 36 "..\..\Views\Shared\Components\TableOrderPosition.cshtml"
                                         Write(SharedResources.Sum);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<div");

WriteLiteral(" class=\"stock-table__main\"");

WriteLiteral(">\r\n");

            
            #line 42 "..\..\Views\Shared\Components\TableOrderPosition.cshtml"
    
            
            #line default
            #line hidden
            
            #line 42 "..\..\Views\Shared\Components\TableOrderPosition.cshtml"
     foreach (var item in Model)
    {
        var wareUrl = Url.Action("WareCard", "Catalog")?.Replace("WareCard", "") + $"{item.ProducerName}/{item.WareNumber}";

            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\"stock-table__row\"");

WriteLiteral(">\r\n            \r\n            <div");

WriteLiteral(" class=\"stock-table__cell\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 48 "..\..\Views\Shared\Components\TableOrderPosition.cshtml"
           Write(Html.Hidden($"Positions[{Model.IndexOf(item)}].Id", item.Id));

            
            #line default
            #line hidden
WriteLiteral("\r\n                <div");

WriteLiteral(" class=\"stock-table__meta\"");

WriteLiteral(">\r\n                    <a");

WriteLiteral(" class=\"stock-table__articul\"");

WriteAttribute("href", Tuple.Create(" href=\"", 1907), Tuple.Create("\"", 1922)
            
            #line 50 "..\..\Views\Shared\Components\TableOrderPosition.cshtml"
, Tuple.Create(Tuple.Create("", 1914), Tuple.Create<System.Object, System.Int32>(wareUrl
            
            #line default
            #line hidden
, 1914), false)
);

WriteLiteral(">");

            
            #line 50 "..\..\Views\Shared\Components\TableOrderPosition.cshtml"
                                                               Write(item.WareName);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                    <a");

WriteLiteral(" class=\"stock-table__brand\"");

WriteAttribute("href", Tuple.Create(" href=\"", 1993), Tuple.Create("\"", 2008)
            
            #line 51 "..\..\Views\Shared\Components\TableOrderPosition.cshtml"
, Tuple.Create(Tuple.Create("", 2000), Tuple.Create<System.Object, System.Int32>(wareUrl
            
            #line default
            #line hidden
, 2000), false)
);

WriteLiteral(">");

            
            #line 51 "..\..\Views\Shared\Components\TableOrderPosition.cshtml"
                                                             Write(item.ProducerName);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                </div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"stock-table__cell\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"stock-table__heading\"");

WriteLiteral(">\r\n                    <a");

WriteLiteral(" class=\"stock-table__heading-link\"");

WriteAttribute("href", Tuple.Create(" href=\"", 2231), Tuple.Create("\"", 2246)
            
            #line 56 "..\..\Views\Shared\Components\TableOrderPosition.cshtml"
, Tuple.Create(Tuple.Create("", 2238), Tuple.Create<System.Object, System.Int32>(wareUrl
            
            #line default
            #line hidden
, 2238), false)
);

WriteLiteral(">");

            
            #line 56 "..\..\Views\Shared\Components\TableOrderPosition.cshtml"
                                                                    Write(item.WareName);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                </div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"stock-table__cell\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"custom-comment\"");

WriteLiteral(" data-modal-win-trigger=\"comment-edited\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 2440), Tuple.Create("\"", 2483)
, Tuple.Create(Tuple.Create("", 2450), Tuple.Create("CartEditPositionComment(", 2450), true)
            
            #line 60 "..\..\Views\Shared\Components\TableOrderPosition.cshtml"
                                     , Tuple.Create(Tuple.Create("", 2474), Tuple.Create<System.Object, System.Int32>(item.Id
            
            #line default
            #line hidden
, 2474), false)
, Tuple.Create(Tuple.Create("", 2482), Tuple.Create(")", 2482), true)
);

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"custom-comment__desc\"");

WriteAttribute("id", Tuple.Create(" id=\"", 2540), Tuple.Create("\"", 2561)
, Tuple.Create(Tuple.Create("", 2545), Tuple.Create("comment_", 2545), true)
            
            #line 61 "..\..\Views\Shared\Components\TableOrderPosition.cshtml"
, Tuple.Create(Tuple.Create("", 2553), Tuple.Create<System.Object, System.Int32>(item.Id
            
            #line default
            #line hidden
, 2553), false)
);

WriteLiteral(">");

            
            #line 61 "..\..\Views\Shared\Components\TableOrderPosition.cshtml"
                                                                       Write(item.Comment);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                </div>\r\n            </div>\r\n\r\n            <div");

WriteLiteral(" class=\"stock-table__cell text-center\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"stock-table__accent\"");

WriteLiteral(" data-tippy-gray-content>\r\n                    05.02.2022<div data-tippy-gray-con" +
"tent-template>\r\n                        <div");

WriteLiteral(" class=\"tooltip-dates-ranges\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"tooltip-dates-range\"");

WriteLiteral(">\r\n                                Получение <span>до 10:50 23.09.2021</span>\r\n  " +
"                          </div>\r\n                            <div");

WriteLiteral(" class=\"tooltip-dates-range\"");

WriteLiteral(">\r\n                                при заказе <span>до 20:15 22.09.2021</span>\r\n " +
"                           </div>\r\n                        </div>\r\n             " +
"       </div>\r\n                </div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"stock-table__cell text-center\"");

WriteLiteral(">\r\n                ");

WriteLiteral("\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"stock-table__cell text-center\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"stock-table__text\"");

WriteLiteral(" data-tippy-gray-content=\"");

            
            #line 83 "..\..\Views\Shared\Components\TableOrderPosition.cshtml"
                                                                   Write(SharedResources.PurchasePriceForOneUnit);

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(">");

            
            #line 83 "..\..\Views\Shared\Components\TableOrderPosition.cshtml"
                                                                                                             Write(SessionHelper.PriceFormat(item.Price));

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"stock-table__cell text-center\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"stock-table__text\"");

WriteLiteral(">");

            
            #line 86 "..\..\Views\Shared\Components\TableOrderPosition.cshtml"
                                          Write(string.Format("{0:0}", item.WareQnt));

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"stock-table__cell text-center\"");

WriteLiteral(">\r\n                <strong");

WriteLiteral(" class=\"stock-table__text\"");

WriteAttribute("id", Tuple.Create(" id=\"", 4033), Tuple.Create("\"", 4056)
, Tuple.Create(Tuple.Create("", 4038), Tuple.Create("position", 4038), true)
            
            #line 89 "..\..\Views\Shared\Components\TableOrderPosition.cshtml"
, Tuple.Create(Tuple.Create("", 4046), Tuple.Create<System.Object, System.Int32>(item.Id
            
            #line default
            #line hidden
, 4046), false)
);

WriteLiteral(">");

            
            #line 89 "..\..\Views\Shared\Components\TableOrderPosition.cshtml"
                                                                     Write(SessionHelper.PriceFormat(new Decimal(Math.Round((double)(item.Price / rate), 2)) * item.WareQnt));

            
            #line default
            #line hidden
WriteLiteral("</strong>\r\n            </div>\r\n        </div>\r\n");

            
            #line 92 "..\..\Views\Shared\Components\TableOrderPosition.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n\r\n");

        }
    }
}
#pragma warning restore 1591
