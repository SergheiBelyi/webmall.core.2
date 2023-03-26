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
    
    #line 2 "..\..\Views\Catalog\WareCard.cshtml"
    using ViewRes;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Views\Catalog\WareCard.cshtml"
    using Webmall.Model.CoreHelpers;
    
    #line default
    #line hidden
    using Webmall.UI;
    
    #line 1 "..\..\Views\Catalog\WareCard.cshtml"
    using Webmall.UI.Core.HtmlHelpers;
    
    #line default
    #line hidden
    using Webmall.UI.Core.Localization;
    
    #line 4 "..\..\Views\Catalog\WareCard.cshtml"
    using Webmall.UI.ViewModel.Catalog;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Catalog/WareCard.cshtml")]
    public partial class _Views_Catalog_WareCard_cshtml : System.Web.Mvc.WebViewPage<Webmall.UI.ViewModel.Catalog.WareCardViewModel>
    {
        public _Views_Catalog_WareCard_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 7 "..\..\Views\Catalog\WareCard.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";
    var product = Model.Ware;
    var skeletonClass = "skeleton skeleton-rect";
    var skeletonStyle  = "--lines:4;--c-w:100%;opacity: 0.6;--l-h:7px;--l-gap:10px;rect-h:100px;";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteLiteral(" class=\"container-fluid\"");

WriteLiteral(">\r\n");

            
            #line 15 "..\..\Views\Catalog\WareCard.cshtml"
    
            
            #line default
            #line hidden
            
            #line 15 "..\..\Views\Catalog\WareCard.cshtml"
      Html.RenderPartial("Components/BreadCrumbsRender", Model.BreadCrumbs);
            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n    <section");

WriteLiteral(" class=\"product-detail-section js-accordion is-active\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"product-detail-section__header js-accordion-trigger\"");

WriteLiteral(" id=\"info-header\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"product-detail-section__heading\"");

WriteLiteral(">");

            
            #line 19 "..\..\Views\Catalog\WareCard.cshtml"
                                                    Write(product.ProducerName);

            
            #line default
            #line hidden
WriteLiteral(" ");

            
            #line 19 "..\..\Views\Catalog\WareCard.cshtml"
                                                                          Write(product.WareNumber);

            
            #line default
            #line hidden
WriteLiteral(" ");

            
            #line 19 "..\..\Views\Catalog\WareCard.cshtml"
                                                                                              Write(product.Name);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"product-detail-section__main js-accordion-body\"");

WriteLiteral(">\r\n            <!-- product-tabs-->\r\n            <div");

WriteLiteral(" class=\"product-detail-section__tabs tabs js-tabs\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"tabs__header\"");

WriteLiteral(">\r\n                    <ul");

WriteLiteral(" class=\"tabs__list\"");

WriteLiteral(">\r\n                        <li");

WriteLiteral(" class=\"tabs__item\"");

WriteLiteral("><a");

WriteLiteral(" class=\"tabs__link js-tabs-trigger is-active\"");

WriteLiteral(" href=\"#section-1\"");

WriteLiteral(">");

            
            #line 26 "..\..\Views\Catalog\WareCard.cshtml"
                                                                                                            Write(SharedResources.Description);

            
            #line default
            #line hidden
WriteLiteral("</a></li>\r\n                        <li");

WriteLiteral(" class=\"tabs__item\"");

WriteLiteral("><a");

WriteLiteral(" class=\"tabs__link js-tabs-trigger\"");

WriteLiteral(" href=\"#section-2\"");

WriteLiteral(" id=\"propertiesTab\"");

WriteLiteral(">");

            
            #line 27 "..\..\Views\Catalog\WareCard.cshtml"
                                                                                                                     Write(SharedResources.Specifications);

            
            #line default
            #line hidden
WriteLiteral("</a></li>\r\n                        <li");

WriteLiteral(" class=\"tabs__item\"");

WriteLiteral("><a");

WriteLiteral(" class=\"tabs__link js-tabs-trigger\"");

WriteLiteral(" href=\"#section-3\"");

WriteLiteral(" id=\"applicabilityTab\"");

WriteLiteral(">");

            
            #line 28 "..\..\Views\Catalog\WareCard.cshtml"
                                                                                                                        Write(SharedResources.Applicability);

            
            #line default
            #line hidden
WriteLiteral("</a></li>\r\n                        <li");

WriteLiteral(" class=\"tabs__item\"");

WriteLiteral("><a");

WriteLiteral(" class=\"tabs__link js-tabs-trigger\"");

WriteLiteral(" href=\"#section-4\"");

WriteLiteral(" id=\"setsTab\"");

WriteLiteral(">");

            
            #line 29 "..\..\Views\Catalog\WareCard.cshtml"
                                                                                                               Write(SharedResources.Sets);

            
            #line default
            #line hidden
WriteLiteral("</a></li>\r\n                        <li");

WriteLiteral(" class=\"tabs__item\"");

WriteLiteral("><a");

WriteLiteral(" class=\"tabs__link js-tabs-trigger\"");

WriteLiteral(" href=\"#section-5\"");

WriteLiteral(" id=\"relatedTab\"");

WriteLiteral(">");

            
            #line 30 "..\..\Views\Catalog\WareCard.cshtml"
                                                                                                                  Write(SharedResources.RelatedProducts);

            
            #line default
            #line hidden
WriteLiteral("</a></li>\r\n                    </ul>\r\n                    <a");

WriteLiteral(" class=\"tabs__helper\"");

WriteLiteral(" href=\"#offers\"");

WriteLiteral(">");

            
            #line 32 "..\..\Views\Catalog\WareCard.cshtml"
                                                      Write(SharedResources.Offer);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"tabs__panes\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"tabs__pane js-tabs-pane is-opened is-active\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"tabs__accordion-toggle js-tabs-accordion-toggle\"");

WriteLiteral(" id=\"section-1\"");

WriteLiteral(">");

            
            #line 36 "..\..\Views\Catalog\WareCard.cshtml"
                                                                                               Write(SharedResources.Description);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                        <div");

WriteLiteral(" class=\"tabs__accordion-body\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"product-main\"");

WriteLiteral(">\r\n                                <!-- product-gallery-->\r\n                     " +
"           <div");

WriteLiteral(" class=\"product-main__gallery\"");

WriteLiteral(">\r\n                                    <div");

WriteLiteral(" class=\"product-main-promo product-main__promo\"");

WriteLiteral(">\r\n                                        <div");

WriteLiteral(" class=\"product-main-promo__main\"");

WriteLiteral(">\r\n                                            <div");

WriteLiteral(" class=\"js-promo-main swiper\"");

WriteLiteral(">\r\n                                                <div");

WriteLiteral(" class=\"swiper-wrapper\"");

WriteLiteral(">\r\n");

            
            #line 45 "..\..\Views\Catalog\WareCard.cshtml"
                                                    
            
            #line default
            #line hidden
            
            #line 45 "..\..\Views\Catalog\WareCard.cshtml"
                                                     if (product.HasImage)
                                                    {
                                                        foreach (var item in product.Images)
                                                        {
                                                            var imgUrl = item.ImageUrl = item.ImageUrl ?? Url.WareImage(item.Id);

                                                            //var imgUrl = !string.IsNullOrEmpty(item.ImageUrl) ? product.Images[0].ImageUrl
                                                            //    : Url.Content("~/assets/images/general/product-default.jpg");


            
            #line default
            #line hidden
WriteLiteral("                                                            <div");

WriteLiteral(" class=\"swiper-slide\"");

WriteLiteral(">\r\n                                                                <a");

WriteLiteral(" class=\"product-main-promo__img-wrap\"");

WriteAttribute("href", Tuple.Create(" href=\"", 3728), Tuple.Create("\"", 3757)
            
            #line 55 "..\..\Views\Catalog\WareCard.cshtml"
                               , Tuple.Create(Tuple.Create("", 3735), Tuple.Create<System.Object, System.Int32>(Url.Content(imgUrl)
            
            #line default
            #line hidden
, 3735), false)
);

WriteLiteral(">\r\n                                                                    <img");

WriteLiteral(" class=\"product-main-promo__img\"");

WriteAttribute("src", Tuple.Create(" src=\"", 3865), Tuple.Create("\"", 3893)
            
            #line 56 "..\..\Views\Catalog\WareCard.cshtml"
                               , Tuple.Create(Tuple.Create("", 3871), Tuple.Create<System.Object, System.Int32>(Url.Content(imgUrl)
            
            #line default
            #line hidden
, 3871), false)
);

WriteAttribute("alt", Tuple.Create(" alt=\"", 3894), Tuple.Create("\"", 3913)
            
            #line 56 "..\..\Views\Catalog\WareCard.cshtml"
                                                           , Tuple.Create(Tuple.Create("", 3900), Tuple.Create<System.Object, System.Int32>(product.Name
            
            #line default
            #line hidden
, 3900), false)
);

WriteLiteral(" data-zoom=\"");

            
            #line 56 "..\..\Views\Catalog\WareCard.cshtml"
                                                                                                                                                                 Write(Url.Content(imgUrl));

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(">\r\n                                                                </a>\r\n        " +
"                                                    </div>\r\n");

            
            #line 59 "..\..\Views\Catalog\WareCard.cshtml"
                                                        }
                                                    }
                                                    else
                                                    {

            
            #line default
            #line hidden
WriteLiteral("                                                        <div");

WriteLiteral(" class=\"swiper-slide\"");

WriteLiteral(">\r\n                                                            <a");

WriteLiteral(" class=\"product-main-promo__img-wrap\"");

WriteAttribute("href", Tuple.Create(" href=\"", 4500), Tuple.Create("\"", 4568)
            
            #line 64 "..\..\Views\Catalog\WareCard.cshtml"
                           , Tuple.Create(Tuple.Create("", 4507), Tuple.Create<System.Object, System.Int32>(Url.Content("~/assets/images/general/product-default.jpg")
            
            #line default
            #line hidden
, 4507), false)
);

WriteLiteral(">\r\n                                                                <img");

WriteLiteral(" class=\"product-main-promo__img\"");

WriteAttribute("src", Tuple.Create(" src=\"", 4672), Tuple.Create("\"", 4739)
            
            #line 65 "..\..\Views\Catalog\WareCard.cshtml"
                           , Tuple.Create(Tuple.Create("", 4678), Tuple.Create<System.Object, System.Int32>(Url.Content("~/assets/images/general/product-default.jpg")
            
            #line default
            #line hidden
, 4678), false)
);

WriteAttribute("alt", Tuple.Create(" alt=\"", 4740), Tuple.Create("\"", 4759)
            
            #line 65 "..\..\Views\Catalog\WareCard.cshtml"
                                                                                              , Tuple.Create(Tuple.Create("", 4746), Tuple.Create<System.Object, System.Int32>(product.Name
            
            #line default
            #line hidden
, 4746), false)
);

WriteLiteral(" data-zoom=\"");

            
            #line 65 "..\..\Views\Catalog\WareCard.cshtml"
                                                                                                                                                                                                    Write(Url.Content("~/assets/images/general/product-default.jpg"));

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(">\r\n                                                            </a>\r\n            " +
"                                            </div>\r\n");

            
            #line 68 "..\..\Views\Catalog\WareCard.cshtml"
                                                    }

            
            #line default
            #line hidden
WriteLiteral("                                                </div>\r\n                         " +
"                   </div>\r\n                                        </div>\r\n     " +
"                                   <div");

WriteLiteral(" class=\"product-main-promo__thumbs\"");

WriteLiteral(">\r\n                                            <div");

WriteLiteral(" class=\"js-thumbs-list swiper\"");

WriteLiteral(">\r\n                                                <div");

WriteLiteral(" class=\"swiper-wrapper\"");

WriteLiteral(">\r\n");

            
            #line 75 "..\..\Views\Catalog\WareCard.cshtml"
                                                    
            
            #line default
            #line hidden
            
            #line 75 "..\..\Views\Catalog\WareCard.cshtml"
                                                     if (product.HasImage)
                                                    {
                                                        foreach (var item in product.Images)
                                                        {
                                                            var imgUrl = !string.IsNullOrEmpty(item.ImageUrl) ? item.ImageUrl
                                                                : Url.Content("~/assets/images/general/product-default.jpg");

            
            #line default
            #line hidden
WriteLiteral("                                                            <div");

WriteLiteral(" class=\"swiper-slide\"");

WriteLiteral(">\r\n                                                                <span");

WriteLiteral(" class=\"product-main-promo__thumb\"");

WriteLiteral(">\r\n                                                                    <img");

WriteLiteral(" class=\"product-main-promo__thumb-img img-responsive\"");

WriteAttribute("src", Tuple.Create(" src=\"", 6276), Tuple.Create("\"", 6304)
            
            #line 83 "..\..\Views\Catalog\WareCard.cshtml"
                                                    , Tuple.Create(Tuple.Create("", 6282), Tuple.Create<System.Object, System.Int32>(Url.Content(imgUrl)
            
            #line default
            #line hidden
, 6282), false)
);

WriteAttribute("alt", Tuple.Create(" alt=\"", 6305), Tuple.Create("\"", 6324)
            
            #line 83 "..\..\Views\Catalog\WareCard.cshtml"
                                                                                , Tuple.Create(Tuple.Create("", 6311), Tuple.Create<System.Object, System.Int32>(product.Name
            
            #line default
            #line hidden
, 6311), false)
);

WriteLiteral(">\r\n                                                                </span>\r\n     " +
"                                                       </div>\r\n");

            
            #line 86 "..\..\Views\Catalog\WareCard.cshtml"
                                                        }
                                                    }
                                                    else
                                                    {

            
            #line default
            #line hidden
WriteLiteral("                                                        <div");

WriteLiteral(" class=\"swiper-slide\"");

WriteLiteral(">\r\n                                                            <span");

WriteLiteral(" class=\"product-main-promo__thumb\"");

WriteLiteral(">\r\n                                                                <img");

WriteLiteral(" class=\"product-main-promo__thumb-img img-responsive\"");

WriteAttribute("src", Tuple.Create(" src=\"", 7003), Tuple.Create("\"", 7070)
            
            #line 92 "..\..\Views\Catalog\WareCard.cshtml"
                                                , Tuple.Create(Tuple.Create("", 7009), Tuple.Create<System.Object, System.Int32>(Url.Content("~/assets/images/general/product-default.jpg")
            
            #line default
            #line hidden
, 7009), false)
);

WriteAttribute("alt", Tuple.Create(" alt=\"", 7071), Tuple.Create("\"", 7090)
            
            #line 92 "..\..\Views\Catalog\WareCard.cshtml"
                                                                                                                   , Tuple.Create(Tuple.Create("", 7077), Tuple.Create<System.Object, System.Int32>(product.Name
            
            #line default
            #line hidden
, 7077), false)
);

WriteLiteral(">\r\n                                                            </span>\r\n         " +
"                                               </div>\r\n");

            
            #line 95 "..\..\Views\Catalog\WareCard.cshtml"
                                                    }

            
            #line default
            #line hidden
WriteLiteral("                                                </div>\r\n                         " +
"                   </div>\r\n                                            <button");

WriteLiteral(" class=\"product-main-promo__thumbs-prev js-thumbs-list-prev\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(">\r\n                                                <svg");

WriteLiteral(" class=\"icon icon-chevron-up product-main-promo__thumbs-prev-icon\"");

WriteLiteral(" width=\"25\"");

WriteLiteral(" height=\"25\"");

WriteLiteral(">\r\n                                                    <use");

WriteAttribute("href", Tuple.Create(" href=\"", 7718), Tuple.Create("\"", 7791)
            
            #line 100 "..\..\Views\Catalog\WareCard.cshtml"
, Tuple.Create(Tuple.Create("", 7725), Tuple.Create<System.Object, System.Int32>(Url.Content("~/assets/images/svg/symbol/sprite.svg#chevron-up")
            
            #line default
            #line hidden
, 7725), false)
);

WriteLiteral("></use>\r\n                                                </svg>\r\n                " +
"                            </button>\r\n                                         " +
"   <button");

WriteLiteral(" class=\"product-main-promo__thumbs-next js-thumbs-list-next\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(">\r\n                                                <svg");

WriteLiteral(" class=\"icon icon-chevron-down product-main-promo__thumbs-next-icon\"");

WriteLiteral(" width=\"25\"");

WriteLiteral(" height=\"25\"");

WriteLiteral(">\r\n                                                    <use");

WriteAttribute("href", Tuple.Create(" href=\"", 8242), Tuple.Create("\"", 8317)
            
            #line 105 "..\..\Views\Catalog\WareCard.cshtml"
, Tuple.Create(Tuple.Create("", 8249), Tuple.Create<System.Object, System.Int32>(Url.Content("~/assets/images/svg/symbol/sprite.svg#chevron-down")
            
            #line default
            #line hidden
, 8249), false)
);

WriteLiteral("></use>\r\n                                                </svg>\r\n                " +
"                            </button>\r\n                                        <" +
"/div>\r\n                                        <div");

WriteLiteral(" class=\"product-main-promo__zoom-pane js-gallery-zoom-pane\"");

WriteLiteral("></div>\r\n                                    </div>\r\n                            " +
"    </div>\r\n                                <!-- product-gallery-->\r\n           " +
"                     <!-- product-info-->\r\n                                <div");

WriteLiteral(" class=\"product-main__info product-info\"");

WriteLiteral(">\r\n                                    <div");

WriteLiteral(" class=\"product-info__header\"");

WriteLiteral(">\r\n                                        <div");

WriteLiteral(" class=\"product-info__heading\"");

WriteLiteral(">");

            
            #line 116 "..\..\Views\Catalog\WareCard.cshtml"
                                                                      Write(product.Name);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                                        <a");

WriteLiteral(" class=\"product-info__brand\"");

WriteAttribute("href", Tuple.Create(" href=\"", 9110), Tuple.Create("\"", 9235)
            
            #line 117 "..\..\Views\Catalog\WareCard.cshtml"
, Tuple.Create(Tuple.Create("", 9117), Tuple.Create<System.Object, System.Int32>(!string.IsNullOrEmpty(Model.Ware.ProducerId) ? Url.Action("Info", "Brands", new {id = Model.Ware.ProducerId }) : ""
            
            #line default
            #line hidden
, 9117), false)
);

WriteLiteral(">\r\n                                            <img");

WriteLiteral(" class=\"product-info__brand-img\"");

WriteAttribute("src", Tuple.Create(" src=\"", 9319), Tuple.Create("\"", 9368)
            
            #line 118 "..\..\Views\Catalog\WareCard.cshtml"
      , Tuple.Create(Tuple.Create("", 9325), Tuple.Create<System.Object, System.Int32>(Url.ProducerImage(Model.Ware.ProducerName)
            
            #line default
            #line hidden
, 9325), false)
);

WriteAttribute("alt", Tuple.Create(" alt=\"", 9369), Tuple.Create("\"", 9396)
            
            #line 118 "..\..\Views\Catalog\WareCard.cshtml"
                                                        , Tuple.Create(Tuple.Create("", 9375), Tuple.Create<System.Object, System.Int32>(product.ProducerName
            
            #line default
            #line hidden
, 9375), false)
);

WriteAttribute("title", Tuple.Create(" title=\"", 9397), Tuple.Create("\"", 9426)
            
            #line 118 "..\..\Views\Catalog\WareCard.cshtml"
                                                                                      , Tuple.Create(Tuple.Create("", 9405), Tuple.Create<System.Object, System.Int32>(product.ProducerName
            
            #line default
            #line hidden
, 9405), false)
);

WriteLiteral(" width=\"90\"");

WriteLiteral(" height=\"30\"");

WriteLiteral(">\r\n                                        </a>\r\n                                " +
"    </div>\r\n\r\n                                    <div");

WriteLiteral(" class=\"product-info__main\"");

WriteLiteral(">\r\n                                        <div");

WriteLiteral(" class=\"product-info__params params\"");

WriteLiteral(">\r\n                                            <div");

WriteLiteral(" class=\"params__param\"");

WriteLiteral(">\r\n                                                <dt");

WriteLiteral(" class=\"params__property\"");

WriteLiteral(">");

            
            #line 125 "..\..\Views\Catalog\WareCard.cshtml"
                                                                        Write(SharedResources.Brand);

            
            #line default
            #line hidden
WriteLiteral(":</dt>\r\n                                                <dd");

WriteLiteral(" class=\"params__value\"");

WriteLiteral(">");

            
            #line 126 "..\..\Views\Catalog\WareCard.cshtml"
                                                                     Write(product.ProducerName);

            
            #line default
            #line hidden
WriteLiteral("</dd>\r\n                                            </div>\r\n                      " +
"                      <div");

WriteLiteral(" class=\"params__param\"");

WriteLiteral(">\r\n                                                <dt");

WriteLiteral(" class=\"params__property\"");

WriteLiteral(">");

            
            #line 129 "..\..\Views\Catalog\WareCard.cshtml"
                                                                        Write(SharedResources.PartNumber);

            
            #line default
            #line hidden
WriteLiteral(":</dt>\r\n                                                <dd");

WriteLiteral(" class=\"params__value\"");

WriteLiteral(">");

            
            #line 130 "..\..\Views\Catalog\WareCard.cshtml"
                                                                     Write(product.WareNumber);

            
            #line default
            #line hidden
WriteLiteral("</dd>\r\n                                            </div>\r\n                      " +
"                  </div>\r\n                                        <div");

WriteLiteral(" class=\"product-info__props\"");

WriteLiteral(">\r\n");

WriteLiteral("                                            ");

            
            #line 134 "..\..\Views\Catalog\WareCard.cshtml"
                                       Write(Html.LazyPanel(HtmlTextWriterTag.Div, Url.Action("ShortProperties", "CatalogService", new { wareId = Model.Ware.Id, cnt = 6 }), "LazyShortPropertiesFun",
                                                      new { id = "ShortProperties", @class = "product-main__props" }));

            
            #line default
            #line hidden
WriteLiteral(@"
                                        </div>
                                    </div>

                                </div>
                                <!-- product-info-->
                            </div>
                        </div>
                    </div>
                    ");

WriteLiteral("\r\n                    <div");

WriteLiteral(" class=\"tabs__pane js-tabs-pane\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"tabs__accordion-toggle js-tabs-accordion-toggle\"");

WriteLiteral(" id=\"section-2\"");

WriteLiteral(">");

            
            #line 146 "..\..\Views\Catalog\WareCard.cshtml"
                                                                                               Write(SharedResources.Specifications);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                        <div");

WriteLiteral(" class=\"tabs__accordion-body\"");

WriteLiteral(">\r\n                            ");

WriteLiteral("\r\n");

WriteLiteral("                            ");

            
            #line 149 "..\..\Views\Catalog\WareCard.cshtml"
                       Write(Html.LazyPanel(HtmlTextWriterTag.Div, Url.Action("Properties", "CatalogService", new { wareId = Model.Ware.Id }), null,
                                new { id = "lazyProps", @class = $"manual-params manual-params--bigger {skeletonClass}", style = skeletonStyle }, "propertiesTab"));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                   " +
" ");

WriteLiteral("\r\n                    <div");

WriteLiteral(" class=\"tabs__pane js-tabs-pane\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"tabs__accordion-toggle js-tabs-accordion-toggle\"");

WriteLiteral(" id=\"section-3\"");

WriteLiteral(">");

            
            #line 155 "..\..\Views\Catalog\WareCard.cshtml"
                                                                                               Write(SharedResources.Applicability);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                        <div");

WriteLiteral(" class=\"tabs__accordion-body\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 157 "..\..\Views\Catalog\WareCard.cshtml"
                       Write(Html.LazyPanel(HtmlTextWriterTag.Div, Url.Action("Applicability", "CatalogService", new { wareId = Model.Ware.Id }), null,
                                new { id = "lazyApplicability", @class = $"card-specification-section {skeletonClass}", style = skeletonStyle }, "applicabilityTab"));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                   " +
" ");

WriteLiteral("\r\n                    <div");

WriteLiteral(" class=\"tabs__pane js-tabs-pane\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"tabs__accordion-toggle js-tabs-accordion-toggle\"");

WriteLiteral(" id=\"section-4\"");

WriteLiteral(">");

            
            #line 163 "..\..\Views\Catalog\WareCard.cshtml"
                                                                                               Write(SharedResources.Sets);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                        <div");

WriteLiteral(" class=\"tabs__accordion-body\"");

WriteLiteral(">\r\n                            <h2");

WriteLiteral(" style=\"margin: 0;\"");

WriteLiteral(">");

            
            #line 165 "..\..\Views\Catalog\WareCard.cshtml"
                                              Write(SharedResources.Sets);

            
            #line default
            #line hidden
WriteLiteral("</h2>\r\n");

WriteLiteral("                            ");

            
            #line 166 "..\..\Views\Catalog\WareCard.cshtml"
                       Write(Html.LazyPanel(HtmlTextWriterTag.Div, Url.Action("Sets", "CatalogService", new { wareId = Model.Ware.Id }), null,
                                new { id = "lazySets", @class = $"card-specification-section {skeletonClass}", style = skeletonStyle }, "setsTab"));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                   " +
" ");

WriteLiteral("\r\n                    <div");

WriteLiteral(" class=\"tabs__pane js-tabs-pane\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"tabs__accordion-toggle js-tabs-accordion-toggle\"");

WriteLiteral(" id=\"section-5\"");

WriteLiteral(">");

            
            #line 172 "..\..\Views\Catalog\WareCard.cshtml"
                                                                                               Write(SharedResources.RelatedProducts);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                        <div");

WriteLiteral(" class=\"tabs__accordion-body\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 174 "..\..\Views\Catalog\WareCard.cshtml"
                       Write(Html.LazyPanel(HtmlTextWriterTag.Div, Url.Action("Related", "CatalogService", new { wareId = Model.Ware.Id }), "LazyRelatedFun",
                                new { id = "lazyRelated", @class = $"items-carousel-wrap {skeletonClass}", style = skeletonStyle }, "relatedTab"));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                   " +
" ");

WriteLiteral("\r\n                </div><!-- /spec table desktop-->\r\n            </div>\r\n        " +
"</div>\r\n    </section>\r\n\r\n");

WriteLiteral("    ");

            
            #line 188 "..\..\Views\Catalog\WareCard.cshtml"
Write(Html.LazyPanel(HtmlTextWriterTag.Div,
        Url.Action("Offers", "CatalogService", new { brand = Model.Ware.ProducerName, article = Model.Ware.WareNumber, filterParams = Model.FilterOptions.ToJson() }), "LazyOfferFun",
        new { id = "lazyOffersDesktop", data_show = false, @class=skeletonClass, style=skeletonStyle }));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n    ");

WriteLiteral("\r\n\r\n</div>\r\n<div");

WriteLiteral(" id=\"locker\"");

WriteLiteral("></div>\r\n");

DefineSection("styles", () => {

WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 258 "..\..\Views\Catalog\WareCard.cshtml"
Write(Styles.Render("~/Content/fancybox/fancy"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

});

WriteLiteral("\r\n");

DefineSection("scripts", () => {

WriteLiteral("\r\n    ");

WriteLiteral("\r\n");

            
            #line 270 "..\..\Views\Catalog\WareCard.cshtml"
    
            
            #line default
            #line hidden
            
            #line 270 "..\..\Views\Catalog\WareCard.cshtml"
       Html.RenderPartial("AddToCartScript"); 
            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 271 "..\..\Views\Catalog\WareCard.cshtml"
    
            
            #line default
            #line hidden
            
            #line 271 "..\..\Views\Catalog\WareCard.cshtml"
       Html.RenderPartial("_WareListScripts"); 
            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 272 "..\..\Views\Catalog\WareCard.cshtml"
    
            
            #line default
            #line hidden
            
            #line 272 "..\..\Views\Catalog\WareCard.cshtml"
       Html.RenderPartial("_WareListScriptsEx"); 
            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 273 "..\..\Views\Catalog\WareCard.cshtml"
    
            
            #line default
            #line hidden
            
            #line 273 "..\..\Views\Catalog\WareCard.cshtml"
       Html.RenderPartial("_FilterScripts", new CatalogFilterViewModel()); 
            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 274 "..\..\Views\Catalog\WareCard.cshtml"
Write(Scripts.Render("~/bundles/fancy"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

});

DefineSection("dialogs", () => {

WriteLiteral("\r\n");

            
            #line 277 "..\..\Views\Catalog\WareCard.cshtml"
    
            
            #line default
            #line hidden
            
            #line 277 "..\..\Views\Catalog\WareCard.cshtml"
       Html.RenderPartial("AddToCartDialog"); 
            
            #line default
            #line hidden
WriteLiteral("\r\n");

});

        }
    }
}
#pragma warning restore 1591
