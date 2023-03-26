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
    
    #line 1 "..\..\Views\Order\OrderListMob.cshtml"
    using ViewRes;
    
    #line default
    #line hidden
    using Webmall.UI;
    using Webmall.UI.Core.Localization;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Order/OrderListMob.cshtml")]
    public partial class _Views_Order_OrderListMob_cshtml : System.Web.Mvc.WebViewPage<Webmall.UI.ViewModel.Order.OrdersListViewModel>
    {
        public _Views_Order_OrderListMob_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 5 "..\..\Views\Order\OrderListMob.cshtml"
  
    Layout = null;
    ViewBag.Title = SharedResources.Orders;

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteLiteral(" class=\"stock-area__mob-table stock-mob-table js-checked-all is-table-mode\"");

WriteLiteral(">\r\n    <header");

WriteLiteral(" class=\"stock-mob-table__header\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"stock-mob-table__row\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"stock-mob-table__cell\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"stock-mob-table__checkbox checkbox-label\"");

WriteLiteral(">\r\n                    <input");

WriteLiteral(" class=\"checkbox-label__input js-checked-all-trigger\"");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" name=\"is-opt-16\"");

WriteLiteral(" id=\"opt-16\"");

WriteLiteral(">\r\n                    <label");

WriteLiteral(" class=\"checkbox-label__main\"");

WriteLiteral(" for=\"opt-16\"");

WriteLiteral("></label>\r\n                </div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"stock-mob-table__cell\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"stock-mob-table__caption\"");

WriteLiteral(">Номер заказа</div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"stock-mob-table__cell\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"stock-mob-table__caption\"");

WriteLiteral(">\r\n                    Дата,\r\n                    <br> Время заказа\r\n            " +
"    </div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"stock-mob-table__cell\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"stock-mob-table__caption text-center\"");

WriteLiteral(">Статус</div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"stock-mob-table__cell\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"stock-mob-table__caption\"");

WriteLiteral(">&nbsp;</div>\r\n            </div>\r\n        </div>\r\n    </header>\r\n    <div");

WriteLiteral(" class=\"stock-mob-table__main\"");

WriteLiteral(">\r\n");

            
            #line 37 "..\..\Views\Order\OrderListMob.cshtml"
        
            
            #line default
            #line hidden
            
            #line 37 "..\..\Views\Order\OrderListMob.cshtml"
         foreach (var item in Model.Orders.List) {
            var status = Model.Statuses.FirstOrDefault(i => i.StatusId == item.StatusId);

            
            #line default
            #line hidden
WriteLiteral("            <div");

WriteLiteral(" class=\"stock-mob-table__row js-accordion\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"stock-mob-table__cell\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"stock-mob-table__checkbox checkbox-label\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" class=\"checkbox-label__input js-checked-all-item\"");

WriteLiteral(" type=\"checkbox\"");

WriteAttribute("name", Tuple.Create(" name=\"", 1837), Tuple.Create("\"", 1859)
, Tuple.Create(Tuple.Create("", 1844), Tuple.Create("is-opt-", 1844), true)
            
            #line 42 "..\..\Views\Order\OrderListMob.cshtml"
                              , Tuple.Create(Tuple.Create("", 1851), Tuple.Create<System.Object, System.Int32>(item.Id
            
            #line default
            #line hidden
, 1851), false)
);

WriteAttribute("id", Tuple.Create(" id=\"", 1860), Tuple.Create("\"", 1881)
, Tuple.Create(Tuple.Create("", 1865), Tuple.Create("opt-mob-", 1865), true)
            
            #line 42 "..\..\Views\Order\OrderListMob.cshtml"
                                                    , Tuple.Create(Tuple.Create("", 1873), Tuple.Create<System.Object, System.Int32>(item.Id
            
            #line default
            #line hidden
, 1873), false)
);

WriteLiteral(">\r\n                        <label");

WriteLiteral(" class=\"checkbox-label__main\"");

WriteAttribute("for", Tuple.Create(" for=\"", 1944), Tuple.Create("\"", 1966)
, Tuple.Create(Tuple.Create("", 1950), Tuple.Create("opt-mob-", 1950), true)
            
            #line 43 "..\..\Views\Order\OrderListMob.cshtml"
, Tuple.Create(Tuple.Create("", 1958), Tuple.Create<System.Object, System.Int32>(item.Id
            
            #line default
            #line hidden
, 1958), false)
);

WriteLiteral("></label>\r\n                    </div>\r\n                </div>\r\n                <d" +
"iv");

WriteLiteral(" class=\"stock-mob-table__cell\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"stock-mob-table__text\"");

WriteLiteral(">\r\n                        <a");

WriteLiteral(" class=\"stock-table__articul\"");

WriteAttribute("href", Tuple.Create(" href=\"", 2195), Tuple.Create("\"", 2259)
            
            #line 48 "..\..\Views\Order\OrderListMob.cshtml"
, Tuple.Create(Tuple.Create("", 2202), Tuple.Create<System.Object, System.Int32>(Url.Action("Detail", "Order", new { orderId = item.Id })
            
            #line default
            #line hidden
, 2202), false)
);

WriteLiteral(">");

            
            #line 48 "..\..\Views\Order\OrderListMob.cshtml"
                                                                                                                    Write(item.Number);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                    </div>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"stock-mob-table__cell\"");

WriteLiteral(">\r\n                    <time");

WriteLiteral(" class=\"stock-table__date\"");

WriteAttribute("datetime", Tuple.Create(" datetime=\"", 2435), Tuple.Create("\"", 2539)
            
            #line 52 "..\..\Views\Order\OrderListMob.cshtml"
, Tuple.Create(Tuple.Create("", 2446), Tuple.Create<System.Object, System.Int32>(item.OrderDate.Date.ToString(CultureInfo.CurrentUICulture)
            
            #line default
            #line hidden
, 2446), false)
            
            #line 52 "..\..\Views\Order\OrderListMob.cshtml"
                                         , Tuple.Create(Tuple.Create(" ", 2505), Tuple.Create<System.Object, System.Int32>(item.OrderDate.ToString("HH:mm")
            
            #line default
            #line hidden
, 2506), false)
);

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 53 "..\..\Views\Order\OrderListMob.cshtml"
                   Write(item.OrderDate.Date.ToString(CultureInfo.CurrentUICulture));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        <span>");

            
            #line 54 "..\..\Views\Order\OrderListMob.cshtml"
                         Write(item.OrderDate.ToString("HH:mm"));

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                    </time>\r\n                </div>\r\n                <di" +
"v");

WriteLiteral(" class=\"stock-mob-table__cell text-center\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"stock-mob-table__text\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"stock-mob-table__status status-badge\"");

WriteAttribute("style", Tuple.Create(" style=\"", 2948), Tuple.Create("\"", 2993)
, Tuple.Create(Tuple.Create("", 2956), Tuple.Create("background-color:", 2956), true)
            
            #line 59 "..\..\Views\Order\OrderListMob.cshtml"
                   , Tuple.Create(Tuple.Create(" ", 2973), Tuple.Create<System.Object, System.Int32>(status?.WebColor
            
            #line default
            #line hidden
, 2974), false)
);

WriteLiteral(">");

            
            #line 59 "..\..\Views\Order\OrderListMob.cshtml"
                                                                                                                   Write(item.StatusName);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                    </div>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"stock-mob-table__cell\"");

WriteLiteral(">\r\n                    <button");

WriteLiteral(" class=\"stock-mob-table__mob-toggle js-accordion-trigger\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(">\r\n                        <svg");

WriteLiteral(" class=\"icon icon-chevron-down stock-mob-table__mob-toggle-icon\"");

WriteLiteral(" width=\"25\"");

WriteLiteral(" height=\"25\"");

WriteLiteral(">\r\n                            <use");

WriteAttribute("href", Tuple.Create(" href=\"", 3375), Tuple.Create("\"", 3448)
            
            #line 65 "..\..\Views\Order\OrderListMob.cshtml"
, Tuple.Create(Tuple.Create("", 3382), Tuple.Create<System.Object, System.Int32>(Url.Content("~/assets/images/svg/symbol/sprite.svg#chevron-down")
            
            #line default
            #line hidden
, 3382), false)
);

WriteLiteral("></use>\r\n                        </svg>\r\n                    </button>\r\n         " +
"       </div>\r\n                <div");

WriteLiteral(" class=\"stock-mob-table__dropdown js-accordion-body\"");

WriteLiteral(" hidden>\r\n                    <div");

WriteLiteral(" class=\"stock-mob-table__utils\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"stock-mob-table__util badge\"");

WriteLiteral(" data-tippy-gray-content=\"Ожидается оплата\"");

WriteLiteral(">\r\n                            <svg");

WriteLiteral(" class=\"badge__icon\"");

WriteLiteral(" width=\"26\"");

WriteLiteral(" height=\"17\"");

WriteLiteral(" viewBox=\"0 0 26 17\"");

WriteLiteral(" fill=\"none\"");

WriteLiteral(" xmlns=\"http://www.w3.org/2000/svg\"");

WriteLiteral(">\r\n                                <path");

WriteLiteral(" d=\"M2 4C2 2.89543 2.89543 2 4 2H17C18.1046 2 19 2.89543 19 4V12C19 13.1046 18.10" +
"46 14 17 14H4C2.89543 14 2 13.1046 2 12V4Z\"");

WriteLiteral(" fill=\"#F79E1B\"");

WriteLiteral("></path>\r\n                                <rect");

WriteLiteral(" x=\"2\"");

WriteLiteral(" y=\"4\"");

WriteLiteral(" width=\"17\"");

WriteLiteral(" height=\"1\"");

WriteLiteral(" fill=\"white\"");

WriteLiteral("></rect>\r\n                                <path");

WriteLiteral(@" d=""M19.0172 14C19.0172 14.1971 19.133 14.3758 19.3128 14.4563C19.4927 14.5369 19.7031 14.5043 19.8501 14.3731L24.3329 10.3731C24.4392 10.2782 24.5 10.1425 24.5 10C24.5 9.85751 24.4392 9.7218 24.3329 9.62693L19.8501 5.62693C19.7031 5.49572 19.4927 5.46313 19.3128 5.54368C19.133 5.62424 19.0172 5.80293 19.0172 6V7.65385H14C13.7239 7.65385 13.5 7.8777 13.5 8.15385V11.8462C13.5 12.1223 13.7239 12.3462 14 12.3462H19.0172V14Z""");

WriteLiteral(" fill=\"#F79E1B\"");

WriteLiteral(" stroke=\"white\"");

WriteLiteral(" stroke-linejoin=\"round\"");

WriteLiteral("></path>\r\n                            </svg>\r\n                        </div>\r\n   " +
"                     <div");

WriteLiteral(" class=\"stock-mob-table__util badge\"");

WriteLiteral(" data-tippy-gray-content=\"\"");

WriteLiteral(">\r\n                            <svg");

WriteLiteral(" class=\"icon icon-truck badge__icon\"");

WriteLiteral(" width=\"25\"");

WriteLiteral(" height=\"25\"");

WriteLiteral(">\r\n                                <use");

WriteAttribute("href", Tuple.Create(" href=\"", 5038), Tuple.Create("\"", 5104)
            
            #line 80 "..\..\Views\Order\OrderListMob.cshtml"
, Tuple.Create(Tuple.Create("", 5045), Tuple.Create<System.Object, System.Int32>(Url.Content("~/assets/images/svg/symbol/sprite.svg#truck")
            
            #line default
            #line hidden
, 5045), false)
);

WriteLiteral("></use>\r\n                            </svg>\r\n                            <div");

WriteLiteral(" data-tippy-gray-content-template=\"\"");

WriteLiteral(@">
                                <strong>Водитель:</strong>
                                <p>Иванов Петр Сергеевич Нет в модели этих данных</p>
                                <strong>Телефон:</strong>
                                <p>05674088786</p>
                            </div>
                        </div>
                        <div");

WriteLiteral(" class=\"stock-mob-table__util badge\"");

WriteLiteral(" data-tippy-gray-content=\"\"");

WriteLiteral(">\r\n                            <svg");

WriteLiteral(" class=\"icon icon-info badge__icon\"");

WriteLiteral(" width=\"25\"");

WriteLiteral(" height=\"25\"");

WriteLiteral(">\r\n                                <use");

WriteAttribute("href", Tuple.Create(" href=\"", 5770), Tuple.Create("\"", 5835)
            
            #line 91 "..\..\Views\Order\OrderListMob.cshtml"
, Tuple.Create(Tuple.Create("", 5777), Tuple.Create<System.Object, System.Int32>(Url.Content("~/assets/images/svg/symbol/sprite.svg#info")
            
            #line default
            #line hidden
, 5777), false)
);

WriteLiteral("></use>\r\n                            </svg>\r\n                            <div");

WriteLiteral(" data-tippy-gray-content-template=\"\"");

WriteLiteral(">\r\n                                <strong>");

            
            #line 94 "..\..\Views\Order\OrderListMob.cshtml"
                                   Write(SharedResources.OrderAuthor);

            
            #line default
            #line hidden
WriteLiteral(":</strong>\r\n                                <p>");

            
            #line 95 "..\..\Views\Order\OrderListMob.cshtml"
                              Write(item.UserName);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                            </div>\r\n                        </div>\r\n       " +
"                 <div");

WriteLiteral(" class=\"stock-mob-table__util badge\"");

WriteLiteral(" data-tippy-dropdown-content=\"\"");

WriteLiteral(" aria-expanded=\"false\"");

WriteLiteral(">\r\n                            <svg");

WriteLiteral(" class=\"icon icon-dots badge__icon\"");

WriteLiteral(" width=\"25\"");

WriteLiteral(" height=\"25\"");

WriteLiteral(">\r\n                                <use");

WriteAttribute("href", Tuple.Create(" href=\"", 6404), Tuple.Create("\"", 6469)
            
            #line 100 "..\..\Views\Order\OrderListMob.cshtml"
, Tuple.Create(Tuple.Create("", 6411), Tuple.Create<System.Object, System.Int32>(Url.Content("~/assets/images/svg/symbol/sprite.svg#dots")
            
            #line default
            #line hidden
, 6411), false)
);

WriteLiteral("></use>\r\n                            </svg>\r\n                            <div");

WriteLiteral(" data-tippy-dropdown-content-template=\"\"");

WriteLiteral(">\r\n                                <ul");

WriteLiteral(" class=\"tooltip-nav\"");

WriteLiteral(">\r\n                                    <li");

WriteLiteral(" class=\"tooltip-nav__item\"");

WriteLiteral(">\r\n                                        <a");

WriteLiteral(" class=\"tooltip-nav__link\"");

WriteLiteral(" href=\"#\"");

WriteLiteral(">");

            
            #line 105 "..\..\Views\Order\OrderListMob.cshtml"
                                                                         Write(SharedResources.DeleteOrder);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                                    </li>\r\n                                " +
"    <li");

WriteLiteral(" class=\"tooltip-nav__item\"");

WriteLiteral(">\r\n                                        <a");

WriteLiteral(" class=\"tooltip-nav__link\"");

WriteLiteral(" href=\"#\"");

WriteLiteral(">");

            
            #line 108 "..\..\Views\Order\OrderListMob.cshtml"
                                                                         Write(SharedResources.RepeatOrder);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                                    </li>\r\n                                " +
"    <li");

WriteLiteral(" class=\"tooltip-nav__item\"");

WriteLiteral(">\r\n                                        <a");

WriteLiteral(" class=\"tooltip-nav__link\"");

WriteLiteral(" href=\"#\"");

WriteLiteral(">");

            
            #line 111 "..\..\Views\Order\OrderListMob.cshtml"
                                                                         Write(SharedResources.PrintAPP);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                                    </li>\r\n                                " +
"    <li");

WriteLiteral(" class=\"tooltip-nav__item\"");

WriteLiteral(">\r\n                                        <a");

WriteLiteral(" class=\"tooltip-nav__link\"");

WriteLiteral(" href=\"#\"");

WriteLiteral(">");

            
            #line 114 "..\..\Views\Order\OrderListMob.cshtml"
                                                                         Write(SharedResources.ExportToExcel);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                                    </li>\r\n                                " +
"</ul>\r\n                            </div>\r\n                        </div>\r\n     " +
"               </div>\r\n\r\n                    <div");

WriteLiteral(" class=\"stock-mob-table__params\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"stock-mob-table__param\"");

WriteLiteral(">\r\n                            <dt");

WriteLiteral(" class=\"stock-mob-table__property\"");

WriteLiteral(">");

            
            #line 123 "..\..\Views\Order\OrderListMob.cshtml"
                                                             Write(SharedResources.Sum);

            
            #line default
            #line hidden
WriteLiteral("</dt>\r\n                            <dd");

WriteLiteral(" class=\"stock-mob-table__value\"");

WriteLiteral(">");

            
            #line 124 "..\..\Views\Order\OrderListMob.cshtml"
                                                          Write(item.Sum);

            
            #line default
            #line hidden
WriteLiteral("</dd>\r\n                        </div>\r\n                        <div");

WriteLiteral(" class=\"stock-mob-table__param\"");

WriteLiteral(">\r\n                            <dt");

WriteLiteral(" class=\"stock-mob-table__property\"");

WriteLiteral(">");

            
            #line 127 "..\..\Views\Order\OrderListMob.cshtml"
                                                             Write(SharedResources.DeliveryDate);

            
            #line default
            #line hidden
WriteLiteral("</dt>\r\n                            <dd");

WriteLiteral(" class=\"stock-mob-table__value\"");

WriteLiteral(">");

            
            #line 128 "..\..\Views\Order\OrderListMob.cshtml"
                                                          Write(item.OrderDate.ToString("dd.MM.yyy"));

            
            #line default
            #line hidden
WriteLiteral("</dd>\r\n                        </div>\r\n                    </div>\r\n\r\n            " +
"        <div");

WriteLiteral(" class=\"stock-mob-table__inner js-inner-table\"");

WriteLiteral(">\r\n                        <button");

WriteLiteral(" class=\"stock-mob-table__inner-trigger is-first js-inner-table-trigger btn\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 8513), Tuple.Create("\"", 8553)
, Tuple.Create(Tuple.Create("", 8523), Tuple.Create("OpenOrderItemPropMob(", 8523), true)
            
            #line 133 "..\..\Views\Order\OrderListMob.cshtml"
                                                         , Tuple.Create(Tuple.Create("", 8544), Tuple.Create<System.Object, System.Int32>(item.Id
            
            #line default
            #line hidden
, 8544), false)
, Tuple.Create(Tuple.Create("", 8552), Tuple.Create(")", 8552), true)
);

WriteLiteral(">\r\n                            <span");

WriteLiteral(" class=\"btn__text\"");

WriteLiteral(">");

            
            #line 134 "..\..\Views\Order\OrderListMob.cshtml"
                                               Write(SharedResources.ShowOrderItems);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                            <svg");

WriteLiteral(" class=\"icon icon-chevron-down btn__icon\"");

WriteLiteral(" width=\"25\"");

WriteLiteral(" height=\"25\"");

WriteLiteral(">\r\n                                <use");

WriteAttribute("href", Tuple.Create(" href=\"", 8784), Tuple.Create("\"", 8857)
            
            #line 136 "..\..\Views\Order\OrderListMob.cshtml"
, Tuple.Create(Tuple.Create("", 8791), Tuple.Create<System.Object, System.Int32>(Url.Content("~/assets/images/svg/symbol/sprite.svg#chevron-down")
            
            #line default
            #line hidden
, 8791), false)
);

WriteLiteral("></use>\r\n                            </svg>\r\n                        </button>\r\n " +
"                       <div");

WriteLiteral(" class=\"stock-mob-table js-checked-all is-detail is-dark\"");

WriteLiteral(" data-loaded=\"false\"");

WriteLiteral(" data-orderIdMob=\"");

            
            #line 139 "..\..\Views\Order\OrderListMob.cshtml"
                                                                                                                      Write(item.Id);

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(" >\r\n                            <div");

WriteAttribute("id", Tuple.Create(" id=\"", 9106), Tuple.Create("\"", 9134)
, Tuple.Create(Tuple.Create("", 9111), Tuple.Create("updateBlockMob-", 9111), true)
            
            #line 140 "..\..\Views\Order\OrderListMob.cshtml"
, Tuple.Create(Tuple.Create("", 9126), Tuple.Create<System.Object, System.Int32>(item.Id
            
            #line default
            #line hidden
, 9126), false)
);

WriteLiteral(">\r\n                                <p>");

            
            #line 141 "..\..\Views\Order\OrderListMob.cshtml"
                              Write(SharedResources.Loading);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n                            </div>\r\n                        </div>\r\n       " +
"                 <button");

WriteLiteral(" class=\"stock-mob-table__inner-trigger is-last js-inner-table-trigger btn\"");

WriteLiteral(">\r\n                            <span");

WriteLiteral(" class=\"btn__text\"");

WriteLiteral(">");

            
            #line 145 "..\..\Views\Order\OrderListMob.cshtml"
                                               Write(SharedResources.ShowOrderItems);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                            <svg");

WriteLiteral(" class=\"icon icon-chevron-down btn__icon\"");

WriteLiteral(" width=\"25\"");

WriteLiteral(" height=\"25\"");

WriteLiteral(">\r\n                                <use");

WriteAttribute("href", Tuple.Create(" href=\"", 9606), Tuple.Create("\"", 9679)
            
            #line 147 "..\..\Views\Order\OrderListMob.cshtml"
, Tuple.Create(Tuple.Create("", 9613), Tuple.Create<System.Object, System.Int32>(Url.Content("~/assets/images/svg/symbol/sprite.svg#chevron-down")
            
            #line default
            #line hidden
, 9613), false)
);

WriteLiteral("></use>\r\n                            </svg>\r\n                        </button>\r\n " +
"                   </div>\r\n                    \r\n                </div>\r\n       " +
"     </div>\r\n");

            
            #line 154 "..\..\Views\Order\OrderListMob.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n</div>");

        }
    }
}
#pragma warning restore 1591
