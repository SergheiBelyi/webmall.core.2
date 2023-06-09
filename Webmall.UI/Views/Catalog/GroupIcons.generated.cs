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
    
    #line 1 "..\..\Views\Catalog\GroupIcons.cshtml"
    using Webmall.UI.Core;
    
    #line default
    #line hidden
    using Webmall.UI.Core.Localization;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Catalog/GroupIcons.cshtml")]
    public partial class _Views_Catalog_GroupIcons_cshtml : System.Web.Mvc.WebViewPage<IEnumerable<Webmall.Model.Entities.Catalog.Group>>
    {
        public _Views_Catalog_GroupIcons_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\Catalog\GroupIcons.cshtml"
  
    var currentParentLink = "~/" + UserPreferences.CurrentCultureLink + "Catalog/";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

WriteLiteral("\r\n<div");

WriteLiteral(" class=\"match-items\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n");

            
            #line 10 "..\..\Views\Catalog\GroupIcons.cshtml"
        
            
            #line default
            #line hidden
            
            #line 10 "..\..\Views\Catalog\GroupIcons.cshtml"
         foreach (var group in Model)
        {
            var imgUrl = $"~/ExtContent/GroupImages/{group.Id}.png";
            if (!File.Exists(Server.MapPath(imgUrl)))
            {
                imgUrl = "~/ExtContent/GroupImages/default.png";
            }

            
            #line default
            #line hidden
WriteLiteral("            <div");

WriteLiteral(" class=\"col-6 col-sm-4 col-md-3\"");

WriteLiteral(">\r\n                <a");

WriteLiteral(" class=\"match-item\"");

WriteAttribute("href", Tuple.Create(" href=\"", 626), Tuple.Create("\"", 676)
            
            #line 18 "..\..\Views\Catalog\GroupIcons.cshtml"
, Tuple.Create(Tuple.Create("", 633), Tuple.Create<System.Object, System.Int32>(Url.Content(currentParentLink + group.Url)
            
            #line default
            #line hidden
, 633), false)
);

WriteLiteral(">\r\n                    <figure");

WriteLiteral(" class=\"match-item__main\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"match-item__img-wrap\"");

WriteLiteral("><img");

WriteLiteral(" class=\"match-item__img img-responsive\"");

WriteAttribute("src", Tuple.Create(" src=\"", 836), Tuple.Create("\"", 862)
            
            #line 20 "..\..\Views\Catalog\GroupIcons.cshtml"
                            , Tuple.Create(Tuple.Create("", 842), Tuple.Create<System.Object, System.Int32>(Url.Content(imgUrl)
            
            #line default
            #line hidden
, 842), false)
);

WriteLiteral(" alt=\"\"");

WriteLiteral("></div>\r\n                        <figcaption");

WriteLiteral(" class=\"match-item__caption\"");

WriteLiteral(">");

            
            #line 21 "..\..\Views\Catalog\GroupIcons.cshtml"
                                                           Write(group.Name);

            
            #line default
            #line hidden
WriteLiteral("</figcaption>\r\n                    </figure>\r\n                </a>\r\n            <" +
"/div>\r\n");

            
            #line 25 "..\..\Views\Catalog\GroupIcons.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("    </div>\r\n</div>\r\n");

        }
    }
}
#pragma warning restore 1591
