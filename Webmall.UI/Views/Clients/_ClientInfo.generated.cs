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
    
    #line 1 "..\..\Views\Clients\_ClientInfo.cshtml"
    using ViewRes;
    
    #line default
    #line hidden
    using Webmall.UI;
    using Webmall.UI.Core.Localization;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Clients/_ClientInfo.cshtml")]
    public partial class _Views_Clients__ClientInfo_cshtml : System.Web.Mvc.WebViewPage<Webmall.Model.Entities.Client.Client>
    {
        public _Views_Clients__ClientInfo_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 4 "..\..\Views\Clients\_ClientInfo.cshtml"
 if (Model != null)
{
    var managerInfo = Model.ManagerData;

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"profile__subsection\"");

WriteLiteral(">\r\n");

            
            #line 8 "..\..\Views\Clients\_ClientInfo.cshtml"
        
            
            #line default
            #line hidden
            
            #line 8 "..\..\Views\Clients\_ClientInfo.cshtml"
         if (!string.IsNullOrEmpty(Model.ManagerData?.Name))
        {

            
            #line default
            #line hidden
WriteLiteral("            <h2");

WriteLiteral(" class=\"profile__subheading secondary-heading\"");

WriteLiteral(">");

            
            #line 10 "..\..\Views\Clients\_ClientInfo.cshtml"
                                                         Write(SharedResources.ClientManager);

            
            #line default
            #line hidden
WriteLiteral("</h2>\r\n");

WriteLiteral("            <div");

WriteLiteral(" class=\"profile__params-area\"");

WriteLiteral(">\r\n                <dl");

WriteLiteral(" class=\"profile__params params is-dotted\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"params__param\"");

WriteLiteral(">\r\n                        <dt");

WriteLiteral(" class=\"params__property\"");

WriteLiteral(">");

            
            #line 14 "..\..\Views\Clients\_ClientInfo.cshtml"
                                                Write(SharedResources.ManagerName);

            
            #line default
            #line hidden
WriteLiteral("</dt>\r\n                        <dd");

WriteLiteral(" class=\"params__value\"");

WriteLiteral(">");

            
            #line 15 "..\..\Views\Clients\_ClientInfo.cshtml"
                                             Write(managerInfo.Name);

            
            #line default
            #line hidden
WriteLiteral("</dd>\r\n                    </div>\r\n                    <div");

WriteLiteral(" class=\"params__param\"");

WriteLiteral(">\r\n                        <dt");

WriteLiteral(" class=\"params__property\"");

WriteLiteral(">");

            
            #line 18 "..\..\Views\Clients\_ClientInfo.cshtml"
                                                Write(SharedResources.Email);

            
            #line default
            #line hidden
WriteLiteral("</dt>\r\n                        <dd");

WriteLiteral(" class=\"params__value\"");

WriteLiteral(">");

            
            #line 19 "..\..\Views\Clients\_ClientInfo.cshtml"
                                             Write(managerInfo.Email);

            
            #line default
            #line hidden
WriteLiteral("</dd>\r\n                    </div>\r\n                    <div");

WriteLiteral(" class=\"params__param\"");

WriteLiteral(">\r\n                        <dt");

WriteLiteral(" class=\"params__property\"");

WriteLiteral(">");

            
            #line 22 "..\..\Views\Clients\_ClientInfo.cshtml"
                                                Write(SharedResources.Phone);

            
            #line default
            #line hidden
WriteLiteral("</dt>\r\n                        <dd");

WriteLiteral(" class=\"params__value\"");

WriteLiteral(">");

            
            #line 23 "..\..\Views\Clients\_ClientInfo.cshtml"
                                             Write(managerInfo.Phone);

            
            #line default
            #line hidden
WriteLiteral("</dd>\r\n                    </div>\r\n                </dl>\r\n            </div>\r\n");

            
            #line 27 "..\..\Views\Clients\_ClientInfo.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("    </div>\r\n");

            
            #line 29 "..\..\Views\Clients\_ClientInfo.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\r\n");

        }
    }
}
#pragma warning restore 1591
