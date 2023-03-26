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
    
    #line 1 "..\..\Views\Garage\Index.cshtml"
    using ViewRes;
    
    #line default
    #line hidden
    using Webmall.UI;
    using Webmall.UI.Core.Localization;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Garage/Index.cshtml")]
    public partial class _Views_Garage_Index_cshtml : System.Web.Mvc.WebViewPage<Webmall.UI.ViewModel.Garage.GarageViewModel>
    {
        public _Views_Garage_Index_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 5 "..\..\Views\Garage\Index.cshtml"
  
    Layout = "~/Views/Shared/_PersonalLayout.cshtml";
    ViewBag.Title = SharedResources.MyGarage;

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteLiteral(" class=\"addresses\"");

WriteLiteral(">\r\n    <h1");

WriteLiteral(" class=\"page-intro__heading main-heading\"");

WriteLiteral(">");

            
            #line 11 "..\..\Views\Garage\Index.cshtml"
                                            Write(ViewBag.Title);

            
            #line default
            #line hidden
WriteLiteral("</h1>\r\n    ");

WriteLiteral("\r\n    <div");

WriteLiteral(" class=\"addresses__header\"");

WriteLiteral(">\r\n        <a");

WriteLiteral(" class=\"addresses__btn btn btn--primary\"");

WriteLiteral(" href=\"#\"");

WriteLiteral(" data-modal-win-trigger=\"address-detail\"");

WriteLiteral("\r\n           id=\"addr-0\"");

WriteLiteral(" data-close-outside=\"false\"");

WriteLiteral(" data-after-open=\"UpdateCarDialog()\"");

WriteLiteral("\r\n           data-id=\"0\"");

WriteLiteral(" data-data=\"\"");

WriteLiteral(">");

            
            #line 16 "..\..\Views\Garage\Index.cshtml"
                               Write(SharedResources.NewCar);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n    </div>\r\n\r\n    <div");

WriteLiteral(" class=\"addresses__main\"");

WriteLiteral(">\r\n");

            
            #line 20 "..\..\Views\Garage\Index.cshtml"
        
            
            #line default
            #line hidden
            
            #line 20 "..\..\Views\Garage\Index.cshtml"
         foreach (var item in Model.Cars)
        {
            Html.RenderPartial("_CarCard", item);
        }

            
            #line default
            #line hidden
WriteLiteral("    </div>\r\n</div>\r\n\r\n");

DefineSection("scripts", () => {

WriteLiteral("\r\n    <script>\r\n        var markaSelector, modelSelector, modificationSelector;\r\n" +
"        var carData;\r\n\r\n        $(function() {\r\n            markaSelector = new " +
"Choices(document.querySelector(\'#Marka\'));\r\n            modelSelector = new Choi" +
"ces(document.querySelector(\'#Model\'));\r\n            modificationSelector = new C" +
"hoices(document.querySelector(\'#Modification\'));\r\n        });\r\n\r\n        functio" +
"n UpdateCarDialog(id) {\r\n            var el = document.getElementById(\"addr-\" + " +
"id);\r\n            if (el && el.dataset.data) {\r\n                carData = JSON.p" +
"arse(el.dataset.data);\r\n            } else\r\n                carData = { isNew: t" +
"rue };\r\n\r\n            markaSelector.setChoiceByValue(carData.MarkaId);\r\n        " +
"    MarkaSelected();\r\n            if (carData.isNew) {\r\n                document" +
".getElementById(\"CarId\").value = \"\";\r\n                document.getElementById(\"V" +
"in\").value = \"\";\r\n                document.getElementById(\"Year\").value = \"\";\r\n " +
"               document.getElementById(\"Comment\").value = \"\";\r\n                d" +
"ocument.getElementById(\"Contacts\").value = \"\";\r\n            } else {\r\n          " +
"      document.getElementById(\"CarId\").value = carData.Id;\r\n                docu" +
"ment.getElementById(\"Vin\").value = carData.Vin;\r\n                document.getEle" +
"mentById(\"Year\").value = carData.Year;\r\n                document.getElementById(" +
"\"Comment\").value = carData.Comment;\r\n                document.getElementById(\"Co" +
"ntacts\").value = carData.Contacts;\r\n            }\r\n        }\r\n\r\n        function" +
" MarkaSelected(obj) {\r\n            modelSelector.clearChoices();\r\n            mo" +
"delSelector.setValue([\"\"]);\r\n            $.getJSON(\"");

            
            #line 66 "..\..\Views\Garage\Index.cshtml"
                  Write(Url.Action("GetModelsList", "SelectionByAuto"));

            
            #line default
            #line hidden
WriteLiteral(@"?markId="" + $(""#Marka"").val()).done(function(data) {
                if (data)
                    modelSelector.setChoices(data, 'Value', 'Text', true);
                if (carData.ModelId) {
                    modelSelector.setChoiceByValue(carData.ModelId);
                    carData.ModelId = null;
                }
                ModelSelected();
            });
        }

        function ModelSelected(obj) {
            modificationSelector.clearChoices();
            modificationSelector.setValue([""""]);
            $.getJSON(""");

            
            #line 80 "..\..\Views\Garage\Index.cshtml"
                  Write(Url.Action("GetModifListByModel", "SelectionByAuto"));

            
            #line default
            #line hidden
WriteLiteral(@"?modelId="" + $(""#Model"").val()).done(function(data) {
                if (data)
                    modificationSelector.setChoices(data, 'Id', 'Name', true);
                if (carData.ModificationId) {
                    modificationSelector.setChoiceByValue(carData.ModificationId);
                    carData.ModificationId = null;
                }
            });
        }
                ");

WriteLiteral("\r\n\r\n        function deleteCar(id) {\r\n            if (!confirm(\'");

            
            #line 122 "..\..\Views\Garage\Index.cshtml"
                     Write(SharedResources.AreYouSure);

            
            #line default
            #line hidden
WriteLiteral("\')) return;\r\n\r\n            $.post(\'");

            
            #line 124 "..\..\Views\Garage\Index.cshtml"
               Write(Url.Action("Delete"));

            
            #line default
            #line hidden
WriteLiteral("?id=\' + id, null, function (content) {\r\n                $(\'#user-car-\' + id).remo" +
"ve();\r\n                $(\'#cont-\' + id).remove();\r\n            });\r\n        }\r\n\r" +
"\n    </script>\r\n");

});

DefineSection("BreadCrumbs", () => {

WriteLiteral("\r\n    <ul");

WriteLiteral(" class=\"breadcrumbs\"");

WriteLiteral("></ul>\r\n");

});

WriteLiteral("\r\n\r\n");

DefineSection("dialogs", () => {

WriteLiteral("\r\n");

            
            #line 140 "..\..\Views\Garage\Index.cshtml"
    
            
            #line default
            #line hidden
            
            #line 140 "..\..\Views\Garage\Index.cshtml"
       Html.RenderPartial("CarDialog", Model); 
            
            #line default
            #line hidden
WriteLiteral("\r\n");

});

        }
    }
}
#pragma warning restore 1591