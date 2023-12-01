using Microsoft.AspNet.FriendlyUrls;
using System.Web.Http;
using System.Web.Routing;

namespace PosteWebTemplate1
{
  public class BRouteConfig
  {

    public static void RegisterRoutes(RouteCollection routes)
    {
      var settings = new FriendlyUrlSettings();
      settings.AutoRedirectMode = RedirectMode.Permanent;
      routes.Clear();
      routes.EnableFriendlyUrls(settings);
      routes.MapHttpRoute(name: "ActionApi", routeTemplate: "webapi/{controller}/{action}/{param}");
      routes.MapHttpRoute(name: "", routeTemplate: "webapi/{controller}/{id}", defaults: new { id = System.Web.Http.RouteParameter.Optional });
    }

  }
}