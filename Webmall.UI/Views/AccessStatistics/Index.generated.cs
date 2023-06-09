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
    
    #line 1 "..\..\Views\AccessStatistics\Index.cshtml"
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
    
    #line 2 "..\..\Views\AccessStatistics\Index.cshtml"
    using ViewRes;
    
    #line default
    #line hidden
    using Webmall.UI;
    
    #line 3 "..\..\Views\AccessStatistics\Index.cshtml"
    using Webmall.UI.Core;
    
    #line default
    #line hidden
    using Webmall.UI.Core.Localization;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/AccessStatistics/Index.cshtml")]
    public partial class _Views_AccessStatistics_Index_cshtml : System.Web.Mvc.WebViewPage<Webmall.UI.Models.AccessStatistics.AccessStatisticsModel>
    {
        public _Views_AccessStatistics_Index_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 7 "..\..\Views\AccessStatistics\Index.cshtml"
  
    ViewBag.Title = "Access statistics";
    Layout = "~/Views/Shared/_PersonalLayout.cshtml";

            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"table-responsive d-none d-md-block\"");

WriteLiteral(">\r\n    <table");

WriteLiteral(" class=\"stock-table table\"");

WriteLiteral(">\r\n        <thead>\r\n            <tr>\r\n                <th>");

            
            #line 15 "..\..\Views\AccessStatistics\Index.cshtml"
               Write(Html.SortColumnLink(Model.Items, "IP", "IP"));

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                ");

WriteLiteral("\r\n                <th>");

            
            #line 17 "..\..\Views\AccessStatistics\Index.cshtml"
               Write(Html.SortColumnLink(Model.Items, "User", "User"));

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                <th>");

            
            #line 18 "..\..\Views\AccessStatistics\Index.cshtml"
               Write(Html.SortColumnLink(Model.Items, "Duration", "Duration"));

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                <th>Count</th>\r\n                <th>");

            
            #line 20 "..\..\Views\AccessStatistics\Index.cshtml"
               Write(Html.SortColumnLink(Model.Items, "RpsMin", "RequestsPerSecondMin"));

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                <th>");

            
            #line 21 "..\..\Views\AccessStatistics\Index.cshtml"
               Write(Html.SortColumnLink(Model.Items, "Rps", "RequestsPerSecond"));

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                <th>");

            
            #line 22 "..\..\Views\AccessStatistics\Index.cshtml"
               Write(Html.SortColumnLink(Model.Items, "RpsMax", "RequestsPerSecondMax"));

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                <th>");

            
            #line 23 "..\..\Views\AccessStatistics\Index.cshtml"
               Write(Html.SortColumnLink(Model.Items, "RpmMin", "RequestsPerMinuteMin"));

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                <th>");

            
            #line 24 "..\..\Views\AccessStatistics\Index.cshtml"
               Write(Html.SortColumnLink(Model.Items, "Rpm", "RequestsPerMinute"));

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                <th>");

            
            #line 25 "..\..\Views\AccessStatistics\Index.cshtml"
               Write(Html.SortColumnLink(Model.Items, "RpmMax", "RequestsPerMinuteMax"));

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                <th>");

            
            #line 26 "..\..\Views\AccessStatistics\Index.cshtml"
               Write(SharedResources.Block);

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");

            
            #line 30 "..\..\Views\AccessStatistics\Index.cshtml"
            
            
            #line default
            #line hidden
            
            #line 30 "..\..\Views\AccessStatistics\Index.cshtml"
             foreach (var item in Model.Items.List)
            {

            
            #line default
            #line hidden
WriteLiteral("                <tr>\r\n                    <td>");

            
            #line 33 "..\..\Views\AccessStatistics\Index.cshtml"
                   Write(Html.ActionLink(item.IP, "Detail", new { key = item.Key }));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                    ");

WriteLiteral("\r\n                    <td>");

            
            #line 35 "..\..\Views\AccessStatistics\Index.cshtml"
                   Write(item.User);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                    <td>");

            
            #line 36 "..\..\Views\AccessStatistics\Index.cshtml"
                   Write(item.Duration);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                    <td");

WriteLiteral(" class=\"center\"");

WriteLiteral(">");

            
            #line 37 "..\..\Views\AccessStatistics\Index.cshtml"
                                  Write(item.LongCount());

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                    <td");

WriteLiteral(" class=\"center\"");

WriteLiteral(">");

            
            #line 38 "..\..\Views\AccessStatistics\Index.cshtml"
                                  Write(item.RequestsPerSecondMin);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                    <td");

WriteLiteral(" class=\"center\"");

WriteLiteral(">");

            
            #line 39 "..\..\Views\AccessStatistics\Index.cshtml"
                                  Write(item.RequestsPerSecond.ToString("n2"));

            
            #line default
            #line hidden
WriteLiteral("/<br />");

            
            #line 39 "..\..\Views\AccessStatistics\Index.cshtml"
                                                                               Write(item.RequestsPerSecondNorm.ToString("n2"));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                    <td");

WriteLiteral(" class=\"center\"");

WriteLiteral(">");

            
            #line 40 "..\..\Views\AccessStatistics\Index.cshtml"
                                  Write(item.RequestsPerSecondMax);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                    <td");

WriteLiteral(" class=\"center\"");

WriteLiteral(">");

            
            #line 41 "..\..\Views\AccessStatistics\Index.cshtml"
                                  Write(item.RequestsPerMinuteMin);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                    <td");

WriteLiteral(" class=\"center\"");

WriteLiteral(">");

            
            #line 42 "..\..\Views\AccessStatistics\Index.cshtml"
                                  Write(item.RequestsPerMinute.ToString("n2"));

            
            #line default
            #line hidden
WriteLiteral("/<br />");

            
            #line 42 "..\..\Views\AccessStatistics\Index.cshtml"
                                                                               Write(item.RequestsPerMinuteNorm.ToString("n2"));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                    <td");

WriteLiteral(" class=\"center\"");

WriteLiteral(">");

            
            #line 43 "..\..\Views\AccessStatistics\Index.cshtml"
                                  Write(item.RequestsPerMinuteMax);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                    <td");

WriteLiteral(" class=\"clickable\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 2385), Tuple.Create("\"", 2419)
, Tuple.Create(Tuple.Create("", 2395), Tuple.Create("block(\'", 2395), true)
            
            #line 44 "..\..\Views\AccessStatistics\Index.cshtml"
, Tuple.Create(Tuple.Create("", 2402), Tuple.Create<System.Object, System.Int32>(item.Key
            
            #line default
            #line hidden
, 2402), false)
, Tuple.Create(Tuple.Create("", 2411), Tuple.Create("\',", 2411), true)
, Tuple.Create(Tuple.Create(" ", 2413), Tuple.Create("this)", 2414), true)
);

WriteLiteral(">\r\n                        <img");

WriteLiteral(" alt=\"blocked\"");

WriteAttribute("src", Tuple.Create(" src=\"", 2465), Tuple.Create("\"", 2513)
            
            #line 45 "..\..\Views\AccessStatistics\Index.cshtml"
, Tuple.Create(Tuple.Create("", 2471), Tuple.Create<System.Object, System.Int32>(Url.Content("~/Content/images/block.png")
            
            #line default
            #line hidden
, 2471), false)
);

WriteAttribute("style", Tuple.Create(" style=\"", 2514), Tuple.Create("\"", 2562)
            
            #line 45 "..\..\Views\AccessStatistics\Index.cshtml"
                    , Tuple.Create(Tuple.Create("", 2522), Tuple.Create<System.Object, System.Int32>(!item.IsBlocked ? "display:none" : ""
            
            #line default
            #line hidden
, 2522), false)
);

WriteLiteral(" />\r\n                    </td>\r\n                </tr>\r\n");

            
            #line 48 "..\..\Views\AccessStatistics\Index.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n");

            
            #line 52 "..\..\Views\AccessStatistics\Index.cshtml"
  Html.RenderPartial("Components/Pagination", Model.Items);
            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("\r\n\r\n<div");

WriteLiteral(" class=\"clear-div\"");

WriteLiteral("></div>\r\n");

            
            #line 56 "..\..\Views\AccessStatistics\Index.cshtml"
 using (Html.BeginForm("SaveLog", "AccessStatistics"))
{

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"right\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 59 "..\..\Views\AccessStatistics\Index.cshtml"
   Write(Html.SubmitButton(SharedResources.Save, new { @class = "btn btn--main" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n");

            
            #line 61 "..\..\Views\AccessStatistics\Index.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\r\n");

DefineSection("scripts", () => {

WriteLiteral("\r\n");

            
            #line 65 "..\..\Views\AccessStatistics\Index.cshtml"
    
            
            #line default
            #line hidden
            
            #line 65 "..\..\Views\AccessStatistics\Index.cshtml"
       Html.RenderPartial("GridViewFooterScripts", Model.Items); 
            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n    <script>\r\n        function block(key, el) {\r\n            $(el).children()" +
".toggle();\r\n            $.post(\'");

            
            #line 70 "..\..\Views\AccessStatistics\Index.cshtml"
               Write(Url.Action("Block"));

            
            #line default
            #line hidden
WriteLiteral("\', \'key=\' + key);\r\n        }\r\n    </script>\r\n");

});

        }
    }
}
#pragma warning restore 1591
