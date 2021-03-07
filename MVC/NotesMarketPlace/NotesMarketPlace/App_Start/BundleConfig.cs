using System.Web;
using System.Web.Optimization;

namespace NotesMarketPlace
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/js/jquery.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/js/bootstrap/bootstrap.js"));


            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));

            //CSS
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap/bootstrap.min.css", "~/Content/bootstrap/bootstrap.css",
                      "~/Content/add_notes.css",
                      "~/Content/buyer_request.css", "~/Content/changepwd.css", "~/Content/contactus.css", "~/Content/dashboard.css", "~/Content/downloads.css", "~/Content/email_varification.css", "~/Content/FAQ.css", "~/Content/forgotpwd.css", "~/Content/homepage.css", "~/Content/index.css", "~/Content/login.css", "~/Content/myrejected_notes.css", "~/Content/mysold_notes.css", "~/Content/note_details.css",
                      "~/Content/responsive_add_notes.css", "~/Content/responsive_buyer_request.css", "~/Content/responsive_changepwd.css", "~/Content/responsive_contactus.css", "~/Content/responsive_dashboard.css", "~/Content/responsive_downloads.css", "~/Content/responsive_FAQ.css", "~/Content/responsive_forgotpwd.css", "~/Content/responsive_homepage.css", "~/Content/responsive_login.css", "~/Content/responsive_note_details.css", "~/Content/responsive_rejected_notes.css",
                      "~/Content/responsive_search_notes.css", "~/Content/responsive_signup.css", "~/Content/responsive_soldnotes.css", "~/Content/responsive_userprofile.css","~/Content/search_notes.css", "~/Content/signup.css", "~/Content/userprofile.css"));
        }
    }
}
