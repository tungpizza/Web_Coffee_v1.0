using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MinhCoffee
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "EspressoMachines",
                url: "espresso-machines/{action}/{id}",
                defaults: new { controller = "EspressoMachines", action = "Index" }
            );

            routes.MapRoute(
                name: "CoffeeGrinders",
                url: "coffee-grinders/{action}/{id}",
                defaults: new { controller = "CoffeeGrinders", action = "Index" }
            );

            routes.MapRoute(
                name: "CoffeeBeans",
                url: "coffee-beans/{action}/{id}",
                defaults: new { controller = "CoffeeBeans", action = "GreenBeans" }
            );

            routes.MapRoute(
                name: "Item",
                url: "Products/{action}/{id}",
                defaults: new { controller = "Products", action = "Item", id = ""}
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "HomePage", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
