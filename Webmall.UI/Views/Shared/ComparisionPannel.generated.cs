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
    
    #line 1 "..\..\Views\Shared\ComparisionPannel.cshtml"
    using System.Linq;
    
    #line default
    #line hidden
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
    
    #line 2 "..\..\Views\Shared\ComparisionPannel.cshtml"
    using ViewRes;
    
    #line default
    #line hidden
    using Webmall.UI;
    
    #line 3 "..\..\Views\Shared\ComparisionPannel.cshtml"
    using Webmall.UI.Core;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/ComparisionPannel.cshtml")]
    public partial class _Views_Shared_ComparisionPannel_cshtml : System.Web.Mvc.WebViewPage<Webmall.UI.Models.WareComparision.ComparisionList>
    {
        public _Views_Shared_ComparisionPannel_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 5 "..\..\Views\Shared\ComparisionPannel.cshtml"
  
    Layout = null;
    var currentParentLink = UserPreferences.CurrentCultureLink + "/";

            
            #line default
            #line hidden
WriteLiteral("           \n");

            
            #line 9 "..\..\Views\Shared\ComparisionPannel.cshtml"
 if (Model.Any())
{

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" id=\"compare\"");

WriteLiteral(">\n        <h5>");

            
            #line 12 "..\..\Views\Shared\ComparisionPannel.cshtml"
        Write(SharedResources.WareComparision + " [" + Model.Count + "]");

            
            #line default
            #line hidden
WriteLiteral("</h5>\n");

            
            #line 13 "..\..\Views\Shared\ComparisionPannel.cshtml"
        
            
            #line default
            #line hidden
            
            #line 13 "..\..\Views\Shared\ComparisionPannel.cshtml"
         foreach (var ware in Model)
        {

            
            #line default
            #line hidden
WriteLiteral("            <p>\n                <a");

WriteAttribute("href", Tuple.Create(" href=\"", 422), Tuple.Create("\"", 478)
            
            #line 16 "..\..\Views\Shared\ComparisionPannel.cshtml"
, Tuple.Create(Tuple.Create("", 429), Tuple.Create<System.Object, System.Int32>(Url.Content("~/" + currentParentLink + ware.URL)
            
            #line default
            #line hidden
, 429), false)
);

WriteLiteral(">");

            
            #line 16 "..\..\Views\Shared\ComparisionPannel.cshtml"
                                                                       Write(ware.Name);

            
            #line default
            #line hidden
WriteLiteral("</a>\n                <a");

WriteLiteral(" class=\"delete\"");

WriteLiteral(" href=\"\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 536), Tuple.Create("\"", 588)
, Tuple.Create(Tuple.Create("", 546), Tuple.Create("RemoveComparision(", 546), true)
            
            #line 17 "..\..\Views\Shared\ComparisionPannel.cshtml"
, Tuple.Create(Tuple.Create("", 564), Tuple.Create<System.Object, System.Int32>(ware.Id
            
            #line default
            #line hidden
, 564), false)
, Tuple.Create(Tuple.Create("", 572), Tuple.Create(");", 572), true)
, Tuple.Create(Tuple.Create(" ", 574), Tuple.Create("return", 575), true)
, Tuple.Create(Tuple.Create(" ", 581), Tuple.Create("false;", 582), true)
);

WriteAttribute("title", Tuple.Create(" title=\"", 589), Tuple.Create("\"", 635)
            
            #line 17 "..\..\Views\Shared\ComparisionPannel.cshtml"
                       , Tuple.Create(Tuple.Create("", 597), Tuple.Create<System.Object, System.Int32>(SharedResources.RemoveFromComparision
            
            #line default
            #line hidden
, 597), false)
);

WriteLiteral("></a>\n            </p>\n");

            
            #line 19 "..\..\Views\Shared\ComparisionPannel.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("        \n");

            
            #line 21 "..\..\Views\Shared\ComparisionPannel.cshtml"
        
            
            #line default
            #line hidden
            
            #line 21 "..\..\Views\Shared\ComparisionPannel.cshtml"
         if (Model.Count > 1)
        {
            
            
            #line default
            #line hidden
            
            #line 23 "..\..\Views\Shared\ComparisionPannel.cshtml"
       Write(Html.ActionLink(SharedResources.GotoComparision, "Index", "Compare", null, new { @class = "compare-link" }));

            
            #line default
            #line hidden
            
            #line 23 "..\..\Views\Shared\ComparisionPannel.cshtml"
                                                                                                                        
        }

            
            #line default
            #line hidden
WriteLiteral("    </div>\n");

            
            #line 26 "..\..\Views\Shared\ComparisionPannel.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\n");

        }
    }
}
#pragma warning restore 1591
