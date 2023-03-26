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
    using Webmall.UI.Core.Localization;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Lxm/SelectionByAutoGroupsAsImages.cshtml")]
    public partial class _Views_Lxm_SelectionByAutoGroupsAsImages_cshtml : System.Web.Mvc.WebViewPage<Webmall.UI.Models.Laximo.GroupsModel>
    {
        public _Views_Lxm_SelectionByAutoGroupsAsImages_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 3 "..\..\Views\Lxm\SelectionByAutoGroupsAsImages.cshtml"
   Layout = null; 
            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteLiteral(" class=\"media-grid\"");

WriteLiteral(">\r\n");

            
            #line 6 "..\..\Views\Lxm\SelectionByAutoGroupsAsImages.cshtml"
    
            
            #line default
            #line hidden
            
            #line 6 "..\..\Views\Lxm\SelectionByAutoGroupsAsImages.cshtml"
     foreach (var group in (Model.SelectedGroup != null) ? Model.SelectedGroup.Children : Model.Groups)
    {
        var imgUrl = $"~/ExtContent/LxmGroupImages/{group.Id}.png";
        if (!File.Exists(Server.MapPath(imgUrl)))
        {
            imgUrl = "~/ExtContent/LxmGroupImages/default.png";
        }

            
            #line default
            #line hidden
WriteLiteral("        <a");

WriteLiteral(" class=\"media-grid__item media-card\"");

WriteAttribute("href", Tuple.Create(" href=\"", 461), Tuple.Create("\"", 600)
            
            #line 13 "..\..\Views\Lxm\SelectionByAutoGroupsAsImages.cshtml"
, Tuple.Create(Tuple.Create("", 468), Tuple.Create<System.Object, System.Int32>(Url.Action("Groups", "Lxm", new { groupId = group.Id, Model.VehicleId, Model.CatalogId, Model.CategoryId, Model.Ssd, Model.Type})
            
            #line default
            #line hidden
, 468), false)
);

WriteLiteral(">\r\n            <figure");

WriteLiteral(" class=\"media-card__main\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"media-card__img-wrap\"");

WriteLiteral(">\r\n                    <img");

WriteLiteral(" class=\"media-card__img\"");

WriteAttribute("src", Tuple.Create(" src=\"", 751), Tuple.Create("\"", 777)
            
            #line 16 "..\..\Views\Lxm\SelectionByAutoGroupsAsImages.cshtml"
, Tuple.Create(Tuple.Create("", 757), Tuple.Create<System.Object, System.Int32>(Url.Content(imgUrl)
            
            #line default
            #line hidden
, 757), false)
);

WriteLiteral(" alt=\"\"");

WriteLiteral(" width=\"120\"");

WriteLiteral(" height=\"175\"");

WriteLiteral(">\r\n                </div>\r\n                <figcaption");

WriteLiteral(" class=\"media-card__info\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"media-card__caption\"");

WriteLiteral(">");

            
            #line 19 "..\..\Views\Lxm\SelectionByAutoGroupsAsImages.cshtml"
                                                Write(group.Name);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                </figcaption>\r\n            </figure>\r\n        </a>\r\n");

            
            #line 23 "..\..\Views\Lxm\SelectionByAutoGroupsAsImages.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("</div>");

        }
    }
}
#pragma warning restore 1591
