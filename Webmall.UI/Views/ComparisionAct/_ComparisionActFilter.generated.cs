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
    
    #line 1 "..\..\Views\ComparisionAct\_ComparisionActFilter.cshtml"
    using ViewRes;
    
    #line default
    #line hidden
    using Webmall.UI;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/ComparisionAct/_ComparisionActFilter.cshtml")]
    public partial class _Views_ComparisionAct__ComparisionActFilter_cshtml : System.Web.Mvc.WebViewPage<Webmall.UI.Models.ComparisionActModel>
    {
        public _Views_ComparisionAct__ComparisionActFilter_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

WriteLiteral("<!-- comparision act filter-->\r\n<div");

WriteLiteral(" class=\"orders-filter\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"orders-filter__heading d-md-none\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 8 "..\..\Views\ComparisionAct\_ComparisionActFilter.cshtml"
   Write(SharedResources.ComparisionActFilter);

            
            #line default
            #line hidden
WriteLiteral("\r\n        <button");

WriteLiteral(" class=\"orders-filter__close d-md-none\"");

WriteLiteral(">\r\n            <svg");

WriteLiteral(" class=\"icon icon-close orders-filter__close-icon\"");

WriteLiteral(">\r\n                <use");

WriteAttribute("href", Tuple.Create(" href=\"", 372), Tuple.Create("\"", 438)
            
            #line 11 "..\..\Views\ComparisionAct\_ComparisionActFilter.cshtml"
, Tuple.Create(Tuple.Create("", 379), Tuple.Create<System.Object, System.Int32>(Url.Content("~/assets/images/svg/symbol/sprite.svg#close")
            
            #line default
            #line hidden
, 379), false)
);

WriteLiteral("></use>\r\n            </svg>\r\n        </button>\r\n    </div>\r\n");

            
            #line 15 "..\..\Views\ComparisionAct\_ComparisionActFilter.cshtml"
    
            
            #line default
            #line hidden
            
            #line 15 "..\..\Views\ComparisionAct\_ComparisionActFilter.cshtml"
     using (Html.BeginForm("Index", "ComparisionAct", FormMethod.Post, new { @class = "orders-filter__main" }))
    {

            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"col-md-9\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"row align-items-center\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"col-md-2\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"orders-filter__date-picker-title\"");

WriteLiteral(">");

            
            #line 21 "..\..\Views\ComparisionAct\_ComparisionActFilter.cshtml"
                                                                 Write(SharedResources.ForPeriod);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                    </div>\r\n                    <div");

WriteLiteral(" class=\"col-md-5\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"orders-filter__date-picker-main\"");

WriteLiteral(">\r\n                            <input");

WriteLiteral(" class=\"orders-filter__date-from\"");

WriteLiteral(" id=\"StartDate\"");

WriteLiteral(" type=\"date\"");

WriteLiteral(" name=\"StartDate\"");

WriteAttribute("placeholder", Tuple.Create(" placeholder=\"", 1138), Tuple.Create("\"", 1179)
            
            #line 25 "..\..\Views\ComparisionAct\_ComparisionActFilter.cshtml"
                                             , Tuple.Create(Tuple.Create("", 1152), Tuple.Create<System.Object, System.Int32>(SharedResources.PeriodFrom
            
            #line default
            #line hidden
, 1152), false)
);

WriteAttribute("value", Tuple.Create(" value=\"", 1180), Tuple.Create("\"", 1233)
            
            #line 25 "..\..\Views\ComparisionAct\_ComparisionActFilter.cshtml"
                                                                                 , Tuple.Create(Tuple.Create("", 1188), Tuple.Create<System.Object, System.Int32>(Model.StartDateAsDate.ToString("yyyy-MM-dd")
            
            #line default
            #line hidden
, 1188), false)
);

WriteLiteral(">\r\n                            ");

WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                   " +
" <div");

WriteLiteral(" class=\"col-md-5\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"orders-filter__date-picker-main\"");

WriteLiteral(">\r\n                            <input");

WriteLiteral(" class=\"orders-filter__date-to\"");

WriteLiteral(" id=\"EndDate\"");

WriteLiteral(" type=\"date\"");

WriteLiteral(" name=\"EndDate\"");

WriteAttribute("placeholder", Tuple.Create(" placeholder=\"", 9867), Tuple.Create("\"", 9900)
            
            #line 38 "..\..\Views\ComparisionAct\_ComparisionActFilter.cshtml"
                                       , Tuple.Create(Tuple.Create("", 9881), Tuple.Create<System.Object, System.Int32>(SharedResources.to
            
            #line default
            #line hidden
, 9881), false)
);

WriteAttribute("value", Tuple.Create("  value=\"", 9901), Tuple.Create("\"", 9953)
            
            #line 38 "..\..\Views\ComparisionAct\_ComparisionActFilter.cshtml"
                                                                    , Tuple.Create(Tuple.Create("", 9910), Tuple.Create<System.Object, System.Int32>(Model.EndDateAsDate.ToString("yyyy-MM-dd")
            
            #line default
            #line hidden
, 9910), false)
);

WriteLiteral(">\r\n                            ");

WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                </d" +
"iv>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"col-md-3\"");

WriteLiteral(">\r\n                <input");

WriteLiteral(" class=\"orders-filter__btn btn btn--main\"");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" name=\"send-data\"");

WriteAttribute("value", Tuple.Create(" value=\"", 18541), Tuple.Create("\"", 18578)
            
            #line 52 "..\..\Views\ComparisionAct\_ComparisionActFilter.cshtml"
                     , Tuple.Create(Tuple.Create("", 18549), Tuple.Create<System.Object, System.Int32>(SharedResources.Reconciliate
            
            #line default
            #line hidden
, 18549), false)
);

WriteLiteral(">\r\n            </div>\r\n        </div>\r\n");

            
            #line 55 "..\..\Views\ComparisionAct\_ComparisionActFilter.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n\r\n");

        }
    }
}
#pragma warning restore 1591
