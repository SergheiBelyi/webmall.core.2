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
    using Webmall.UI;
    
    #line 1 "..\..\Views\Shared\Components\Logo.cshtml"
    using Webmall.UI.Core.Helpers;
    
    #line default
    #line hidden
    using Webmall.UI.Core.Localization;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/Components/Logo.cshtml")]
    public partial class _Views_Shared_Components_Logo_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_Shared_Components_Logo_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 3 "..\..\Views\Shared\Components\Logo.cshtml"
  
    var langHref = this.ToLocalizedUrl("/");

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteLiteral(" class=\"logo header__logo\"");

WriteLiteral(">\r\n    <a");

WriteLiteral(" class=\"logo__wrap\"");

WriteAttribute("href", Tuple.Create(" href=\"", 147), Tuple.Create("\"", 163)
            
            #line 8 "..\..\Views\Shared\Components\Logo.cshtml"
, Tuple.Create(Tuple.Create("", 154), Tuple.Create<System.Object, System.Int32>(langHref
            
            #line default
            #line hidden
, 154), false)
);

WriteLiteral(">\r\n        <img");

WriteLiteral(" class=\"logo__img img-responsive\"");

WriteAttribute("src", Tuple.Create(" src=\"", 212), Tuple.Create("\"", 258)
            
            #line 9 "..\..\Views\Shared\Components\Logo.cshtml"
, Tuple.Create(Tuple.Create("", 218), Tuple.Create<System.Object, System.Int32>(Url.Content("~/assets/images/logo.svg")
            
            #line default
            #line hidden
, 218), false)
);

WriteLiteral(" alt=\"\"");

WriteLiteral(" width=\"190\"");

WriteLiteral(" height=\"60\"");

WriteLiteral(" role=\"presentation\"");

WriteLiteral(">\r\n    </a>\r\n</div>");

        }
    }
}
#pragma warning restore 1591
