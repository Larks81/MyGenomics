using System.Web;
using System.Web.Optimization;

namespace MyGenomics.WebSite
{
    public class BundleConfig
    {
        // Per ulteriori informazioni sul Bundling, visitare il sito Web all'indirizzo http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Utilizzare la versione di sviluppo di Modernizr per eseguire attività di sviluppo e formazione. Successivamente, quando si è
            // pronti per passare alla produzione, utilizzare lo strumento di compilazione disponibile all'indirizzo http://modernizr.com per selezionare solo i test necessari.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));            

            bundles.Add(new ScriptBundle("~/bundles/angular-lib").Include(
                "~/Scripts/angular.js",
                "~/Scripts/angular-resource.js",
                "~/Scripts/angular-route.js",
                "~/Scripts/lodash.js",                
                "~/Scripts/angular-ui/ui-bootstrap.js",
                "~/Scripts/angular-ui/ui-bootstrap-tpls.js"));

            bundles.Add(new ScriptBundle("~/bundles/app-base").Include(
                "~/App/*.js",
                "~/App/services/*.js"));

            bundles.Add(new ScriptBundle("~/bundles/app-controllers").Include(
                "~/App/controllers/*.js"));

            bundles.Add(new ScriptBundle("~/bundles/app-directives").Include(                
                "~/App/directives/*.js"));
        }
    }
}