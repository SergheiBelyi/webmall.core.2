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
    
    #line 1 "..\..\Views\Clients\ClientPresenters.cshtml"
    using ViewRes;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Views\Clients\ClientPresenters.cshtml"
    using Webmall.Model;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Views\Clients\ClientPresenters.cshtml"
    using Webmall.Model.Entities.User;
    
    #line default
    #line hidden
    using Webmall.UI;
    
    #line 2 "..\..\Views\Clients\ClientPresenters.cshtml"
    using Webmall.UI.Core;
    
    #line default
    #line hidden
    using Webmall.UI.Core.Localization;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Clients/ClientPresenters.cshtml")]
    public partial class _Views_Clients_ClientPresenters_cshtml : System.Web.Mvc.WebViewPage<Webmall.UI.ViewModel.Client.ClientViewModel>
    {
        public _Views_Clients_ClientPresenters_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 7 "..\..\Views\Clients\ClientPresenters.cshtml"
  
    Layout = null;

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteLiteral(" class=\"addresses users__subsection\"");

WriteLiteral(">\r\n    <h2");

WriteLiteral(" class=\"profile__subheading secondary-heading\"");

WriteLiteral(">");

            
            #line 12 "..\..\Views\Clients\ClientPresenters.cshtml"
                                                 Write(SharedResources.Representations);

            
            #line default
            #line hidden
WriteLiteral("</h2>\r\n    ");

WriteLiteral("\r\n    <div");

WriteLiteral(" class=\"table-responsive\"");

WriteLiteral(">\r\n        <table");

WriteLiteral(" class=\"table\"");

WriteLiteral(">\r\n            <thead>\r\n                <tr>\r\n                    <th>&nbsp;</th>" +
"\r\n                    <th>");

            
            #line 19 "..\..\Views\Clients\ClientPresenters.cshtml"
                   Write(SharedResources.FIO);

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                    <th>");

            
            #line 20 "..\..\Views\Clients\ClientPresenters.cshtml"
                   Write(SharedResources.EmailPhone);

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                    <th");

WriteLiteral(" class=\"text-center\"");

WriteAttribute("title", Tuple.Create(" title=\"", 719), Tuple.Create("\"", 751)
            
            #line 21 "..\..\Views\Clients\ClientPresenters.cshtml"
, Tuple.Create(Tuple.Create("", 727), Tuple.Create<System.Object, System.Int32>(SharedResources.KeyUser
            
            #line default
            #line hidden
, 727), false)
);

WriteLiteral(">\r\n                        <svg");

WriteLiteral(" class=\"icon icon-key\"");

WriteAttribute("alt", Tuple.Create(" alt=\"", 805), Tuple.Create("\"", 835)
            
            #line 22 "..\..\Views\Clients\ClientPresenters.cshtml"
, Tuple.Create(Tuple.Create("", 811), Tuple.Create<System.Object, System.Int32>(SharedResources.KeyUser
            
            #line default
            #line hidden
, 811), false)
);

WriteLiteral(">\r\n                            <use");

WriteAttribute("href", Tuple.Create(" href=\"", 871), Tuple.Create("\"", 935)
            
            #line 23 "..\..\Views\Clients\ClientPresenters.cshtml"
, Tuple.Create(Tuple.Create("", 878), Tuple.Create<System.Object, System.Int32>(Url.Content("~/assets/images/svg/symbol/sprite.svg#key")
            
            #line default
            #line hidden
, 878), false)
);

WriteLiteral("></use>\r\n                        </svg>\r\n                    </th>\r\n             " +
"       <th");

WriteLiteral(" class=\"text-center\"");

WriteAttribute("title", Tuple.Create(" title=\"", 1047), Tuple.Create("\"", 1084)
            
            #line 26 "..\..\Views\Clients\ClientPresenters.cshtml"
, Tuple.Create(Tuple.Create("", 1055), Tuple.Create<System.Object, System.Int32>(SharedResources.AllOrderUser
            
            #line default
            #line hidden
, 1055), false)
);

WriteLiteral(">\r\n                        <svg");

WriteLiteral(" class=\"icon icon-contacts\"");

WriteLiteral(">\r\n                            <use");

WriteAttribute("href", Tuple.Create(" href=\"", 1178), Tuple.Create("\"", 1247)
            
            #line 28 "..\..\Views\Clients\ClientPresenters.cshtml"
, Tuple.Create(Tuple.Create("", 1185), Tuple.Create<System.Object, System.Int32>(Url.Content("~/assets/images/svg/symbol/sprite.svg#contacts")
            
            #line default
            #line hidden
, 1185), false)
);

WriteLiteral("></use>\r\n                        </svg>\r\n                    </th>\r\n             " +
"       <th");

WriteLiteral(" class=\"text-center\"");

WriteAttribute("title", Tuple.Create(" title=\"", 1359), Tuple.Create("\"", 1402)
            
            #line 31 "..\..\Views\Clients\ClientPresenters.cshtml"
, Tuple.Create(Tuple.Create("", 1367), Tuple.Create<System.Object, System.Int32>(SharedResources.ComparisionActUser
            
            #line default
            #line hidden
, 1367), false)
);

WriteLiteral(">\r\n                        <svg");

WriteLiteral(" class=\"icon icon-file\"");

WriteLiteral(">\r\n                            <use");

WriteAttribute("href", Tuple.Create(" href=\"", 1492), Tuple.Create("\"", 1557)
            
            #line 33 "..\..\Views\Clients\ClientPresenters.cshtml"
, Tuple.Create(Tuple.Create("", 1499), Tuple.Create<System.Object, System.Int32>(Url.Content("~/assets/images/svg/symbol/sprite.svg#file")
            
            #line default
            #line hidden
, 1499), false)
);

WriteLiteral("></use>\r\n                        </svg>\r\n                    </th>\r\n             " +
"       <th");

WriteLiteral(" class=\"text-center\"");

WriteAttribute("title", Tuple.Create(" title=\"", 1669), Tuple.Create("\"", 1703)
            
            #line 36 "..\..\Views\Clients\ClientPresenters.cshtml"
, Tuple.Create(Tuple.Create("", 1677), Tuple.Create<System.Object, System.Int32>(SharedResources.TradeUser
            
            #line default
            #line hidden
, 1677), false)
);

WriteLiteral(">\r\n                        <svg");

WriteLiteral(" class=\"icon icon-shopping-cart\"");

WriteLiteral(">\r\n                            <use");

WriteAttribute("href", Tuple.Create(" href=\"", 1802), Tuple.Create("\"", 1876)
            
            #line 38 "..\..\Views\Clients\ClientPresenters.cshtml"
, Tuple.Create(Tuple.Create("", 1809), Tuple.Create<System.Object, System.Int32>(Url.Content("~/assets/images/svg/symbol/sprite.svg#shopping-cart")
            
            #line default
            #line hidden
, 1809), false)
);

WriteLiteral("></use>\r\n                        </svg>\r\n                    </th>\r\n             " +
"       ");

WriteLiteral("\r\n                    ");

WriteLiteral("\r\n                    <th");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">\r\n                        ");

WriteLiteral("\r\n                    </th>\r\n                    <th>&nbsp;</th>\r\n               " +
" </tr>\r\n            </thead>\r\n            <tbody>\r\n");

            
            #line 56 "..\..\Views\Clients\ClientPresenters.cshtml"
                
            
            #line default
            #line hidden
            
            #line 56 "..\..\Views\Clients\ClientPresenters.cshtml"
                  
                    var isKey = SessionHelper.CurrentUser.CurrentPresenter.Roles.IsFlagSet((long)RepresentativeRole.KeyRepresentative);
                
            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 59 "..\..\Views\Clients\ClientPresenters.cshtml"
                
            
            #line default
            #line hidden
            
            #line 59 "..\..\Views\Clients\ClientPresenters.cshtml"
                 foreach (var item in Model.AllClientPresenters)
                {
                    var canChangeKey = SessionHelper.CurrentUser.Roles.IsFlagSet((long)UserRoles.RepresentativeManager)
                             || (item.User.Id != SessionHelper.CurrentUser.Id && isKey);
                    var canChange = isKey || SessionHelper.CurrentUser.Roles.IsFlagSet((long)UserRoles.RepresentativeManager);
                    string id;

            
            #line default
            #line hidden
WriteLiteral("                    <tr>\r\n                        <td>\r\n");

            
            #line 67 "..\..\Views\Clients\ClientPresenters.cshtml"
                            
            
            #line default
            #line hidden
            
            #line 67 "..\..\Views\Clients\ClientPresenters.cshtml"
                             if (item.User.IsBlocked)
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <img");

WriteLiteral(" alt=\"blocked\"");

WriteAttribute("src", Tuple.Create(" src=\"", 3550), Tuple.Create("\"", 3598)
            
            #line 69 "..\..\Views\Clients\ClientPresenters.cshtml"
, Tuple.Create(Tuple.Create("", 3556), Tuple.Create<System.Object, System.Int32>(Url.Content("~/Content/images/block.png")
            
            #line default
            #line hidden
, 3556), false)
);

WriteLiteral(" />\r\n");

            
            #line 70 "..\..\Views\Clients\ClientPresenters.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("                        </td>\r\n                        <td>");

            
            #line 72 "..\..\Views\Clients\ClientPresenters.cshtml"
                        Write(item.User.FullName + ((!item.IsAccepted) ? "(" + item.Client.Name + ")" : ""));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                        <td>\r\n                            <ul");

WriteLiteral(" class=\"client-detail-contacts\"");

WriteLiteral(">\r\n");

            
            #line 75 "..\..\Views\Clients\ClientPresenters.cshtml"
                                
            
            #line default
            #line hidden
            
            #line 75 "..\..\Views\Clients\ClientPresenters.cshtml"
                                 if (!string.IsNullOrEmpty(item.User.Phones))
                                {

            
            #line default
            #line hidden
WriteLiteral("                                    <li> <a");

WriteAttribute("href", Tuple.Create(" href=\"", 4033), Tuple.Create("\"", 4063)
, Tuple.Create(Tuple.Create("", 4040), Tuple.Create("tel:", 4040), true)
            
            #line 77 "..\..\Views\Clients\ClientPresenters.cshtml"
, Tuple.Create(Tuple.Create("", 4044), Tuple.Create<System.Object, System.Int32>(item.User.Phones
            
            #line default
            #line hidden
, 4044), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"fas fa-phone-alt\"");

WriteLiteral("></i> ");

            
            #line 77 "..\..\Views\Clients\ClientPresenters.cshtml"
                                                                                                       Write(item.User.Phones);

            
            #line default
            #line hidden
WriteLiteral("</a></li>\r\n");

            
            #line 78 "..\..\Views\Clients\ClientPresenters.cshtml"
                                }

            
            #line default
            #line hidden
WriteLiteral("                                ");

            
            #line 79 "..\..\Views\Clients\ClientPresenters.cshtml"
                                 if (!string.IsNullOrEmpty(item.User.Email))
                                {

            
            #line default
            #line hidden
WriteLiteral("                                    <li> <a");

WriteAttribute("href", Tuple.Create(" href=\"", 4317), Tuple.Create("\"", 4349)
, Tuple.Create(Tuple.Create("", 4324), Tuple.Create("mailto:", 4324), true)
            
            #line 81 "..\..\Views\Clients\ClientPresenters.cshtml"
, Tuple.Create(Tuple.Create("", 4331), Tuple.Create<System.Object, System.Int32>(item.User.Email
            
            #line default
            #line hidden
, 4331), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"fas fa-envelope\"");

WriteLiteral("></i> ");

            
            #line 81 "..\..\Views\Clients\ClientPresenters.cshtml"
                                                                                                        Write(item.User.Email);

            
            #line default
            #line hidden
WriteLiteral("</a></li>\r\n");

            
            #line 82 "..\..\Views\Clients\ClientPresenters.cshtml"
                                }

            
            #line default
            #line hidden
WriteLiteral("                            </ul>\r\n                        </td>\r\n               " +
"         <td>\r\n                            <div");

WriteLiteral(" class=\"checkbox-label\"");

WriteLiteral(">\r\n");

            
            #line 87 "..\..\Views\Clients\ClientPresenters.cshtml"
                                
            
            #line default
            #line hidden
            
            #line 87 "..\..\Views\Clients\ClientPresenters.cshtml"
                                   id = $"{RepresentativeRole.KeyRepresentative}_{item.Id}"; 
            
            #line default
            #line hidden
WriteLiteral("\r\n                                <input");

WriteLiteral(" class=\"checkbox-label__input\"");

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" represent=\"true\"");

WriteAttribute("id", Tuple.Create(" id=\"", 4796), Tuple.Create("\"", 4804)
            
            #line 88 "..\..\Views\Clients\ClientPresenters.cshtml"
                          , Tuple.Create(Tuple.Create("", 4801), Tuple.Create<System.Object, System.Int32>(id
            
            #line default
            #line hidden
, 4801), false)
);

WriteLiteral("\r\n                                       name=\"prd\"");

WriteAttribute("value", Tuple.Create(" value=\"", 4856), Tuple.Create("\"", 4877)
            
            #line 89 "..\..\Views\Clients\ClientPresenters.cshtml"
, Tuple.Create(Tuple.Create("", 4864), Tuple.Create<System.Object, System.Int32>(item.Roles
            
            #line default
            #line hidden
, 4864), false)
);

WriteLiteral(" ");

            
            #line 89 "..\..\Views\Clients\ClientPresenters.cshtml"
                                                                    Write(item.IsKeyRepresentative ? "checked=checked" : "");

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                       ");

            
            #line 90 "..\..\Views\Clients\ClientPresenters.cshtml"
                                   Write(!canChangeKey ? "disabled = disabled" : "");

            
            #line default
            #line hidden
WriteLiteral(" />\r\n                                <label");

WriteLiteral(" class=\"checkbox-label__main\"");

WriteAttribute("for", Tuple.Create(" for=\"", 5089), Tuple.Create("\"", 5098)
            
            #line 91 "..\..\Views\Clients\ClientPresenters.cshtml"
, Tuple.Create(Tuple.Create("", 5095), Tuple.Create<System.Object, System.Int32>(id
            
            #line default
            #line hidden
, 5095), false)
);

WriteLiteral("></label>\r\n                            </div>\r\n                        </td>\r\n   " +
"                     <td>\r\n                            <div");

WriteLiteral(" class=\"checkbox-label\"");

WriteLiteral(">\r\n");

            
            #line 96 "..\..\Views\Clients\ClientPresenters.cshtml"
                                
            
            #line default
            #line hidden
            
            #line 96 "..\..\Views\Clients\ClientPresenters.cshtml"
                                   id = $"{RepresentativeRole.AllOrders}_{item.Id}"; 
            
            #line default
            #line hidden
WriteLiteral("\r\n                                <input");

WriteLiteral(" class=\"checkbox-label__input\"");

WriteLiteral(" represent=\"true\"");

WriteLiteral(" type=\"checkbox\"");

WriteAttribute("id", Tuple.Create(" id=\"", 5454), Tuple.Create("\"", 5462)
            
            #line 97 "..\..\Views\Clients\ClientPresenters.cshtml"
                          , Tuple.Create(Tuple.Create("", 5459), Tuple.Create<System.Object, System.Int32>(id
            
            #line default
            #line hidden
, 5459), false)
);

WriteLiteral("\r\n                                       name=\"prd\"");

WriteAttribute("value", Tuple.Create(" value=\"", 5514), Tuple.Create("\"", 5535)
            
            #line 98 "..\..\Views\Clients\ClientPresenters.cshtml"
, Tuple.Create(Tuple.Create("", 5522), Tuple.Create<System.Object, System.Int32>(item.Roles
            
            #line default
            #line hidden
, 5522), false)
);

WriteLiteral(" ");

            
            #line 98 "..\..\Views\Clients\ClientPresenters.cshtml"
                                                                    Write(item.Roles.IsFlagSet((long)RepresentativeRole.AllOrders) ? "checked=checked" : "");

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                       ");

            
            #line 99 "..\..\Views\Clients\ClientPresenters.cshtml"
                                   Write(!canChange ? "disabled = disabled" : "");

            
            #line default
            #line hidden
WriteLiteral(" />\r\n                                <label");

WriteLiteral(" class=\"checkbox-label__main\"");

WriteAttribute("for", Tuple.Create(" for=\"", 5776), Tuple.Create("\"", 5785)
            
            #line 100 "..\..\Views\Clients\ClientPresenters.cshtml"
, Tuple.Create(Tuple.Create("", 5782), Tuple.Create<System.Object, System.Int32>(id
            
            #line default
            #line hidden
, 5782), false)
);

WriteLiteral("></label>\r\n                            </div>\r\n                        </td>\r\n   " +
"                     <td>\r\n                            <div");

WriteLiteral(" class=\"checkbox-label\"");

WriteLiteral(">\r\n");

            
            #line 105 "..\..\Views\Clients\ClientPresenters.cshtml"
                                
            
            #line default
            #line hidden
            
            #line 105 "..\..\Views\Clients\ClientPresenters.cshtml"
                                   id = $"{RepresentativeRole.Verification}_{item.Id}"; 
            
            #line default
            #line hidden
WriteLiteral("\r\n                                <input");

WriteLiteral(" class=\"checkbox-label__input\"");

WriteLiteral(" represent=\"true\"");

WriteLiteral(" type=\"checkbox\"");

WriteAttribute("id", Tuple.Create(" id=\"", 6144), Tuple.Create("\"", 6152)
            
            #line 106 "..\..\Views\Clients\ClientPresenters.cshtml"
                          , Tuple.Create(Tuple.Create("", 6149), Tuple.Create<System.Object, System.Int32>(id
            
            #line default
            #line hidden
, 6149), false)
);

WriteLiteral("\r\n                                       name=\"prd\"");

WriteAttribute("value", Tuple.Create(" value=\"", 6204), Tuple.Create("\"", 6225)
            
            #line 107 "..\..\Views\Clients\ClientPresenters.cshtml"
, Tuple.Create(Tuple.Create("", 6212), Tuple.Create<System.Object, System.Int32>(item.Roles
            
            #line default
            #line hidden
, 6212), false)
);

WriteLiteral(" ");

            
            #line 107 "..\..\Views\Clients\ClientPresenters.cshtml"
                                                                    Write(item.Roles.IsFlagSet((long)RepresentativeRole.Verification) ? "checked=checked" : "");

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                       ");

            
            #line 108 "..\..\Views\Clients\ClientPresenters.cshtml"
                                   Write(!canChange ? "disabled = disabled" : "");

            
            #line default
            #line hidden
WriteLiteral(" />\r\n                                <label");

WriteLiteral(" class=\"checkbox-label__main\"");

WriteAttribute("for", Tuple.Create(" for=\"", 6469), Tuple.Create("\"", 6478)
            
            #line 109 "..\..\Views\Clients\ClientPresenters.cshtml"
, Tuple.Create(Tuple.Create("", 6475), Tuple.Create<System.Object, System.Int32>(id
            
            #line default
            #line hidden
, 6475), false)
);

WriteLiteral("></label>\r\n                            </div>\r\n                        </td>\r\n   " +
"                     <td>\r\n                            <div");

WriteLiteral(" class=\"checkbox-label\"");

WriteLiteral(">\r\n");

            
            #line 114 "..\..\Views\Clients\ClientPresenters.cshtml"
                                
            
            #line default
            #line hidden
            
            #line 114 "..\..\Views\Clients\ClientPresenters.cshtml"
                                   id = $"{RepresentativeRole.Trade}_{item.Id}"; 
            
            #line default
            #line hidden
WriteLiteral("\r\n                                <input");

WriteLiteral(" class=\"checkbox-label__input\"");

WriteLiteral(" represent=\"true\"");

WriteLiteral(" type=\"checkbox\"");

WriteAttribute("id", Tuple.Create(" id=\"", 6830), Tuple.Create("\"", 6838)
            
            #line 115 "..\..\Views\Clients\ClientPresenters.cshtml"
                          , Tuple.Create(Tuple.Create("", 6835), Tuple.Create<System.Object, System.Int32>(id
            
            #line default
            #line hidden
, 6835), false)
);

WriteLiteral("\r\n                                       name=\"prd\"");

WriteAttribute("value", Tuple.Create(" value=\"", 6890), Tuple.Create("\"", 6911)
            
            #line 116 "..\..\Views\Clients\ClientPresenters.cshtml"
, Tuple.Create(Tuple.Create("", 6898), Tuple.Create<System.Object, System.Int32>(item.Roles
            
            #line default
            #line hidden
, 6898), false)
);

WriteLiteral(" ");

            
            #line 116 "..\..\Views\Clients\ClientPresenters.cshtml"
                                                                    Write(item.Roles.IsFlagSet((long)RepresentativeRole.Trade) ? "checked=checked" : "");

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                                       ");

            
            #line 117 "..\..\Views\Clients\ClientPresenters.cshtml"
                                   Write(!canChange ? "disabled = disabled" : "");

            
            #line default
            #line hidden
WriteLiteral(" />\r\n                                <label");

WriteLiteral(" class=\"checkbox-label__main\"");

WriteAttribute("for", Tuple.Create(" for=\"", 7148), Tuple.Create("\"", 7157)
            
            #line 118 "..\..\Views\Clients\ClientPresenters.cshtml"
, Tuple.Create(Tuple.Create("", 7154), Tuple.Create<System.Object, System.Int32>(id
            
            #line default
            #line hidden
, 7154), false)
);

WriteLiteral("></label>\r\n                            </div>\r\n                        </td>\r\n   " +
"                     ");

WriteLiteral("\r\n                        <td");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">\r\n");

            
            #line 130 "..\..\Views\Clients\ClientPresenters.cshtml"
                            
            
            #line default
            #line hidden
            
            #line 130 "..\..\Views\Clients\ClientPresenters.cshtml"
                             if (canChangeKey && (!item.IsKeyRepresentative && item.User.Id == SessionHelper.CurrentUser.Id))
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <a");

WriteLiteral(" class=\"user-status-remove\"");

WriteAttribute("href", Tuple.Create(" href=\"", 8263), Tuple.Create("\"", 8376)
            
            #line 132 "..\..\Views\Clients\ClientPresenters.cshtml"
, Tuple.Create(Tuple.Create("", 8270), Tuple.Create<System.Object, System.Int32>(Url.Action("DeleteRepresentation", new {id = item.Id, clientId = Model.CurrentClientPresenter.Client.Id})
            
            #line default
            #line hidden
, 8270), false)
);

WriteAttribute("title", Tuple.Create("\r\n                                   title=\"", 8377), Tuple.Create("\"", 8444)
            
            #line 133 "..\..\Views\Clients\ClientPresenters.cshtml"
, Tuple.Create(Tuple.Create("", 8421), Tuple.Create<System.Object, System.Int32>(SharedResources.Delete
            
            #line default
            #line hidden
, 8421), false)
);

WriteAttribute("onclick", Tuple.Create("\r\n                                   onclick=\"", 8445), Tuple.Create("\"", 8539)
, Tuple.Create(Tuple.Create(" ", 8491), Tuple.Create("return", 8492), true)
, Tuple.Create(Tuple.Create(" ", 8498), Tuple.Create("confirm(\'", 8499), true)
            
            #line 134 "..\..\Views\Clients\ClientPresenters.cshtml"
, Tuple.Create(Tuple.Create("", 8508), Tuple.Create<System.Object, System.Int32>(SharedResources.AreYouSure
            
            #line default
            #line hidden
, 8508), false)
, Tuple.Create(Tuple.Create("", 8535), Tuple.Create("\');", 8535), true)
, Tuple.Create(Tuple.Create(" ", 8538), Tuple.Create("", 8538), true)
);

WriteLiteral(">\r\n                                    <svg");

WriteLiteral(" class=\"icon icon-close\"");

WriteLiteral(">\r\n                                        <use");

WriteAttribute("href", Tuple.Create(" href=\"", 8654), Tuple.Create("\"", 8720)
            
            #line 136 "..\..\Views\Clients\ClientPresenters.cshtml"
, Tuple.Create(Tuple.Create("", 8661), Tuple.Create<System.Object, System.Int32>(Url.Content("~/assets/images/svg/symbol/sprite.svg#close")
            
            #line default
            #line hidden
, 8661), false)
);

WriteLiteral("></use>\r\n                                    </svg>\r\n                            " +
"    </a>\r\n");

            
            #line 139 "..\..\Views\Clients\ClientPresenters.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("                        </td>\r\n                        <td>\r\n");

            
            #line 142 "..\..\Views\Clients\ClientPresenters.cshtml"
                            
            
            #line default
            #line hidden
            
            #line 142 "..\..\Views\Clients\ClientPresenters.cshtml"
                             if (!item.IsAccepted)
                            {
                                if (//item.User.Id != SessionHelper.CurrentUser.Id ||
                                    SessionHelper.CurrentUser.Roles.IsFlagSet((long)UserRoles.RepresentativeManager) ||
                                    item.Roles.IsFlagSet((long)RepresentativeRole.KeyRepresentative))
                                {

            
            #line default
            #line hidden
WriteLiteral("                                    <a");

WriteAttribute("href", Tuple.Create(" href=\"", 9371), Tuple.Create("\"", 9420)
            
            #line 148 "..\..\Views\Clients\ClientPresenters.cshtml"
, Tuple.Create(Tuple.Create("", 9378), Tuple.Create<System.Object, System.Int32>(Url.Action("Approve", new {id = item.Id})
            
            #line default
            #line hidden
, 9378), false)
);

WriteLiteral(" class=\"vos\"");

WriteAttribute("title", Tuple.Create(" title=\"", 9433), Tuple.Create("\"", 9465)
            
            #line 148 "..\..\Views\Clients\ClientPresenters.cshtml"
                            , Tuple.Create(Tuple.Create("", 9441), Tuple.Create<System.Object, System.Int32>(SharedResources.Approve
            
            #line default
            #line hidden
, 9441), false)
);

WriteLiteral(">");

            
            #line 148 "..\..\Views\Clients\ClientPresenters.cshtml"
                                                                                                                                 Write(SharedResources.Approve);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n");

            
            #line 149 "..\..\Views\Clients\ClientPresenters.cshtml"
                                }
                                else
                                {

            
            #line default
            #line hidden
WriteLiteral("                                    <img");

WriteAttribute("src", Tuple.Create(" src=\"", 9645), Tuple.Create("\"", 9696)
            
            #line 152 "..\..\Views\Clients\ClientPresenters.cshtml"
, Tuple.Create(Tuple.Create("", 9651), Tuple.Create<System.Object, System.Int32>(Url.Content("~/Content/images/sing-vos.png")
            
            #line default
            #line hidden
, 9651), false)
);

WriteAttribute("alt", Tuple.Create(" alt=\"", 9697), Tuple.Create("\"", 9736)
            
            #line 152 "..\..\Views\Clients\ClientPresenters.cshtml"
                  , Tuple.Create(Tuple.Create("", 9703), Tuple.Create<System.Object, System.Int32>(SharedResources.WaitingToApprove
            
            #line default
            #line hidden
, 9703), false)
);

WriteAttribute("title", Tuple.Create(" title=\"", 9737), Tuple.Create("\"", 9778)
            
            #line 152 "..\..\Views\Clients\ClientPresenters.cshtml"
                                                            , Tuple.Create(Tuple.Create("", 9745), Tuple.Create<System.Object, System.Int32>(SharedResources.WaitingToApprove
            
            #line default
            #line hidden
, 9745), false)
);

WriteLiteral(" />\r\n");

            
            #line 153 "..\..\Views\Clients\ClientPresenters.cshtml"
                                }
                            }

            
            #line default
            #line hidden
WriteLiteral("                        </td>\r\n                    </tr>\r\n");

            
            #line 157 "..\..\Views\Clients\ClientPresenters.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("            </tbody>\r\n        </table>\r\n\r\n    </div>\r\n</div>\r\n");

        }
    }
}
#pragma warning restore 1591
