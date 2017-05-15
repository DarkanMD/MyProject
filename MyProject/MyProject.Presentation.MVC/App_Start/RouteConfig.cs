using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyProject.Presentation.MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "ProductModel", action = "CreateProductModel", id = UrlParameter.Optional }
            );
            //routes.MapRoute(
            //    name: "SomeAction",
            //    url: "Olo/lo",
            //    defaults: new
            //    {
            //        controller = "ProductModel",
            //        action = "CreateProductModel"
            //    }
            //);
        }
    }
}
