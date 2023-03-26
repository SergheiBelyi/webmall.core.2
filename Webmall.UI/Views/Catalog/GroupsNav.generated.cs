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
    
    #line 2 "..\..\Views\Catalog\GroupsNav.cshtml"
    using ViewRes;
    
    #line default
    #line hidden
    
    #line 1 "..\..\Views\Catalog\GroupsNav.cshtml"
    using Webmall.Model.Entities.Catalog;
    
    #line default
    #line hidden
    using Webmall.UI;
    
    #line 3 "..\..\Views\Catalog\GroupsNav.cshtml"
    using Webmall.UI.Core;
    
    #line default
    #line hidden
    using Webmall.UI.Core.Localization;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Catalog/GroupsNav.cshtml")]
    public partial class _Views_Catalog_GroupsNav_cshtml : System.Web.Mvc.WebViewPage<List<Group>>
    {
        public _Views_Catalog_GroupsNav_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 5 "..\..\Views\Catalog\GroupsNav.cshtml"
  
    Layout = null;
    var currentParentLink = "~/" + UserPreferences.CurrentCultureLink + "Catalog/";

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("<div");

WriteLiteral(" class=\"category-nav d-none d-md-block\"");

WriteLiteral(">\r\n");

            
            #line 12 "..\..\Views\Catalog\GroupsNav.cshtml"
    
            
            #line default
            #line hidden
            
            #line 12 "..\..\Views\Catalog\GroupsNav.cshtml"
     if (Model != null && Model.Any())
    {

            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\"category-nav__title h3\"");

WriteLiteral(">");

            
            #line 14 "..\..\Views\Catalog\GroupsNav.cshtml"
                                       Write(SharedResources.ProductCategory);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");

WriteLiteral("        <ul");

WriteLiteral(" class=\"category-nav__list\"");

WriteLiteral(">\r\n");

            
            #line 16 "..\..\Views\Catalog\GroupsNav.cshtml"
            
            
            #line default
            #line hidden
            
            #line 16 "..\..\Views\Catalog\GroupsNav.cshtml"
             foreach (var item in Model)
            {
                var url = Url.Content(currentParentLink + item.Url);
                var active = (item.Id == ViewBag.CurrentGroupId) ? "active" : "";

            
            #line default
            #line hidden
WriteLiteral("                <li");

WriteAttribute("class", Tuple.Create(" class=\"", 662), Tuple.Create("\"", 696)
, Tuple.Create(Tuple.Create("", 670), Tuple.Create("category-nav__item", 670), true)
            
            #line 20 "..\..\Views\Catalog\GroupsNav.cshtml"
, Tuple.Create(Tuple.Create(" ", 688), Tuple.Create<System.Object, System.Int32>(active
            
            #line default
            #line hidden
, 689), false)
);

WriteLiteral("><a");

WriteLiteral(" class=\"category-nav__link\"");

WriteAttribute("href", Tuple.Create(" href=\"", 727), Tuple.Create("\"", 738)
            
            #line 20 "..\..\Views\Catalog\GroupsNav.cshtml"
            , Tuple.Create(Tuple.Create("", 734), Tuple.Create<System.Object, System.Int32>(url
            
            #line default
            #line hidden
, 734), false)
);

WriteLiteral(">");

            
            #line 20 "..\..\Views\Catalog\GroupsNav.cshtml"
                                                                                            Write(item.Name);

            
            #line default
            #line hidden
WriteLiteral("</a></li>\r\n");

            
            #line 21 "..\..\Views\Catalog\GroupsNav.cshtml"

            }

            
            #line default
            #line hidden
WriteLiteral("        </ul>\r\n");

            
            #line 24 "..\..\Views\Catalog\GroupsNav.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("</div>");

        }
    }
}
#pragma warning restore 1591
