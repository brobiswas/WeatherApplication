using System.Web.Mvc;
using System.Web.Routing;

namespace WeatherApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "WeatherApp",
                url: "{controller}/{action}/{City}",
                defaults: new { controller = "Weather", action = "GetWeatherInfo" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Weather", action = "Weather", id = UrlParameter.Optional }
            );
        }
    }
}
