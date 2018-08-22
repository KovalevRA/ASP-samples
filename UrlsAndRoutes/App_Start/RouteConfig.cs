using System.Web.Mvc;
using System.Web.Routing;
using UrlsAndRoutes.Infrustructure;

namespace UrlsAndRoutes
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.MapMvcAttributeRoutes();

			routes.Add(new Route("SayHello", new CustomRouteHandler()));

			routes.Add(new LegacyRoute(
				"~/articles/About_ASPNET_MVC",
				"~/old/NET_Framework_4"
				));

			routes.MapRoute("MyRoute", "{controller}/{action}");
			routes.MapRoute("MyOtherRoute", "App/{action}", new { controller = "Home" });
		}
	}
}