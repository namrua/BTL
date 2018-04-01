using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BTL
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Product Category",
                url: "danh-muc/{metatitle}-{id}",
                defaults: new { controller = "Product", action = "ProductCategory", id = UrlParameter.Optional },
                namespaces: new[] { "BTL.Controllers" }
            );
            routes.MapRoute(
                name: "Them gio hang",
                url: "them-gio-hang",
                defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
                namespaces: new[] { "BTL.Controllers" }
            );
            routes.MapRoute(
               name: "Gio hang",
               url: "gio-hang",
               defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "BTL.Controllers" }
           );
            routes.MapRoute(
              name: "Thanh toan",
              url: "thanh-toan",
              defaults: new { controller = "Cart", action = "Payment", id = UrlParameter.Optional },
              namespaces: new[] { "BTL.Controllers" }
          );
            routes.MapRoute(
            name: "Thanh toan thanh cong",
            url: "hoan-thanh",
            defaults: new { controller = "Cart", action = "Success", id = UrlParameter.Optional },
            namespaces: new[] { "BTL.Controllers" }
        );
            routes.MapRoute(
                name: "Category",
                url: "san-pham/{metatitle}-{id}",
                defaults: new { controller = "Product", action = "Category", id = UrlParameter.Optional },
                namespaces: new[] { "BTL.Controllers" }
            );
            routes.MapRoute(
               name: "About",
               url: "gioi-thieu",
               defaults: new { controller = "About", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "BTL.Controllers" }
           );
            routes.MapRoute(
               name: "Product",
               url: "chi-tiet/{metatitle}-{id}",
               defaults: new { controller = "Product", action = "Product", id = UrlParameter.Optional },
               namespaces: new[] { "BTL.Controllers" }
           );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "BTL.Controllers" }
            );
        }
    }
}
