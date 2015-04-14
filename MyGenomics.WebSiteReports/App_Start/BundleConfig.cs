using System.Web;
using System.Web.Optimization;

namespace MyGenomics.WebSiteReports
{
    public class BundleConfig
    {
        // Per ulteriori informazioni sul Bundling, visitare il sito Web all'indirizzo http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            //Scripts
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-ui-{version}.js"));
            

            //Styles
            bundles.Add(new StyleBundle("~/Content/css")
                .IncludeDirectory("~/Content","*.css" , true)
                .IncludeDirectory("~/css", "*.css", true)
                .IncludeDirectory("~/App/components", "*.css", true)                
                );

            //bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
            //            "~/Content/themes/base/jquery.ui.core.css",
            //            "~/Content/themes/base/jquery.ui.resizable.css",
            //            "~/Content/themes/base/jquery.ui.selectable.css",
            //            "~/Content/themes/base/jquery.ui.accordion.css",
            //            "~/Content/themes/base/jquery.ui.autocomplete.css",
            //            "~/Content/themes/base/jquery.ui.button.css",
            //            "~/Content/themes/base/jquery.ui.dialog.css",
            //            "~/Content/themes/base/jquery.ui.slider.css",
            //            "~/Content/themes/base/jquery.ui.tabs.css",
            //            "~/Content/themes/base/jquery.ui.datepicker.css",
            //            "~/Content/themes/base/jquery.ui.progressbar.css",
            //            "~/Content/themes/base/jquery.ui.theme.css",
            //            "~/Content/angular-wizard.css",
            //            //"~/Content/bootstrap.css",
            //            "~/Content/animate.css"));

            bundles.Add(new ScriptBundle("~/bundles/angular-lib").Include(
                "~/Scripts/angular.js",
                "~/Scripts/angular-resource.js",
                "~/Scripts/angular-route.js",                
                "~/Scripts/bootstrap.js",
                "~/Scripts/angular-ui/ui-bootstrap.js",
                "~/Scripts/angular-ui/ui-bootstrap-tpls.js",
                "~/Scripts/angular-toastr.js",
                "~/Scripts/angular-toastr.tpls.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular-components")                
                .IncludeDirectory("~/App/components", "*.js", true)
                .IncludeDirectory("~/js/AdminLTE", "*.js", true)
                .IncludeDirectory("~/js/plugins/sparkline", "*.js", true)
                //.IncludeDirectory("~/js/plugins/jvectormap", "*.js", true)
                .IncludeDirectory("~/js/plugins/fullcalendar", "*.js", true)
                .IncludeDirectory("~/js/plugins/jqueryKnob", "*.js", true)
                .IncludeDirectory("~/js/plugins/daterangepicker", "*.js", true)
                .IncludeDirectory("~/js/plugins/iCheck", "*.js", true));

            bundles.Add(new ScriptBundle("~/bundles/app-base").Include(
                "~/App/*.js",
                "~/App/services/*.js"));

            bundles.Add(new ScriptBundle("~/bundles/app-controllers").Include(
                "~/App/controllers/*.js"));
            
            bundles.Add(new ScriptBundle("~/bundles/app-directives")
                .IncludeDirectory("~/App/directives","*.js", true));

        }
    }
}

