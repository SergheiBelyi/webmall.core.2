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
    using Webmall.UI;
    
    #line 1 "..\..\Views\Brands\Index.cshtml"
    using Webmall.UI.Core.HtmlHelpers;
    
    #line default
    #line hidden
    using Webmall.UI.Core.Localization;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Brands/Index.cshtml")]
    public partial class _Views_Brands_Index_cshtml : System.Web.Mvc.WebViewPage<Webmall.UI.ViewModel.Brands.BrandListViewModel>
    {
        public _Views_Brands_Index_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 5 "..\..\Views\Brands\Index.cshtml"
   Layout = "~/Views/Shared/_Inner.cshtml"; 
            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n\r\n");

DefineSection("BreadCrumbs", () => {

WriteLiteral("\r\n");

            
            #line 9 "..\..\Views\Brands\Index.cshtml"
    
            
            #line default
            #line hidden
            
            #line 9 "..\..\Views\Brands\Index.cshtml"
      Html.RenderPartial("Components/BreadCrumbsRender", Model.BreadCrumbs);
            
            #line default
            #line hidden
WriteLiteral("\r\n");

});

WriteLiteral("\r\n");

WriteLiteral("\r\n\r\n");

WriteLiteral("\r\n\r\n");

DefineSection("Sidebar", () => {

WriteLiteral("\r\n    <aside");

WriteLiteral(" class=\"catalog-layout__aside\"");

WriteLiteral(">\r\n");

            
            #line 22 "..\..\Views\Brands\Index.cshtml"
        
            
            #line default
            #line hidden
            
            #line 22 "..\..\Views\Brands\Index.cshtml"
          
            Html.RenderPartial("Components/CommonFilter", Model.FilterModel);
        
            
            #line default
            #line hidden
WriteLiteral("\r\n    </aside>\r\n");

});

WriteLiteral("\r\n<main");

WriteLiteral(" class=\"primary__main\"");

WriteLiteral(">\r\n    <!-- brands-area-->\r\n    <div");

WriteLiteral(" class=\"brands-area\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"brands-area__top brands-nav\"");

WriteLiteral(">\r\n            <ul");

WriteLiteral(" class=\"brands-nav__list\"");

WriteLiteral(">\r\n");

            
            #line 33 "..\..\Views\Brands\Index.cshtml"
                
            
            #line default
            #line hidden
            
            #line 33 "..\..\Views\Brands\Index.cshtml"
                 for (char letter = 'A'; letter <= 'Z'; letter++)
                {

            
            #line default
            #line hidden
WriteLiteral("                    <li");

WriteLiteral(" class=\"brands-nav__item letter_link\"");

WriteLiteral(">\r\n                        <a");

WriteLiteral(" class=\"brands-nav__link\"");

WriteLiteral(" href=\"#\"");

WriteLiteral(" data-value=\"");

            
            #line 36 "..\..\Views\Brands\Index.cshtml"
                                                                    Write(letter);

            
            #line default
            #line hidden
WriteLiteral("\"");

WriteLiteral(">");

            
            #line 36 "..\..\Views\Brands\Index.cshtml"
                                                                             Write(letter);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                    </li>\r\n");

            
            #line 38 "..\..\Views\Brands\Index.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("                <li");

WriteLiteral(" class=\"brands-nav__item\"");

WriteLiteral(">\r\n                    <a");

WriteLiteral(" class=\"brands-nav__link is-numbers letter_link\"");

WriteLiteral(" data-value=\"0\"");

WriteLiteral(" href=\"#\"");

WriteLiteral(">0-9</a>\r\n                </li>\r\n                <li");

WriteLiteral(" class=\"brands-nav__item\"");

WriteLiteral(">\r\n                    <a");

WriteLiteral(" class=\"brands-nav__link is-numbers letter_link\"");

WriteLiteral(" data-value=\"other\"");

WriteLiteral(" href=\"#\"");

WriteLiteral(">А-Я</a>\r\n                </li>\r\n            </ul>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"brands-area__main\"");

WriteLiteral(">\r\n");

            
            #line 48 "..\..\Views\Brands\Index.cshtml"
            
            
            #line default
            #line hidden
            
            #line 48 "..\..\Views\Brands\Index.cshtml"
             foreach (var item in Model.Data.List)
            {

            
            #line default
            #line hidden
WriteLiteral("                <a");

WriteLiteral(" class=\"brand-card\"");

WriteAttribute("href", Tuple.Create(" href=\"", 1638), Tuple.Create("\"", 1686)
            
            #line 50 "..\..\Views\Brands\Index.cshtml"
, Tuple.Create(Tuple.Create("", 1645), Tuple.Create<System.Object, System.Int32>(Url.Action("Info", new {id = item.Name})
            
            #line default
            #line hidden
, 1645), false)
);

WriteLiteral(">\r\n                    <figure");

WriteLiteral(" class=\"brands-area__item brand-card__main\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"brand-card__img-wrap\"");

WriteLiteral(">\r\n                            <img");

WriteLiteral(" class=\"brand-card__img\"");

WriteAttribute("src", Tuple.Create(" src=\"", 1879), Tuple.Create("\"", 1932)
            
            #line 53 "..\..\Views\Brands\Index.cshtml"
, Tuple.Create(Tuple.Create("", 1885), Tuple.Create<System.Object, System.Int32>(item.UrlName ?? Url.ProducerImage(item.Name)
            
            #line default
            #line hidden
, 1885), false)
);

WriteLiteral(" alt=\"\"");

WriteLiteral(" width=\"80\"");

WriteLiteral(" height=\"80\"");

WriteLiteral(">\r\n                        </div>\r\n                        <figcaption");

WriteLiteral(" class=\"brand-card__caption\"");

WriteLiteral(">");

            
            #line 55 "..\..\Views\Brands\Index.cshtml"
                                                           Write(item.Name);

            
            #line default
            #line hidden
WriteLiteral("</figcaption>\r\n                    </figure>\r\n                </a>\r\n");

            
            #line 58 "..\..\Views\Brands\Index.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("        </div>\r\n    </div><!-- /brands-area-->\r\n\r\n    <div");

WriteLiteral(" class=\"header-control\"");

WriteLiteral(">\r\n");

            
            #line 63 "..\..\Views\Brands\Index.cshtml"
        
            
            #line default
            #line hidden
            
            #line 63 "..\..\Views\Brands\Index.cshtml"
         if (Model.Data.AllowPagging)
        {
            Html.RenderPartial("Components/Pagination", Model.Data);
        }

            
            #line default
            #line hidden
WriteLiteral("    </div>\r\n\r\n</main>\r\n\r\n");

DefineSection("styles", () => {

WriteLiteral("\r\n");

});

DefineSection("scripts", () => {

WriteLiteral("\r\n");

            
            #line 75 "..\..\Views\Brands\Index.cshtml"
    
            
            #line default
            #line hidden
            
            #line 75 "..\..\Views\Brands\Index.cshtml"
       Html.RenderPartial("GridViewFooterScripts", Model.Data); 
            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 76 "..\..\Views\Brands\Index.cshtml"
    
            
            #line default
            #line hidden
            
            #line 76 "..\..\Views\Brands\Index.cshtml"
       Html.RenderPartial("_FilterScripts", new Webmall.UI.ViewModel.Catalog.CatalogFilterViewModel()); 
            
            #line default
            #line hidden
WriteLiteral(@"
<script>
        document.addEventListener('DOMContentLoaded',
            function () {
                var form = document.getElementById(""filterForm"");
                var input = document.createElement(""input"");
                input.type = ""hidden"";
                input.name = ""letter"";
                form.appendChild(input);

");

            
            #line 86 "..\..\Views\Brands\Index.cshtml"
                
            
            #line default
            #line hidden
            
            #line 86 "..\..\Views\Brands\Index.cshtml"
                 if (!string.IsNullOrEmpty(Model.FilterOptions.Letter))
                {

            
            #line default
            #line hidden
WriteLiteral("                    ");

WriteLiteral("\r\n                        input.value = \'");

            
            #line 89 "..\..\Views\Brands\Index.cshtml"
                                  Write(Model.FilterOptions.Letter);

            
            #line default
            #line hidden
WriteLiteral("\';\r\n                    ");

WriteLiteral("\r\n");

            
            #line 91 "..\..\Views\Brands\Index.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("\r\n                $(\".letter_link\").click((ev) => {\r\n                    input.va" +
"lue = ev.target.dataset.value;\r\n                    submitFilter();\r\n           " +
"     });\r\n            });\r\n</script>\r\n");

});

        }
    }
}
#pragma warning restore 1591
