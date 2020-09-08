using System.Web.Mvc;
using System.Web.Routing;

namespace AdminPanelCore.UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
             name: "urunler",
             url: "urunler",
             defaults: new { controller = "Home", action = "Products", id = UrlParameter.Optional }
         );

            routes.MapRoute(
             name: "hakkimizda",
             url: "hakkimizda",
             defaults: new { controller = "Home", action = "About", id = UrlParameter.Optional }
         );

            routes.MapRoute(
             name: "iletisim",
             url: "iletisim",
             defaults: new { controller = "Home", action = "Contact", id = UrlParameter.Optional }
         );

            routes.MapRoute(
             name: "Home2",
             url: "",
             defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
         );
            routes.MapRoute(
              name: "Home",
              url: "anasayfa",
              defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
          );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}