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
    
    #line 1 "..\..\Areas\Test\Views\Catalog2\CatalogListNoPagination.cshtml"
    using ViewRes;
    
    #line default
    #line hidden
    using Webmall.UI;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/Test/Views/Catalog2/CatalogListNoPagination.cshtml")]
    public partial class _Areas_Test_Views_Catalog2_CatalogListNoPagination_cshtml : System.Web.Mvc.WebViewPage<Webmall.UI.Models.Catalog.CatalogWaresModel>
    {
        public _Areas_Test_Views_Catalog2_CatalogListNoPagination_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<div");

WriteLiteral(" class=\"table-responsive d-none d-md-block\"");

WriteLiteral(">\r\n    <table");

WriteLiteral(" class=\"stock-table\"");

WriteLiteral(">\r\n        <thead");

WriteLiteral(" class=\"stock-table__thead\"");

WriteLiteral(">\r\n            <tr");

WriteLiteral(" class=\"stock-table__tr\"");

WriteLiteral(">\r\n                <th");

WriteLiteral(" class=\"stock-table__th\"");

WriteLiteral("></th>\r\n                <th");

WriteLiteral(" class=\"stock-table__th\"");

WriteLiteral(">");

            
            #line 9 "..\..\Areas\Test\Views\Catalog2\CatalogListNoPagination.cshtml"
                                       Write(SharedResources.Brand);

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                <th");

WriteLiteral(" class=\"stock-table__th\"");

WriteLiteral(">");

            
            #line 10 "..\..\Areas\Test\Views\Catalog2\CatalogListNoPagination.cshtml"
                                       Write(SharedResources.PartNumber);

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                <th");

WriteLiteral(" class=\"stock-table__th\"");

WriteLiteral(">");

            
            #line 11 "..\..\Areas\Test\Views\Catalog2\CatalogListNoPagination.cshtml"
                                       Write(SharedResources.Name);

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n            </tr>\r\n        </thead>\r\n");

            
            #line 14 "..\..\Areas\Test\Views\Catalog2\CatalogListNoPagination.cshtml"
        
            
            #line default
            #line hidden
            
            #line 14 "..\..\Areas\Test\Views\Catalog2\CatalogListNoPagination.cshtml"
         foreach (var ware in Model.Wares.List)
        {

            
            #line default
            #line hidden
WriteLiteral("            <tbody");

WriteLiteral(" class=\"stock-table__tbody\"");

WriteLiteral(">\r\n                <tr");

WriteLiteral(" class=\"stock-table__tr\"");

WriteLiteral(">\r\n                    <td");

WriteLiteral(" class=\"stock-table__td\"");

WriteLiteral(">\r\n                        ");

WriteLiteral("\r\n                    </td>\r\n                    <td");

WriteLiteral(" class=\"stock-table__td\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"stock-table__meta\"");

WriteLiteral(">\r\n                            <a");

WriteLiteral(" class=\"stock-table__meta-title\"");

WriteAttribute("href", Tuple.Create(" href=\"", 1038), Tuple.Create("\"", 1054)
            
            #line 23 "..\..\Areas\Test\Views\Catalog2\CatalogListNoPagination.cshtml"
, Tuple.Create(Tuple.Create("", 1045), Tuple.Create<System.Object, System.Int32>(ware.Url
            
            #line default
            #line hidden
, 1045), false)
);

WriteLiteral(">");

            
            #line 23 "..\..\Areas\Test\Views\Catalog2\CatalogListNoPagination.cshtml"
                                                                           Write(ware.ProducerName);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                        </div>\r\n                    </td>\r\n                " +
"    <td");

WriteLiteral(" class=\"stock-table__td\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"stock-table__meta\"");

WriteLiteral(">\r\n                            <a");

WriteLiteral(" class=\"stock-table__meta-title\"");

WriteAttribute("href", Tuple.Create(" href=\"", 1308), Tuple.Create("\"", 1324)
            
            #line 28 "..\..\Areas\Test\Views\Catalog2\CatalogListNoPagination.cshtml"
, Tuple.Create(Tuple.Create("", 1315), Tuple.Create<System.Object, System.Int32>(ware.Url
            
            #line default
            #line hidden
, 1315), false)
);

WriteLiteral(">");

            
            #line 28 "..\..\Areas\Test\Views\Catalog2\CatalogListNoPagination.cshtml"
                                                                           Write(ware.WareNumber);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                        </div>\r\n                    </td>\r\n                " +
"    <td");

WriteLiteral(" class=\"stock-table__td\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"stock-table__meta\"");

WriteLiteral(">\r\n                            <a");

WriteLiteral(" class=\"stock-table__meta-title\"");

WriteAttribute("href", Tuple.Create(" href=\"", 1576), Tuple.Create("\"", 1592)
            
            #line 33 "..\..\Areas\Test\Views\Catalog2\CatalogListNoPagination.cshtml"
, Tuple.Create(Tuple.Create("", 1583), Tuple.Create<System.Object, System.Int32>(ware.Url
            
            #line default
            #line hidden
, 1583), false)
);

WriteLiteral(">");

            
            #line 33 "..\..\Areas\Test\Views\Catalog2\CatalogListNoPagination.cshtml"
                                                                           Write(ware.Name);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                        </div>\r\n                    </td>\r\n                " +
"</tr>\r\n            </tbody>\r\n");

            
            #line 38 "..\..\Areas\Test\Views\Catalog2\CatalogListNoPagination.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("    </table>\r\n</div>\r\n\r\n");

        }
    }
}
#pragma warning restore 1591
