using System.Web.Optimization;

namespace WebApplication
{
  /// <prologue>
  ///
  /// <file name="BundleConfig.cs"/>
  ///
  /// <remarks>
  /// N/A
  /// </remarks>
  ///
  /// 
  /// <author name="Jason Truong" date="02/07/19"/>
  /// 
  ///
  /// <history>
  ///   <entry date="02/07/19" author="Jason Truong" scr="" 
  ///          desc="Created"/> 
  /// </history>
  ///
  /// </prologue>
  /// <summary>
  /// Contains all bundles scripts and css files.
  /// </summary>
  ///
  /// <remarks>
  /// N/A
  /// </remarks>
  public class BundleConfig
  {
    #region Register

    /// <summary>
    /// Bundle Scripts and Content files for easier reference
    /// </summary>
    /// 
    /// <param name="bundles">
    /// Collection of Bundles.
    /// </param>
    public static void RegisterBundles(BundleCollection bundles)
    {
      bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                  "~/Scripts/jquery-{version}.js"));

      // Use the development version of Modernizr to develop with and learn from. Then, when you're
      // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
      bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                  "~/Scripts/modernizr-*"));

      bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js"));

      bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/site.css"));

      bundles.Add(new ScriptBundle("~/bundles/app").Include(
               "~/Scripts/knockout-{version}.js",
               "~/Scripts/app.js",
               "~/Scripts/moment.min.js"));
    }

    #endregion
  }
}
