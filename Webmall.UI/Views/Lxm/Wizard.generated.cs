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
    
    #line 1 "..\..\Views\Lxm\Wizard.cshtml"
    using ViewRes;
    
    #line default
    #line hidden
    using Webmall.UI;
    using Webmall.UI.Core.Localization;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Lxm/Wizard.cshtml")]
    public partial class _Views_Lxm_Wizard_cshtml : System.Web.Mvc.WebViewPage<Webmall.UI.Models.Laximo.WizardModel>
    {
        public _Views_Lxm_Wizard_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 4 "..\..\Views\Lxm\Wizard.cshtml"
  
    Layout = null;

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 8 "..\..\Views\Lxm\Wizard.cshtml"
 using (Html.BeginForm("Wizard", "Lxm", FormMethod.Get))
{
    
            
            #line default
            #line hidden
            
            #line 10 "..\..\Views\Lxm\Wizard.cshtml"
Write(Html.HiddenFor(m => m.CatalogId));

            
            #line default
            #line hidden
            
            #line 10 "..\..\Views\Lxm\Wizard.cshtml"
                                     

    foreach (var item in Model.Rows)
    {
        var selected = !string.IsNullOrEmpty(item.Value);

            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\"select-picker__stage\"");

WriteLiteral(">\r\n            <div>\r\n");

WriteLiteral("                ");

            
            #line 17 "..\..\Views\Lxm\Wizard.cshtml"
           Write(item.Name);

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 18 "..\..\Views\Lxm\Wizard.cshtml"
                
            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\Lxm\Wizard.cshtml"
                 if (selected)
                {

            
            #line default
            #line hidden
WriteLiteral("                    <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" data-ssd=\"");

            
            #line 20 "..\..\Views\Lxm\Wizard.cshtml"
                                     Write(item.Ssd);

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral("> X</a>\r\n");

            
            #line 21 "..\..\Views\Lxm\Wizard.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("            </div>\r\n            <div");

WriteLiteral(" class=\"input-field\"");

WriteLiteral(">\r\n                <select");

WriteAttribute("id", Tuple.Create(" id=\"", 602), Tuple.Create("\"", 617)
            
            #line 24 "..\..\Views\Lxm\Wizard.cshtml"
, Tuple.Create(Tuple.Create("", 607), Tuple.Create<System.Object, System.Int32>(item.Name
            
            #line default
            #line hidden
, 607), false)
);

WriteLiteral(" class=\"js-select-lxm\"");

WriteAttribute("name", Tuple.Create(" name=\"", 640), Tuple.Create("\"", 657)
            
            #line 24 "..\..\Views\Lxm\Wizard.cshtml"
, Tuple.Create(Tuple.Create("", 647), Tuple.Create<System.Object, System.Int32>(item.Name
            
            #line default
            #line hidden
, 647), false)
);

WriteLiteral(" ");

            
            #line 24 "..\..\Views\Lxm\Wizard.cshtml"
                                                                            Write(selected ? "disabled" : "");

            
            #line default
            #line hidden
WriteLiteral(">\r\n");

            
            #line 25 "..\..\Views\Lxm\Wizard.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 25 "..\..\Views\Lxm\Wizard.cshtml"
                     if (selected)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <option");

WriteLiteral(" value=\"\"");

WriteLiteral(">");

            
            #line 27 "..\..\Views\Lxm\Wizard.cshtml"
                                    Write(item.Value);

            
            #line default
            #line hidden
WriteLiteral("</option>\r\n");

            
            #line 28 "..\..\Views\Lxm\Wizard.cshtml"
                    }
                    else
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <option");

WriteLiteral(" value=\"\"");

WriteLiteral(">");

            
            #line 31 "..\..\Views\Lxm\Wizard.cshtml"
                                    Write(SharedResources.SelectValue);

            
            #line default
            #line hidden
WriteLiteral("</option>\r\n");

            
            #line 32 "..\..\Views\Lxm\Wizard.cshtml"
                        foreach (var opt in item.Options)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <option");

WriteAttribute("value", Tuple.Create(" value=\"", 1086), Tuple.Create("\"", 1102)
            
            #line 34 "..\..\Views\Lxm\Wizard.cshtml"
, Tuple.Create(Tuple.Create("", 1094), Tuple.Create<System.Object, System.Int32>(opt.Key
            
            #line default
            #line hidden
, 1094), false)
);

WriteLiteral(">");

            
            #line 34 "..\..\Views\Lxm\Wizard.cshtml"
                                                Write(opt.Value);

            
            #line default
            #line hidden
WriteLiteral("</option>\r\n");

            
            #line 35 "..\..\Views\Lxm\Wizard.cshtml"
                        }
                    }

            
            #line default
            #line hidden
WriteLiteral("                </select>\r\n            </div>\r\n        </div>\r\n");

            
            #line 40 "..\..\Views\Lxm\Wizard.cshtml"
    }
    if (Model.AllowShowAutos)
    {

            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\"select-picker__bottom\"");

WriteLiteral(">\r\n            <button");

WriteLiteral(" class=\"select-picker__btn btn btn--primary btn--block\"");

WriteLiteral(" type=\"button\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 1416), Tuple.Create("\"", 1464)
, Tuple.Create(Tuple.Create("", 1426), Tuple.Create("ShowAutos(\'", 1426), true)
            
            #line 44 "..\..\Views\Lxm\Wizard.cshtml"
                             , Tuple.Create(Tuple.Create("", 1437), Tuple.Create<System.Object, System.Int32>(Model.Ssd
            
            #line default
            #line hidden
, 1437), false)
, Tuple.Create(Tuple.Create("", 1447), Tuple.Create("\');", 1447), true)
, Tuple.Create(Tuple.Create(" ", 1450), Tuple.Create("return", 1451), true)
, Tuple.Create(Tuple.Create(" ", 1457), Tuple.Create("false;", 1458), true)
);

WriteLiteral(">");

            
            #line 44 "..\..\Views\Lxm\Wizard.cshtml"
                                                                                                                                     Write(SharedResources.Show);

            
            #line default
            #line hidden
WriteLiteral("</button>\r\n        </div>\r\n");

            
            #line 46 "..\..\Views\Lxm\Wizard.cshtml"
    }
}

            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
