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
    
    #line 1 "..\..\Views\Clients\_ContractCard.cshtml"
    using ViewRes;
    
    #line default
    #line hidden
    using Webmall.UI;
    using Webmall.UI.Core.Localization;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Clients/_ContractCard.cshtml")]
    public partial class _Views_Clients__ContractCard_cshtml : System.Web.Mvc.WebViewPage<Webmall.Model.Entities.Client.Contract>
    {
        public _Views_Clients__ContractCard_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 4 "..\..\Views\Clients\_ContractCard.cshtml"
   var item = Model; 
            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<article");

WriteLiteral(" class=\"addresses__address address-card\"");

WriteAttribute("id", Tuple.Create(" id=\"", 139), Tuple.Create("\"", 166)
, Tuple.Create(Tuple.Create("", 144), Tuple.Create("cont-contract-", 144), true)
            
            #line 6 "..\..\Views\Clients\_ContractCard.cshtml"
, Tuple.Create(Tuple.Create("", 158), Tuple.Create<System.Object, System.Int32>(item.Id
            
            #line default
            #line hidden
, 158), false)
);

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"address-card__heading\"");

WriteLiteral(">");

            
            #line 7 "..\..\Views\Clients\_ContractCard.cshtml"
                                  Write(item.Name);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n    <div");

WriteLiteral(" class=\"params__param\"");

WriteLiteral(">\r\n        <dd");

WriteLiteral(" class=\"params__value\"");

WriteLiteral(">");

            
            #line 9 "..\..\Views\Clients\_ContractCard.cshtml"
                             Write(item.Description);

            
            #line default
            #line hidden
WriteLiteral("</dd>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"address-card__main\"");

WriteLiteral(">\r\n        <dl");

WriteLiteral(" class=\"address-card__params params\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"params__param\"");

WriteLiteral(">\r\n                <dt");

WriteLiteral(" class=\"params__property\"");

WriteLiteral(">");

            
            #line 14 "..\..\Views\Clients\_ContractCard.cshtml"
                                        Write(SharedResources.Credit);

            
            #line default
            #line hidden
WriteLiteral("</dt>\r\n                <dd");

WriteLiteral(" class=\"params__value\"");

WriteLiteral(">");

            
            #line 15 "..\..\Views\Clients\_ContractCard.cshtml"
                                      Write(item.MaxSum > 0 ? item.MaxSum?.ToString("n0") : SharedResources.No);

            
            #line default
            #line hidden
WriteLiteral("</dd>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"params__param\"");

WriteLiteral(">\r\n                <dt");

WriteLiteral(" class=\"params__property\"");

WriteLiteral(">");

            
            #line 18 "..\..\Views\Clients\_ContractCard.cshtml"
                                        Write(SharedResources.PaymentConditions);

            
            #line default
            #line hidden
WriteLiteral("</dt>\r\n                <dd");

WriteLiteral(" class=\"params__value\"");

WriteLiteral(">");

            
            #line 19 "..\..\Views\Clients\_ContractCard.cshtml"
                                      Write(item.PayDelayDays == 0 ? SharedResources.No : item.PayDelayDays.ToString());

            
            #line default
            #line hidden
WriteLiteral("</dd>\r\n            </div>\r\n        </dl>\r\n    </div>\r\n</article>\r\n");

        }
    }
}
#pragma warning restore 1591