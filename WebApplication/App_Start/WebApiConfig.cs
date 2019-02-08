using System.Web.Http;

namespace WebApplication
{
  public static class WebApiConfig
  {
    /// <prologue>
    ///
    /// <file name="WebApiConfig.cs"/>
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
    /// 
    /// <summary>
    /// Web Api Configurations
    /// </summary>
    ///
    /// <remarks>
    /// N/A
    /// </remarks>
    public static void Register(HttpConfiguration config)
    {
      // Web API configuration and services

      // Web API routes
      config.MapHttpAttributeRoutes();

      config.Routes.MapHttpRoute(
          name: "DefaultApi",
          routeTemplate: "api/{controller}/{id}",
          defaults: new { id = RouteParameter.Optional }
      );
    }
  }
}