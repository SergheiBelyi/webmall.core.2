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
    using Webmall.UI;
    
    #line 1 "..\..\Views\Shared\GridViewFooterScripts.cshtml"
    using Webmall.UI.Core;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/GridViewFooterScripts.cshtml")]
    public partial class _Views_Shared_GridViewFooterScripts_cshtml : System.Web.Mvc.WebViewPage<GridViewOptions>
    {
        public _Views_Shared_GridViewFooterScripts_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\n");

WriteLiteral("\n<script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(">\n    document.GridViewFooter_Model_SortTypeCookieName = \'");

            
            #line 7 "..\..\Views\Shared\GridViewFooterScripts.cshtml"
                                                   Write(Model.SortTypeCookieName);

            
            #line default
            #line hidden
WriteLiteral("\';\n    document.GridViewFooter_Model_SortDirCookieName = \'");

            
            #line 8 "..\..\Views\Shared\GridViewFooterScripts.cshtml"
                                                  Write(Model.SortDirCookieName);

            
            #line default
            #line hidden
WriteLiteral("\';\n</script>\n\n");

            
            #line 11 "..\..\Views\Shared\GridViewFooterScripts.cshtml"
Write(Scripts.Render("~/bundles/views/gridViewFooter"));

            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
