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
    
    #line 1 "..\..\Views\ComparisionAct\_ComparisionActDetail.cshtml"
    using ValmiStore.Model.Entities.User;
    
    #line default
    #line hidden
    using Webmall.UI;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/ComparisionAct/_ComparisionActDetail.cshtml")]
    public partial class _Views_ComparisionAct__ComparisionActDetail_cshtml : System.Web.Mvc.WebViewPage<List<ComparisionActDetail>>
    {
        public _Views_ComparisionAct__ComparisionActDetail_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 4 "..\..\Views\ComparisionAct\_ComparisionActDetail.cshtml"
   
    Layout = null;

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 8 "..\..\Views\ComparisionAct\_ComparisionActDetail.cshtml"
 foreach (var item in Model)
{

            
            #line default
            #line hidden
WriteLiteral("    <tr");

WriteLiteral(" class=\"spec-payment-table__tr\"");

WriteLiteral(">\r\n        <td");

WriteLiteral(" class=\"spec-payment-table__td\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"spec-payment-table__value-gray\"");

WriteLiteral(">");

            
            #line 12 "..\..\Views\ComparisionAct\_ComparisionActDetail.cshtml"
                                                   Write(item.WareNum);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n        </td>\r\n        <td");

WriteLiteral(" class=\"spec-payment-table__td\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"spec-payment-table__value\"");

WriteLiteral(">");

            
            #line 15 "..\..\Views\ComparisionAct\_ComparisionActDetail.cshtml"
                                              Write(item.Name);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n        </td>\r\n        <td");

WriteLiteral(" class=\"spec-payment-table__td\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"spec-payment-table__value-primary\"");

WriteLiteral(">");

            
            #line 18 "..\..\Views\ComparisionAct\_ComparisionActDetail.cshtml"
                                                      Write(item.ProducerName);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n        </td>\r\n        <td");

WriteLiteral(" class=\"spec-payment-table__td\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"spec-payment-table__value\"");

WriteLiteral(">");

            
            #line 21 "..\..\Views\ComparisionAct\_ComparisionActDetail.cshtml"
                                               Write(string.Format("{0:n2}", item.Price));

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n        </td>\r\n        <td");

WriteLiteral(" class=\"spec-payment-table__td\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"spec-payment-table__value text-center\"");

WriteLiteral(">");

            
            #line 24 "..\..\Views\ComparisionAct\_ComparisionActDetail.cshtml"
                                                          Write(item.WareQnt);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n        </td>\r\n        <td");

WriteLiteral(" class=\"spec-payment-table__td\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"spec-payment-table__value\"");

WriteLiteral(">");

            
            #line 27 "..\..\Views\ComparisionAct\_ComparisionActDetail.cshtml"
                                               Write(string.Format("{0:n2}", item.Price * item.WareQnt));

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n        </td>\r\n    </tr>\r\n");

            
            #line 30 "..\..\Views\ComparisionAct\_ComparisionActDetail.cshtml"
}

            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591