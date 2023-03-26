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
    
    #line 1 "..\..\Views\SelectionByAuto\WaresForModif.cshtml"
    using ViewRes;
    
    #line default
    #line hidden
    using Webmall.UI;
    using Webmall.UI.Core.Localization;
    
    #line 2 "..\..\Views\SelectionByAuto\WaresForModif.cshtml"
    using Webmall.UI.Core.Renderers;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Views\SelectionByAuto\WaresForModif.cshtml"
    using Webmall.UI.Models.SelectionByAuto;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Views\SelectionByAuto\WaresForModif.cshtml"
    using Webmall.UI.ViewModel;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/SelectionByAuto/WaresForModif.cshtml")]
    public partial class _Views_SelectionByAuto_WaresForModif_cshtml : System.Web.Mvc.WebViewPage<Webmall.UI.Models.SelectionByAuto.AutoGroupsModel>
    {
        public _Views_SelectionByAuto_WaresForModif_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 8 "..\..\Views\SelectionByAuto\WaresForModif.cshtml"
  
    Layout = "~/Views/Shared/_Inner.cshtml";
    var renderGroups = Model.SelectedGroup?.Children?.Any() == true;

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

DefineSection("BreadCrumbs", () => {

WriteLiteral("\r\n");

            
            #line 14 "..\..\Views\SelectionByAuto\WaresForModif.cshtml"
    
            
            #line default
            #line hidden
            
            #line 14 "..\..\Views\SelectionByAuto\WaresForModif.cshtml"
      
        var links = new List<BreadCrumbsModel>
        {
            new BreadCrumbsModel
            {
                Url = Url.Action("Selection", "SelectionByAuto") + "#section-1",
                Name = Model.VehicleInfo?.Mark?.Name + " " + Model.VehicleInfo?.Model?.Name
            },
            new BreadCrumbsModel {Name = SharedResources.SelectByGroups}
        };
    
            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 25 "..\..\Views\SelectionByAuto\WaresForModif.cshtml"
    
            
            #line default
            #line hidden
            
            #line 25 "..\..\Views\SelectionByAuto\WaresForModif.cshtml"
      Html.RenderPartial("Components/BreadCrumbsRender", links);
            
            #line default
            #line hidden
WriteLiteral("\r\n");

});

WriteLiteral("\r\n");

DefineSection("Sidebar", () => {

WriteLiteral("\r\n    <aside");

WriteLiteral(" class=\"match-area__aside filter\"");

WriteLiteral(">\r\n        <!-- tree-nav-widget-->\r\n        <div");

WriteLiteral(" class=\"match-area__nav tree-nav-widget js-accordion is-active\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"tree-nav-widget__header\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"tree-nav-widget__heading js-accordion-trigger\"");

WriteLiteral(">");

            
            #line 33 "..\..\Views\SelectionByAuto\WaresForModif.cshtml"
                                                                       Write(Model.VehicleInfo?.Mark?.Name);

            
            #line default
            #line hidden
WriteLiteral(" ");

            
            #line 33 "..\..\Views\SelectionByAuto\WaresForModif.cshtml"
                                                                                                        Write(Model.VehicleInfo?.Model?.Name);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"tree-nav-widget__main js-accordion-body\"");

WriteLiteral(">\r\n                <nav");

WriteLiteral(" class=\"tree-nav-widget__nav tree-nav\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 37 "..\..\Views\SelectionByAuto\WaresForModif.cshtml"
                Write(new HtmlString(Html.RenderTree(Model.Groups, Model.SelectedGroup, "groups", gr =>
                    {
                        //var baseModel = Model.Clone();
                        //baseModel.= gr.Id;
                        var group = (AutoGroupTree)gr;
                        return group.Group.Children.Any() 
                            ? gr.Name
                            : "<a href=\"\" onclick=\"updateAssemblyInfo('" + Url.Action("AssemblyWares", new { modifId = Model.VehicleInfo.Id, assemblyId = gr.Id }) + "', event);\">" + gr.Name + "</a>";
                    })));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </nav>\r\n            </div>\r\n        </div><!-- /tree-nav-widget" +
"-->\r\n    </aside>\r\n");

});

WriteLiteral("\r\n<button");

WriteLiteral(" class=\"filter-toggle match-area__filter-toggle\"");

WriteLiteral(" type=\"button\"");

WriteLiteral(">\r\n    <svg");

WriteLiteral(" class=\"icon icon-tree filter-toggle__icon\"");

WriteLiteral(" width=\"25\"");

WriteLiteral(" height=\"25\"");

WriteLiteral(">\r\n        <use");

WriteAttribute("href", Tuple.Create(" href=\"", 2209), Tuple.Create("\"", 2274)
            
            #line 54 "..\..\Views\SelectionByAuto\WaresForModif.cshtml"
, Tuple.Create(Tuple.Create("", 2216), Tuple.Create<System.Object, System.Int32>(Url.Content("~/assets/images/svg/symbol/sprite.svg#tree")
            
            #line default
            #line hidden
, 2216), false)
);

WriteLiteral("></use>\r\n    </svg>\r\n    <span");

WriteLiteral(" class=\"filter-toggle__text\"");

WriteLiteral(">");

            
            #line 56 "..\..\Views\SelectionByAuto\WaresForModif.cshtml"
                                 Write(SharedResources.Categories);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n</button>\r\n\r\n");

WriteLiteral("\r\n\r\n<main");

WriteLiteral(" class=\"match-area__main\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"match-area__tabs tabs js-tabs\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"tabs__header\"");

WriteLiteral(">\r\n            ");

WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"tabs__panes\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"tabs__pane js-tabs-pane is-active\"");

WriteLiteral(" id=\"assemblyDetail\"");

WriteLiteral(">\r\n");

            
            #line 82 "..\..\Views\SelectionByAuto\WaresForModif.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 82 "..\..\Views\SelectionByAuto\WaresForModif.cshtml"
                     if (renderGroups)
                    {
                       // Html.RenderPartial("SelectionByAutoGroupsAsImages", Model);
                    }

            
            #line default
            #line hidden
WriteLiteral("                </div>\r\n                <div");

WriteLiteral(" class=\"tabs__pane js-tabs-pane\"");

WriteLiteral("></div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</main>\r\n");

DefineSection("styles", () => {

WriteLiteral("\r\n    ");

WriteLiteral("\r\n    ");

WriteLiteral("\r\n");

});

WriteLiteral("\r\n");

DefineSection("scripts", () => {

WriteLiteral("\r\n    <script>\r\n    $(function () {\r\n        var searchInput = $(\'#searchInput\');" +
"\r\n        searchInput.click(stopEvent);\r\n        searchInput.change(function() {" +
"\r\n            searchGroup(searchInput.val());\r\n        });\r\n        searchInput." +
"keyup(function () {\r\n            searchGroup(searchInput.val());\r\n        });\r\n " +
"   });\r\n\r\n    function updateAssemblyInfo(url, e) {\r\n        updatePannel(url, \'" +
"assemblyDetail\', \'progressWindow\', tippyInitGroupDetail);\r\n        if (e) {\r\n   " +
"         $(\"li.current\").removeClass(\"current\");\r\n            e.srcElement.paren" +
"tElement.classList.add(\"current\");\r\n            e.preventDefault();\r\n        }\r\n" +
"    }\r\n\r\n    function tippyInitGroupDetail() {\r\n        tippy(\'.group-tippy\',\r\n " +
"           {\r\n                allowHTML: true,\r\n                content: \'Loadin" +
"g...\',\r\n                onCreate(instance) {\r\n                    // Setup our o" +
"wn custom state properties\r\n                    instance._isFetching = false;\r\n " +
"                   instance._src = null;\r\n                    instance._error = " +
"null;\r\n                },\r\n                onShow(instance) {\r\n                 " +
"   if (instance._isFetching || instance._src || instance._error) {\r\n            " +
"            return;\r\n                    }\r\n                    instance._isFetc" +
"hing = true;\r\n                    instance.setContent(g_getHint(instance.referen" +
"ce));\r\n                    instance._isFetching = false;\r\n                },\r\n  " +
"              onHidden(instance) {\r\n                    instance.setContent(\'Loa" +
"ding...\');\r\n                    // Unset these properties so new network request" +
"s can be initiated\r\n                    instance._src = null;\r\n                 " +
"   instance._error = null;\r\n                }\r\n            });\r\n        tippy(\'." +
"group-tippy-mobile\',\r\n            {\r\n                allowHTML: true,\r\n         " +
"       content: \'Loading...\',\r\n                onCreate(instance) {\r\n           " +
"         // Setup our own custom state properties\r\n                    instance." +
"_isFetching = false;\r\n                    instance._src = null;\r\n               " +
"     instance._error = null;\r\n                },\r\n                onShow(instanc" +
"e) {\r\n                    if (instance._isFetching || instance._src || instance." +
"_error) {\r\n                        return;\r\n                    }\r\n             " +
"       instance._isFetching = true;\r\n                    instance.setContent(g_g" +
"etHint(document.getElementById(instance.reference.dataset.id)));\r\n              " +
"      instance._isFetching = false;\r\n                },\r\n                onHidde" +
"n(instance) {\r\n                    instance.setContent(\'Loading...\');\r\n         " +
"           // Unset these properties so new network requests can be initiated\r\n " +
"                   instance._src = null;\r\n                    instance._error = " +
"null;\r\n                }\r\n            });\r\n    }\r\n\r\n    function searchGroup(sea" +
"rchStr) {\r\n        var nav = $(\'#filteredNavigation\');\r\n        var show = false" +
";\r\n\r\n        nav.hide();\r\n        nav.html(\'\');\r\n        if (searchStr.length >=" +
" 3) {\r\n            ");

WriteLiteral("\r\n                show = true;\r\n            }\r\n\r\n            if (show) {\r\n       " +
"         nav.show();\r\n                $(\"#groups\").hide();\r\n            } else {" +
"\r\n                $(\"#groups\").show();\r\n            }\r\n        }\r\n\r\n");

            
            #line 215 "..\..\Views\SelectionByAuto\WaresForModif.cshtml"
        
            
            #line default
            #line hidden
            
            #line 215 "..\..\Views\SelectionByAuto\WaresForModif.cshtml"
         if (!renderGroups)
        {

            
            #line default
            #line hidden
WriteLiteral("            ");

WriteLiteral("\r\n                ");

WriteLiteral("\r\n            ");

WriteLiteral("\r\n");

            
            #line 220 "..\..\Views\SelectionByAuto\WaresForModif.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("    </script>\r\n    ");

WriteLiteral("\r\n");

});

        }
    }
}
#pragma warning restore 1591
