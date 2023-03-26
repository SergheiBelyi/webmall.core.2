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
    
    #line 1 "..\..\Views\VINRequest\ViewRequest.cshtml"
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
    
    #line 3 "..\..\Views\VINRequest\ViewRequest.cshtml"
    using ViewRes;
    
    #line default
    #line hidden
    
    #line 2 "..\..\Views\VINRequest\ViewRequest.cshtml"
    using Webmall.Model.Entities.User;
    
    #line default
    #line hidden
    using Webmall.UI;
    
    #line 4 "..\..\Views\VINRequest\ViewRequest.cshtml"
    using Webmall.UI.Core;
    
    #line default
    #line hidden
    using Webmall.UI.Core.Localization;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/VINRequest/ViewRequest.cshtml")]
    public partial class _Views_VINRequest_ViewRequest_cshtml : System.Web.Mvc.WebViewPage<VINRequest>
    {
        public _Views_VINRequest_ViewRequest_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 6 "..\..\Views\VINRequest\ViewRequest.cshtml"
  
    Layout = "~/Views/Shared/_PersonalLayout.cshtml";
    ViewBag.Title = SharedResources.ViewRequesByAuto;

            
            #line default
            #line hidden
WriteLiteral("\r\n<h1");

WriteLiteral(" class=\"main-title\"");

WriteLiteral(">");

            
            #line 10 "..\..\Views\VINRequest\ViewRequest.cshtml"
                  Write(SharedResources.VINRequest);

            
            #line default
            #line hidden
WriteLiteral(" №");

            
            #line 10 "..\..\Views\VINRequest\ViewRequest.cshtml"
                                               Write(Model.Id);

            
            #line default
            #line hidden
WriteLiteral("</h1>\r\n\r\n<div");

WriteLiteral(" class=\"card-specification-section\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"section-area\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"section-area__heading\"");

WriteLiteral(">");

            
            #line 14 "..\..\Views\VINRequest\ViewRequest.cshtml"
                                      Write(SharedResources.AutoData);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n        <div");

WriteLiteral(" class=\"manual-params manual-params--bigger\"");

WriteLiteral(">\r\n            <dl");

WriteLiteral(" class=\"manual-params__param\"");

WriteLiteral(">\r\n                <dt");

WriteLiteral(" class=\"manual-params__value\"");

WriteLiteral(">");

            
            #line 17 "..\..\Views\VINRequest\ViewRequest.cshtml"
                                            Write(SharedResources.AutoVINCode);

            
            #line default
            #line hidden
WriteLiteral("</dt>\r\n                <dd");

WriteLiteral(" class=\"manual-params__property\"");

WriteLiteral(">");

            
            #line 18 "..\..\Views\VINRequest\ViewRequest.cshtml"
                                               Write(Model.VIN);

            
            #line default
            #line hidden
WriteLiteral("</dd>\r\n            </dl>\r\n            <dl");

WriteLiteral(" class=\"manual-params__param\"");

WriteLiteral(">\r\n                <dt");

WriteLiteral(" class=\"manual-params__value\"");

WriteLiteral(">");

            
            #line 21 "..\..\Views\VINRequest\ViewRequest.cshtml"
                                            Write(SharedResources.AutoMarka);

            
            #line default
            #line hidden
WriteLiteral("</dt>\r\n                <dd");

WriteLiteral(" class=\"manual-params__property\"");

WriteLiteral(">");

            
            #line 22 "..\..\Views\VINRequest\ViewRequest.cshtml"
                                               Write(Model.MarkaName);

            
            #line default
            #line hidden
WriteLiteral("</dd>\r\n            </dl>\r\n            <dl");

WriteLiteral(" class=\"manual-params__param\"");

WriteLiteral(">\r\n                <dt");

WriteLiteral(" class=\"manual-params__value\"");

WriteLiteral(">");

            
            #line 25 "..\..\Views\VINRequest\ViewRequest.cshtml"
                                            Write(SharedResources.AutoModel);

            
            #line default
            #line hidden
WriteLiteral("</dt>\r\n                <dd");

WriteLiteral(" class=\"manual-params__property\"");

WriteLiteral(">");

            
            #line 26 "..\..\Views\VINRequest\ViewRequest.cshtml"
                                               Write(Model.ModelName);

            
            #line default
            #line hidden
WriteLiteral("</dd>\r\n            </dl>\r\n            <dl");

WriteLiteral(" class=\"manual-params__param\"");

WriteLiteral(">\r\n                <dt");

WriteLiteral(" class=\"manual-params__value\"");

WriteLiteral(">");

            
            #line 29 "..\..\Views\VINRequest\ViewRequest.cshtml"
                                            Write(SharedResources.AutoModification);

            
            #line default
            #line hidden
WriteLiteral("</dt>\r\n                <dd");

WriteLiteral(" class=\"manual-params__property\"");

WriteLiteral(">");

            
            #line 30 "..\..\Views\VINRequest\ViewRequest.cshtml"
                                               Write(Model.ModifName);

            
            #line default
            #line hidden
WriteLiteral("</dd>\r\n            </dl>\r\n            <dl");

WriteLiteral(" class=\"manual-params__param\"");

WriteLiteral(">\r\n                <dt");

WriteLiteral(" class=\"manual-params__value\"");

WriteLiteral(">");

            
            #line 33 "..\..\Views\VINRequest\ViewRequest.cshtml"
                                            Write(SharedResources.YearOfProduce);

            
            #line default
            #line hidden
WriteLiteral("</dt>\r\n                <dd");

WriteLiteral(" class=\"manual-params__property\"");

WriteLiteral(">");

            
            #line 34 "..\..\Views\VINRequest\ViewRequest.cshtml"
                                               Write(Model.Year);

            
            #line default
            #line hidden
WriteLiteral("</dd>\r\n            </dl>\r\n            <dl");

WriteLiteral(" class=\"manual-params__param\"");

WriteLiteral(">\r\n                <dt");

WriteLiteral(" class=\"manual-params__value\"");

WriteLiteral(">");

            
            #line 37 "..\..\Views\VINRequest\ViewRequest.cshtml"
                                            Write(SharedResources.Comment);

            
            #line default
            #line hidden
WriteLiteral("</dt>\r\n                <dd");

WriteLiteral(" class=\"manual-params__property\"");

WriteLiteral(">");

            
            #line 38 "..\..\Views\VINRequest\ViewRequest.cshtml"
                                               Write(Model.Comment);

            
            #line default
            #line hidden
WriteLiteral("</dd>\r\n            </dl>\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"section-area\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"section-area__heading\"");

WriteLiteral(">");

            
            #line 43 "..\..\Views\VINRequest\ViewRequest.cshtml"
                                      Write(SharedResources.NeedPartList);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n        <div");

WriteLiteral(" class=\"table-responsive\"");

WriteLiteral(">\r\n            <table");

WriteLiteral(" class=\"table\"");

WriteLiteral(">\r\n                <thead>\r\n                    <tr>\r\n                        <th" +
">");

            
            #line 48 "..\..\Views\VINRequest\ViewRequest.cshtml"
                       Write(SharedResources.Name);

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                        <th>");

            
            #line 49 "..\..\Views\VINRequest\ViewRequest.cshtml"
                       Write(SharedResources.Amount);

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                        <th>");

            
            #line 50 "..\..\Views\VINRequest\ViewRequest.cshtml"
                       Write(SharedResources.SelectedPartNumbers);

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                        <th>");

            
            #line 51 "..\..\Views\VINRequest\ViewRequest.cshtml"
                       Write(SharedResources.Responce);

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n");

            
            #line 52 "..\..\Views\VINRequest\ViewRequest.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 52 "..\..\Views\VINRequest\ViewRequest.cshtml"
                         if (SecurityHelper.IsUserInRoleTypes((long)UserRoles.VINRequestManager))
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <th></th>\r\n");

            
            #line 55 "..\..\Views\VINRequest\ViewRequest.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </tr>\r\n                </thead>\r\n                <tbody>\r\n");

            
            #line 59 "..\..\Views\VINRequest\ViewRequest.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 59 "..\..\Views\VINRequest\ViewRequest.cshtml"
                     foreach (var item in @Model.Parts)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <tr>\r\n                            <td>");

            
            #line 62 "..\..\Views\VINRequest\ViewRequest.cshtml"
                           Write(item.Description);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                            <td>");

            
            #line 63 "..\..\Views\VINRequest\ViewRequest.cshtml"
                           Write(item.Quantity);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                            <td>\r\n");

            
            #line 65 "..\..\Views\VINRequest\ViewRequest.cshtml"
                                
            
            #line default
            #line hidden
            
            #line 65 "..\..\Views\VINRequest\ViewRequest.cshtml"
                                  
                                    IEnumerable<string> links = new List<string>();
                                    if (item.WareNums != null)
                                    {
                                        links = item.WareNums.Replace(" ", "|").Replace(";", "|").Replace(",", "|").Split('|').Where(s => !string.IsNullOrWhiteSpace(s));
                                    }
                                
            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 72 "..\..\Views\VINRequest\ViewRequest.cshtml"
                                
            
            #line default
            #line hidden
            
            #line 72 "..\..\Views\VINRequest\ViewRequest.cshtml"
                                 foreach (var link in links)
                                {
                                    
            
            #line default
            #line hidden
            
            #line 74 "..\..\Views\VINRequest\ViewRequest.cshtml"
                               Write(Html.ActionLink(link, "Search", "Catalog", new { number = link }, null));

            
            #line default
            #line hidden
            
            #line 74 "..\..\Views\VINRequest\ViewRequest.cshtml"
                                                                                                            
                                    
            
            #line default
            #line hidden
            
            #line 75 "..\..\Views\VINRequest\ViewRequest.cshtml"
                                Write(links.Last() == link ? "" : ", ");

            
            #line default
            #line hidden
            
            #line 75 "..\..\Views\VINRequest\ViewRequest.cshtml"
                                                                       
                                }

            
            #line default
            #line hidden
WriteLiteral("                            </td>\r\n                            <td>\r\n");

WriteLiteral("                                ");

            
            #line 79 "..\..\Views\VINRequest\ViewRequest.cshtml"
                           Write(item.ResponseComment);

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </td>\r\n");

            
            #line 81 "..\..\Views\VINRequest\ViewRequest.cshtml"
                            
            
            #line default
            #line hidden
            
            #line 81 "..\..\Views\VINRequest\ViewRequest.cshtml"
                             if (SecurityHelper.IsUserInRoleTypes((long)UserRoles.VINRequestManager))
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <td>\r\n                                    <a");

WriteLiteral(" class=\"clickable\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 4052), Tuple.Create("\"", 4122)
, Tuple.Create(Tuple.Create("", 4062), Tuple.Create("showdlg(", 4062), true)
            
            #line 84 "..\..\Views\VINRequest\ViewRequest.cshtml"
, Tuple.Create(Tuple.Create("", 4070), Tuple.Create<System.Object, System.Int32>(item.Id
            
            #line default
            #line hidden
, 4070), false)
, Tuple.Create(Tuple.Create("", 4078), Tuple.Create(",", 4078), true)
, Tuple.Create(Tuple.Create(" ", 4079), Tuple.Create("\'", 4080), true)
            
            #line 84 "..\..\Views\VINRequest\ViewRequest.cshtml"
     , Tuple.Create(Tuple.Create("", 4081), Tuple.Create<System.Object, System.Int32>(item.WareNums
            
            #line default
            #line hidden
, 4081), false)
, Tuple.Create(Tuple.Create("", 4095), Tuple.Create("\',", 4095), true)
, Tuple.Create(Tuple.Create(" ", 4097), Tuple.Create("\'", 4098), true)
            
            #line 84 "..\..\Views\VINRequest\ViewRequest.cshtml"
                       , Tuple.Create(Tuple.Create("", 4099), Tuple.Create<System.Object, System.Int32>(item.ResponseComment
            
            #line default
            #line hidden
, 4099), false)
, Tuple.Create(Tuple.Create("", 4120), Tuple.Create("\')", 4120), true)
);

WriteLiteral("><img");

WriteAttribute("src", Tuple.Create(" src=\"", 4128), Tuple.Create("\"", 4175)
            
            #line 84 "..\..\Views\VINRequest\ViewRequest.cshtml"
                                                          , Tuple.Create(Tuple.Create("", 4134), Tuple.Create<System.Object, System.Int32>(Url.Content("~/Content/images/edit.png")
            
            #line default
            #line hidden
, 4134), false)
);

WriteLiteral(" width=\"21\"");

WriteLiteral(" height=\"19\"");

WriteLiteral("></a>\r\n                                </td>\r\n");

            
            #line 86 "..\..\Views\VINRequest\ViewRequest.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("                        </tr>\r\n");

            
            #line 88 "..\..\Views\VINRequest\ViewRequest.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n    <" +
"div");

WriteLiteral(" class=\"section-area__summary\"");

WriteLiteral(">\r\n        <a");

WriteLiteral(" class=\"section-area__summary-cancel\"");

WriteAttribute("href", Tuple.Create(" href=\"", 4494), Tuple.Create("\"", 4523)
            
            #line 94 "..\..\Views\VINRequest\ViewRequest.cshtml"
, Tuple.Create(Tuple.Create("", 4501), Tuple.Create<System.Object, System.Int32>(Url.Action("Index")
            
            #line default
            #line hidden
, 4501), false)
);

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-times-circle\"");

WriteLiteral("></i> ");

            
            #line 94 "..\..\Views\VINRequest\ViewRequest.cshtml"
                                                                                                            Write(SharedResources.ReturnToRequests);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n");

            
            #line 95 "..\..\Views\VINRequest\ViewRequest.cshtml"
        
            
            #line default
            #line hidden
            
            #line 95 "..\..\Views\VINRequest\ViewRequest.cshtml"
         if (SecurityHelper.IsUserInRoleTypes((long)UserRoles.VINRequestManager))
        {
            using (Html.BeginForm("MarkVINRequestAsAnswered", "VINRequest", FormMethod.Post, new { @style = "display:inline-block" }))
            {
                
            
            #line default
            #line hidden
            
            #line 99 "..\..\Views\VINRequest\ViewRequest.cshtml"
           Write(Html.Hidden("id"));

            
            #line default
            #line hidden
            
            #line 99 "..\..\Views\VINRequest\ViewRequest.cshtml"
                                  

            
            #line default
            #line hidden
WriteLiteral("                <input");

WriteLiteral(" class=\"btn btn--main\"");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" name=\"send-data\"");

WriteAttribute("value", Tuple.Create(" value=\"", 4955), Tuple.Create("\"", 4992)
            
            #line 100 "..\..\Views\VINRequest\ViewRequest.cshtml"
   , Tuple.Create(Tuple.Create("", 4963), Tuple.Create<System.Object, System.Int32>(SharedResources.SendResponce
            
            #line default
            #line hidden
, 4963), false)
);

WriteLiteral(">\r\n");

            
            #line 101 "..\..\Views\VINRequest\ViewRequest.cshtml"

                
            
            #line default
            #line hidden
            
            #line 102 "..\..\Views\VINRequest\ViewRequest.cshtml"
                                                                    
            }
        }

            
            #line default
            #line hidden
WriteLiteral("    </div>\r\n</div>\r\n");

DefineSection("dialogs", () => {

WriteLiteral("\r\n    <div");

WriteLiteral(" id=\"dialog-vin\"");

WriteLiteral(" title=\"Подбор каталожных номеров\"");

WriteLiteral(" style=\"display: none\"");

WriteLiteral(">\r\n");

            
            #line 110 "..\..\Views\VINRequest\ViewRequest.cshtml"
        
            
            #line default
            #line hidden
            
            #line 110 "..\..\Views\VINRequest\ViewRequest.cshtml"
         using (Html.BeginForm("MakeOrUpdateResponse", "VINRequest", FormMethod.Post))
        {

            
            #line default
            #line hidden
WriteLiteral("            <label>\r\n");

WriteLiteral("                ");

            
            #line 113 "..\..\Views\VINRequest\ViewRequest.cshtml"
           Write(SharedResources.SelectedPartNumbersFull);

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 114 "..\..\Views\VINRequest\ViewRequest.cshtml"
           Write(Html.TextBox("wareNums"));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </label>\r\n");

WriteLiteral("            <label>\r\n");

WriteLiteral("                ");

            
            #line 117 "..\..\Views\VINRequest\ViewRequest.cshtml"
           Write(SharedResources.Comment);

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 118 "..\..\Views\VINRequest\ViewRequest.cshtml"
           Write(Html.TextArea("responseComment"));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </label>\r\n");

WriteLiteral("            <div");

WriteLiteral(" class=\"right\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 121 "..\..\Views\VINRequest\ViewRequest.cshtml"
           Write(Html.SubmitButton(SharedResources.Save));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n");

            
            #line 123 "..\..\Views\VINRequest\ViewRequest.cshtml"
            
            
            #line default
            #line hidden
            
            #line 123 "..\..\Views\VINRequest\ViewRequest.cshtml"
       Write(Html.Hidden("id"));

            
            #line default
            #line hidden
            
            #line 123 "..\..\Views\VINRequest\ViewRequest.cshtml"
                              
            
            
            #line default
            #line hidden
            
            #line 124 "..\..\Views\VINRequest\ViewRequest.cshtml"
       Write(Html.Hidden("posid"));

            
            #line default
            #line hidden
            
            #line 124 "..\..\Views\VINRequest\ViewRequest.cshtml"
                                 
        }

            
            #line default
            #line hidden
WriteLiteral("    </div>\r\n");

});

DefineSection("scripts", () => {

WriteLiteral("\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">

        function showdlg(posid, wareNums, responseComment) {
            $('#posid').val(posid);
            $('#wareNums').val(wareNums);
            $('#responseComment').val(responseComment);
            $('#dialog-vin').dialog('open');
        }

        $(function () {
            $(""#dialog-vin"").dialog({
                autoOpen: false,
                show: {
                    effect: ""fade"",
                    duration: 500
                },
                hide: {
                    effect: ""fade"",
                    duration: 500
                }
            });
        });
    </script>
");

});

        }
    }
}
#pragma warning restore 1591
