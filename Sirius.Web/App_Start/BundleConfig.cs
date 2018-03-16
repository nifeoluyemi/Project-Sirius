using System.Web;
using System.Web.Optimization;

namespace Sirius.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = true;

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-2.1.4.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-1.11.4.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryvalmin").Include(
                        "~/Scripts/jquery.validate.min.js",
                        "~/Scripts/jquery.validate.unobtrusive.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/unobtrusive-ajax").Include(
                        "~/Scripts/jquery.unobtrusive-ajax.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/respond.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/sweetalert/css").Include(
                      "~/Content/sweetalert.css"));

            bundles.Add(new ScriptBundle("~/sweetalert/js").Include(
                      "~/Scripts/sweetalert.min.js"));

            bundles.Add(new StyleBundle("~/toastr/css").Include(
                      "~/Content/toastr.min.css"));

            bundles.Add(new ScriptBundle("~/toastr/js").Include(
                      "~/Scripts/toastr.min.js"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/core.css",
                        "~/Content/themes/base/resizable.css",
                        "~/Content/themes/base/selectable.css",
                        "~/Content/themes/base/accordion.css",
                        "~/Content/themes/base/autocomplete.css",
                        "~/Content/themes/base/button.css",
                        "~/Content/themes/base/dialog.css",
                        "~/Content/themes/base/slider.css",
                        "~/Content/themes/base/tabs.css",
                        "~/Content/themes/base/datepicker.css",
                        "~/Content/themes/base/progressbar.css",
                        "~/Content/themes/base/theme.css"));

            //
            //required bootstrap
            bundles.Add(new StyleBundle("~/Template/bootstrap").Include(
                    "~/Content/bootstrap.min.css",
                    "~/Content/font-awesome.min.css"
                ));
            bundles.Add(new StyleBundle("~/account/css").Include(
                    "~/Content/account.css"
                ));
            //General CSS..
            bundles.Add(new StyleBundle("~/Template/gencss").Include(
                    "~/Template/dist/css/AdminLTE.min.css",
                    "~/Template/dist/css/SiriusPM.css"
                ));
            //Login CSS required...
            bundles.Add(new StyleBundle("~/Template/logincss").Include(
                "~/Template/plugins/iCheck/square/blue.css"
                ));
            //Register CSS required..
            bundles.Add(new StyleBundle("~/Template/regcss").Include(
                "~/Template/dist/css/gsdk-base.css"
                ));

            bundles.Add(new StyleBundle("~/Croppie/css").Include(
                "~/Template/dist/css/croppie.css"
                ));

            //User & Admin Layout Css required..
            bundles.Add(new StyleBundle("~/Template/maincss").Include(
                "~/Template/dist/css/skins/skin-purple.min.css"
                ));

            bundles.Add(new StyleBundle("~/DataTable/css").Include(
                "~/Template/plugins/datatables/dataTables.bootstrap.css"
                ));

            bundles.Add(new StyleBundle("~/Select2/css").Include(
                "~/Template/plugins/select2/select2.min.css"
                ));

            bundles.Add(new ScriptBundle("~/Select2/js").Include(
                "~/Template/plugins/select2/select2.full.min.js"
                ));

            //Scripts...
            //General Scripts required...
            bundles.Add(new ScriptBundle("~/Template/general-js").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery-ui-{version}.js",
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/jquery.validate.min.js",
                "~/Scripts/jquery.validate.unobtrusive.js"
                ));

            //Scripts required in Login page...
            bundles.Add(new ScriptBundle("~/Template/login-js").Include(
                "~/Template/plugins/iCheck/icheck.min.js",
                "~/Template/dist/js/login.validate.js"
                ));

            bundles.Add(new StyleBundle("~/iCheck/css").Include(
                "~/Template/plugins/iCheck/all.css"
                ));

            bundles.Add(new ScriptBundle("~/iCheck/js").Include(
                "~/Template/plugins/iCheck/icheck.min.js"
                ));

            //Scripts required in Register page...
            bundles.Add(new ScriptBundle("~/Template/reg-js").Include(
                "~/Template/dist/js/jquery.bootstrap.wizard.js",
                "~/Template/dist/js/wizard.js",
                "~/Template/plugins/input-mask/jquery.inputmask.js",
                "~/Template/plugins/input-mask/jquery.inputmask.date.extensions.js",
                "~/Template/plugins/input-mask/jquery.inputmask.extensions.js"
                ));

            bundles.Add(new ScriptBundle("~/Croppie/js").Include(
                "~/Template/dist/js/croppie.js"
                ));

            //Scripts required in Main page...
            bundles.Add(new ScriptBundle("~/Template/main-js").Include(
                "~/Template/dist/js/main.min.js",
                "~/Template/plugins/slimScroll/jquery.slimscroll.min.js"
                ));

            bundles.Add(new ScriptBundle("~/DataTable/js").Include(
                "~/Template/plugins/datatables/jquery.dataTables.min.js",
                "~/Template/plugins/datatables/dataTables.bootstrap.min.js"
                ));


            bundles.Add(new StyleBundle("~/ionRangeSlider/css").Include(
                "~/Template/plugins/ionslider/ion.rangeSlider.css",
                "~/Template/plugins/ionslider/ion.rangeSlider.skinHTML5.css"
                ));

            bundles.Add(new ScriptBundle("~/ionRangeSlider/js").Include(
                "~/Template/plugins/ionslider/ion.rangeSlider.js"
                ));

            bundles.Add(new StyleBundle("~/datepicker/css").Include(
                "~/Template/plugins/datepicker/css/bootstrap-datepicker3.css"
                ));

            bundles.Add(new ScriptBundle("~/datepicker/js").Include(
                "~/Template/plugins/datepicker/js/bootstrap-datepicker.js"
                ));

            bundles.Add(new ScriptBundle("~/userDimension/js").Include(
                "~/Scripts/App/userDimension.js"
                ));
            bundles.Add(new ScriptBundle("~/imageCropper/js").Include(
                "~/Scripts/App/imageCropper.js"
                ));

            bundles.Add(new ScriptBundle("~/portfilter/js").Include(
                "~/Template/plugins/portfilter/bootstrap-portfilter.min.js"
                ));

            bundles.Add(new StyleBundle("~/image-picker/css").Include(
                "~/Template/plugins/image-picker/image-picker.css"
                ));

            bundles.Add(new ScriptBundle("~/image-picker/js").Include(
                "~/Template/plugins/image-picker/image-picker.min.js"
                ));


            bundles.Add(new ScriptBundle("~/angular/js").Include(
                "~/Scripts/Angular/angular.min.js"
                ));

            bundles.Add(new ScriptBundle("~/angular-route/js").Include(
                "~/Scripts/Angular/angular-ui-router.min.js"
                ));

            bundles.Add(new ScriptBundle("~/angular-boostrap/js").Include(
                "~/Scripts/angular-ui/ui-bootstrap.min.js",
                "~/Scripts/angular-ui/ui-bootstrap-tpls.min.js"
                ));

            bundles.Add(new ScriptBundle("~/sirius/app").Include(
               "~/App/shared/shared.core.js",
               "~/App/shared/shared.ui.js",
               "~/App/app.js",
               "~/App/services/userService.js",
               "~/App/services/notificationService.js",
               "~/App/layout/layout.js",
               "~/App/layout/sidebar.js",
               "~/App/layout/header.js"
               ));

        }
    }
}
