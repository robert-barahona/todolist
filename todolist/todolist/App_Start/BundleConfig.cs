using System.Web;
using System.Web.Optimization;

namespace todolist
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                    "~/Scripts/jquery.min.js",
                    "~/Scripts/jquery.dropotron.min.js",
                    "~/Scripts/jquery.scrolly.min.js",
                    "~/Scripts/jquery.scrollex.min.js",
                    "~/Scripts/browser.min.js",
                    "~/Scripts/breakpoints.min.js",
                    "~/Scripts/util.js",
                      "~/Scripts/main.js"));



            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/estilos/fontawesome-all.min.css",
                      "~/Content/estilos/main.css",
                      "~/Content/estilos/noscript.css"));
        }
    }
}
