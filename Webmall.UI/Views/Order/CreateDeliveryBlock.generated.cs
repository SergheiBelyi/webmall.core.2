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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Order/CreateDeliveryBlock.cshtml")]
    public partial class _Views_Order_CreateDeliveryBlock_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_Order_CreateDeliveryBlock_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 2 "..\..\Views\Order\CreateDeliveryBlock.cshtml"
  
    Layout = null;

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteLiteral(" class=\"tabs__pane js-tabs-pane\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"tabs__accordion-toggle js-tabs-accordion-toggle\"");

WriteLiteral(" id=\"delivery-2\"");

WriteLiteral(">Доставка</div>\r\n    <div");

WriteLiteral(" class=\"tabs__accordion-body\"");

WriteLiteral(">\r\n        <!-- delivery-table-->\r\n        <div");

WriteLiteral(" class=\"delivery-table\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"delivery-table__header\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"delivery-table__addresses user-addresses\"");

WriteLiteral(" hidden>\r\n                    <div");

WriteLiteral(" class=\"user-addresses__field\"");

WriteLiteral(">\r\n                        <select");

WriteLiteral(" class=\"user-addresses__input select\"");

WriteLiteral(" name=\"address\"");

WriteLiteral(">\r\n                            <option");

WriteLiteral(" value=\"\"");

WriteLiteral(" selected disabled hidden>Адрес доставки</option>\r\n                            <o" +
"ption");

WriteLiteral(" value=\"addr\"");

WriteLiteral(">Адрес доставки 1</option>\r\n                            <option");

WriteLiteral(" value=\"addr\"");

WriteLiteral(">Адрес доставки 2</option>\r\n                            <option");

WriteLiteral(" value=\"addr\"");

WriteLiteral(">Адрес доставки 3</option>\r\n                            <option");

WriteLiteral(" value=\"addr\"");

WriteLiteral(">Адрес доставки 4</option>\r\n                        </select>\r\n                  " +
"  </div>\r\n                    <button");

WriteLiteral(" class=\"user-addresses__btn btn-add\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(" data-modal-win-trigger=\"address-add\"");

WriteLiteral(">\r\n                        <span");

WriteLiteral(" class=\"btn-add__icon-wrap\"");

WriteLiteral(">\r\n                            <svg");

WriteLiteral(" class=\"icon icon-plus btn-add__icon\"");

WriteLiteral(" width=\"25\"");

WriteLiteral(" height=\"25\"");

WriteLiteral(">\r\n                                <use");

WriteAttribute("href", Tuple.Create(" href=\"", 1318), Tuple.Create("\"", 1383)
            
            #line 25 "..\..\Views\Order\CreateDeliveryBlock.cshtml"
, Tuple.Create(Tuple.Create("", 1325), Tuple.Create<System.Object, System.Int32>(Url.Content("~/assets/images/svg/symbol/sprite.svg#plus")
            
            #line default
            #line hidden
, 1325), false)
);

WriteLiteral("></use>\r\n                            </svg>\r\n                        </span>\r\n   " +
"                     <span");

WriteLiteral(" class=\"btn-add__text\"");

WriteLiteral(">Добавить</span>\r\n                    </button>\r\n                </div>\r\n        " +
"        <div");

WriteLiteral(" class=\"delivery-table__checks\"");

WriteLiteral(">\r\n                    <!-- check-order-->\r\n                    <div");

WriteLiteral(" class=\"delivery-table__check check-order\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"check-order__option checkbox-label\"");

WriteLiteral(">\r\n                            <input");

WriteLiteral(" class=\"checkbox-label__input\"");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" name=\"opt\"");

WriteLiteral(" id=\"opts-1\"");

WriteLiteral(">\r\n                            <label");

WriteLiteral(" class=\"checkbox-label__main\"");

WriteLiteral(" for=\"opts-1\"");

WriteLiteral(">\r\n                                <span");

WriteLiteral(" class=\"checkbox-label__main-text\"");

WriteLiteral(">Нужен товарный чек</span>\r\n                            </label>\r\n               " +
"         </div>\r\n                    </div><!-- /check-order-->\r\n               " +
"     <!-- check-order-->\r\n                    <div");

WriteLiteral(" class=\"delivery-table__check check-order is-accent\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"check-order__option checkbox-label\"");

WriteLiteral(">\r\n                            <input");

WriteLiteral(" class=\"checkbox-label__input\"");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" name=\"opt\"");

WriteLiteral(" id=\"opts-2\"");

WriteLiteral(">\r\n                            <label");

WriteLiteral(" class=\"checkbox-label__main\"");

WriteLiteral(" for=\"opts-2\"");

WriteLiteral(">\r\n                                <span");

WriteLiteral(" class=\"checkbox-label__main-text\"");

WriteLiteral(">Доставлять по доступности</span>\r\n                            </label>\r\n        " +
"                </div>\r\n                    </div><!-- /check-order-->\r\n        " +
"        </div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"delivery-table__main\"");

WriteLiteral(">\r\n                <!-- table-->\r\n                <div");

WriteLiteral(" class=\"table-responsive delivery-table__area\"");

WriteLiteral(">\r\n                    <table>\r\n                        <thead>\r\n                " +
"            <tr>\r\n                                <th>Способ доставки</th>\r\n    " +
"                            <th");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">21.05.2021</th>\r\n                                <th");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">21.05.2021</th>\r\n                                <th");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">21.05.2021</th>\r\n                                <th");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">21.05.2021</th>\r\n                                <th");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">21.05.2021</th>\r\n                                <th");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">21.05.2021</th>\r\n                                <th");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">21.05.2021</th>\r\n                                <th");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">21.05.2021</th>\r\n                            </tr>\r\n                        </th" +
"ead>\r\n                        <tbody>\r\n                            <tr");

WriteLiteral(" class=\"is-days\"");

WriteLiteral(@">
                                <td>&nbsp;</td>
                                <td>пт</td>
                                <td>сб</td>
                                <td>вс</td>
                                <td>пн</td>
                                <td>вт</td>
                                <td>ср</td>
                                <td>чт</td>
                                <td>пт</td>
                            </tr>
                            <tr>
                                <td>
                                    <strong>До двери</strong>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <strong>Курьер</strong>
                                </td>
                                <td>
                                    <ul");

WriteLiteral(" class=\"is-current\"");

WriteLiteral(">\r\n                                        <li>11:00-13:00</li>\r\n                " +
"                        <li>13:00-15:00</li>\r\n                                  " +
"      <li>15:00-17:00</li>\r\n                                    </ul>\r\n         " +
"                       </td>\r\n                                <td>\r\n            " +
"                        <ul>\r\n                                        <li>09:00-" +
"11:00</li>\r\n                                        <li>11:00-13:00</li>\r\n      " +
"                                  <li>13:00-15:00</li>\r\n                        " +
"                <li>15:00-17:00</li>\r\n                                    </ul>\r" +
"\n                                </td>\r\n                                <td>\r\n  " +
"                                  <ul>\r\n                                        " +
"<li>09:00-11:00</li>\r\n                                        <li>11:00-13:00</l" +
"i>\r\n                                        <li>13:00-15:00</li>\r\n              " +
"                          <li>15:00-17:00</li>\r\n                                " +
"    </ul>\r\n                                </td>\r\n                              " +
"  <td>\r\n                                    <ul>\r\n                              " +
"          <li>09:00-11:00</li>\r\n                                        <li>11:0" +
"0-13:00</li>\r\n                                        <li>13:00-15:00</li>\r\n    " +
"                                    <li>15:00-17:00</li>\r\n                      " +
"              </ul>\r\n                                </td>\r\n                    " +
"            <td>\r\n                                    <ul>\r\n                    " +
"                    <li>09:00-11:00</li>\r\n                                      " +
"  <li>11:00-13:00</li>\r\n                                        <li>13:00-15:00<" +
"/li>\r\n                                        <li>15:00-17:00</li>\r\n            " +
"                        </ul>\r\n                                </td>\r\n          " +
"                      <td>\r\n                                    <ul>\r\n          " +
"                              <li>09:00-11:00</li>\r\n                            " +
"            <li>11:00-13:00</li>\r\n                                        <li>13" +
":00-15:00</li>\r\n                                        <li>15:00-17:00</li>\r\n  " +
"                                  </ul>\r\n                                </td>\r\n" +
"                                <td>\r\n                                    <ul>\r\n" +
"                                        <li>09:00-11:00</li>\r\n                  " +
"                      <li>11:00-13:00</li>\r\n                                    " +
"    <li>13:00-15:00</li>\r\n                                        <li>15:00-17:0" +
"0</li>\r\n                                    </ul>\r\n                             " +
"   </td>\r\n                                <td>\r\n                                " +
"    <ul>\r\n                                        <li>09:00-11:00</li>\r\n        " +
"                                <li>11:00-13:00</li>\r\n                          " +
"              <li>13:00-15:00</li>\r\n                                        <li>" +
"15:00-17:00</li>\r\n                                    </ul>\r\n                   " +
"             </td>\r\n                            </tr>\r\n                        <" +
"/tbody>\r\n                    </table>\r\n                </div><!-- /table-->\r\n   " +
"             <!-- delivery-timetable-->\r\n                <div");

WriteLiteral(" class=\"delivery-table__timetable delivery-timetable\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"delivery-timetable__header\"");

WriteLiteral(">Способ доставки - курьер</div>\r\n                    <div");

WriteLiteral(" class=\"delivery-timetable__main\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"delivery-timetable__row js-accordion\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"delivery-timetable__caption js-accordion-trigger\"");

WriteLiteral(">21.05.2021 пт</div>\r\n                            <div");

WriteLiteral(" class=\"delivery-timetable__body js-accordion-body\"");

WriteLiteral(" hidden>\r\n                                <ul");

WriteLiteral(" class=\"delivery-timetable__list\"");

WriteLiteral(">\r\n                                    <li");

WriteLiteral(" class=\"delivery-timetable__item\"");

WriteLiteral(">09:00-11:00</li>\r\n                                    <li");

WriteLiteral(" class=\"delivery-timetable__item\"");

WriteLiteral(">09:00-11:00</li>\r\n                                    <li");

WriteLiteral(" class=\"delivery-timetable__item\"");

WriteLiteral(">13:00-15:00</li>\r\n                                    <li");

WriteLiteral(" class=\"delivery-timetable__item\"");

WriteLiteral(">15:00-17:00</li>\r\n                                </ul>\r\n                       " +
"     </div>\r\n                        </div>\r\n                        <div");

WriteLiteral(" class=\"delivery-timetable__row js-accordion\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"delivery-timetable__caption js-accordion-trigger\"");

WriteLiteral(">21.05.2021 сб</div>\r\n                            <div");

WriteLiteral(" class=\"delivery-timetable__body js-accordion-body\"");

WriteLiteral(" hidden>\r\n                                <ul");

WriteLiteral(" class=\"delivery-timetable__list\"");

WriteLiteral(">\r\n                                    <li");

WriteLiteral(" class=\"delivery-timetable__item\"");

WriteLiteral(">09:00-11:00</li>\r\n                                    <li");

WriteLiteral(" class=\"delivery-timetable__item\"");

WriteLiteral(">09:00-11:00</li>\r\n                                    <li");

WriteLiteral(" class=\"delivery-timetable__item\"");

WriteLiteral(">13:00-15:00</li>\r\n                                    <li");

WriteLiteral(" class=\"delivery-timetable__item\"");

WriteLiteral(">15:00-17:00</li>\r\n                                </ul>\r\n                       " +
"     </div>\r\n                        </div>\r\n                        <div");

WriteLiteral(" class=\"delivery-timetable__row js-accordion\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"delivery-timetable__caption js-accordion-trigger\"");

WriteLiteral(">21.05.2021 вс</div>\r\n                            <div");

WriteLiteral(" class=\"delivery-timetable__body js-accordion-body\"");

WriteLiteral(" hidden>\r\n                                <ul");

WriteLiteral(" class=\"delivery-timetable__list\"");

WriteLiteral(">\r\n                                    <li");

WriteLiteral(" class=\"delivery-timetable__item\"");

WriteLiteral(">09:00-11:00</li>\r\n                                    <li");

WriteLiteral(" class=\"delivery-timetable__item\"");

WriteLiteral(">09:00-11:00</li>\r\n                                    <li");

WriteLiteral(" class=\"delivery-timetable__item\"");

WriteLiteral(">13:00-15:00</li>\r\n                                    <li");

WriteLiteral(" class=\"delivery-timetable__item\"");

WriteLiteral(">15:00-17:00</li>\r\n                                </ul>\r\n                       " +
"     </div>\r\n                        </div>\r\n                        <div");

WriteLiteral(" class=\"delivery-timetable__row js-accordion\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"delivery-timetable__caption js-accordion-trigger\"");

WriteLiteral(">21.05.2021 пн</div>\r\n                            <div");

WriteLiteral(" class=\"delivery-timetable__body js-accordion-body\"");

WriteLiteral(" hidden>\r\n                                <ul");

WriteLiteral(" class=\"delivery-timetable__list\"");

WriteLiteral(">\r\n                                    <li");

WriteLiteral(" class=\"delivery-timetable__item\"");

WriteLiteral(">09:00-11:00</li>\r\n                                    <li");

WriteLiteral(" class=\"delivery-timetable__item\"");

WriteLiteral(">09:00-11:00</li>\r\n                                    <li");

WriteLiteral(" class=\"delivery-timetable__item\"");

WriteLiteral(">13:00-15:00</li>\r\n                                    <li");

WriteLiteral(" class=\"delivery-timetable__item\"");

WriteLiteral(">15:00-17:00</li>\r\n                                </ul>\r\n                       " +
"     </div>\r\n                        </div>\r\n                        <div");

WriteLiteral(" class=\"delivery-timetable__row js-accordion\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"delivery-timetable__caption js-accordion-trigger\"");

WriteLiteral(">21.05.2021 вт</div>\r\n                            <div");

WriteLiteral(" class=\"delivery-timetable__body js-accordion-body\"");

WriteLiteral(" hidden>\r\n                                <ul");

WriteLiteral(" class=\"delivery-timetable__list\"");

WriteLiteral(">\r\n                                    <li");

WriteLiteral(" class=\"delivery-timetable__item\"");

WriteLiteral(">09:00-11:00</li>\r\n                                    <li");

WriteLiteral(" class=\"delivery-timetable__item\"");

WriteLiteral(">09:00-11:00</li>\r\n                                    <li");

WriteLiteral(" class=\"delivery-timetable__item\"");

WriteLiteral(">13:00-15:00</li>\r\n                                    <li");

WriteLiteral(" class=\"delivery-timetable__item\"");

WriteLiteral(">15:00-17:00</li>\r\n                                </ul>\r\n                       " +
"     </div>\r\n                        </div>\r\n                        <div");

WriteLiteral(" class=\"delivery-timetable__row js-accordion\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"delivery-timetable__caption js-accordion-trigger\"");

WriteLiteral(">21.05.2021 ср</div>\r\n                            <div");

WriteLiteral(" class=\"delivery-timetable__body js-accordion-body\"");

WriteLiteral(" hidden>\r\n                                <ul");

WriteLiteral(" class=\"delivery-timetable__list\"");

WriteLiteral(">\r\n                                    <li");

WriteLiteral(" class=\"delivery-timetable__item\"");

WriteLiteral(">09:00-11:00</li>\r\n                                    <li");

WriteLiteral(" class=\"delivery-timetable__item\"");

WriteLiteral(">09:00-11:00</li>\r\n                                    <li");

WriteLiteral(" class=\"delivery-timetable__item\"");

WriteLiteral(">13:00-15:00</li>\r\n                                    <li");

WriteLiteral(" class=\"delivery-timetable__item\"");

WriteLiteral(">15:00-17:00</li>\r\n                                </ul>\r\n                       " +
"     </div>\r\n                        </div>\r\n                        <div");

WriteLiteral(" class=\"delivery-timetable__row js-accordion\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"delivery-timetable__caption js-accordion-trigger\"");

WriteLiteral(">21.05.2021 чт</div>\r\n                            <div");

WriteLiteral(" class=\"delivery-timetable__body js-accordion-body\"");

WriteLiteral(" hidden>\r\n                                <ul");

WriteLiteral(" class=\"delivery-timetable__list\"");

WriteLiteral(">\r\n                                    <li");

WriteLiteral(" class=\"delivery-timetable__item\"");

WriteLiteral(">09:00-11:00</li>\r\n                                    <li");

WriteLiteral(" class=\"delivery-timetable__item\"");

WriteLiteral(">09:00-11:00</li>\r\n                                    <li");

WriteLiteral(" class=\"delivery-timetable__item\"");

WriteLiteral(">13:00-15:00</li>\r\n                                    <li");

WriteLiteral(" class=\"delivery-timetable__item\"");

WriteLiteral(">15:00-17:00</li>\r\n                                </ul>\r\n                       " +
"     </div>\r\n                        </div>\r\n                        <div");

WriteLiteral(" class=\"delivery-timetable__row js-accordion\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"delivery-timetable__caption js-accordion-trigger\"");

WriteLiteral(">21.05.2021 пт</div>\r\n                            <div");

WriteLiteral(" class=\"delivery-timetable__body js-accordion-body\"");

WriteLiteral(" hidden>\r\n                                <ul");

WriteLiteral(" class=\"delivery-timetable__list\"");

WriteLiteral(">\r\n                                    <li");

WriteLiteral(" class=\"delivery-timetable__item\"");

WriteLiteral(">09:00-11:00</li>\r\n                                    <li");

WriteLiteral(" class=\"delivery-timetable__item\"");

WriteLiteral(">09:00-11:00</li>\r\n                                    <li");

WriteLiteral(" class=\"delivery-timetable__item\"");

WriteLiteral(">13:00-15:00</li>\r\n                                    <li");

WriteLiteral(" class=\"delivery-timetable__item\"");

WriteLiteral(">15:00-17:00</li>\r\n                                </ul>\r\n                       " +
"     </div>\r\n                        </div>\r\n                    </div>\r\n       " +
"         </div><!-- /delivery-timetable-->\r\n            </div>\r\n            <div" +
"");

WriteLiteral(" class=\"delivery-table__bottom\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"delivery-table__bottom-caption\"");

WriteLiteral(">Курьерская доставка</div>\r\n                <div");

WriteLiteral(" class=\"delivery-table__bottom-value\"");

WriteLiteral(">500 р</div>\r\n            </div>\r\n        </div><!-- /delivery-table-->\r\n    </di" +
"v>\r\n</div>");

        }
    }
}
#pragma warning restore 1591
