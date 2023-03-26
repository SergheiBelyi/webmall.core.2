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
    
    #line 1 "..\..\Views\Cart\Preview.cshtml"
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
    
    #line 2 "..\..\Views\Cart\Preview.cshtml"
    using ViewRes;
    
    #line default
    #line hidden
    using Webmall.UI;
    
    #line 3 "..\..\Views\Cart\Preview.cshtml"
    using Webmall.UI.Core;
    
    #line default
    #line hidden
    using Webmall.UI.Core.Localization;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Cart/Preview.cshtml")]
    public partial class _Views_Cart_Preview_cshtml : System.Web.Mvc.WebViewPage<IEnumerable<Webmall.UI.Models.Cart.OrderPreviewModel>>
    {
        public _Views_Cart_Preview_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 5 "..\..\Views\Cart\Preview.cshtml"
  
    Layout = "~/Views/Shared/_PersonalLayout.cshtml";
    var valuteName = SessionHelper.DefaultValute.Code;

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

WriteLiteral("<aside");

WriteLiteral(" id=\"catalog-content\"");

WriteLiteral(">\r\n    <h2>");

            
            #line 13 "..\..\Views\Cart\Preview.cshtml"
   Write(SharedResources.OrderPreview);

            
            #line default
            #line hidden
WriteLiteral("</h2>\r\n");

WriteLiteral("    ");

            
            #line 14 "..\..\Views\Cart\Preview.cshtml"
Write(new HtmlString (SharedResources.OrderPreviewComment));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 15 "..\..\Views\Cart\Preview.cshtml"
    
            
            #line default
            #line hidden
            
            #line 15 "..\..\Views\Cart\Preview.cshtml"
     using (Html.BeginForm("Create", "Order", FormMethod.Post, new { @class = "shopping-cart-form" }))
    {
        int i = 0;
        foreach (var item in Model)
        {
            var groupId = string.Format("group_{0}", i);

            
            #line default
            #line hidden
WriteLiteral("            <h3>");

            
            #line 21 "..\..\Views\Cart\Preview.cshtml"
           Write(string.Format(SharedResources.Order + " № {0}", i + 1));

            
            #line default
            #line hidden
WriteLiteral("</h3>\r\n");

WriteLiteral("            <ul>\r\n                <li><b>");

            
            #line 23 "..\..\Views\Cart\Preview.cshtml"
                  Write(SharedResources.Amount);

            
            #line default
            #line hidden
WriteLiteral(":</b> ");

            
            #line 23 "..\..\Views\Cart\Preview.cshtml"
                                               Write(item.Positions.Count());

            
            #line default
            #line hidden
WriteLiteral(" ");

            
            #line 23 "..\..\Views\Cart\Preview.cshtml"
                                                                       Write(SharedResources.positions);

            
            #line default
            #line hidden
WriteLiteral(" </li>\r\n                <li><b>");

            
            #line 24 "..\..\Views\Cart\Preview.cshtml"
                  Write(SharedResources.Sum);

            
            #line default
            #line hidden
WriteLiteral(":</b> ");

            
            #line 24 "..\..\Views\Cart\Preview.cshtml"
                                            Write(SessionHelper.PriceFormat(item.Positions.Sum(pos => pos.ClientPrice * pos.WareQnt)));

            
            #line default
            #line hidden
WriteLiteral(" ");

            
            #line 24 "..\..\Views\Cart\Preview.cshtml"
                                                                                                                                 Write(valuteName);

            
            #line default
            #line hidden
WriteLiteral("</li>\r\n                <li><b>");

            
            #line 25 "..\..\Views\Cart\Preview.cshtml"
                  Write(SharedResources.Client);

            
            #line default
            #line hidden
WriteLiteral(":</b> ");

            
            #line 25 "..\..\Views\Cart\Preview.cshtml"
                                               Write(item.Term);

            
            #line default
            #line hidden
WriteLiteral("</li>\r\n            </ul>\r\n");

WriteLiteral("            <table");

WriteLiteral(" class=\"all-product clients cart\"");

WriteLiteral(">\r\n                <thead>\r\n                    <tr>\r\n                        <th" +
"");

WriteLiteral(" width=\"18\"");

WriteLiteral("><input");

WriteAttribute("id", Tuple.Create(" id=\"", 1293), Tuple.Create("\"", 1306)
            
            #line 30 "..\..\Views\Cart\Preview.cshtml"
, Tuple.Create(Tuple.Create("", 1298), Tuple.Create<System.Object, System.Int32>(groupId
            
            #line default
            #line hidden
, 1298), false)
);

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" checked=\"checked\"");

WriteAttribute("onclick", Tuple.Create(" onclick=\"", 1341), Tuple.Create("\"", 1382)
            
            #line 30 "..\..\Views\Cart\Preview.cshtml"
                       , Tuple.Create(Tuple.Create("", 1351), Tuple.Create<System.Object, System.Int32>(string.Format("Group({0})", i)
            
            #line default
            #line hidden
, 1351), false)
);

WriteLiteral(" /></th>\r\n                        <th");

WriteLiteral(" width=\"220\"");

WriteLiteral(">");

            
            #line 31 "..\..\Views\Cart\Preview.cshtml"
                                   Write(SharedResources.Number);

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                        <th");

WriteLiteral(" width=\"200\"");

WriteLiteral(">");

            
            #line 32 "..\..\Views\Cart\Preview.cshtml"
                                   Write(SharedResources.WareName);

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                        <th");

WriteLiteral(" width=\"60\"");

WriteLiteral(">");

            
            #line 33 "..\..\Views\Cart\Preview.cshtml"
                                  Write(SharedResources.Brand);

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                        <th");

WriteLiteral(" width=\"80\"");

WriteLiteral(">");

            
            #line 34 "..\..\Views\Cart\Preview.cshtml"
                                  Write(SharedResources.UnitPrice);

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                        <th");

WriteLiteral(" width=\"45\"");

WriteLiteral(">");

            
            #line 35 "..\..\Views\Cart\Preview.cshtml"
                                  Write(SharedResources.Amount);

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                        <th");

WriteLiteral(" width=\"80\"");

WriteLiteral(">");

            
            #line 36 "..\..\Views\Cart\Preview.cshtml"
                                  Write(SharedResources.Sum);

            
            #line default
            #line hidden
WriteLiteral(",");

            
            #line 36 "..\..\Views\Cart\Preview.cshtml"
                                                       Write(valuteName);

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                    </tr>\r\n                </thead>\r\n");

            
            #line 39 "..\..\Views\Cart\Preview.cshtml"
                
            
            #line default
            #line hidden
            
            #line 39 "..\..\Views\Cart\Preview.cshtml"
                 foreach (var pos in item.Positions)
                {

            
            #line default
            #line hidden
WriteLiteral("                <tr>\r\n                    <td>\r\n                        <input");

WriteAttribute("id", Tuple.Create(" id=\"", 2026), Tuple.Create("\"", 2069)
            
            #line 43 "..\..\Views\Cart\Preview.cshtml"
, Tuple.Create(Tuple.Create("", 2031), Tuple.Create<System.Object, System.Int32>(string.Format("position_{0}", pos.Id)
            
            #line default
            #line hidden
, 2031), false)
);

WriteAttribute("name", Tuple.Create(" name=\"", 2070), Tuple.Create("\"", 2110)
            
            #line 43 "..\..\Views\Cart\Preview.cshtml"
 , Tuple.Create(Tuple.Create("", 2077), Tuple.Create<System.Object, System.Int32>(string.Format("subgroup_{0}", i)
            
            #line default
            #line hidden
, 2077), false)
);

WriteLiteral(" type=\"checkbox\"");

WriteLiteral(" checked=\"checked\"");

WriteAttribute("value", Tuple.Create(" value=\"", 2145), Tuple.Create("\"", 2160)
            
            #line 43 "..\..\Views\Cart\Preview.cshtml"
                                                                             , Tuple.Create(Tuple.Create("", 2153), Tuple.Create<System.Object, System.Int32>(pos.Id
            
            #line default
            #line hidden
, 2153), false)
);

WriteAttribute("onclick", Tuple.Create("\r\n                               onclick=\"", 2161), Tuple.Create("\"", 2237)
            
            #line 44 "..\..\Views\Cart\Preview.cshtml"
, Tuple.Create(Tuple.Create("", 2203), Tuple.Create<System.Object, System.Int32>(string.Format("SubGroup({0})", i)
            
            #line default
            #line hidden
, 2203), false)
);

WriteLiteral(" />\r\n                    </td>\r\n                    <td>");

            
            #line 46 "..\..\Views\Cart\Preview.cshtml"
                   Write(pos.WareNum);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                    <td>");

            
            #line 47 "..\..\Views\Cart\Preview.cshtml"
                   Write(pos.WareName);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                    <td>");

            
            #line 48 "..\..\Views\Cart\Preview.cshtml"
                   Write(pos.ProducerName);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                    <td>");

            
            #line 49 "..\..\Views\Cart\Preview.cshtml"
                   Write(pos.ClientPrice);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                    <td");

WriteLiteral(" class=\"cantity\"");

WriteLiteral(">");

            
            #line 50 "..\..\Views\Cart\Preview.cshtml"
                                   Write(pos.WareQnt);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                    <td>");

            
            #line 51 "..\..\Views\Cart\Preview.cshtml"
                    Write(string.Format("{0:0.00}", pos.Sum));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                </tr>\r\n");

            
            #line 53 "..\..\Views\Cart\Preview.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("            </table>\r\n");

            
            #line 55 "..\..\Views\Cart\Preview.cshtml"
            
            
            #line default
            #line hidden
            
            #line 56 "..\..\Views\Cart\Preview.cshtml"
                                    

            i++;
        }
        
            
            #line default
            #line hidden
            
            #line 62 "..\..\Views\Cart\Preview.cshtml"
                 

            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\"right\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 64 "..\..\Views\Cart\Preview.cshtml"
       Write(Html.SubmitButton(SharedResources.SubmitOrder));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n");

WriteLiteral("        <div");

WriteLiteral(" class=\"clear-div\"");

WriteLiteral("> </div>\r\n");

WriteLiteral("        <p");

WriteLiteral(" class=\"atention\"");

WriteLiteral("><b>");

            
            #line 67 "..\..\Views\Cart\Preview.cshtml"
                          Write(SharedResources.Total);

            
            #line default
            #line hidden
WriteLiteral(":</b> ");

            
            #line 67 "..\..\Views\Cart\Preview.cshtml"
                                                      Write(SharedResources._amount);

            
            #line default
            #line hidden
WriteLiteral(": <b>");

            
            #line 67 "..\..\Views\Cart\Preview.cshtml"
                                                                                   Write(Model.Sum(g => g.Positions.Count()));

            
            #line default
            #line hidden
WriteLiteral("</b> ");

            
            #line 67 "..\..\Views\Cart\Preview.cshtml"
                                                                                                                            Write(SharedResources.positions);

            
            #line default
            #line hidden
WriteLiteral(", ");

            
            #line 67 "..\..\Views\Cart\Preview.cshtml"
                                                                                                                                                        Write(SharedResources._sum);

            
            #line default
            #line hidden
WriteLiteral(": <b>");

            
            #line 67 "..\..\Views\Cart\Preview.cshtml"
                                                                                                                                                                                  Write(Model.Sum(g => g.Positions.Sum(pos => pos.ClientPrice * pos.WareQnt)));

            
            #line default
            #line hidden
WriteLiteral("</b> ");

            
            #line 67 "..\..\Views\Cart\Preview.cshtml"
                                                                                                                                                                                                                                                             Write(valuteName);

            
            #line default
            #line hidden
WriteLiteral(".</p>\r\n");

            
            #line 68 "..\..\Views\Cart\Preview.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("</aside>\r\n\r\n");

DefineSection("scripts", () => {

WriteLiteral("\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">

        function Group(id) {
            var checked = $(""#group_"" + id).is(':checked');
            var subGroupName = 'subgroup_' + id;
            if (checked) {
                $(""input[name="" + subGroupName + ""]"").prop('checked', 'checked');
            } else {
                $(""input[name="" + subGroupName + ""]"").removeAttr('checked');
            }
        }

        function SubGroup(id) {
            var groupName = '#group_' + id;
            var subGroupName = 'subgroup_' + id;
            if ($(""input[name="" + subGroupName + ""]:checked"").length == $('input[name=' + subGroupName + ']').length
                && (!$(groupName).is(':checked'))) {
                $(groupName).prop('checked', 'checked');
            } else {
                $(groupName).removeAttr('checked');
            }
        }
    </script>
");

});

        }
    }
}
#pragma warning restore 1591