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
    using Webmall.UI.Core.Localization;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/_WareListScriptsEx.cshtml")]
    public partial class _Views_Shared__WareListScriptsEx_cshtml : System.Web.Mvc.WebViewPage<Webmall.UI.ViewModel.Catalog.WareCardViewModel>
    {
        public _Views_Shared__WareListScriptsEx_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">
    $(function() {
        $("".stock-table__product-img"").click(imageLoader);
    });

    function imageLoader (e) {
        var wareId = this.dataset.template;
        if (this.loaded) {
            openFancy(wareId);
        } else {
            updatePannel(""");

            
            #line 13 "..\..\Views\Shared\_WareListScriptsEx.cshtml"
                     Write(Url.Action("GetWareImages", "CatalogService"));

            
            #line default
            #line hidden
WriteLiteral(@"?Id="" + wareId,
                ""WareImagePannel_"" + wareId,
                null,
                function(el) {
                    el.loaded = true;
                    openFancy(wareId);
                },
                this);
        }
        return false;
    }

    function openFancy(wareId) {
        $.fancybox.open($('#WareImagePannel_' + wareId + ' a'),
            {
                touch: false,
                thumbs: {
                    autoStart: true
                }
            });
    }

    ");

WriteLiteral("\r\n</script>");

        }
    }
}
#pragma warning restore 1591
