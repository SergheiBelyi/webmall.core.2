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
    
    #line 1 "..\..\Views\Clients\_Contacts.cshtml"
    using ViewRes;
    
    #line default
    #line hidden
    using Webmall.UI;
    using Webmall.UI.Core.Localization;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Clients/_Contacts.cshtml")]
    public partial class _Views_Clients__Contacts_cshtml : System.Web.Mvc.WebViewPage<Webmall.Model.Entities.Client.Client>
    {
        public _Views_Clients__Contacts_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 4 "..\..\Views\Clients\_Contacts.cshtml"
  
    Layout = null;

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 8 "..\..\Views\Clients\_Contacts.cshtml"
 if (Model?.Contacts != null)
{

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"addresses users__subsection\"");

WriteLiteral(">\r\n        <h2");

WriteLiteral(" class=\"profile__subheading secondary-heading\"");

WriteLiteral(">");

            
            #line 11 "..\..\Views\Clients\_Contacts.cshtml"
                                                     Write(SharedResources.Contacts);

            
            #line default
            #line hidden
WriteLiteral("</h2>\r\n        <div");

WriteLiteral(" class=\"addresses__header text-left\"");

WriteLiteral(">\r\n            <a");

WriteLiteral(" class=\"addresses__btn btn btn--primary\"");

WriteLiteral(" href=\"#\"");

WriteLiteral(" data-modal-win-trigger=\"contact-detail\"");

WriteLiteral("\r\n               id=\"contact-0\"");

WriteLiteral(" data-close-outside=\"false\"");

WriteLiteral(" data-after-open=\"UpdateContactDialog();\"");

WriteLiteral("\r\n               data-id=\"0\"");

WriteLiteral(" data-data=\"\"");

WriteLiteral(">");

            
            #line 15 "..\..\Views\Clients\_Contacts.cshtml"
                                   Write(SharedResources.NewContact);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"addresses__main\"");

WriteLiteral(">\r\n");

            
            #line 18 "..\..\Views\Clients\_Contacts.cshtml"
            
            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\Clients\_Contacts.cshtml"
             foreach (var item in Model.Contacts)
            {
                Html.RenderPartial("_ContactCard", item);
            }

            
            #line default
            #line hidden
WriteLiteral("        </div>\r\n\r\n    </div>\r\n");

            
            #line 25 "..\..\Views\Clients\_Contacts.cshtml"
}
            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591