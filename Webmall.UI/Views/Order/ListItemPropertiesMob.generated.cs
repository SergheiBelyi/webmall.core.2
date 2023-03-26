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
    
    #line 1 "..\..\Views\Order\ListItemPropertiesMob.cshtml"
    using ViewRes;
    
    #line default
    #line hidden
    using Webmall.UI;
    using Webmall.UI.Core.Localization;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Order/ListItemPropertiesMob.cshtml")]
    public partial class _Views_Order_ListItemPropertiesMob_cshtml : System.Web.Mvc.WebViewPage<List<Webmall.Model.Entities.Order.OrderPosition>>
    {
        public _Views_Order_ListItemPropertiesMob_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 4 "..\..\Views\Order\ListItemPropertiesMob.cshtml"
  
    Layout = null;

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 8 "..\..\Views\Order\ListItemPropertiesMob.cshtml"
 if (Model.Any())
{

            
            #line default
            #line hidden
WriteLiteral("    <header");

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

WriteLiteral(" name=\"is-optM-0\"");

WriteLiteral(" id=\"optM-0\"");

WriteLiteral(">\r\n                    <label");

WriteLiteral(" class=\"checkbox-label__main\"");

WriteLiteral(" for=\"optM-0\"");

WriteLiteral("></label>\r\n                </div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"stock-mob-table__cell\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"stock-mob-table__caption\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 20 "..\..\Views\Order\ListItemPropertiesMob.cshtml"
               Write(SharedResources.WareNumber);

            
            #line default
            #line hidden
WriteLiteral(", ");

            
            #line 20 "..\..\Views\Order\ListItemPropertiesMob.cshtml"
                                            Write(SharedResources._brand);

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"stock-mob-table__cell\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"stock-mob-table__caption\"");

WriteLiteral(">");

            
            #line 24 "..\..\Views\Order\ListItemPropertiesMob.cshtml"
                                                 Write(SharedResources.DeliveryDate);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"stock-mob-table__cell\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"stock-mob-table__caption text-center\"");

WriteLiteral(">");

            
            #line 27 "..\..\Views\Order\ListItemPropertiesMob.cshtml"
                                                             Write(SharedResources.Amount);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"stock-mob-table__cell\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"stock-mob-table__caption\"");

WriteLiteral(">");

            
            #line 30 "..\..\Views\Order\ListItemPropertiesMob.cshtml"
                                                 Write(SharedResources.Sum);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"stock-mob-table__cell\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"stock-mob-table__caption\"");

WriteLiteral(">&nbsp;</div>\r\n            </div>\r\n        </div>\r\n    </header>\r\n");

WriteLiteral("    <div");

WriteLiteral(" class=\"stock-mob-table__main\"");

WriteLiteral(">\r\n");

            
            #line 38 "..\..\Views\Order\ListItemPropertiesMob.cshtml"
        
            
            #line default
            #line hidden
            
            #line 38 "..\..\Views\Order\ListItemPropertiesMob.cshtml"
         foreach (var item in Model)
        {
            var wareUrl = Url.Action("WareCard", "Catalog")?.Replace("WareCard", "") + $"{item.ProducerName}/{item.WareNumber}";


            
            #line default
            #line hidden
WriteLiteral("            <div");

WriteLiteral(" class=\"stock-mob-table__row js-accordion\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"stock-mob-table__cell\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"stock-mob-table__checkbox checkbox-label\"");

WriteLiteral(">\r\n                            <input");

WriteLiteral(" class=\"checkbox-label__input js-checked-all-item\"");

WriteLiteral(" type=\"checkbox\"");

WriteAttribute("name", Tuple.Create(" name=\"", 1975), Tuple.Create("\"", 1998)
, Tuple.Create(Tuple.Create("", 1982), Tuple.Create("is-optM-", 1982), true)
            
            #line 45 "..\..\Views\Order\ListItemPropertiesMob.cshtml"
                                   , Tuple.Create(Tuple.Create("", 1990), Tuple.Create<System.Object, System.Int32>(item.Id
            
            #line default
            #line hidden
, 1990), false)
);

WriteAttribute("id", Tuple.Create(" id=\"", 1999), Tuple.Create("\"", 2017)
, Tuple.Create(Tuple.Create("", 2004), Tuple.Create("optM-", 2004), true)
            
            #line 45 "..\..\Views\Order\ListItemPropertiesMob.cshtml"
                                                      , Tuple.Create(Tuple.Create("", 2009), Tuple.Create<System.Object, System.Int32>(item.Id
            
            #line default
            #line hidden
, 2009), false)
);

WriteLiteral(">\r\n                            <label");

WriteLiteral(" class=\"checkbox-label__main\"");

WriteAttribute("for", Tuple.Create(" for=\"", 2084), Tuple.Create("\"", 2103)
, Tuple.Create(Tuple.Create("", 2090), Tuple.Create("optM-", 2090), true)
            
            #line 46 "..\..\Views\Order\ListItemPropertiesMob.cshtml"
, Tuple.Create(Tuple.Create("", 2095), Tuple.Create<System.Object, System.Int32>(item.Id
            
            #line default
            #line hidden
, 2095), false)
);

WriteLiteral("></label>\r\n                        </div>\r\n                    </div>\r\n          " +
"          <div");

WriteLiteral(" class=\"stock-mob-table__cell\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"stock-mob-table__info\"");

WriteLiteral(">\r\n                            <a");

WriteLiteral(" class=\"stock-mob-table__articul\"");

WriteAttribute("href", Tuple.Create(" href=\"", 2356), Tuple.Create("\"", 2371)
            
            #line 51 "..\..\Views\Order\ListItemPropertiesMob.cshtml"
, Tuple.Create(Tuple.Create("", 2363), Tuple.Create<System.Object, System.Int32>(wareUrl
            
            #line default
            #line hidden
, 2363), false)
);

WriteLiteral(">");

            
            #line 51 "..\..\Views\Order\ListItemPropertiesMob.cshtml"
                                                                           Write(item.WareNumber);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                            <div");

WriteLiteral(" class=\"stock-mob-table__heading\"");

WriteLiteral(">\r\n                                <a");

WriteLiteral(" class=\"stock-mob-table__heading-link\"");

WriteAttribute("href", Tuple.Create(" href=\"", 2535), Tuple.Create("\"", 2550)
            
            #line 53 "..\..\Views\Order\ListItemPropertiesMob.cshtml"
, Tuple.Create(Tuple.Create("", 2542), Tuple.Create<System.Object, System.Int32>(wareUrl
            
            #line default
            #line hidden
, 2542), false)
);

WriteLiteral(">");

            
            #line 53 "..\..\Views\Order\ListItemPropertiesMob.cshtml"
                                                                                    Write(item.ProducerName);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                            </div>\r\n                        </div>\r\n       " +
"             </div>\r\n                    <div");

WriteLiteral(" class=\"stock-mob-table__cell\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"stock-mob-table__text\"");

WriteLiteral(">");

            
            #line 58 "..\..\Views\Order\ListItemPropertiesMob.cshtml"
                                                      Write(item.DeliveryPresentation);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                    </div>\r\n                    <div");

WriteLiteral(" class=\"stock-mob-table__cell text-center\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"stock-mob-table__text\"");

WriteLiteral(">");

            
            #line 61 "..\..\Views\Order\ListItemPropertiesMob.cshtml"
                                                      Write(item.WareQnt);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                    </div>\r\n                    <div");

WriteLiteral(" class=\"stock-mob-table__cell\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"stock-mob-table__prices\"");

WriteLiteral(">\r\n                            <strong");

WriteLiteral(" class=\"stock-mob-table__price-primary\"");

WriteLiteral(">");

            
            #line 65 "..\..\Views\Order\ListItemPropertiesMob.cshtml"
                                                                      Write(item.Sum);

            
            #line default
            #line hidden
WriteLiteral("</strong>\r\n                            ");

WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                   " +
" <div");

WriteLiteral(" class=\"stock-mob-table__cell\"");

WriteLiteral(">\r\n                        <button");

WriteLiteral(" class=\"stock-mob-table__mob-toggle js-accordion-trigger\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(">\r\n                            <svg");

WriteLiteral(" class=\"icon icon-chevron-down stock-mob-table__mob-toggle-icon\"");

WriteLiteral(" width=\"25\"");

WriteLiteral(" height=\"25\"");

WriteLiteral(">\r\n                                <use");

WriteAttribute("href", Tuple.Create(" href=\"", 3717), Tuple.Create("\"", 3790)
            
            #line 72 "..\..\Views\Order\ListItemPropertiesMob.cshtml"
, Tuple.Create(Tuple.Create("", 3724), Tuple.Create<System.Object, System.Int32>(Url.Content("~/assets/images/svg/symbol/sprite.svg#chevron-down")
            
            #line default
            #line hidden
, 3724), false)
);

WriteLiteral("></use>\r\n                            </svg>\r\n                        </button>\r\n " +
"                   </div>\r\n                    <div");

WriteLiteral(" class=\"stock-mob-table__dropdown js-accordion-body\"");

WriteLiteral(" hidden=\"\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"stock-mob-table__params\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"stock-mob-table__param\"");

WriteLiteral(">\r\n                                <dt");

WriteLiteral(" class=\"stock-mob-table__property\"");

WriteLiteral(">");

            
            #line 79 "..\..\Views\Order\ListItemPropertiesMob.cshtml"
                                                                 Write(SharedResources.Name);

            
            #line default
            #line hidden
WriteLiteral("</dt>\r\n                                <dd");

WriteLiteral(" class=\"stock-mob-table__value\"");

WriteLiteral(">");

            
            #line 80 "..\..\Views\Order\ListItemPropertiesMob.cshtml"
                                                              Write(item.WareName);

            
            #line default
            #line hidden
WriteLiteral("</dd>\r\n                            </div>\r\n                            <div");

WriteLiteral(" class=\"stock-mob-table__param\"");

WriteLiteral(">\r\n                                <dt");

WriteLiteral(" class=\"stock-mob-table__property\"");

WriteLiteral(">");

            
            #line 83 "..\..\Views\Order\ListItemPropertiesMob.cshtml"
                                                                 Write(SharedResources.PricePerOne);

            
            #line default
            #line hidden
WriteLiteral("</dt>\r\n                                <dd");

WriteLiteral(" class=\"stock-mob-table__value\"");

WriteLiteral(">");

            
            #line 84 "..\..\Views\Order\ListItemPropertiesMob.cshtml"
                                                              Write(item.Price);

            
            #line default
            #line hidden
WriteLiteral("</dd>\r\n                            </div>\r\n                            <div");

WriteLiteral(" class=\"stock-mob-table__param is-centered\"");

WriteLiteral(">\r\n                                <dt");

WriteLiteral(" class=\"stock-mob-table__property\"");

WriteLiteral(">");

            
            #line 87 "..\..\Views\Order\ListItemPropertiesMob.cshtml"
                                                                 Write(SharedResources.Status);

            
            #line default
            #line hidden
WriteLiteral("</dt>\r\n                                <dd");

WriteLiteral(" class=\"stock-mob-table__value\"");

WriteLiteral(">\r\n                                    <div");

WriteLiteral(" class=\"stock-mob-table__status status-badge is-active\"");

WriteLiteral(">");

            
            #line 89 "..\..\Views\Order\ListItemPropertiesMob.cshtml"
                                                                                           Write(item.StatusName);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                                </dd>\r\n                            </div>" +
"\r\n\r\n                            <div");

WriteLiteral(" class=\"stock-mob-table__param\"");

WriteLiteral(">\r\n                                <dt");

WriteLiteral(" class=\"stock-mob-table__property\"");

WriteLiteral(">");

            
            #line 94 "..\..\Views\Order\ListItemPropertiesMob.cshtml"
                                                                 Write(SharedResources.Note);

            
            #line default
            #line hidden
WriteLiteral("</dt>\r\n                                <dd");

WriteLiteral(" class=\"stock-mob-table__value\"");

WriteLiteral(">");

            
            #line 95 "..\..\Views\Order\ListItemPropertiesMob.cshtml"
                                                              Write(item.Comment);

            
            #line default
            #line hidden
WriteLiteral("</dd>\r\n                            </div>\r\n                        </div>\r\n      " +
"              </div>\r\n            </div>\r\n");

            
            #line 100 "..\..\Views\Order\ListItemPropertiesMob.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("    </div>\r\n");

            
            #line 102 "..\..\Views\Order\ListItemPropertiesMob.cshtml"
}
else
{

            
            #line default
            #line hidden
WriteLiteral("    <div>");

            
            #line 105 "..\..\Views\Order\ListItemPropertiesMob.cshtml"
    Write(SharedResources.NoData);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");

            
            #line 106 "..\..\Views\Order\ListItemPropertiesMob.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\r\n");

        }
    }
}
#pragma warning restore 1591