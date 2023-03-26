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
    
    #line 2 "..\..\Views\Security\LogOn.cshtml"
    using ViewRes;
    
    #line default
    #line hidden
    
    #line 1 "..\..\Views\Security\LogOn.cshtml"
    using Webmall.Model;
    
    #line default
    #line hidden
    using Webmall.UI;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Security/LogOn.cshtml")]
    public partial class _Views_Security_LogOn_cshtml : System.Web.Mvc.WebViewPage<Webmall.UI.Models.LogOnModel>
    {
        public _Views_Security_LogOn_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 4 "..\..\Views\Security\LogOn.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";
    ViewBag.Title = SharedResources.Authorize;

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteLiteral(" class=\"container-fluid\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"content\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"auth-area\"");

WriteLiteral(">\r\n            <h1");

WriteLiteral(" class=\"auth-area__heading main-heading\"");

WriteLiteral(">");

            
            #line 12 "..\..\Views\Security\LogOn.cshtml"
                                                   Write(ViewBag.Title);

            
            #line default
            #line hidden
WriteLiteral("</h1>\r\n            <div");

WriteLiteral(" class=\"auth-area__top\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"auth-area__socials\"");

WriteLiteral(">\r\n                    <a");

WriteLiteral(" class=\"auth-area__social soc-btn\"");

WriteLiteral(" href=\"#\"");

WriteLiteral(">\r\n                        <img");

WriteLiteral(" class=\"soc-btn__icon\"");

WriteAttribute("src", Tuple.Create(" src=\"", 557), Tuple.Create("\"", 605)
            
            #line 16 "..\..\Views\Security\LogOn.cshtml"
, Tuple.Create(Tuple.Create("", 563), Tuple.Create<System.Object, System.Int32>(Url.Content("~/assets/images/google.png")
            
            #line default
            #line hidden
, 563), false)
);

WriteLiteral(" alt=\"google\"");

WriteLiteral(" width=\"35\"");

WriteLiteral(" height=\"35\"");

WriteLiteral(">\r\n                        <span");

WriteLiteral(" class=\"soc-btn__text\"");

WriteLiteral(">\r\n                            Войти с помощью <strong>Google</strong>\r\n         " +
"               </span>\r\n                    </a>\r\n                    <a");

WriteLiteral(" class=\"auth-area__social soc-btn\"");

WriteLiteral(" href=\"#\"");

WriteLiteral(">\r\n                        <img");

WriteLiteral(" class=\"soc-btn__icon\"");

WriteAttribute("src", Tuple.Create(" src=\"", 945), Tuple.Create("\"", 995)
            
            #line 22 "..\..\Views\Security\LogOn.cshtml"
, Tuple.Create(Tuple.Create("", 951), Tuple.Create<System.Object, System.Int32>(Url.Content("~/assets/images/facebook.png")
            
            #line default
            #line hidden
, 951), false)
);

WriteLiteral(" alt=\"facebook\"");

WriteLiteral(" width=\"35\"");

WriteLiteral(" height=\"35\"");

WriteLiteral(">\r\n                        <span");

WriteLiteral(" class=\"soc-btn__text\"");

WriteLiteral(">\r\n                            Войти с помощью <strong>Facebook</strong>\r\n       " +
"                 </span>\r\n                    </a>\r\n                </div>\r\n    " +
"        </div>\r\n");

            
            #line 29 "..\..\Views\Security\LogOn.cshtml"
            
            
            #line default
            #line hidden
            
            #line 29 "..\..\Views\Security\LogOn.cshtml"
             using (Html.BeginForm("Logon", "Security", FormMethod.Post, new { @class = "auth-form auth-area__main", name = "auth-form" }))
            {
                
            
            #line default
            #line hidden
            
            #line 31 "..\..\Views\Security\LogOn.cshtml"
           Write(Html.ValidationSummary(true, SharedResources.ErrorsFound));

            
            #line default
            #line hidden
            
            #line 31 "..\..\Views\Security\LogOn.cshtml"
                                                                          

            
            #line default
            #line hidden
WriteLiteral("                <div");

WriteLiteral(" class=\"auth-form__fields\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"auth-form__field\"");

WriteLiteral(">\r\n                        <label");

WriteLiteral(" class=\"auth-form__caption\"");

WriteLiteral(" for=\"auth-field-1\"");

WriteLiteral(">");

            
            #line 34 "..\..\Views\Security\LogOn.cshtml"
                                                                        Write(SharedResources.Login);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n                        <input");

WriteLiteral(" class=\"auth-form__input input\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(" name=\"UserName\"");

WriteLiteral(" id=\"user-email\"");

WriteLiteral(">\r\n                    </div>\r\n                    <div");

WriteLiteral(" class=\"auth-form__field\"");

WriteLiteral(">\r\n                        <label");

WriteLiteral(" class=\"auth-form__caption\"");

WriteLiteral(" for=\"auth-field-2\"");

WriteLiteral(">");

            
            #line 38 "..\..\Views\Security\LogOn.cshtml"
                                                                        Write(SharedResources.Password);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n                        <input");

WriteLiteral(" class=\"auth-form__input input\"");

WriteLiteral(" type=\"password\"");

WriteLiteral(" name=\"pass\"");

WriteLiteral(" id=\"user-psw\"");

WriteLiteral(">\r\n                    </div>\r\n                </div>\r\n");

WriteLiteral("                <div");

WriteLiteral(" class=\"auth-form__bottom\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"auth-form__checkbox checkbox-label\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" class=\"checkbox-label__input\"");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" name=\"RememberMe\"");

WriteLiteral(" id=\"remember\"");

WriteLiteral(" value=\"true\"");

WriteLiteral(" ");

            
            #line 44 "..\..\Views\Security\LogOn.cshtml"
                                                                                                                      Write(Model.RememberMe ? "checked=\"checked\"" : "");

            
            #line default
            #line hidden
WriteLiteral(">\r\n                        <label");

WriteLiteral(" class=\"checkbox-label__main\"");

WriteLiteral(" for=\"remember\"");

WriteLiteral(">");

            
            #line 45 "..\..\Views\Security\LogOn.cshtml"
                                                                      Write(SecurityResources.RememberMe);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n                    </div>\r\n                    <button");

WriteLiteral(" class=\"auth-form__btn btn btn--primary\"");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" name=\"send\"");

WriteLiteral(">");

            
            #line 47 "..\..\Views\Security\LogOn.cshtml"
                                                                                         Write(SharedResources.Enter);

            
            #line default
            #line hidden
WriteLiteral("</button>\r\n                </div>\r\n");

WriteLiteral("                <div");

WriteLiteral(" class=\"auth-form__links\"");

WriteLiteral(">\r\n                    <a");

WriteLiteral(" class=\"auth-form__link\"");

WriteAttribute("href", Tuple.Create(" href=\"", 2844), Tuple.Create("\"", 2882)
            
            #line 50 "..\..\Views\Security\LogOn.cshtml"
, Tuple.Create(Tuple.Create("", 2851), Tuple.Create<System.Object, System.Int32>(Url.Action("PasswordRecovery")
            
            #line default
            #line hidden
, 2851), false)
);

WriteLiteral(">");

            
            #line 50 "..\..\Views\Security\LogOn.cshtml"
                                                                                 Write(SecurityResources.AreYouForgetPassword);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n");

            
            #line 51 "..\..\Views\Security\LogOn.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 51 "..\..\Views\Security\LogOn.cshtml"
                     if (ConfigHelper.AllowAutoRegistration)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <a");

WriteLiteral(" class=\"auth-form__link\"");

WriteAttribute("href", Tuple.Create(" href=\"", 3064), Tuple.Create("\"", 3110)
            
            #line 53 "..\..\Views\Security\LogOn.cshtml"
, Tuple.Create(Tuple.Create("", 3071), Tuple.Create<System.Object, System.Int32>(Url.Action("Registration", "Security")
            
            #line default
            #line hidden
, 3071), false)
);

WriteLiteral(">");

            
            #line 53 "..\..\Views\Security\LogOn.cshtml"
                                                                                             Write(SharedResources.Registration);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n");

            
            #line 54 "..\..\Views\Security\LogOn.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </div>\r\n");

            
            #line 56 "..\..\Views\Security\LogOn.cshtml"
                
            
            #line default
            #line hidden
            
            #line 56 "..\..\Views\Security\LogOn.cshtml"
           Write(Html.Hidden("ReturnUrl", Model.ReturnUrl));

            
            #line default
            #line hidden
            
            #line 56 "..\..\Views\Security\LogOn.cshtml"
                                                          
            }

            
            #line default
            #line hidden
WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n\r\n");

WriteLiteral("\r\n");

WriteLiteral("\r\n\r\n");

        }
    }
}
#pragma warning restore 1591
