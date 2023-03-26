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
    
    #line 2 "..\..\Views\Layout\Dialogs\_AuthorizeDialog.cshtml"
    using ViewRes;
    
    #line default
    #line hidden
    
    #line 1 "..\..\Views\Layout\Dialogs\_AuthorizeDialog.cshtml"
    using Webmall.Model;
    
    #line default
    #line hidden
    using Webmall.UI;
    using Webmall.UI.Core.Localization;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Layout/Dialogs/_AuthorizeDialog.cshtml")]
    public partial class _Views_Layout_Dialogs__AuthorizeDialog_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_Layout_Dialogs__AuthorizeDialog_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"modal-content\"");

WriteLiteral(" data-modal-win=\"modal-auth\"");

WriteLiteral(" hidden>\r\n    <div");

WriteLiteral(" class=\"modal-content__heading modal-win-title\"");

WriteLiteral(">");

            
            #line 5 "..\..\Views\Layout\Dialogs\_AuthorizeDialog.cshtml"
                                                   Write(SharedResources.Authorize);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n    <div");

WriteLiteral(" class=\"modal-content__body\"");

WriteLiteral(">\r\n");

            
            #line 7 "..\..\Views\Layout\Dialogs\_AuthorizeDialog.cshtml"
        
            
            #line default
            #line hidden
            
            #line 7 "..\..\Views\Layout\Dialogs\_AuthorizeDialog.cshtml"
         using (Html.BeginForm("LogOn", "Security", FormMethod.Post, new { @class = "main-form", name = "auth-form", id = "auth-form-mob" }))
        {

            
            #line default
            #line hidden
WriteLiteral("            <div");

WriteLiteral(" class=\"main-form__field\"");

WriteLiteral(">\r\n                <label");

WriteLiteral(" class=\"main-form__label\"");

WriteLiteral(" for=\"user-email-mod\"");

WriteLiteral(">");

            
            #line 10 "..\..\Views\Layout\Dialogs\_AuthorizeDialog.cshtml"
                                                                Write(SharedResources.Email);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n                <input");

WriteLiteral(" class=\"main-form__input\"");

WriteLiteral(" type=\"email\"");

WriteLiteral(" name=\"UserName\"");

WriteLiteral(" id=\"user-email-mod\"");

WriteLiteral(">\r\n            </div>\r\n");

WriteLiteral("            <div");

WriteLiteral(" class=\"main-form__field\"");

WriteLiteral(">\r\n                <label");

WriteLiteral(" class=\"main-form__label\"");

WriteLiteral(" for=\"user-psw-mod\"");

WriteLiteral(">");

            
            #line 14 "..\..\Views\Layout\Dialogs\_AuthorizeDialog.cshtml"
                                                              Write(SharedResources.Password);

            
            #line default
            #line hidden
WriteLiteral(" <span>*</span>:</label>\r\n                <input");

WriteLiteral(" class=\"main-form__input\"");

WriteLiteral(" type=\"password\"");

WriteLiteral(" name=\"Pass\"");

WriteLiteral(" id=\"user-psw-mod\"");

WriteLiteral(">\r\n            </div>\r\n");

WriteLiteral("            <div");

WriteLiteral(" class=\"main-form__field main-form__field--flex\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"main-form__checkbox checkbox-label\"");

WriteLiteral(">\r\n                    <input");

WriteLiteral(" class=\"checkbox-label__input\"");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" name=\"is-remember\"");

WriteLiteral(" id=\"remember-psw-mod\"");

WriteLiteral(" ");

            
            #line 19 "..\..\Views\Layout\Dialogs\_AuthorizeDialog.cshtml"
                                                                                                              Write(ConfigHelper.IsDefaultRememberMe ? "checked=\"checked\"" : "");

            
            #line default
            #line hidden
WriteLiteral(">\r\n                    <label");

WriteLiteral(" class=\"checkbox-label__main\"");

WriteLiteral(" for=\"remember-psw-mod\"");

WriteLiteral(">");

            
            #line 20 "..\..\Views\Layout\Dialogs\_AuthorizeDialog.cshtml"
                                                                          Write(SecurityResources.RememberMe);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n                </div><a");

WriteLiteral(" class=\"main-form__recover-psw\"");

WriteAttribute("href", Tuple.Create(" href=\"", 1416), Tuple.Create("\"", 1466)
            
            #line 21 "..\..\Views\Layout\Dialogs\_AuthorizeDialog.cshtml"
, Tuple.Create(Tuple.Create("", 1423), Tuple.Create<System.Object, System.Int32>(Url.Action("PasswordRecovery", "Security")
            
            #line default
            #line hidden
, 1423), false)
);

WriteLiteral(">");

            
            #line 21 "..\..\Views\Layout\Dialogs\_AuthorizeDialog.cshtml"
                                                                                                      Write(SecurityResources.AreYouForgetPassword);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n            </div>\r\n");

WriteLiteral("            <div");

WriteLiteral(" class=\"main-form__footer text-center\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" class=\"main-form__btn btn btn--main btn--upper\"");

WriteLiteral(" type=\"submit\"");

WriteAttribute("value", Tuple.Create(" value=\"", 1674), Tuple.Create("\"", 1704)
            
            #line 24 "..\..\Views\Layout\Dialogs\_AuthorizeDialog.cshtml"
            , Tuple.Create(Tuple.Create("", 1682), Tuple.Create<System.Object, System.Int32>(SharedResources.Enter
            
            #line default
            #line hidden
, 1682), false)
);

WriteLiteral(">\r\n            </div>\r\n");

            
            #line 26 "..\..\Views\Layout\Dialogs\_AuthorizeDialog.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\"main-form__footer text-center\"");

WriteLiteral(">\r\n            <a");

WriteLiteral(" class=\"main-form__btn btn btn--main btn--upper\"");

WriteAttribute("href", Tuple.Create(" href=\"", 1854), Tuple.Create("\"", 1893)
            
            #line 28 "..\..\Views\Layout\Dialogs\_AuthorizeDialog.cshtml"
, Tuple.Create(Tuple.Create("", 1861), Tuple.Create<System.Object, System.Int32>(Url.Action("LogOn", "Security")
            
            #line default
            #line hidden
, 1861), false)
);

WriteLiteral(">");

            
            #line 28 "..\..\Views\Layout\Dialogs\_AuthorizeDialog.cshtml"
                                                                                                  Write(SharedResources.Registration);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n        </div>\r\n    </div>\r\n</div>\r\n");

        }
    }
}
#pragma warning restore 1591
