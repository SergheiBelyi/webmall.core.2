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
    
    #line 1 "..\..\Views\Garage\CarDialog.cshtml"
    using ViewRes;
    
    #line default
    #line hidden
    using Webmall.UI;
    using Webmall.UI.Core.Localization;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Garage/CarDialog.cshtml")]
    public partial class _Views_Garage_CarDialog_cshtml : System.Web.Mvc.WebViewPage<Webmall.UI.ViewModel.Garage.GarageViewModel>
    {
        public _Views_Garage_CarDialog_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

WriteLiteral("<div");

WriteLiteral(" class=\"modal-content\"");

WriteLiteral(" data-modal-win=\"address-detail\"");

WriteLiteral(" hidden>\r\n    <form");

WriteLiteral(" class=\"add-modal\"");

WriteLiteral(" method=\"POST\"");

WriteAttribute("action", Tuple.Create(" action=\"", 181), Tuple.Create("\"", 212)
            
            #line 6 "..\..\Views\Garage\CarDialog.cshtml"
, Tuple.Create(Tuple.Create("", 190), Tuple.Create<System.Object, System.Int32>(Url.Action("SaveCar")
            
            #line default
            #line hidden
, 190), false)
);

WriteLiteral(" name=\"product-add\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"modal-content\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"modal-content__header\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"modal-content__heading\"");

WriteLiteral(">");

            
            #line 9 "..\..\Views\Garage\CarDialog.cshtml"
                                               Write(SharedResources.AutoData);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"managed managed-delivery-address\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                    <input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" id =\"CarId\" name=\"Id\"/>\r\n                    <div");

WriteLiteral(" class=\"col-sm-2\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"main-form__field\"");

WriteLiteral(">\r\n                            <label");

WriteLiteral(" class=\"main-form__label\"");

WriteLiteral(" for=\"Marka\"");

WriteLiteral(">");

            
            #line 16 "..\..\Views\Garage\CarDialog.cshtml"
                                                                   Write(SharedResources.AutoMarka);

            
            #line default
            #line hidden
WriteLiteral(" <span>*</span></label>\r\n");

WriteLiteral("                            ");

            
            #line 17 "..\..\Views\Garage\CarDialog.cshtml"
                       Write(Html.DropDownList("MarkaId", Model.AutoMarks.Select(i => new SelectListItem {Value = i.Id, Text = i.Name}),
                                new {id = "Marka", @class = "", onchange = "MarkaSelected()"}));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                   " +
" <div");

WriteLiteral(" class=\"col-sm-2\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"main-form__field\"");

WriteLiteral(">\r\n                            <label");

WriteLiteral(" class=\"main-form__label\"");

WriteLiteral(" for=\"Model\"");

WriteLiteral(">");

            
            #line 23 "..\..\Views\Garage\CarDialog.cshtml"
                                                                   Write(SharedResources.AutoModel);

            
            #line default
            #line hidden
WriteLiteral(" <span>*</span></label>\r\n");

WriteLiteral("                            ");

            
            #line 24 "..\..\Views\Garage\CarDialog.cshtml"
                       Write(Html.DropDownList("ModelId", new List<SelectListItem>(),
                                new {id = "Model", onchange = "ModelSelected()"}));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n                        </div>\r\n                    </div>\r\n                <" +
"/div>\r\n                <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"col-sm-6\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"main-form__field\"");

WriteLiteral(">\r\n                            <label");

WriteLiteral(" class=\"main-form__label\"");

WriteLiteral(" for=\"Modification\"");

WriteLiteral(">");

            
            #line 33 "..\..\Views\Garage\CarDialog.cshtml"
                                                                          Write(SharedResources.AutoModification);

            
            #line default
            #line hidden
WriteLiteral(" <span>*</span></label>\r\n");

WriteLiteral("                            ");

            
            #line 34 "..\..\Views\Garage\CarDialog.cshtml"
                       Write(Html.DropDownList("ModificationId", new List<SelectListItem>(),
                                new {id = "Modification"}));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                </d" +
"iv>\r\n                <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"col-sm-6\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"main-form__field\"");

WriteLiteral(">\r\n                            <label");

WriteLiteral(" class=\"main-form__label\"");

WriteLiteral(" for=\"Vin\"");

WriteLiteral(">");

            
            #line 42 "..\..\Views\Garage\CarDialog.cshtml"
                                                                 Write(SharedResources.AutoVINCode);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n");

WriteLiteral("                            ");

            
            #line 43 "..\..\Views\Garage\CarDialog.cshtml"
                       Write(Html.TextBox("Vin", "", new {id = "Vin", @class = "profile-form__input input"}));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                </d" +
"iv>\r\n                <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"col-sm-6\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"main-form__field\"");

WriteLiteral(">\r\n                            <label");

WriteLiteral(" class=\"main-form__label\"");

WriteLiteral(" for=\"Year\"");

WriteLiteral(">");

            
            #line 50 "..\..\Views\Garage\CarDialog.cshtml"
                                                                  Write(SharedResources.YearOfProduce);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n");

WriteLiteral("                            ");

            
            #line 51 "..\..\Views\Garage\CarDialog.cshtml"
                       Write(Html.TextBox("Year", "", new {id = "Year", @class = "profile-form__input input", type = "number"}));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                </d" +
"iv>\r\n                <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"col-sm-6\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"main-form__field\"");

WriteLiteral(">\r\n                            <label");

WriteLiteral(" class=\"main-form__label\"");

WriteLiteral(" for=\"Comment\"");

WriteLiteral(">");

            
            #line 58 "..\..\Views\Garage\CarDialog.cshtml"
                                                                     Write(SharedResources.Note);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n");

WriteLiteral("                            ");

            
            #line 59 "..\..\Views\Garage\CarDialog.cshtml"
                       Write(Html.TextBox("Comment", "", new {id = "Comment", @class = "profile-form__input input"}));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                </d" +
"iv>\r\n                <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"col-sm-6\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"main-form__field\"");

WriteLiteral(">\r\n                            <label");

WriteLiteral(" class=\"main-form__label\"");

WriteLiteral(" for=\"Contacts\"");

WriteLiteral(">");

            
            #line 66 "..\..\Views\Garage\CarDialog.cshtml"
                                                                      Write(SharedResources.ContactInfo);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n");

WriteLiteral("                            ");

            
            #line 67 "..\..\Views\Garage\CarDialog.cshtml"
                       Write(Html.TextBox("Contacts", "", new {id = "Contacts", @class = "profile-form__input input"}));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                </d" +
"iv>\r\n            </div>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"add-modal__bottom\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" class=\"add-modal__btn btn btn--primary\"");

WriteLiteral(" type=\"submit\"");

WriteAttribute("value", Tuple.Create(" value=\"", 4036), Tuple.Create("\"", 4065)
            
            #line 74 "..\..\Views\Garage\CarDialog.cshtml"
    , Tuple.Create(Tuple.Create("", 4044), Tuple.Create<System.Object, System.Int32>(SharedResources.Save
            
            #line default
            #line hidden
, 4044), false)
);

WriteLiteral(">\r\n            </div>\r\n    </form>\r\n</div>");

        }
    }
}
#pragma warning restore 1591
