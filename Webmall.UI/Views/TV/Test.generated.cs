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
    using Webmall.UI;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/TV/Test.cshtml")]
    public partial class _Views_TV_Test_cshtml : System.Web.Mvc.WebViewPage<Webmall.UI.Models.TV.TVModel>
    {
        public _Views_TV_Test_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\n");

            
            #line 4 "..\..\Views\TV\Test.cshtml"
  
    Layout = null;

            
            #line default
            #line hidden
WriteLiteral("\n\n<!DOCTYPE html>\n\n<html>\n<head>\n    <link");

WriteLiteral(" href=\"http://vjs.zencdn.net/6.4.0/video-js.css\"");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(">\n\n    <!-- If you\'d like to support IE8 -->\n    <script");

WriteLiteral(" src=\"http://vjs.zencdn.net/ie8/1.1.2/videojs-ie8.min.js\"");

WriteLiteral("></script>\n</head>\n<body>\n<video");

WriteLiteral(" id=\"my-video\"");

WriteLiteral(" class=\"video-js\"");

WriteLiteral(" controls");

WriteLiteral(" preload=\"auto\"");

WriteLiteral(" width=\"640\"");

WriteLiteral(" height=\"264\"");

WriteLiteral("\n       poster=\"MY_VIDEO_POSTER.jpg\"");

WriteLiteral(" data-setup=\"{}\"");

WriteLiteral(">\n");

            
            #line 20 "..\..\Views\TV\Test.cshtml"
    
            
            #line default
            #line hidden
            
            #line 20 "..\..\Views\TV\Test.cshtml"
     foreach (var item in Model.PlayList)
    {

            
            #line default
            #line hidden
WriteLiteral("        <source");

WriteAttribute("src", Tuple.Create(" src=\"", 510), Tuple.Create("\"", 538)
            
            #line 22 "..\..\Views\TV\Test.cshtml"
, Tuple.Create(Tuple.Create("", 516), Tuple.Create<System.Object, System.Int32>(Url.Content(item.URL)
            
            #line default
            #line hidden
, 516), false)
);

WriteLiteral(" type=\'video/mp4\'");

WriteLiteral(">\n");

            
            #line 23 "..\..\Views\TV\Test.cshtml"
        
            
            #line default
            #line hidden
            
            #line 32 "..\..\Views\TV\Test.cshtml"
                 
    }

            
            #line default
            #line hidden
WriteLiteral("    ");

WriteLiteral("\n    <p");

WriteLiteral(" class=\"vjs-no-js\"");

WriteLiteral(">\n        To view this video please enable JavaScript, and consider upgrading to " +
"a web browser that\n        <a");

WriteLiteral(" href=\"http://videojs.com/html5-video-support/\"");

WriteLiteral(" target=\"_blank\"");

WriteLiteral(">supports HTML5 video</a>\n    </p>\n</video>\n\n    <script");

WriteLiteral(" src=\"http://vjs.zencdn.net/6.4.0/video.js\"");

WriteLiteral("></script>\n</body>\n</html>\n");

        }
    }
}
#pragma warning restore 1591
