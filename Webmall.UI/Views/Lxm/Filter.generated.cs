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
    
    #line 1 "..\..\Views\Lxm\Filter.cshtml"
    using ViewRes;
    
    #line default
    #line hidden
    using Webmall.UI;
    
    #line 2 "..\..\Views\Lxm\Filter.cshtml"
    using Webmall.UI.Core;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Views\Lxm\Filter.cshtml"
    using Webmall.UI.Models.Laximo;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Lxm/Filter.cshtml")]
    public partial class _Views_Lxm_Filter_cshtml : System.Web.Mvc.WebViewPage<FilterModel>
    {
        public _Views_Lxm_Filter_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\n");

            
            #line 7 "..\..\Views\Lxm\Filter.cshtml"
  
    Layout = null;
    ViewBag.Title = "Filter";
    var baseModel = Model.Clone();

            
            #line default
            #line hidden
WriteLiteral("\n\n");

            
            #line 13 "..\..\Views\Lxm\Filter.cshtml"
 using (Html.BeginForm("Unit", "Lxm", FormMethod.Get))
{
    
            
            #line default
            #line hidden
            
            #line 15 "..\..\Views\Lxm\Filter.cshtml"
Write(Html.HiddenFor(m=>Model.VehicleId));

            
            #line default
            #line hidden
            
            #line 15 "..\..\Views\Lxm\Filter.cshtml"
                                       
    
            
            #line default
            #line hidden
            
            #line 16 "..\..\Views\Lxm\Filter.cshtml"
Write(Html.HiddenFor(m => Model.CatalogId));

            
            #line default
            #line hidden
            
            #line 16 "..\..\Views\Lxm\Filter.cshtml"
                                         
    
            
            #line default
            #line hidden
            
            #line 17 "..\..\Views\Lxm\Filter.cshtml"
Write(Html.HiddenFor(m => Model.CategoryId));

            
            #line default
            #line hidden
            
            #line 17 "..\..\Views\Lxm\Filter.cshtml"
                                          
    
            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\Lxm\Filter.cshtml"
Write(Html.HiddenFor(m => Model.UnitId));

            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\Lxm\Filter.cshtml"
                                      
    
            
            #line default
            #line hidden
            
            #line 19 "..\..\Views\Lxm\Filter.cshtml"
Write(Html.HiddenFor(m => Model.Ssd));

            
            #line default
            #line hidden
            
            #line 19 "..\..\Views\Lxm\Filter.cshtml"
                                   


            
            #line default
            #line hidden
WriteLiteral("    <label");

WriteLiteral(" class=\"long\"");

WriteLiteral(">\n");

WriteLiteral("        ");

            
            #line 22 "..\..\Views\Lxm\Filter.cshtml"
   Write(Model.Filters[0].Name);

            
            #line default
            #line hidden
WriteLiteral("<br>\n");

WriteLiteral("        ");

            
            #line 23 "..\..\Views\Lxm\Filter.cshtml"
   Write(Html.DropDownList("filter",  Model.Filters[0].Values.Select(i=>new SelectListItem { Text = i.Name, Value = i.SsdModification })));

            
            #line default
            #line hidden
WriteLiteral("\n    </label>\n");

WriteLiteral("    <br />\n");

            
            #line 26 "..\..\Views\Lxm\Filter.cshtml"

    
            
            #line default
            #line hidden
            
            #line 27 "..\..\Views\Lxm\Filter.cshtml"
Write(Html.SubmitButton(SharedResources.Select));

            
            #line default
            #line hidden
            
            #line 27 "..\..\Views\Lxm\Filter.cshtml"
                                              
}

            
            #line default
            #line hidden
WriteLiteral("\n");

        }
    }
}
#pragma warning restore 1591