using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UrlMini
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Redirect",
                url: "{shortCode}",
                defaults: new { controller = "Home", action = "RedirectWithCode", shortCode = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Encode",
                url: "Encoder",
                defaults: new { controller = "Home", action = "Encoder" }
            );



            routes.MapRoute(
                name: "BackEnd",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", id = UrlParameter.Optional }
            );
        }
    }
}
