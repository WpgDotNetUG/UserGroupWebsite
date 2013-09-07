using System.Web.Optimization;

namespace DotNetUserGroup.Website.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-1.*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include("~/Scripts/knockout-2.1.0.js"));

            bundles.Add(new ScriptBundle("~/bundles/vm-home")
                            .Include("~/Scripts/vm/Models/*.js")
                            .Include("~/Scripts/vm/Views/Home/*.js")
                );

            bundles.Add(new StyleBundle("~/Content/css")
                            .Include("~/Content/font-awesome.css",
                                     "~/Content/styles.css"));
        }
    }
}