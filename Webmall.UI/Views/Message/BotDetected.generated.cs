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
    
    #line 2 "..\..\Views\Message\BotDetected.cshtml"
    using ViewRes;
    
    #line default
    #line hidden
    
    #line 1 "..\..\Views\Message\BotDetected.cshtml"
    using Webmall.Model;
    
    #line default
    #line hidden
    using Webmall.UI;
    
    #line 3 "..\..\Views\Message\BotDetected.cshtml"
    using Webmall.UI.Core;
    
    #line default
    #line hidden
    using Webmall.UI.Core.Localization;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Message/BotDetected.cshtml")]
    public partial class _Views_Message_BotDetected_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_Message_BotDetected_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 4 "..\..\Views\Message\BotDetected.cshtml"
  
    ViewBag.Title = String.IsNullOrEmpty((string)TempData["Title"]) ? SharedResources.Message : TempData["Title"];
    Layout = "~/Views/Shared/_Layout.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteLiteral(" class=\"container-fluid\"");

WriteLiteral(">\r\n    <main");

WriteLiteral(" class=\"search-result\"");

WriteLiteral(">\r\n        <h1");

WriteLiteral(" class=\"main-title\"");

WriteLiteral(">");

            
            #line 11 "..\..\Views\Message\BotDetected.cshtml"
                          Write(SharedResources.Message);

            
            #line default
            #line hidden
WriteLiteral("</h1>\r\n        <h3>Системе показалось, что Вы бот и она Вас заблокировала. Если э" +
"то не так, обратитесь к администратору!</h3>\r\n");

            
            #line 13 "..\..\Views\Message\BotDetected.cshtml"
        
            
            #line default
            #line hidden
            
            #line 13 "..\..\Views\Message\BotDetected.cshtml"
         using (Html.BeginForm("BotDetectedClearing", "Security", FormMethod.Post, new {id = "register-form"}))
        {

            
            #line default
            #line hidden
WriteLiteral("            <label>\r\n");

WriteLiteral("                ");

            
            #line 16 "..\..\Views\Message\BotDetected.cshtml"
           Write(SecurityResources.ConfirmYouAreNotRobot);

            
            #line default
            #line hidden
WriteLiteral("\r\n                <div");

WriteLiteral(" id=\"Recaptcha1\"");

WriteLiteral("></div>\r\n            </label>\r\n");

            
            #line 19 "..\..\Views\Message\BotDetected.cshtml"
            
            
            #line default
            #line hidden
            
            #line 19 "..\..\Views\Message\BotDetected.cshtml"
       Write(Html.SubmitButton(SharedResources.Confirmation));

            
            #line default
            #line hidden
            
            #line 19 "..\..\Views\Message\BotDetected.cshtml"
                                                            
        }

            
            #line default
            #line hidden
WriteLiteral("    </main>\r\n</div>\r\n\r\n");

DefineSection("headerScript", () => {

WriteLiteral("\r\n    <script");

WriteLiteral(" src=\"//www.google.com/recaptcha/api.js?onload=CaptchaCallback&render=explicit\"");

WriteLiteral(" async defer></script>\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\r\n        var CaptchaCallback = function () {\r\n            window.grecaptcha.ren" +
"der(\'Recaptcha1\', { \'sitekey\': \'");

            
            #line 29 "..\..\Views\Message\BotDetected.cshtml"
                                                            Write(ConfigHelper.CaptchaSiteKey);

            
            #line default
            #line hidden
WriteLiteral("\' });\r\n        };\r\n    </script>\r\n");

});

        }
    }
}
#pragma warning restore 1591
