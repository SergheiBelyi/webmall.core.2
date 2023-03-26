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
    
    #line 1 "..\..\Views\CatalogService\Applicability.cshtml"
    using ViewRes;
    
    #line default
    #line hidden
    using Webmall.UI;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/CatalogService/Applicability.cshtml")]
    public partial class _Views_CatalogService_Applicability_cshtml : System.Web.Mvc.WebViewPage<List<Webmall.Model.Entities.Auto.Applicability>>
    {
        public _Views_CatalogService_Applicability_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 4 "..\..\Views\CatalogService\Applicability.cshtml"
  
    Layout = null;

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 8 "..\..\Views\CatalogService\Applicability.cshtml"
 if (Model.Any())
{
    var markList = Model.Select(i => i.Mark).Distinct();
    var last = markList.LastOrDefault();


            
            #line default
            #line hidden
WriteLiteral("<div");

WriteLiteral(" class=\"kit-area\"");

WriteLiteral(">\r\n    <ul");

WriteLiteral(" class=\"extra-items kit-area__tags\"");

WriteLiteral(">\r\n");

            
            #line 15 "..\..\Views\CatalogService\Applicability.cshtml"
        
            
            #line default
            #line hidden
            
            #line 15 "..\..\Views\CatalogService\Applicability.cshtml"
         foreach (var item in markList)
        {

            
            #line default
            #line hidden
WriteLiteral("            <li");

WriteLiteral(" class=\"extra-items__item\"");

WriteLiteral(">\r\n                <a");

WriteLiteral(" class=\"extra-items__link\"");

WriteLiteral(" href=\"#\"");

WriteLiteral(">");

            
            #line 18 "..\..\Views\CatalogService\Applicability.cshtml"
                                                 Write(item);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n            </li>\r\n");

            
            #line 20 "..\..\Views\CatalogService\Applicability.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("    </ul>\r\n    <div");

WriteLiteral(" class=\"kit-area__main\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"table-responsive kit-area__wrap\"");

WriteLiteral(">\r\n            <table");

WriteLiteral(" class=\"kit-table kit-area__table\"");

WriteLiteral(">\r\n                <thead>\r\n                    <tr>\r\n                        <th" +
">");

            
            #line 27 "..\..\Views\CatalogService\Applicability.cshtml"
                       Write(SharedResources.EngineVolume);

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                        <th");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">");

            
            #line 28 "..\..\Views\CatalogService\Applicability.cshtml"
                                           Write(SharedResources.VolumeCm);

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                        <th");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">");

            
            #line 29 "..\..\Views\CatalogService\Applicability.cshtml"
                                           Write(SharedResources.YearOfProduce);

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                        <th");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">");

            
            #line 30 "..\..\Views\CatalogService\Applicability.cshtml"
                                           Write(SharedResources.PowerHp);

            
            #line default
            #line hidden
WriteLiteral(" (");

            
            #line 30 "..\..\Views\CatalogService\Applicability.cshtml"
                                                                     Write(SharedResources._kWt);

            
            #line default
            #line hidden
WriteLiteral(")</th>\r\n                        <th");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">");

            
            #line 31 "..\..\Views\CatalogService\Applicability.cshtml"
                                           Write(SharedResources.BodyType);

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                    </tr>\r\n                </thead>\r\n");

            
            #line 34 "..\..\Views\CatalogService\Applicability.cshtml"
                
            
            #line default
            #line hidden
            
            #line 34 "..\..\Views\CatalogService\Applicability.cshtml"
                 foreach (var item in markList)
                {
                    var allModel = Model.Where(i => i.Mark == item);

            
            #line default
            #line hidden
WriteLiteral("                    <tbody>\r\n                        <tr>\r\n                      " +
"      <td");

WriteLiteral(" colspan=\"5\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\"kit-table__heading\"");

WriteLiteral(">");

            
            #line 40 "..\..\Views\CatalogService\Applicability.cshtml"
                                                           Write(item);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                            </td>\r\n                        </tr>\r\n       " +
"             </tbody>\r\n");

WriteLiteral("                    <tbody");

WriteLiteral(" class=\"spec-table__tbody\"");

WriteLiteral(">\r\n");

            
            #line 45 "..\..\Views\CatalogService\Applicability.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 45 "..\..\Views\CatalogService\Applicability.cshtml"
                         foreach (var modelItem in allModel)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <tr>\r\n                                <td>\r\n         " +
"                           <div");

WriteLiteral(" class=\"kit-table__heading\"");

WriteLiteral("><a");

WriteLiteral(" class=\"kit-table__title-link\"");

WriteLiteral(" href=\"#\"");

WriteLiteral(">");

            
            #line 49 "..\..\Views\CatalogService\Applicability.cshtml"
                                                                                                         Write(modelItem.Mark);

            
            #line default
            #line hidden
WriteLiteral(" ");

            
            #line 49 "..\..\Views\CatalogService\Applicability.cshtml"
                                                                                                                         Write(modelItem.Model);

            
            #line default
            #line hidden
WriteLiteral("</a></div>\r\n                                </td>\r\n                              " +
"  <td");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">");

            
            #line 51 "..\..\Views\CatalogService\Applicability.cshtml"
                                                   Write(modelItem.Modification);

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n                                <td");

WriteLiteral(" class=\"text-center\"");

WriteLiteral("><span");

WriteLiteral(" class=\"kit-table__heading\"");

WriteLiteral(">");

            
            #line 52 "..\..\Views\CatalogService\Applicability.cshtml"
                                                                                    Write(String.Format("{0:dd.MM.yyyy}", modelItem.DateBegin));

            
            #line default
            #line hidden
WriteLiteral(" - ");

            
            #line 52 "..\..\Views\CatalogService\Applicability.cshtml"
                                                                                                                                            Write(String.Format("{0:dd.MM.yyyy}", modelItem.DateEnd));

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n                                <td");

WriteLiteral(" class=\"text-center\"");

WriteLiteral("><span");

WriteLiteral(" class=\"spec-table__amount\"");

WriteLiteral(">");

            
            #line 53 "..\..\Views\CatalogService\Applicability.cshtml"
                                                                                    Write(modelItem.PS);

            
            #line default
            #line hidden
WriteLiteral(" (");

            
            #line 53 "..\..\Views\CatalogService\Applicability.cshtml"
                                                                                                   Write(modelItem.KW);

            
            #line default
            #line hidden
WriteLiteral(")</span></td>\r\n                                <td");

WriteLiteral(" class=\"text-center\"");

WriteLiteral("><span");

WriteLiteral(" class=\"spec-table__instock\"");

WriteLiteral(">");

            
            #line 54 "..\..\Views\CatalogService\Applicability.cshtml"
                                                                                     Write(modelItem.BodyTypeName);

            
            #line default
            #line hidden
WriteLiteral("</span></td>\r\n                            </tr>\r\n");

            
            #line 56 "..\..\Views\CatalogService\Applicability.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </tbody>\r\n");

            
            #line 58 "..\..\Views\CatalogService\Applicability.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("\r\n            </table>\r\n        </div>\r\n\r\n        <div");

WriteLiteral(" class=\"kit-area__data kit-products\"");

WriteLiteral(">\r\n");

            
            #line 64 "..\..\Views\CatalogService\Applicability.cshtml"
            
            
            #line default
            #line hidden
            
            #line 64 "..\..\Views\CatalogService\Applicability.cshtml"
             foreach (var item in markList) {
                var allModel = Model.Where(i => i.Mark == item);


            
            #line default
            #line hidden
WriteLiteral("            <div");

WriteLiteral(" class=\"kit-products__item kit-product js-accordion\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"kit-product__header js-accordion-trigger\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"kit-product__heading\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 70 "..\..\Views\CatalogService\Applicability.cshtml"
                   Write(item);

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                \r\n         " +
"       <div");

WriteLiteral(" class=\"kit-product__main js-accordion-body\"");

WriteLiteral(">\r\n");

            
            #line 75 "..\..\Views\CatalogService\Applicability.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 75 "..\..\Views\CatalogService\Applicability.cshtml"
                     foreach (var modelItem in allModel)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <div");

WriteLiteral(" class=\"kit-product__subsection\"");

WriteLiteral(">\r\n                            <div");

WriteLiteral(" class=\"kit-product__model\"");

WriteLiteral(">");

            
            #line 78 "..\..\Views\CatalogService\Applicability.cshtml"
                                                       Write(modelItem.Mark);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                            <div");

WriteLiteral(" class=\"kit-product__props\"");

WriteLiteral(">\r\n                                <div");

WriteLiteral(" class=\"kit-product__prop\"");

WriteLiteral(">\r\n                                    <dt");

WriteLiteral(" class=\"kit-product__property\"");

WriteLiteral(">");

            
            #line 81 "..\..\Views\CatalogService\Applicability.cshtml"
                                                                 Write(SharedResources.EngineVolume);

            
            #line default
            #line hidden
WriteLiteral("</dt>\r\n                                    <dd");

WriteLiteral(" class=\"kit-product__value\"");

WriteLiteral(">\r\n                                        <a");

WriteLiteral(" class=\"kit-product__link\"");

WriteLiteral(" href=\"#\"");

WriteLiteral(">");

            
            #line 83 "..\..\Views\CatalogService\Applicability.cshtml"
                                                                         Write(modelItem.Mark);

            
            #line default
            #line hidden
WriteLiteral(" ");

            
            #line 83 "..\..\Views\CatalogService\Applicability.cshtml"
                                                                                         Write(modelItem.Model);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                                    </dd>\r\n                                " +
"</div>\r\n\r\n                                <div");

WriteLiteral(" class=\"kit-product__prop\"");

WriteLiteral(">\r\n                                    <dt");

WriteLiteral(" class=\"kit-product__property\"");

WriteLiteral(">");

            
            #line 88 "..\..\Views\CatalogService\Applicability.cshtml"
                                                                 Write(SharedResources.VolumeCm);

            
            #line default
            #line hidden
WriteLiteral("</dt>\r\n                                    <dd");

WriteLiteral(" class=\"kit-product__value\"");

WriteLiteral(">\r\n                                        <a");

WriteLiteral(" class=\"kit-product__link\"");

WriteLiteral(" href=\"#\"");

WriteLiteral(">");

            
            #line 90 "..\..\Views\CatalogService\Applicability.cshtml"
                                                                         Write(modelItem.Modification);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                                    </dd>\r\n                                " +
"</div>\r\n                                <div");

WriteLiteral(" class=\"kit-product__prop\"");

WriteLiteral(">\r\n                                    <dt");

WriteLiteral(" class=\"kit-product__property\"");

WriteLiteral(">");

            
            #line 94 "..\..\Views\CatalogService\Applicability.cshtml"
                                                                 Write(SharedResources.YearOfProduce);

            
            #line default
            #line hidden
WriteLiteral("</dt>\r\n                                    <dd");

WriteLiteral(" class=\"kit-product__value\"");

WriteLiteral(">\r\n                                        <a");

WriteLiteral(" class=\"kit-product__link\"");

WriteLiteral(" href=\"#\"");

WriteLiteral(">");

            
            #line 96 "..\..\Views\CatalogService\Applicability.cshtml"
                                                                         Write(String.Format("{0:dd.MM.yyyy}", modelItem.DateBegin));

            
            #line default
            #line hidden
WriteLiteral(" - ");

            
            #line 96 "..\..\Views\CatalogService\Applicability.cshtml"
                                                                                                                                 Write(String.Format("{0:dd.MM.yyyy}", modelItem.DateEnd));

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                                    </dd>\r\n                                " +
"</div>\r\n                                <div");

WriteLiteral(" class=\"kit-product__prop\"");

WriteLiteral(">\r\n                                    <dt");

WriteLiteral(" class=\"kit-product__property\"");

WriteLiteral(">");

            
            #line 100 "..\..\Views\CatalogService\Applicability.cshtml"
                                                                 Write(SharedResources.PowerHp);

            
            #line default
            #line hidden
WriteLiteral(" (");

            
            #line 100 "..\..\Views\CatalogService\Applicability.cshtml"
                                                                                           Write(SharedResources._kWt);

            
            #line default
            #line hidden
WriteLiteral(")</dt>\r\n                                    <dd");

WriteLiteral(" class=\"kit-product__value\"");

WriteLiteral(">\r\n                                        <a");

WriteLiteral(" class=\"kit-product__link\"");

WriteLiteral(" href=\"#\"");

WriteLiteral(">");

            
            #line 102 "..\..\Views\CatalogService\Applicability.cshtml"
                                                                         Write(modelItem.PS);

            
            #line default
            #line hidden
WriteLiteral(" (");

            
            #line 102 "..\..\Views\CatalogService\Applicability.cshtml"
                                                                                        Write(modelItem.KW);

            
            #line default
            #line hidden
WriteLiteral(")</a>\r\n                                    </dd>\r\n                               " +
" </div>\r\n                                <div");

WriteLiteral(" class=\"kit-product__prop\"");

WriteLiteral(">\r\n                                    <dt");

WriteLiteral(" class=\"kit-product__property\"");

WriteLiteral(">");

            
            #line 106 "..\..\Views\CatalogService\Applicability.cshtml"
                                                                 Write(SharedResources.BodyType);

            
            #line default
            #line hidden
WriteLiteral("</dt>\r\n                                    <dd");

WriteLiteral(" class=\"kit-product__value\"");

WriteLiteral(">\r\n                                        <a");

WriteLiteral(" class=\"kit-product__link\"");

WriteLiteral(" href=\"#\"");

WriteLiteral(">");

            
            #line 108 "..\..\Views\CatalogService\Applicability.cshtml"
                                                                         Write(modelItem.BodyTypeName);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                                    </dd>\r\n                                " +
"</div>\r\n                            </div>\r\n                        </div>\r\n");

            
            #line 113 "..\..\Views\CatalogService\Applicability.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </div>\r\n            </div>\r\n");

            
            #line 116 "..\..\Views\CatalogService\Applicability.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n");

            
            #line 120 "..\..\Views\CatalogService\Applicability.cshtml"

}
else
{

            
            #line default
            #line hidden
WriteLiteral("    <div>");

            
            #line 124 "..\..\Views\CatalogService\Applicability.cshtml"
    Write(SharedResources.NoData);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");

            
            #line 125 "..\..\Views\CatalogService\Applicability.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

        }
    }
}
#pragma warning restore 1591
