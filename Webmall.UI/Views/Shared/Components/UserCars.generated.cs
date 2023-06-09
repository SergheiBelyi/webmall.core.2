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
    
    #line 1 "..\..\Views\Shared\Components\UserCars.cshtml"
    using ViewRes;
    
    #line default
    #line hidden
    using Webmall.UI;
    
    #line 2 "..\..\Views\Shared\Components\UserCars.cshtml"
    using Webmall.UI.Core;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Views\Shared\Components\UserCars.cshtml"
    using Webmall.UI.Core.HtmlHelpers;
    
    #line default
    #line hidden
    using Webmall.UI.Core.Localization;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/Components/UserCars.cshtml")]
    public partial class _Views_Shared_Components_UserCars_cshtml : System.Web.Mvc.WebViewPage<Webmall.UI.ViewModel.Garage.GarageViewModel>
    {
        public _Views_Shared_Components_UserCars_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

WriteLiteral("<div");

WriteLiteral(" class=\"header-utilities__util header-utility js-dropdown is-lock has-overlay\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"header-utility__main\"");

WriteLiteral(">\r\n        <button");

WriteLiteral(" class=\"header-utility__link js-dropdown-toggle\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(">\r\n            <svg");

WriteLiteral(" class=\"icon icon-garage header-utility__icon\"");

WriteLiteral(" width=\"25\"");

WriteLiteral(" height=\"25\"");

WriteLiteral(">\r\n                <use");

WriteAttribute("href", Tuple.Create(" href=", 445), Tuple.Create("", 511)
            
            #line 11 "..\..\Views\Shared\Components\UserCars.cshtml"
, Tuple.Create(Tuple.Create("", 451), Tuple.Create<System.Object, System.Int32>(Url.Content("~/assets/images/svg/symbol/sprite.svg#garage")
            
            #line default
            #line hidden
, 451), false)
);

WriteLiteral("></use>\r\n            </svg>\r\n");

            
            #line 13 "..\..\Views\Shared\Components\UserCars.cshtml"
            
            
            #line default
            #line hidden
            
            #line 13 "..\..\Views\Shared\Components\UserCars.cshtml"
             if (SessionHelper.CurrentUser != null)
            {

            
            #line default
            #line hidden
WriteLiteral("                <span");

WriteLiteral(" class=\"header-utility__counter\"");

WriteLiteral(">");

            
            #line 15 "..\..\Views\Shared\Components\UserCars.cshtml"
                                                  Write(Model.Cars?.Count ?? 0);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n");

            
            #line 16 "..\..\Views\Shared\Components\UserCars.cshtml"
                
            
            #line default
            #line hidden
            
            #line 16 "..\..\Views\Shared\Components\UserCars.cshtml"
                                                                                                                    
            }
            else
            {
                
            
            #line default
            #line hidden
            
            #line 20 "..\..\Views\Shared\Components\UserCars.cshtml"
                                                                 
            }

            
            #line default
            #line hidden
WriteLiteral("\r\n        </button>\r\n        <div");

WriteLiteral(" class=\"header-utility__body\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"header-utility__garage garage-widget\"");

WriteLiteral(">\r\n");

            
            #line 26 "..\..\Views\Shared\Components\UserCars.cshtml"
                
            
            #line default
            #line hidden
            
            #line 26 "..\..\Views\Shared\Components\UserCars.cshtml"
                 if (string.IsNullOrEmpty(SessionHelper.CurrentClientId))
                {

            
            #line default
            #line hidden
WriteLiteral("                    <div");

WriteLiteral(" class=\"garage-widget__header\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"garage-widget__heading\"");

WriteLiteral(">");

            
            #line 29 "..\..\Views\Shared\Components\UserCars.cshtml"
                                                       Write(SharedResources.YouAreNotAuthorized);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                        <button");

WriteLiteral(" class=\"garage-widget__close js-dropdown-toggle\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(">\r\n                            <svg");

WriteLiteral(" class=\"icon icon-close garage-widget__close-icon\"");

WriteLiteral(" width=\"25\"");

WriteLiteral(" height=\"25\"");

WriteLiteral(">\r\n                                <use");

WriteAttribute("href", Tuple.Create(" href=\"", 1568), Tuple.Create("\"", 1634)
            
            #line 32 "..\..\Views\Shared\Components\UserCars.cshtml"
, Tuple.Create(Tuple.Create("", 1575), Tuple.Create<System.Object, System.Int32>(Url.Content("~/assets/images/svg/symbol/sprite.svg#close")
            
            #line default
            #line hidden
, 1575), false)
);

WriteLiteral("></use>\r\n                            </svg>\r\n                        </button>\r\n " +
"                   </div>\r\n");

            
            #line 36 "..\..\Views\Shared\Components\UserCars.cshtml"
                }
                else
                {

            
            #line default
            #line hidden
WriteLiteral("                    <div");

WriteLiteral(" class=\"garage-widget__header\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"garage-widget__heading\"");

WriteLiteral(">");

            
            #line 40 "..\..\Views\Shared\Components\UserCars.cshtml"
                                                       Write(SharedResources.MyGarage);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                        ");

WriteLiteral("\r\n                        <button");

WriteLiteral(" class=\"garage-widget__close js-dropdown-toggle\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(">\r\n                            <svg");

WriteLiteral(" class=\"icon icon-close garage-widget__close-icon\"");

WriteLiteral(" width=\"25\"");

WriteLiteral(" height=\"25\"");

WriteLiteral(">\r\n                                <use");

WriteAttribute("href", Tuple.Create(" href=\"", 2285), Tuple.Create("\"", 2351)
            
            #line 44 "..\..\Views\Shared\Components\UserCars.cshtml"
, Tuple.Create(Tuple.Create("", 2292), Tuple.Create<System.Object, System.Int32>(Url.Content("~/assets/images/svg/symbol/sprite.svg#close")
            
            #line default
            #line hidden
, 2292), false)
);

WriteLiteral("></use>\r\n                            </svg>\r\n                        </button>\r\n " +
"                   </div>\r\n");

            
            #line 48 "..\..\Views\Shared\Components\UserCars.cshtml"
                    if (Model?.Cars != null)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <div");

WriteLiteral(" class=\"garage-widget__main\"");

WriteLiteral(">\r\n");

            
            #line 51 "..\..\Views\Shared\Components\UserCars.cshtml"
                            
            
            #line default
            #line hidden
            
            #line 51 "..\..\Views\Shared\Components\UserCars.cshtml"
                             foreach (var item in Model.Cars)
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <div");

WriteLiteral(" class=\"garage-widget__item car-item\"");

WriteAttribute("id", Tuple.Create(" id=\"", 2755), Tuple.Create("\"", 2777)
, Tuple.Create(Tuple.Create("", 2760), Tuple.Create("user-car-", 2760), true)
            
            #line 53 "..\..\Views\Shared\Components\UserCars.cshtml"
       , Tuple.Create(Tuple.Create("", 2769), Tuple.Create<System.Object, System.Int32>(item.Id
            
            #line default
            #line hidden
, 2769), false)
);

WriteLiteral(">\r\n                                    <div");

WriteLiteral(" class=\"car-item__radio radio-label\"");

WriteLiteral(">\r\n                                        <input");

WriteLiteral(" class=\"radio-label__input\"");

WriteLiteral(" type=\"radio\"");

WriteLiteral(" name=\"car\"");

WriteAttribute("id", Tuple.Create(" id=\"", 2957), Tuple.Create("\"", 2974)
, Tuple.Create(Tuple.Create("", 2962), Tuple.Create("car-", 2962), true)
            
            #line 55 "..\..\Views\Shared\Components\UserCars.cshtml"
                          , Tuple.Create(Tuple.Create("", 2966), Tuple.Create<System.Object, System.Int32>(item.Id
            
            #line default
            #line hidden
, 2966), false)
);

WriteAttribute("onchange", Tuple.Create(" onchange=\"", 2975), Tuple.Create("\"", 3005)
, Tuple.Create(Tuple.Create("", 2986), Tuple.Create("selectCar(", 2986), true)
            
            #line 55 "..\..\Views\Shared\Components\UserCars.cshtml"
                                                        , Tuple.Create(Tuple.Create("", 2996), Tuple.Create<System.Object, System.Int32>(item.Id
            
            #line default
            #line hidden
, 2996), false)
, Tuple.Create(Tuple.Create("", 3004), Tuple.Create(")", 3004), true)
);

WriteLiteral("\r\n                                              ");

            
            #line 56 "..\..\Views\Shared\Components\UserCars.cshtml"
                                          Write(item.IsSelected ? "checked=\"checked\"" : "");

            
            #line default
            #line hidden
WriteLiteral(">\r\n                                        <label");

WriteLiteral(" class=\"radio-label__main\"");

WriteAttribute("for", Tuple.Create(" for=\"", 3176), Tuple.Create("\"", 3194)
, Tuple.Create(Tuple.Create("", 3182), Tuple.Create("car-", 3182), true)
            
            #line 57 "..\..\Views\Shared\Components\UserCars.cshtml"
  , Tuple.Create(Tuple.Create("", 3186), Tuple.Create<System.Object, System.Int32>(item.Id
            
            #line default
            #line hidden
, 3186), false)
);

WriteLiteral("></label>\r\n                                    </div>\r\n                          " +
"          <div");

WriteLiteral(" class=\"car-item__main\"");

WriteLiteral(">\r\n                                        <div");

WriteLiteral(" class=\"car-item__header\"");

WriteLiteral(">\r\n                                            <img");

WriteLiteral(" class=\"car-item__img\"");

WriteAttribute("src", Tuple.Create(" src=\"", 3458), Tuple.Create("\"", 3493)
            
            #line 61 "..\..\Views\Shared\Components\UserCars.cshtml"
, Tuple.Create(Tuple.Create("", 3464), Tuple.Create<System.Object, System.Int32>(Url.MarkaImage(item.Marka)
            
            #line default
            #line hidden
, 3464), false)
);

WriteLiteral(" alt=\"\"");

WriteLiteral(" width=\"36\"");

WriteLiteral(" height=\"36\"");

WriteLiteral(">\r\n                                            <ul");

WriteLiteral(" class=\"car-item__controls car-controls\"");

WriteLiteral(">\r\n                                                <li");

WriteLiteral(" class=\"car-controls__control\"");

WriteLiteral(">\r\n                                                    <a");

WriteLiteral(" class=\"car-controls__link\"");

WriteAttribute("title", Tuple.Create(" title=\"", 3782), Tuple.Create("\"", 3816)
            
            #line 64 "..\..\Views\Shared\Components\UserCars.cshtml"
         , Tuple.Create(Tuple.Create("", 3790), Tuple.Create<System.Object, System.Int32>(SharedResources.VINSearch
            
            #line default
            #line hidden
, 3790), false)
);

WriteAttribute("href", Tuple.Create(" href=\"", 3817), Tuple.Create("\"", 3877)
            
            #line 64 "..\..\Views\Shared\Components\UserCars.cshtml"
                                           , Tuple.Create(Tuple.Create("", 3824), Tuple.Create<System.Object, System.Int32>(Url.Action("VinSearch", "Lxm", new { vin=item.Vin })
            
            #line default
            #line hidden
, 3824), false)
);

WriteLiteral(">\r\n                                                        <svg");

WriteLiteral(" class=\"icon icon-search-glass car-controls__icon\"");

WriteLiteral(" width=\"25\"");

WriteLiteral(" height=\"25\"");

WriteLiteral(">\r\n                                                            <use");

WriteAttribute("href", Tuple.Create(" href=\"", 4081), Tuple.Create("\"", 4154)
            
            #line 66 "..\..\Views\Shared\Components\UserCars.cshtml"
, Tuple.Create(Tuple.Create("", 4088), Tuple.Create<System.Object, System.Int32>(Url.Content("~/assets/images/svg/symbol/sprite.svg#search-glass")
            
            #line default
            #line hidden
, 4088), false)
);

WriteLiteral("></use>\r\n                                                        </svg>\r\n        " +
"                                            </a>\r\n                              " +
"                  </li>\r\n                                                <li");

WriteLiteral(" class=\"car-controls__control\"");

WriteLiteral(">\r\n                                                    <a");

WriteLiteral(" class=\"car-controls__link\"");

WriteAttribute("title", Tuple.Create(" title=\"", 4506), Tuple.Create("\"", 4537)
            
            #line 71 "..\..\Views\Shared\Components\UserCars.cshtml"
         , Tuple.Create(Tuple.Create("", 4514), Tuple.Create<System.Object, System.Int32>(SharedResources.Delete
            
            #line default
            #line hidden
, 4514), false)
);

WriteLiteral(" href=\"\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4546), Tuple.Create("\"", 4575)
, Tuple.Create(Tuple.Create("", 4556), Tuple.Create("removeCar(", 4556), true)
            
            #line 71 "..\..\Views\Shared\Components\UserCars.cshtml"
                                                             , Tuple.Create(Tuple.Create("", 4566), Tuple.Create<System.Object, System.Int32>(item.Id
            
            #line default
            #line hidden
, 4566), false)
, Tuple.Create(Tuple.Create("", 4574), Tuple.Create(")", 4574), true)
);

WriteLiteral(">\r\n                                                        <svg");

WriteLiteral(" class=\"icon icon-trash car-controls__icon\"");

WriteLiteral(" width=\"25\"");

WriteLiteral(" height=\"25\"");

WriteLiteral(">\r\n                                                            <use");

WriteAttribute("href", Tuple.Create(" href=\"", 4772), Tuple.Create("\"", 4838)
            
            #line 73 "..\..\Views\Shared\Components\UserCars.cshtml"
, Tuple.Create(Tuple.Create("", 4779), Tuple.Create<System.Object, System.Int32>(Url.Content("~/assets/images/svg/symbol/sprite.svg#trash")
            
            #line default
            #line hidden
, 4779), false)
);

WriteLiteral("></use>\r\n                                                        </svg>\r\n        " +
"                                            </a>\r\n                              " +
"                  </li>\r\n                                                <li");

WriteLiteral(" class=\"car-controls__control\"");

WriteLiteral(">\r\n                                                    <a");

WriteLiteral(" class=\"car-controls__link\"");

WriteAttribute("title", Tuple.Create(" title=\"", 5190), Tuple.Create("\"", 5219)
            
            #line 78 "..\..\Views\Shared\Components\UserCars.cshtml"
         , Tuple.Create(Tuple.Create("", 5198), Tuple.Create<System.Object, System.Int32>(SharedResources.Edit
            
            #line default
            #line hidden
, 5198), false)
);

WriteAttribute("href", Tuple.Create(" href=\"", 5220), Tuple.Create("\"", 5281)
            
            #line 78 "..\..\Views\Shared\Components\UserCars.cshtml"
                                      , Tuple.Create(Tuple.Create("", 5227), Tuple.Create<System.Object, System.Int32>(Url.Action("Index", "Garage", new { edit = item.Id })
            
            #line default
            #line hidden
, 5227), false)
);

WriteLiteral(">\r\n                                                        <svg");

WriteLiteral(" class=\"icon icon-edit car-controls__icon\"");

WriteLiteral(" width=\"25\"");

WriteLiteral(" height=\"25\"");

WriteLiteral(">\r\n                                                            <use");

WriteAttribute("href", Tuple.Create(" href=\"", 5477), Tuple.Create("\"", 5542)
            
            #line 80 "..\..\Views\Shared\Components\UserCars.cshtml"
, Tuple.Create(Tuple.Create("", 5484), Tuple.Create<System.Object, System.Int32>(Url.Content("~/assets/images/svg/symbol/sprite.svg#edit")
            
            #line default
            #line hidden
, 5484), false)
);

WriteLiteral("></use>\r\n                                                        </svg>\r\n        " +
"                                            </a>\r\n                              " +
"                  </li>\r\n                                                <li");

WriteLiteral(" class=\"car-controls__control\"");

WriteLiteral(">\r\n                                                    <a");

WriteLiteral(" class=\"car-controls__link\"");

WriteAttribute("title", Tuple.Create(" title=\"", 5894), Tuple.Create("\"", 5929)
            
            #line 85 "..\..\Views\Shared\Components\UserCars.cshtml"
         , Tuple.Create(Tuple.Create("", 5902), Tuple.Create<System.Object, System.Int32>(SharedResources.VINRequest
            
            #line default
            #line hidden
, 5902), false)
);

WriteAttribute("href", Tuple.Create(" href=\"", 5930), Tuple.Create("\"", 5992)
            
            #line 85 "..\..\Views\Shared\Components\UserCars.cshtml"
                                            , Tuple.Create(Tuple.Create("", 5937), Tuple.Create<System.Object, System.Int32>(Url.Action("Index", "VINRequest", new { add=item.Id })
            
            #line default
            #line hidden
, 5937), false)
);

WriteLiteral(">\r\n                                                        <svg");

WriteLiteral(" class=\"icon icon-vin-bubble car-controls__icon\"");

WriteLiteral(" width=\"25\"");

WriteLiteral(" height=\"25\"");

WriteLiteral(">\r\n                                                            <use");

WriteAttribute("href", Tuple.Create(" href=\"", 6194), Tuple.Create("\"", 6265)
            
            #line 87 "..\..\Views\Shared\Components\UserCars.cshtml"
, Tuple.Create(Tuple.Create("", 6201), Tuple.Create<System.Object, System.Int32>(Url.Content("~/assets/images/svg/symbol/sprite.svg#vin-bubble")
            
            #line default
            #line hidden
, 6201), false)
);

WriteLiteral(@"></use>
                                                        </svg>
                                                    </a>
                                                </li>
                                            </ul>
                                        </div>
                                        <div");

WriteLiteral(" class=\"car-item__info\"");

WriteLiteral(">\r\n                                            <div");

WriteLiteral(" class=\"car-item__heading\"");

WriteLiteral(">");

            
            #line 94 "..\..\Views\Shared\Components\UserCars.cshtml"
                                                                      Write(item.Marka);

            
            #line default
            #line hidden
WriteLiteral(" ");

            
            #line 94 "..\..\Views\Shared\Components\UserCars.cshtml"
                                                                                  Write(item.Model);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                                            <dl");

WriteLiteral(" class=\"car-item__params\"");

WriteLiteral(">\r\n                                                <div");

WriteLiteral(" class=\"cart-item__param\"");

WriteLiteral(">\r\n                                                <dt");

WriteLiteral(" class=\"car-item__property\"");

WriteLiteral(">VIN:</dt>\r\n                                                <dd");

WriteLiteral(" class=\"car-item__value\"");

WriteLiteral(">");

            
            #line 98 "..\..\Views\Shared\Components\UserCars.cshtml"
                                                                       Write(item.Vin);

            
            #line default
            #line hidden
WriteLiteral("</dd>\r\n                                        </div>\r\n                          " +
"              <div");

WriteLiteral(" class=\"cart-item__param\"");

WriteLiteral(">\r\n                                            <dt");

WriteLiteral(" class=\"car-item__property\"");

WriteLiteral(">");

            
            #line 101 "..\..\Views\Shared\Components\UserCars.cshtml"
                                                                      Write(SharedResources.YearOfProduce);

            
            #line default
            #line hidden
WriteLiteral(":</dt>\r\n                                            <dd");

WriteLiteral(" class=\"car-item__value\"");

WriteLiteral(">");

            
            #line 102 "..\..\Views\Shared\Components\UserCars.cshtml"
                                                                   Write(item.Year);

            
            #line default
            #line hidden
WriteLiteral("</dd>\r\n                                        </div>\r\n                          " +
"              <div");

WriteLiteral(" class=\"cart-item__param\"");

WriteLiteral(">\r\n                                            <dt");

WriteLiteral(" class=\"car-item__property\"");

WriteLiteral(">");

            
            #line 105 "..\..\Views\Shared\Components\UserCars.cshtml"
                                                                      Write(SharedResources.Engine);

            
            #line default
            #line hidden
WriteLiteral(":</dt>\r\n                                            <dd");

WriteLiteral(" class=\"car-item__value\"");

WriteLiteral(">");

            
            #line 106 "..\..\Views\Shared\Components\UserCars.cshtml"
                                                                   Write(item.Modification);

            
            #line default
            #line hidden
WriteLiteral("</dd>\r\n                                        </div>\r\n                          " +
"              </dl>\r\n                                    </div>\r\n               " +
"                 </div>\r\n                            </div>\r\n");

            
            #line 112 "..\..\Views\Shared\Components\UserCars.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                        </div>\r\n");

            
            #line 114 "..\..\Views\Shared\Components\UserCars.cshtml"
                    }
                    

            
            #line default
            #line hidden
WriteLiteral("                    <div");

WriteLiteral(" class=\"garage-widget__footer\"");

WriteLiteral(">\r\n                        <a");

WriteLiteral(" class=\"garage-widget__btn btn btn--primary btn--sm\"");

WriteLiteral(" href=\"#\"");

WriteLiteral(">\r\n                            <span");

WriteLiteral(" class=\"btn__text\"");

WriteLiteral(">");

            
            #line 118 "..\..\Views\Shared\Components\UserCars.cshtml"
                                               Write(SharedResources.NewCar);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                            <svg");

WriteLiteral(" class=\"icon icon-chevron-right btn__icon\"");

WriteLiteral(" width=\"25\"");

WriteLiteral(" height=\"25\"");

WriteLiteral(">\r\n                                <use");

WriteAttribute("href", Tuple.Create(" href=\"", 8395), Tuple.Create("\"", 8469)
            
            #line 120 "..\..\Views\Shared\Components\UserCars.cshtml"
, Tuple.Create(Tuple.Create("", 8402), Tuple.Create<System.Object, System.Int32>(Url.Content("~/assets/images/svg/symbol/sprite.svg#chevron-right")
            
            #line default
            #line hidden
, 8402), false)
);

WriteLiteral("></use>\r\n                            </svg>\r\n                        </a>\r\n      " +
"                  <a");

WriteLiteral(" class=\"garage-widget__btn btn btn--primary-reverse btn--sm\"");

WriteAttribute("href", Tuple.Create(" href=\"", 8631), Tuple.Create("\"", 8668)
            
            #line 123 "..\..\Views\Shared\Components\UserCars.cshtml"
             , Tuple.Create(Tuple.Create("", 8638), Tuple.Create<System.Object, System.Int32>(Url.Action("Index", "Garage")
            
            #line default
            #line hidden
, 8638), false)
);

WriteLiteral(">\r\n                            <span");

WriteLiteral(" class=\"btn__text\"");

WriteLiteral(">");

            
            #line 124 "..\..\Views\Shared\Components\UserCars.cshtml"
                                               Write(SharedResources.GotoGarage);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                            <svg");

WriteLiteral(" class=\"icon icon-chevron-right btn__icon\"");

WriteLiteral(" width=\"25\"");

WriteLiteral(" height=\"25\"");

WriteLiteral(">\r\n                                <use");

WriteAttribute("href", Tuple.Create(" href=\"", 8896), Tuple.Create("\"", 8970)
            
            #line 126 "..\..\Views\Shared\Components\UserCars.cshtml"
, Tuple.Create(Tuple.Create("", 8903), Tuple.Create<System.Object, System.Int32>(Url.Content("~/assets/images/svg/symbol/sprite.svg#chevron-right")
            
            #line default
            #line hidden
, 8903), false)
);

WriteLiteral("></use>\r\n                            </svg>\r\n                        </a>\r\n      " +
"              </div>\r\n");

            
            #line 130 "..\..\Views\Shared\Components\UserCars.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n</div>");

        }
    }
}
#pragma warning restore 1591
