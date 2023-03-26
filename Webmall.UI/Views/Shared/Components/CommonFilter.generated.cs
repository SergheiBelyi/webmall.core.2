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
    
    #line 1 "..\..\Views\Shared\Components\CommonFilter.cshtml"
    using System.Web.Mvc.Html;
    
    #line default
    #line hidden
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using HtmlHelpers.BeginCollectionItem;
    
    #line 2 "..\..\Views\Shared\Components\CommonFilter.cshtml"
    using ViewRes;
    
    #line default
    #line hidden
    using Webmall.UI;
    using Webmall.UI.Core.Localization;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/Components/CommonFilter.cshtml")]
    public partial class _Views_Shared_Components_CommonFilter_cshtml : System.Web.Mvc.WebViewPage<Webmall.UI.ViewModel.Common.BaseFilterViewModel>
    {
        public _Views_Shared_Components_CommonFilter_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n<form");

WriteLiteral(" class=\"filter catalog-layout__filter\"");

WriteLiteral(" id=\"filterForm\"");

WriteLiteral(" name=\"filterForm\"");

WriteLiteral(" method=\"get\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"filter__mob-header\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"filter__mob-heading filter__close\"");

WriteLiteral(">");

            
            #line 8 "..\..\Views\Shared\Components\CommonFilter.cshtml"
                                                  Write(SharedResources.Filters);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n        <button");

WriteLiteral(" class=\"filter__collapse\"");

WriteLiteral(">");

            
            #line 9 "..\..\Views\Shared\Components\CommonFilter.cshtml"
                                    Write(SharedResources.CollapseAll);

            
            #line default
            #line hidden
WriteLiteral("</button>\r\n    </div>\r\n\r\n    <div");

WriteLiteral(" class=\"filter__header\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"filter__heading\"");

WriteLiteral(">");

            
            #line 13 "..\..\Views\Shared\Components\CommonFilter.cshtml"
                                Write(SharedResources.Filters);

            
            #line default
            #line hidden
WriteLiteral("</div><span");

WriteLiteral(" class=\"filter__collapse\"");

WriteLiteral(">");

            
            #line 13 "..\..\Views\Shared\Components\CommonFilter.cshtml"
                                                                                             Write(SharedResources.CollapseAll);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n    </div>\r\n\r\n    <div");

WriteLiteral(" class=\"filter__main\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"filter__sections\"");

WriteLiteral(">\r\n");

            
            #line 18 "..\..\Views\Shared\Components\CommonFilter.cshtml"
            
            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\Shared\Components\CommonFilter.cshtml"
             foreach(var section in Model.Sections)
            {
                Html.RenderPartial("Components/FilterSelectSection", section);
            }

            
            #line default
            #line hidden
WriteLiteral("        </div>\r\n        <div");

WriteLiteral(" class=\"filter__footer\"");

WriteLiteral(">\r\n            <a");

WriteLiteral(" class=\"filter__btn-reset btn btn--primary-reverse btn--sm\"");

WriteLiteral(" href=\"#\"");

WriteLiteral(" onclick=\"return resetFilter()\"");

WriteLiteral(">\r\n                <svg");

WriteLiteral(" class=\"icon icon-close btn__icon\"");

WriteLiteral(" width=\"25\"");

WriteLiteral(" height=\"25\"");

WriteLiteral(">\r\n                    <use");

WriteAttribute("href", Tuple.Create(" href=\"", 1108), Tuple.Create("\"", 1174)
            
            #line 26 "..\..\Views\Shared\Components\CommonFilter.cshtml"
, Tuple.Create(Tuple.Create("", 1115), Tuple.Create<System.Object, System.Int32>(Url.Content("~/assets/images/svg/symbol/sprite.svg#close")
            
            #line default
            #line hidden
, 1115), false)
);

WriteLiteral("></use>\r\n                </svg><span");

WriteLiteral(" class=\"btn__text\"");

WriteLiteral(">");

            
            #line 27 "..\..\Views\Shared\Components\CommonFilter.cshtml"
                                         Write(SharedResources.Reset);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n            </a>\r\n");

            
            #line 29 "..\..\Views\Shared\Components\CommonFilter.cshtml"
            
            
            #line default
            #line hidden
            
            #line 29 "..\..\Views\Shared\Components\CommonFilter.cshtml"
             if (!Model.AutoSubmit)
            {

            
            #line default
            #line hidden
WriteLiteral("                <a");

WriteLiteral(" class=\"filter__btn-accept btn btn--primary btn--sm\"");

WriteLiteral(" href=\"\"");

WriteLiteral(" onclick=\"return submitFilter()\"");

WriteLiteral(">");

            
            #line 31 "..\..\Views\Shared\Components\CommonFilter.cshtml"
                                                                                                          Write(SharedResources.Apply);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n");

            
            #line 32 "..\..\Views\Shared\Components\CommonFilter.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("        </div>\r\n    </div>\r\n\r\n</form>\r\n\r\n");

        }
    }
}
#pragma warning restore 1591
