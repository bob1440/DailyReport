using System.Web;
using System.Web.Optimization;


namespace DailyReport.App_Start
{
    public class BundleConfig
    {
        // 如需 Bundling 的詳細資訊，請造訪 http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
            //            "~/Scripts/jquery-ui-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.unobtrusive*",
            //            "~/Scripts/jquery.validate*"));

            // 使用開發版本的 Modernizr 進行開發並學習。然後，當您
            // 準備好實際執行時，請使用 http://modernizr.com 上的建置工具，只選擇您需要的測試。
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/global/css").Include(
                        "~/assets/global/plugins/font-awesome/css/font-awesome.min.css",
                        "~/assets/global/plugins/simple-line-icons/simple-line-icons.min.css",
                        "~/assets/global/plugins/bootstrap/css/bootstrap.min.css",
                        "~/assets/global/plugins/uniform/css/uniform.default.css",
                        "~/assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css"));

            //bundles.Add(new StyleBundle("~/THEME/css").Include(
            //            "~/assets/global/css/components.css",
            //            "~/assets/global/css/plugins.css",
            //            "~/assets/admin/layout/css/layout.css",
            //            "~/assets/admin/layout/css/themes/default.css",
            //            "~/assets/admin/layout/css/custom.css"));

            bundles.Add(new ScriptBundle("~/global/script").Include(
                        "~/assets/global/plugins/jquery-ui/jquery-ui-1.10.3.custom.min.js",
                        "~/assets/global/plugins/bootstrap/js/bootstrap.min.js",
                        "~/assets/global/plugins/bootstrap-hover-dropdown/bootstrap-hover-dropdown.min.js",
                        "~/assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js",
                        "~/assets/global/plugins/jquery.blockui.min.js",
                        "~/assets/global/plugins/jquery.cokie.min.js",
                        "~/assets/global/plugins/uniform/jquery.uniform.min.js",
                        "~/assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js"));
        }
    }
}