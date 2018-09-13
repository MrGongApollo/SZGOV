using System.Web;
using System.Web.Optimization;

namespace LayUI.Win
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Modernizr
            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));
            #endregion

            #region Commonjs
            bundles.Add(new ScriptBundle("~/bundles/Commonjs").Include(
          "~/Scripts/jquery-{version}.js",
          "~/plug/layui/layui.js",
          "~/Scripts/base.js",
          "~/Scripts/moment.min.js",
          "~/Scripts/respond.js"));
            #endregion

            #region Commoncss
            bundles.Add(new StyleBundle("~/bundles/css").Include(
          "~/plug/layui/css/layui.css",
          "~/plug/font-awesome/css/font-awesome.min.css",
          "~/Content/base.css"));
            #endregion

            #region Editcss
            bundles.Add(new StyleBundle("~/bundles/Editcss").Include("~/Content/edit.css"));
            #endregion

            #region jQuery.Cookie
            bundles.Add(new ScriptBundle("~/Scripts/Cookie").Include("~/Scripts/jquery.cookie.min.js"));
            #endregion

            #region win10css
          bundles.Add(new StyleBundle("~/bundles/win10").Include(
          "~/plug/win10-ui/css/animate.css",
          "~/plug/win10-ui/css/default.css"));
            #endregion
        }
    }
}
