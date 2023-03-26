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
    
    #line 1 "..\..\Views\Security\PasswordRecoveryPinCheck.cshtml"
    using ViewRes;
    
    #line default
    #line hidden
    using Webmall.UI;
    using Webmall.UI.Core.Localization;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Security/PasswordRecoveryPinCheck.cshtml")]
    public partial class _Views_Security_PasswordRecoveryPinCheck_cshtml : System.Web.Mvc.WebViewPage<Webmall.UI.Models.PinCode>
    {
        public _Views_Security_PasswordRecoveryPinCheck_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 4 "..\..\Views\Security\PasswordRecoveryPinCheck.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";
    ViewBag.Title = SharedResources.ChangePassword_Cap;
    var minutes = (Model.ValidTo - DateTime.Now).TotalMinutes;
    var text = (minutes > 1)
        ? $"<strong id=\"timer\">{Math.Round(minutes)}</strong> {SecurityResources.Minutes}"
        : $"<strong id=\"timer\">{Math.Round(minutes * 60)}</strong> {SecurityResources.Seconds}";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteLiteral(" class=\"container-fluid\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"content\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"restore\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"restore__img-wrap\"");

WriteLiteral(">\r\n                <img");

WriteLiteral(" class=\"restore__img\"");

WriteAttribute("src", Tuple.Create(" src=\"", 628), Tuple.Create("\"", 686)
            
            #line 17 "..\..\Views\Security\PasswordRecoveryPinCheck.cshtml"
, Tuple.Create(Tuple.Create("", 634), Tuple.Create<System.Object, System.Int32>(Url.Content("~/assets/images/restore-password.svg")
            
            #line default
            #line hidden
, 634), false)
);

WriteLiteral(" alt=\"\"");

WriteLiteral(" width=\"620\"");

WriteLiteral(" height=\"640\"");

WriteLiteral(">\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"restore__main\"");

WriteLiteral(">\r\n                <!-- restore-form-->\r\n                <div");

WriteLiteral(" class=\"restore__form restore-form\"");

WriteLiteral(">\r\n                    <img");

WriteLiteral(" class=\"restore-form__img\"");

WriteAttribute("src", Tuple.Create(" src=\"", 929), Tuple.Create("\"", 975)
            
            #line 22 "..\..\Views\Security\PasswordRecoveryPinCheck.cshtml"
, Tuple.Create(Tuple.Create("", 935), Tuple.Create<System.Object, System.Int32>(Url.Content("~/assets/images/lock.svg")
            
            #line default
            #line hidden
, 935), false)
);

WriteLiteral(" alt=\"\"");

WriteLiteral(" width=\"620\"");

WriteLiteral(" height=\"640\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"restore-form__heading\"");

WriteLiteral(">");

            
            #line 23 "..\..\Views\Security\PasswordRecoveryPinCheck.cshtml"
                                                  Write(SharedResources.ChangePassword_Cap);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");

            
            #line 24 "..\..\Views\Security\PasswordRecoveryPinCheck.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 24 "..\..\Views\Security\PasswordRecoveryPinCheck.cshtml"
                     using (Html.BeginForm("ChangePassword", "Security", FormMethod.Post, new { @class = "restore-form__main", id = "register-form", name = "auth-form" }))
                    {
                        
            
            #line default
            #line hidden
            
            #line 26 "..\..\Views\Security\PasswordRecoveryPinCheck.cshtml"
                   Write(Html.ValidationSummary(true, SharedResources.ErrorsFound));

            
            #line default
            #line hidden
            
            #line 26 "..\..\Views\Security\PasswordRecoveryPinCheck.cshtml"
                                                                                  

            
            #line default
            #line hidden
WriteLiteral("                        <div");

WriteLiteral(" class=\"restore-form__fields\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"restore-form__fields\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\"restore-form__field\"");

WriteLiteral(">\r\n                                    <label");

WriteLiteral(" class=\"restore-form__caption\"");

WriteLiteral(" for=\"pinCode\"");

WriteLiteral(">");

            
            #line 30 "..\..\Views\Security\PasswordRecoveryPinCheck.cshtml"
                                                                                  Write(SharedResources.EnterPinCode);

            
            #line default
            #line hidden
WriteLiteral(" <span>*</span></label>\r\n");

WriteLiteral("                                    ");

            
            #line 31 "..\..\Views\Security\PasswordRecoveryPinCheck.cshtml"
                               Write(Html.TextBox("pinCode", null, new { @class = "restore-form__input input" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                    ");

            
            #line 32 "..\..\Views\Security\PasswordRecoveryPinCheck.cshtml"
                               Write(Html.ActionLink(SharedResources.ResendPin, "ResendPin", null, new { @class = "restore-form__control" }));

            
            #line default
            #line hidden
WriteLiteral(";\r\n                                </div>\r\n                                <div");

WriteLiteral(" class=\"restore-form__field\"");

WriteLiteral(">\r\n                                    <label");

WriteLiteral(" class=\"restore-form__caption\"");

WriteLiteral(" for=\"password\"");

WriteLiteral(">");

            
            #line 35 "..\..\Views\Security\PasswordRecoveryPinCheck.cshtml"
                                                                                   Write(SharedResources.Password);

            
            #line default
            #line hidden
WriteLiteral(" <span>*</span></label>\r\n");

WriteLiteral("                                    ");

            
            #line 36 "..\..\Views\Security\PasswordRecoveryPinCheck.cshtml"
                               Write(Html.Password("password", null, new { @class = "restore-form__input input" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </div>\r\n                                <div");

WriteLiteral(" class=\"restore-form__field\"");

WriteLiteral(">\r\n                                    <label");

WriteLiteral(" class=\"restore-form__caption\"");

WriteLiteral(" for=\"password2\"");

WriteLiteral(">");

            
            #line 39 "..\..\Views\Security\PasswordRecoveryPinCheck.cshtml"
                                                                                    Write(SharedResources.RepeatPassword);

            
            #line default
            #line hidden
WriteLiteral(" <span>*</span></label>\r\n");

WriteLiteral("                                    ");

            
            #line 40 "..\..\Views\Security\PasswordRecoveryPinCheck.cshtml"
                               Write(Html.Password("password2", null, new { @class = "restore-form__input input" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                    <div");

WriteLiteral(" class=\"restore-form__helper\"");

WriteLiteral(">\r\n");

WriteLiteral("                                        ");

            
            #line 42 "..\..\Views\Security\PasswordRecoveryPinCheck.cshtml"
                                   Write(SecurityResources.AttemptsRemain);

            
            #line default
            #line hidden
WriteLiteral(": <strong>");

            
            #line 42 "..\..\Views\Security\PasswordRecoveryPinCheck.cshtml"
                                                                              Write(Model.AttemptsRemain);

            
            #line default
            #line hidden
WriteLiteral("</strong> ");

            
            #line 42 "..\..\Views\Security\PasswordRecoveryPinCheck.cshtml"
                                                                                                             Write(SecurityResources.InTime);

            
            #line default
            #line hidden
WriteLiteral(" ");

            
            #line 42 "..\..\Views\Security\PasswordRecoveryPinCheck.cshtml"
                                                                                                                                       Write(Html.Raw(text));

            
            #line default
            #line hidden
WriteLiteral("\r\n                                        <br>");

            
            #line 43 "..\..\Views\Security\PasswordRecoveryPinCheck.cshtml"
                                       Write(SharedResources.Email);

            
            #line default
            #line hidden
WriteLiteral(": <strong>");

            
            #line 43 "..\..\Views\Security\PasswordRecoveryPinCheck.cshtml"
                                                                       Write(Model.Owner);

            
            #line default
            #line hidden
WriteLiteral("</strong>\r\n                                    </div>\r\n                          " +
"      </div>\r\n                            </div>\r\n                        </div>" +
"\r\n");

WriteLiteral("                        <div");

WriteLiteral(" class=\"restore-form__bottom\"");

WriteLiteral(">\r\n                            <input");

WriteLiteral(" class=\"restore-form__btn btn btn--primary\"");

WriteLiteral(" type=\"submit\"");

WriteAttribute("value", Tuple.Create(" value=\"", 3339), Tuple.Create("\"", 3370)
            
            #line 49 "..\..\Views\Security\PasswordRecoveryPinCheck.cshtml"
                   , Tuple.Create(Tuple.Create("", 3347), Tuple.Create<System.Object, System.Int32>(SharedResources.Change
            
            #line default
            #line hidden
, 3347), false)
);

WriteLiteral(">\r\n                        </div>\r\n");

            
            #line 51 "..\..\Views\Security\PasswordRecoveryPinCheck.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </div><!-- /restore-form-->\r\n            </div>\r\n        </div><!" +
"-- /restore-->\r\n    </div>\r\n</div>\r\n\r\n");

        }
    }
}
#pragma warning restore 1591