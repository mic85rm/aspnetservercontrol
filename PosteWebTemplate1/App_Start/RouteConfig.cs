using Microsoft.AspNet.FriendlyUrls;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;

namespace PosteWebTemplate1
{
  public static class RouteConfig
  {
    public static void RegisterRoutes(RouteCollection routes)
    {
      var settings = new FriendlyUrlSettings();
      settings.AutoRedirectMode = RedirectMode.Permanent;
      routes.EnableFriendlyUrls(settings);
    }
  }
}
