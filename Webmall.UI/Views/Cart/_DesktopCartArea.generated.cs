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
    
    #line 1 "..\..\Views\Cart\_DesktopCartArea.cshtml"
    using ViewRes;
    
    #line default
    #line hidden
    using Webmall.UI;
    
    #line 2 "..\..\Views\Cart\_DesktopCartArea.cshtml"
    using Webmall.UI.Core;
    
    #line default
    #line hidden
    using Webmall.UI.Core.Localization;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Cart/_DesktopCartArea.cshtml")]
    public partial class _Views_Cart__DesktopCartArea_cshtml : System.Web.Mvc.WebViewPage<Webmall.UI.Models.Cart.CartModel>
    {
        public _Views_Cart__DesktopCartArea_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 5 "..\..\Views\Cart\_DesktopCartArea.cshtml"
   var rate = SessionHelper.CurrentValute.Rate; 
            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<!-- stock-table-->\r\n<div");

WriteLiteral(" class=\"stock-area__table\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"stock-table stock-area__table-main js-checked-all scrollbar\"");

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

WriteLiteral(" checked=\"checked\"");

WriteLiteral(" name=\"is-opt-0\"");

WriteLiteral(" id=\"opt-0\"");

WriteLiteral(">\r\n                        <label");

WriteLiteral(" class=\"checkbox-label__main\"");

WriteLiteral(" for=\"opt-0\"");

WriteLiteral("></label>\r\n                    </div>\r\n                </div>\r\n                <d" +
"iv");

WriteLiteral(" class=\"stock-table__cell\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"stock-table__caption\"");

WriteLiteral(">");

            
            #line 19 "..\..\Views\Cart\_DesktopCartArea.cshtml"
                                                 Write(SharedResources.AddTime);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"stock-table__cell\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"stock-table__caption\"");

WriteLiteral(">");

            
            #line 22 "..\..\Views\Cart\_DesktopCartArea.cshtml"
                                                 Write(SharedResources.PartNumber);

            
            #line default
            #line hidden
WriteLiteral(", ");

            
            #line 22 "..\..\Views\Cart\_DesktopCartArea.cshtml"
                                                                              Write(SharedResources.Brand);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"stock-table__cell\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"stock-table__caption\"");

WriteLiteral(">");

            
            #line 25 "..\..\Views\Cart\_DesktopCartArea.cshtml"
                                                 Write(SharedResources.Name);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"stock-table__cell text-center\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"stock-table__caption\"");

WriteLiteral(">");

            
            #line 28 "..\..\Views\Cart\_DesktopCartArea.cshtml"
                                                 Write(SharedResources.Note);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"stock-table__cell text-center\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"stock-table__caption\"");

WriteLiteral(">");

            
            #line 31 "..\..\Views\Cart\_DesktopCartArea.cshtml"
                                                 Write(SharedResources.Presence);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"stock-table__cell\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"stock-table__caption\"");

WriteLiteral(">");

            
            #line 34 "..\..\Views\Cart\_DesktopCartArea.cshtml"
                                                 Write(SharedResources.Stock);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"stock-table__cell text-center\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"stock-table__caption\"");

WriteLiteral(">");

            
            #line 37 "..\..\Views\Cart\_DesktopCartArea.cshtml"
                                                 Write(SharedResources.DeliveryDate);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"stock-table__cell text-center\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"stock-table__caption\"");

WriteLiteral(">");

            
            #line 40 "..\..\Views\Cart\_DesktopCartArea.cshtml"
                                                 Write(SharedResources.ReturnPeriod);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"stock-table__cell text-center\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"stock-table__caption\"");

WriteLiteral(">");

            
            #line 43 "..\..\Views\Cart\_DesktopCartArea.cshtml"
                                                 Write(SharedResources.PricePerOne);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"stock-table__cell text-center\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"stock-table__caption\"");

WriteLiteral(">");

            
            #line 46 "..\..\Views\Cart\_DesktopCartArea.cshtml"
                                                 Write(SharedResources.Amount);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"stock-table__cell text-center\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"stock-table__caption\"");

WriteLiteral(">");

            
            #line 49 "..\..\Views\Cart\_DesktopCartArea.cshtml"
                                                 Write(SharedResources.Sum);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"stock-table__cell text-center\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"stock-table__caption\"");

WriteLiteral(">&nbsp;</div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    <d" +
"iv");

WriteLiteral(" class=\"stock-table__main\"");

WriteLiteral(">\r\n");

            
            #line 57 "..\..\Views\Cart\_DesktopCartArea.cshtml"
    
            
            #line default
            #line hidden
            
            #line 57 "..\..\Views\Cart\_DesktopCartArea.cshtml"
     foreach (var item in Model.Positions.List)
    {
        var wareUrl = item.Url;
        //var wareUrl =  Url.Action("WareIndex", "Catalog", new { group = Request.QueryString["group"], id = item.WareId, returnUrl = Request.Url });
        var deliveryRatingClass = (item.DeliveryRating >= 90) ? "is-success" : (item.DeliveryRating >= 50) ? "is-warning" : "is-danger";
                
            
            #line default
            #line hidden
            
            #line 72 "..\..\Views\Cart\_DesktopCartArea.cshtml"
                  


            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\"stock-table__row\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"stock-table__cell text-center\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"stock-table__checkbox checkbox-label\"");

WriteLiteral(">\r\n                    <input");

WriteLiteral(" class=\"checkbox-label__input js-checked-all-item\"");

WriteLiteral(" type=\"checkbox\"");

WriteAttribute("value", Tuple.Create(" value=\"", 4115), Tuple.Create("\"", 4131)
            
            #line 77 "..\..\Views\Cart\_DesktopCartArea.cshtml"
                    , Tuple.Create(Tuple.Create("", 4123), Tuple.Create<System.Object, System.Int32>(item.Id
            
            #line default
            #line hidden
, 4123), false)
);

WriteLiteral(" name=\"selected\"");

WriteAttribute("id", Tuple.Create(" id=\"", 4148), Tuple.Create("\"", 4165)
, Tuple.Create(Tuple.Create("", 4153), Tuple.Create("opt-", 4153), true)
            
            #line 77 "..\..\Views\Cart\_DesktopCartArea.cshtml"
                                                      , Tuple.Create(Tuple.Create("", 4157), Tuple.Create<System.Object, System.Int32>(item.Id
            
            #line default
            #line hidden
, 4157), false)
);

WriteLiteral(" checked=\"checked\"");

WriteLiteral(">\r\n                    <label");

WriteLiteral(" class=\"checkbox-label__main\"");

WriteAttribute("for", Tuple.Create(" for=\"", 4242), Tuple.Create("\"", 4260)
, Tuple.Create(Tuple.Create("", 4248), Tuple.Create("opt-", 4248), true)
            
            #line 78 "..\..\Views\Cart\_DesktopCartArea.cshtml"
, Tuple.Create(Tuple.Create("", 4252), Tuple.Create<System.Object, System.Int32>(item.Id
            
            #line default
            #line hidden
, 4252), false)
);

WriteLiteral("></label>\r\n                </div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"stock-table__cell\"");

WriteLiteral(">\r\n                <time");

WriteLiteral(" class=\"stock-table__date\"");

WriteAttribute("datetime", Tuple.Create(" datetime=\"", 4408), Tuple.Create("\"", 4454)
            
            #line 82 "..\..\Views\Cart\_DesktopCartArea.cshtml"
, Tuple.Create(Tuple.Create("", 4419), Tuple.Create<System.Object, System.Int32>(item.CreationDate.ToString("yyyy")
            
            #line default
            #line hidden
, 4419), false)
);

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 83 "..\..\Views\Cart\_DesktopCartArea.cshtml"
               Write(item.CreationDate.ToString("dd.MM.yyyy"));

            
            #line default
            #line hidden
WriteLiteral(" <span>");

            
            #line 83 "..\..\Views\Cart\_DesktopCartArea.cshtml"
                                                               Write(item.CreationDate.ToString("HH:mm"));

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                </time>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"stock-table__cell\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"stock-table__meta\"");

WriteLiteral(">\r\n                    <a");

WriteLiteral(" class=\"stock-table__articul\"");

WriteAttribute("href", Tuple.Create(" href=\"", 4761), Tuple.Create("\"", 4776)
            
            #line 88 "..\..\Views\Cart\_DesktopCartArea.cshtml"
, Tuple.Create(Tuple.Create("", 4768), Tuple.Create<System.Object, System.Int32>(wareUrl
            
            #line default
            #line hidden
, 4768), false)
);

WriteLiteral(">");

            
            #line 88 "..\..\Views\Cart\_DesktopCartArea.cshtml"
                                                               Write(item.WareNum);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                    <a");

WriteLiteral(" class=\"stock-table__brand\"");

WriteAttribute("href", Tuple.Create(" href=\"", 4846), Tuple.Create("\"", 4861)
            
            #line 89 "..\..\Views\Cart\_DesktopCartArea.cshtml"
, Tuple.Create(Tuple.Create("", 4853), Tuple.Create<System.Object, System.Int32>(wareUrl
            
            #line default
            #line hidden
, 4853), false)
);

WriteLiteral(">");

            
            #line 89 "..\..\Views\Cart\_DesktopCartArea.cshtml"
                                                             Write(item.ProducerName);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                </div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"stock-table__cell\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"stock-table__heading\"");

WriteLiteral(">\r\n                    <a");

WriteLiteral(" class=\"stock-table__heading-link\"");

WriteAttribute("href", Tuple.Create(" href=\"", 5084), Tuple.Create("\"", 5099)
            
            #line 94 "..\..\Views\Cart\_DesktopCartArea.cshtml"
, Tuple.Create(Tuple.Create("", 5091), Tuple.Create<System.Object, System.Int32>(wareUrl
            
            #line default
            #line hidden
, 5091), false)
);

WriteLiteral(">");

            
            #line 94 "..\..\Views\Cart\_DesktopCartArea.cshtml"
                                                                    Write(item.WareName);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                </div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"stock-table__cell\"");

WriteLiteral(">\r\n");

            
            #line 98 "..\..\Views\Cart\_DesktopCartArea.cshtml"
                
            
            #line default
            #line hidden
            
            #line 98 "..\..\Views\Cart\_DesktopCartArea.cshtml"
                 if (!string.IsNullOrEmpty(item.Comment))
                {

            
            #line default
            #line hidden
WriteLiteral("                    <div");

WriteLiteral(" class=\"stock-table__comment custom-comment\"");

WriteLiteral(" data-modal-win-trigger=\"comment-edit\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 5394), Tuple.Create("\"", 5437)
, Tuple.Create(Tuple.Create("", 5404), Tuple.Create("CartEditPositionComment(", 5404), true)
            
            #line 100 "..\..\Views\Cart\_DesktopCartArea.cshtml"
                                                            , Tuple.Create(Tuple.Create("", 5428), Tuple.Create<System.Object, System.Int32>(item.Id
            
            #line default
            #line hidden
, 5428), false)
, Tuple.Create(Tuple.Create("", 5436), Tuple.Create(")", 5436), true)
);

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"custom-comment__badge badge\"");

WriteLiteral(">\r\n                            <svg");

WriteLiteral(" class=\"icon icon-pen badge__icon\"");

WriteLiteral(" width=\"25\"");

WriteLiteral(" height=\"25\"");

WriteLiteral(">\r\n                                <use");

WriteAttribute("href", Tuple.Create(" href=\"", 5636), Tuple.Create("\"", 5700)
            
            #line 103 "..\..\Views\Cart\_DesktopCartArea.cshtml"
, Tuple.Create(Tuple.Create("", 5643), Tuple.Create<System.Object, System.Int32>(Url.Content("~/assets/images/svg/symbol/sprite.svg#pen")
            
            #line default
            #line hidden
, 5643), false)
);

WriteLiteral("></use>\r\n                            </svg>\r\n                        </div>\r\n    " +
"                    <div");

WriteLiteral(" class=\"custom-comment__text\"");

WriteAttribute("id", Tuple.Create(" id=\"", 5835), Tuple.Create("\"", 5856)
, Tuple.Create(Tuple.Create("", 5840), Tuple.Create("comment_", 5840), true)
            
            #line 106 "..\..\Views\Cart\_DesktopCartArea.cshtml"
, Tuple.Create(Tuple.Create("", 5848), Tuple.Create<System.Object, System.Int32>(item.Id
            
            #line default
            #line hidden
, 5848), false)
);

WriteLiteral(">");

            
            #line 106 "..\..\Views\Cart\_DesktopCartArea.cshtml"
                                                                           Write(item.Comment);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                    </div>\r\n");

            
            #line 108 "..\..\Views\Cart\_DesktopCartArea.cshtml"
                }
                else
                {

            
            #line default
            #line hidden
WriteLiteral("                    <div");

WriteLiteral(" class=\"stock-table__comment custom-comment\"");

WriteLiteral(" data-modal-win-trigger=\"comment-add\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 6072), Tuple.Create("\"", 6120)
, Tuple.Create(Tuple.Create("", 6082), Tuple.Create("CartAddPositionComment(", 6082), true)
            
            #line 111 "..\..\Views\Cart\_DesktopCartArea.cshtml"
                                                          , Tuple.Create(Tuple.Create("", 6105), Tuple.Create<System.Object, System.Int32>(item.Id
            
            #line default
            #line hidden
, 6105), false)
, Tuple.Create(Tuple.Create("", 6113), Tuple.Create(",", 6113), true)
, Tuple.Create(Tuple.Create(" ", 6114), Tuple.Create("this)", 6115), true)
);

WriteLiteral(">\r\n                        <svg");

WriteLiteral(" class=\"icon icon-comment custom-comment__icon\"");

WriteLiteral(" width=\"25\"");

WriteLiteral(" height=\"25\"");

WriteLiteral(">\r\n                            <use");

WriteAttribute("href", Tuple.Create(" href=\"", 6257), Tuple.Create("\"", 6325)
            
            #line 113 "..\..\Views\Cart\_DesktopCartArea.cshtml"
, Tuple.Create(Tuple.Create("", 6264), Tuple.Create<System.Object, System.Int32>(Url.Content("~/assets/images/svg/symbol/sprite.svg#comment")
            
            #line default
            #line hidden
, 6264), false)
);

WriteLiteral("></use>\r\n                        </svg>\r\n                    </div>\r\n");

            
            #line 116 "..\..\Views\Cart\_DesktopCartArea.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"stock-table__cell text-center\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"stock-table__text\"");

WriteLiteral(">");

            
            #line 120 "..\..\Views\Cart\_DesktopCartArea.cshtml"
                                          Write(item.AvailableQntStr);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"stock-table__cell\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"stock-table__stock\"");

WriteLiteral(">\r\n                    <div");

WriteAttribute("class", Tuple.Create(" class=\"", 6708), Tuple.Create("\"", 6773)
, Tuple.Create(Tuple.Create("", 6716), Tuple.Create("stock-table__progress", 6716), true)
, Tuple.Create(Tuple.Create(" ", 6737), Tuple.Create("progress-badge", 6738), true)
            
            #line 124 "..\..\Views\Cart\_DesktopCartArea.cshtml"
, Tuple.Create(Tuple.Create(" ", 6752), Tuple.Create<System.Object, System.Int32>(deliveryRatingClass
            
            #line default
            #line hidden
, 6753), false)
);

WriteLiteral(" data-tippy-gray-content=\"");

            
            #line 124 "..\..\Views\Cart\_DesktopCartArea.cshtml"
                                                                                                               Write(SharedResources.DeliveryProbability);

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(">");

            
            #line 124 "..\..\Views\Cart\_DesktopCartArea.cshtml"
                                                                                                                                                     Write(item.DeliveryRating);

            
            #line default
            #line hidden
WriteLiteral("%</div>");

            
            #line 124 "..\..\Views\Cart\_DesktopCartArea.cshtml"
                                                                                                                                                                                Write(item.WarehouseName);

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"stock-table__cell text-center\"");

WriteLiteral(">\r\n                <time");

WriteLiteral(" class=\"stock-table__accent\"");

WriteAttribute("datetime", Tuple.Create(" datetime=\"", 7036), Tuple.Create("\"", 7085)
            
            #line 128 "..\..\Views\Cart\_DesktopCartArea.cshtml"
, Tuple.Create(Tuple.Create("", 7047), Tuple.Create<System.Object, System.Int32>(item.DeliveryTerm?.ToString("yyyy")
            
            #line default
            #line hidden
, 7047), false)
);

WriteLiteral(" data-tippy-gray-content=\"");

            
            #line 128 "..\..\Views\Cart\_DesktopCartArea.cshtml"
                                                                                                                        Write(SharedResources.TermDays);

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(">");

            
            #line 128 "..\..\Views\Cart\_DesktopCartArea.cshtml"
                                                                                                                                                   Write(item.DeliveryTermAsString);

            
            #line default
            #line hidden
WriteLiteral("</time>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"stock-table__cell text-center\"");

WriteLiteral(">\r\n");

            
            #line 131 "..\..\Views\Cart\_DesktopCartArea.cshtml"
                
            
            #line default
            #line hidden
            
            #line 131 "..\..\Views\Cart\_DesktopCartArea.cshtml"
                 if (item.IsReturnAllowed)
                {

            
            #line default
            #line hidden
WriteLiteral("                    <div");

WriteLiteral(" class=\"stock-table__text\"");

WriteLiteral(">");

            
            #line 133 "..\..\Views\Cart\_DesktopCartArea.cshtml"
                                              Write(item.ReturnDays);

            
            #line default
            #line hidden
WriteLiteral(" ");

            
            #line 133 "..\..\Views\Cart\_DesktopCartArea.cshtml"
                                                               Write(SharedResources.days);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");

            
            #line 134 "..\..\Views\Cart\_DesktopCartArea.cshtml"
                }
                else
                {

            
            #line default
            #line hidden
WriteLiteral("                    <div");

WriteLiteral(" class=\"stock-table__text is-error\"");

WriteLiteral(" data-tippy-gray-content=\"");

            
            #line 137 "..\..\Views\Cart\_DesktopCartArea.cshtml"
                                                                                Write(SharedResources.NonRefundable);

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(">\r\n                        <svg");

WriteLiteral(" class=\"icon icon-close stock-table__text-icon\"");

WriteLiteral(" width=\"25\"");

WriteLiteral(" height=\"25\"");

WriteLiteral(">\r\n                            <use");

WriteAttribute("href", Tuple.Create(" href=\"", 7723), Tuple.Create("\"", 7789)
            
            #line 139 "..\..\Views\Cart\_DesktopCartArea.cshtml"
, Tuple.Create(Tuple.Create("", 7730), Tuple.Create<System.Object, System.Int32>(Url.Content("~/assets/images/svg/symbol/sprite.svg#close")
            
            #line default
            #line hidden
, 7730), false)
);

WriteLiteral("></use>\r\n                        </svg>\r\n                    </div>\r\n");

            
            #line 142 "..\..\Views\Cart\_DesktopCartArea.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"stock-table__cell text-center\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"stock-table__text\"");

WriteLiteral(" data-tippy-gray-content=\"");

            
            #line 146 "..\..\Views\Cart\_DesktopCartArea.cshtml"
                                                                   Write(SharedResources.PurchasePriceForOneUnit);

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(">");

            
            #line 146 "..\..\Views\Cart\_DesktopCartArea.cshtml"
                                                                                                             Write(SessionHelper.PriceFormat(item.ClientPrice));

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"stock-table__cell\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"counter stock-table__counter\"");

WriteLiteral(" data-tippy-gray-content=\"");

            
            #line 149 "..\..\Views\Cart\_DesktopCartArea.cshtml"
                                                                              Write(SharedResources.SaleMultiplisity);

            
            #line default
            #line hidden
WriteLiteral(" = ");

            
            #line 149 "..\..\Views\Cart\_DesktopCartArea.cshtml"
                                                                                                                  Write(item.SaleQnt);

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(">\r\n                    <button");

WriteLiteral(" class=\"counter__btn counter__btn--remove\"");

WriteLiteral(" data-action=\"remove\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(">\r\n                        <svg");

WriteLiteral(" class=\"icon icon-minus counter__btn-icon\"");

WriteLiteral(" width=\"25\"");

WriteLiteral(" height=\"25\"");

WriteLiteral(">\r\n                            <use");

WriteAttribute("href", Tuple.Create(" href=\"", 8559), Tuple.Create("\"", 8625)
            
            #line 152 "..\..\Views\Cart\_DesktopCartArea.cshtml"
, Tuple.Create(Tuple.Create("", 8566), Tuple.Create<System.Object, System.Int32>(Url.Content("~/assets/images/svg/symbol/sprite.svg#minus")
            
            #line default
            #line hidden
, 8566), false)
);

WriteLiteral("></use>\r\n                        </svg>\r\n                    </button>\r\n         " +
"           <input");

WriteAttribute("id", Tuple.Create(" id=\"", 8724), Tuple.Create("\"", 8745)
, Tuple.Create(Tuple.Create("", 8729), Tuple.Create("inp-qnt-", 8729), true)
            
            #line 155 "..\..\Views\Cart\_DesktopCartArea.cshtml"
, Tuple.Create(Tuple.Create("", 8737), Tuple.Create<System.Object, System.Int32>(item.Id
            
            #line default
            #line hidden
, 8737), false)
);

WriteLiteral(" class=\"counter__input input\"");

WriteLiteral(" type=\"tel\"");

WriteLiteral(" name=\"quantity\"");

WriteLiteral(" maxlength=\"3\"");

WriteLiteral(" readonly");

WriteAttribute("value", Tuple.Create(" value=\"", 8825), Tuple.Create("\"", 8855)
            
            #line 155 "..\..\Views\Cart\_DesktopCartArea.cshtml"
                                                        , Tuple.Create(Tuple.Create("", 8833), Tuple.Create<System.Object, System.Int32>($"{item.WareQnt:0}"
            
            #line default
            #line hidden
, 8833), false)
);

WriteAttribute("onchange", Tuple.Create("\r\n                           onchange=\"", 8856), Tuple.Create("\"", 8927)
, Tuple.Create(Tuple.Create("", 8895), Tuple.Create("UpdatePosition(this,", 8895), true)
            
            #line 156 "..\..\Views\Cart\_DesktopCartArea.cshtml"
, Tuple.Create(Tuple.Create(" ", 8915), Tuple.Create<System.Object, System.Int32>(item.Id
            
            #line default
            #line hidden
, 8916), false)
, Tuple.Create(Tuple.Create("", 8926), Tuple.Create(")", 8926), true)
);

WriteAttribute("onkeypress", Tuple.Create(" onkeypress=\"", 8928), Tuple.Create("\"", 8975)
, Tuple.Create(Tuple.Create("", 8941), Tuple.Create("return", 8941), true)
, Tuple.Create(Tuple.Create(" ", 8947), Tuple.Create("JumpNext(event,", 8948), true)
            
            #line 156 "..\..\Views\Cart\_DesktopCartArea.cshtml"
                          , Tuple.Create(Tuple.Create(" ", 8963), Tuple.Create<System.Object, System.Int32>(item.Id
            
            #line default
            #line hidden
, 8964), false)
, Tuple.Create(Tuple.Create("", 8974), Tuple.Create(")", 8974), true)
);

WriteLiteral(">\r\n                    <button");

WriteLiteral(" class=\"counter__btn counter__btn--add\"");

WriteLiteral(" data-action=\"add\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(">\r\n                        <svg");

WriteLiteral(" class=\"icon icon-plus counter__btn-icon\"");

WriteLiteral(" width=\"25\"");

WriteLiteral(" height=\"25\"");

WriteLiteral(">\r\n                            <use");

WriteAttribute("href", Tuple.Create(" href=\"", 9207), Tuple.Create("\"", 9272)
            
            #line 159 "..\..\Views\Cart\_DesktopCartArea.cshtml"
, Tuple.Create(Tuple.Create("", 9214), Tuple.Create<System.Object, System.Int32>(Url.Content("~/assets/images/svg/symbol/sprite.svg#plus")
            
            #line default
            #line hidden
, 9214), false)
);

WriteLiteral("></use>\r\n                        </svg>\r\n                    </button>\r\n");

WriteLiteral("                    ");

            
            #line 162 "..\..\Views\Cart\_DesktopCartArea.cshtml"
               Write(Html.Hidden($"WareQntOld{item.Id}", $"{item.WareQnt:0}"));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"stock-table__cell text-center\"");

WriteLiteral(">\r\n                <strong");

WriteLiteral(" class=\"stock-table__text cart-sum\"");

WriteAttribute("id", Tuple.Create(" id=\"", 9583), Tuple.Create("\"", 9606)
, Tuple.Create(Tuple.Create("", 9588), Tuple.Create("position", 9588), true)
            
            #line 166 "..\..\Views\Cart\_DesktopCartArea.cshtml"
, Tuple.Create(Tuple.Create("", 9596), Tuple.Create<System.Object, System.Int32>(item.Id
            
            #line default
            #line hidden
, 9596), false)
);

WriteLiteral(">");

            
            #line 166 "..\..\Views\Cart\_DesktopCartArea.cshtml"
                                                                              Write(SessionHelper.PriceFormat(new Decimal(Math.Round((double)(item.ClientPrice / rate), 2)) * item.WareQnt));

            
            #line default
            #line hidden
WriteLiteral("</strong>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"stock-table__cell text-center\"");

WriteLiteral(">\r\n                <a");

WriteLiteral(" class=\"stock-table__remove\"");

WriteLiteral(" data-tippy-gray-content=\"");

            
            #line 169 "..\..\Views\Cart\_DesktopCartArea.cshtml"
                                                                   Write(SharedResources.Delete);

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 9896), Tuple.Create("\"", 9947)
, Tuple.Create(Tuple.Create("", 9906), Tuple.Create("return", 9906), true)
, Tuple.Create(Tuple.Create(" ", 9912), Tuple.Create("RemoveCartPosition(this,", 9913), true)
            
            #line 169 "..\..\Views\Cart\_DesktopCartArea.cshtml"
                                                         , Tuple.Create(Tuple.Create(" ", 9937), Tuple.Create<System.Object, System.Int32>(item.Id
            
            #line default
            #line hidden
, 9938), false)
, Tuple.Create(Tuple.Create("", 9946), Tuple.Create(")", 9946), true)
);

WriteLiteral(">\r\n                    <svg");

WriteLiteral(" class=\"icon icon-close stock-table__remove-icon\"");

WriteLiteral(" width=\"25\"");

WriteLiteral(" height=\"25\"");

WriteLiteral(">\r\n                        <use");

WriteAttribute("href", Tuple.Create(" href=\"", 10078), Tuple.Create("\"", 10144)
            
            #line 171 "..\..\Views\Cart\_DesktopCartArea.cshtml"
, Tuple.Create(Tuple.Create("", 10085), Tuple.Create<System.Object, System.Int32>(Url.Content("~/assets/images/svg/symbol/sprite.svg#close")
            
            #line default
            #line hidden
, 10085), false)
);

WriteLiteral("></use>\r\n                    </svg>\r\n                </a>\r\n            </div>\r\n  " +
"      </div>\r\n");

            
            #line 176 "..\..\Views\Cart\_DesktopCartArea.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("    ");

WriteLiteral("\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"stock-table__bottom\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"stock-table__row\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"stock-table__summary\"");

WriteLiteral(">\r\n                    ");

WriteLiteral("\r\n                    <div");

WriteLiteral(" class=\"stock-table__summary-total\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 566 "..\..\Views\Cart\_DesktopCartArea.cshtml"
                   Write(SharedResources.Quantity);

            
            #line default
            #line hidden
WriteLiteral(": <strong");

WriteLiteral(" id=\"totalQnt\"");

WriteLiteral("></strong> <strong>");

            
            #line 566 "..\..\Views\Cart\_DesktopCartArea.cshtml"
                                                                                      Write(SharedResources.Things);

            
            #line default
            #line hidden
WriteLiteral(".</strong> / ");

            
            #line 566 "..\..\Views\Cart\_DesktopCartArea.cshtml"
                                                                                                                          Write(SharedResources.TotalSelectedSum);

            
            #line default
            #line hidden
WriteLiteral(":<strong> <span");

WriteLiteral(" id=\"totalSelectedSum\"");

WriteLiteral("></span> <span>");

            
            #line 566 "..\..\Views\Cart\_DesktopCartArea.cshtml"
                                                                                                                                                                                                               Write(Model.ValuteName);

            
            #line default
            #line hidden
WriteLiteral("</span></strong>\r\n                    </div>\r\n                </div>\r\n           " +
" </div>\r\n        </div>\r\n    </div>\r\n</div><!-- /stock-table-->");

        }
    }
}
#pragma warning restore 1591
