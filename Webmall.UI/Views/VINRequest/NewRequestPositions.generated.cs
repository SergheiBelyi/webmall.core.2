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
    
    #line 1 "..\..\Views\VINRequest\NewRequestPositions.cshtml"
    using ViewRes;
    
    #line default
    #line hidden
    using Webmall.UI;
    
    #line 2 "..\..\Views\VINRequest\NewRequestPositions.cshtml"
    using Webmall.UI.Core;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/VINRequest/NewRequestPositions.cshtml")]
    public partial class _Views_VINRequest_NewRequestPositions_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_VINRequest_NewRequestPositions_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("    ");

            
            #line 3 "..\..\Views\VINRequest\NewRequestPositions.cshtml"
      
        Layout = null;
        var list = SessionHelper.CurrentUser.VINRequestPositions;
    
            
            #line default
            #line hidden
WriteLiteral("\n<div");

WriteLiteral(" id=\"reqPos\"");

WriteLiteral(" class=\"table-responsive\"");

WriteLiteral(">\n");

            
            #line 8 "..\..\Views\VINRequest\NewRequestPositions.cshtml"
    
            
            #line default
            #line hidden
            
            #line 8 "..\..\Views\VINRequest\NewRequestPositions.cshtml"
     if (list.Count > 0)
    {

            
            #line default
            #line hidden
WriteLiteral("        <table");

WriteLiteral(" class=\"table\"");

WriteLiteral(">\n            <thead>\n                <tr>\r\n                    <th>");

            
            #line 13 "..\..\Views\VINRequest\NewRequestPositions.cshtml"
                   Write(SharedResources.Name);

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                    <th>");

            
            #line 14 "..\..\Views\VINRequest\NewRequestPositions.cshtml"
                   Write(SharedResources.Amount);

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                    <th></th>\r\n                </tr>\n            </thead>\n" +
"");

            
            #line 18 "..\..\Views\VINRequest\NewRequestPositions.cshtml"
            
            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\VINRequest\NewRequestPositions.cshtml"
             foreach (var mark in list)
            {

            
            #line default
            #line hidden
WriteLiteral("                <tr>\n                    <td>");

            
            #line 21 "..\..\Views\VINRequest\NewRequestPositions.cshtml"
                   Write(mark.Description);

            
            #line default
            #line hidden
WriteLiteral("</td>\n                    <td>");

            
            #line 22 "..\..\Views\VINRequest\NewRequestPositions.cshtml"
                   Write(mark.Quantity);

            
            #line default
            #line hidden
WriteLiteral("</td>\n                    <td");

WriteLiteral(" class=\"left\"");

WriteLiteral(">\n                        <img");

WriteAttribute("alt", Tuple.Create(" alt=\"", 698), Tuple.Create("\"", 727)
            
            #line 24 "..\..\Views\VINRequest\NewRequestPositions.cshtml"
, Tuple.Create(Tuple.Create("", 704), Tuple.Create<System.Object, System.Int32>(SharedResources.Delete
            
            #line default
            #line hidden
, 704), false)
);

WriteAttribute("title", Tuple.Create(" title=\"", 728), Tuple.Create("\"", 759)
            
            #line 24 "..\..\Views\VINRequest\NewRequestPositions.cshtml"
, Tuple.Create(Tuple.Create("", 736), Tuple.Create<System.Object, System.Int32>(SharedResources.Delete
            
            #line default
            #line hidden
, 736), false)
);

WriteLiteral(" class=\"clickable\"");

WriteAttribute("src", Tuple.Create("\n                             src=\"", 778), Tuple.Create("\"", 864)
            
            #line 25 "..\..\Views\VINRequest\NewRequestPositions.cshtml"
, Tuple.Create(Tuple.Create("", 813), Tuple.Create<System.Object, System.Int32>(Url.Content("~/Content/images/cancel-compare.gif")
            
            #line default
            #line hidden
, 813), false)
);

WriteLiteral(" width=\"11\"");

WriteLiteral(" height=\"11\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 888), Tuple.Create("\"", 961)
, Tuple.Create(Tuple.Create("", 898), Tuple.Create("updatePositionsPanel(\'", 898), true)
            
            #line 25 "..\..\Views\VINRequest\NewRequestPositions.cshtml"
                                                              , Tuple.Create(Tuple.Create("", 920), Tuple.Create<System.Object, System.Int32>(mark.Description
            
            #line default
            #line hidden
, 920), false)
, Tuple.Create(Tuple.Create("", 937), Tuple.Create("\',", 937), true)
, Tuple.Create(Tuple.Create(" ", 939), Tuple.Create("0,", 940), true)
, Tuple.Create(Tuple.Create(" ", 942), Tuple.Create("\'d\');return", 943), true)
, Tuple.Create(Tuple.Create(" ", 954), Tuple.Create("false;", 955), true)
);

WriteLiteral(">\n                    </td>\n                </tr>\n");

            
            #line 28 "..\..\Views\VINRequest\NewRequestPositions.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("        </table>\n");

            
            #line 30 "..\..\Views\VINRequest\NewRequestPositions.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("</div>");

        }
    }
}
#pragma warning restore 1591
