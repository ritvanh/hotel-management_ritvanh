using System.Web;
using System.Web.Optimization;

namespace HotelManager
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                                    "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.bundle.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            bundles.Add(new ScriptBundle("~/Content/js").Include(
                      "~/Content/js/ajax-mail.js",
                      "~/Content/js/animated-headlines.js",
                      "~/Content/js/bootstrap.min.js",
                      "~/Content/js/isotope.pkgd.min.js",
                      "~/Content/js/jquery.counterup.js",
                      "~/Content/js/jquery.isotope.js",
                      "~/Content/js/jquery.magnific-popup.js",
                      "~/Content/js/lettering.js",
                      "~/Content/js/mailchimp.js",
                      "~/Content/js/main.js",
                      "~/Content/js/owl.carousel.min.js",
                      "~/Content/js/packery-mode.pkgd.min.js",
                      "~/Content/js/parallax.js",
                      "~/Content/js/plugins.js",
                      "~/Content/js/room-sidenav.js",
                      "~/Content/js/textilate.js",
                      "~/Content/js/video-player.js",
                      "~/Content/js/waypoints.min.js",
                      "~/Content/js/vendor/jquery-1.12.0.min.js",
                      "~/Content/js/vendor/modernizr-2.8.3.min.js"
                      ));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                      "~/Content/css/bootstrap.min.css",
                      "~/Content/css/core.css",
                      "~/Content/css/custom.css",
                      "~/Content/css/font-awesome.min.css",
                      "~/Content/css/materialdesignicons.min.css",
                      "~/Content/css/owl.carousel.css",
                      "~/Content/css/owl.theme.css",
                      "~/Content/css/owl.transitions.css",
                      "~/Content/css/responsive.css",
                      "~/Content/css/color/color-1.css",
                      "~/Content/css/color/color-2.css",
                      "~/Content/css/color/color-3.css",
                      "~/Content/css/color/color-4.css",
                      "~/Content/css/color/color-5.css",
                      "~/Content/css/color/color-6.css",
                      "~/Content/css/color/color-7.css",
                      "~/Content/css/color/color-8.css",
                      "~/Content/css/color/color-9.css",
                      "~/Content/css/color/color-10.css",
                      "~/Content/css/color/color-11.css",
                      "~/Content/css/color/color-12.css",
                      "~/Content/css/color/color-13.css",
                      "~/Content/css/color/color-14.css",
                      "~/Content/css/color/color-15.css",
                      "~/Content/css/color/skin-default.css",
                      "~/Content/css/style.css",
                      "~/Content/css/plugins/animate.css",
                      "~/Content/css/plugins/animated-headlines.css",
                      "~/Content/css/plugins/bootstrap-datepicker3.min.css",
                      "~/Content/css/plugins/bootstrap-select.min.css",
                      "~/Content/css/plugins/jquery-ui.min.css",
                      "~/Content/css/plugins/magnific-popup.css",
                      "~/Content/css/plugins/meanmenu.min.css",
                      "~/Content/css/plugins/owl-carousel.css",
                      "~/Content/css/plugins/owl-theme.css",
                      "~/Content/css/plugins/owl-transitions.css",
                      "~/Content/css/shortcode/alert.css",
                      "~/Content/css/shortcode/button.css",
                      "~/Content/css/shortcode/default.css",
                      "~/Content/css/shortcode/header.css",
                      "~/Content/css/shortcode/progress.css",
                      "~/Content/css/shortcode/shortcodes.css",
                      "~/Content/css/shortcode/video.css"
                      ));
        }
    }
}
