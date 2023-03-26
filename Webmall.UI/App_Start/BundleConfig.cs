using System.Web.Optimization;

namespace Webmall.UI
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region ScriptBundles

            bundles.Add(new ScriptBundle("~/assets/js/all").Include(
                "~/assets/js/libs.min.js",
                "~/assets/js/Modal.js",
                "~/assets/js/main.js"
            ));

            bundles.Add(new ScriptBundle("~/Client/dist/orders.bundle.js").Include(
                "~/Client/dist/orders.bundle.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js",
                //"~/Scripts/btclr.js",
                "~/Scripts/jquery-migrate-{version}.js"
                //"~/Scripts/jquery-ui-{version}.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/tools").Include(
                //"~/Scripts/jquery.autosize.js",
                //"~/Scripts/jquery.hotkeys.js",
                //"~/Scripts/jquery.selectedText.js",
                "~/Scripts/jquery.cookie.js",
                //"~/Content/chosen/chosen.jquery.js",
                //"~/Content/chosen/chosen.proto.js",
                //"~/Scripts/choices/choices.min.js",
                "~/Content/EasyAutocomplete/jquery.easy-autocomplete.js",
                //"~/Scripts/jquery.checkbox.js",
                //"~/Scripts/jquery.ui.selectmenu.js",
                //"~/Scripts/jquery.ui.form.js",
                //"~/Scripts/jquery.watermark.js",
                //"~/Scripts/jquery.sizes.js",
                //"~/Scripts/jquery.autocomplete.js",
                //"~/Content/fancybox/jquery.mousewheel-3.0.4.pack.js",
                //"~/Content/fancybox/jquery.fancybox-1.3.4.pack.js",
                "~/Scripts/url.js"
                //"~/Scripts/jquery.reject.js",
                //"~/Scripts/html2canvas.js"
                //"~/Scripts/MicrosoftAjax.js",
                //"~/Scripts/MicrosoftMvcValidation.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate.js",
                 "~/Scripts/additional-methods.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery.autocomplete").Include(
                "~/Scripts/jquery.autocomplete.js"));

            bundles.Add(new ScriptBundle("~/bundles/filter").Include(
                "~/Scripts/jquery.multiselect.js",
                "~/Scripts/jquery.treeview.js"
                //"~/Scripts/jstree/jstree.js"
                ));

            //var eui = new ScriptBundle("~/bundles/easyui").Include(
            //    "~/Scripts/jquery.easyui.min.js");
            //eui.Transforms.Clear();
            //bundles.Add(eui);

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/jcarousel").Include(
                "~/scripts/jcarousel/jquery.jcarousel.js",
                "~/scripts/jcarousel/jcarousel.responsive.js",
                "~/scripts/jcarousel/jquery.jcarousel-autoscroll.js",
                "~/scripts/jcarousel/jcarousel.basic.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/default").Include(
                "~/Scripts/script.js",
                "~/Scripts/default.js",
                // "~/Scripts/date.js",
                "~/Scripts/Views/layout.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/order").Include(
                "~/Scripts/commonOrderScripts.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/fancy").Include(
                //"~/Scripts/fancybox/jquery.mousewheel-3.0.4.pack.js",
                //"~/Scripts/fancybox/jquery.fancybox-1.3.4.pack.js"
                "~/Scripts/fancybox/jquery.fancybox-3.5.7.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/overlib").Include(
                "~/Scripts/overlib/overlib_mini.js",
                "~/Scripts/overlib/overlib_adaptive_width.js"
                ));

            //bundles.Add(new ScriptBundle("~/bundles/owl_slider").Include(
            //    "~/Scripts/slider/js/owl.carousel.js",
            //    "~/Scripts/slider/js/jquery.liCover.js",
            //    "~/Scripts/slider/js/script.js"
            //    ));

            bundles.Add(new ScriptBundle("~/bundles/notify").Include(
                "~/Scripts/notify.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/cart").Include(
                "~/Scripts/Views/cart.js"));

            bundles.Add(new ScriptBundle("~/bundles/views/home").Include(
                "~/Scripts/Views/home.js"));

            bundles.Add(new ScriptBundle("~/bundles/views/catalog/autofilter").Include(
                "~/Scripts/Views/catalog/autoFilter.js"));

            bundles.Add(new ScriptBundle("~/bundles/views/gridViewFooter").Include(
                "~/Scripts/Views/gridViewFooter.js"));

            bundles.Add(new ScriptBundle("~/bundles/dialogs/wareSpecDialog").Include(
                "~/Scripts/Dialogs/wareSpecDialog.js"));

            bundles.Add(new ScriptBundle("~/bundles/laximo").Include(
                "~/Scripts/jquery.mousewheel.js",
                "~/Scripts/dragscrollable.js",
                "~/Scripts/Views/laximo.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery.maskedinput").Include(
                "~/Scripts/jquery.maskedinput.js"));

            bundles.Add(new ScriptBundle("~/bundles/ulogin").Include(
                "~/Scripts/ulogin.js"));

            #endregion

            #region StyleBundles
            bundles.Add(new StyleBundle("~/assets/css/all").Include(
                "~/assets/css/styles.min.css",
                "~/Content/css-skeletons.min.css"
                ));

            bundles.Add(new StyleBundle("~/Content/autocomplete").Include(
                "~/Content/EasyAutocomplete/easy-autocomplete.css",
                "~/Content/EasyAutocomplete/easy-autocomplete.themes.css"
                ));

            //bundles.Add(new StyleBundle("~/Content/jUI").Include(
            //    "~/Content/components-jQuery.UI.css"
            //    ));

            bundles.Add(new StyleBundle("~/Content/views/inner").Include(
                "~/Content/Views/inner.css"
            ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                   //"~/Content/jquery.reject.css",
                   //"~/Content/chosen/chosen.css",
                   //"~/Content/choices/base.min.css",
                   //"~/Content/choices/choices.min.css"
                ));

            bundles.Add(new StyleBundle("~/Content/fancybox/fancy").Include(
                "~/Content/fancybox/jquery.fancybox-3.5.7.css"
                ));

            //bundles.Add(new StyleBundle("~/Content/jquery-filter").Include(
            //    "~/Content/jquery.multiselect.css",
            //    "~/Content/jquery.treeview.css",
            //    "~/Scripts/jstree/themes/default/style.css"
            //    ));

            //bundles.Add(new StyleBundle("~/Content/easyuicss").Include(
            //    "~/Content/easyui/default/easyui.css",
            //    "~/Content/easyui/icon.css",
            //    "~/Content/easyui/color.css"));

            bundles.Add(new StyleBundle("~/Content/views/home").Include(
                "~/Content/views/home.css"));

            bundles.Add(new StyleBundle("~/Content/views/laximo").Include(
                "~/Content/views/laximo.css"));

            #endregion

        }
    }
}
