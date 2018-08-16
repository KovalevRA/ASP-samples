using System.Web.Mvc;
using System.Web.Routing;

namespace UrlsAndRoutes
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.MapRoute(
							name: "MyRoute",
							url: "{controller}/{action}/{id}/{*catchcall}",
							defaults: new
							{
								controller = "Home",
								action = "Index",
								id = UrlParameter.Optional
							},
							namespaces: new[] { "UrlsAndRoutes.AdditionalControllers" }
						);

			routes.MapRoute(null, "Public/{controller}/{action}",
				defaults: new { action = "Index", controller = "Home" });

			routes.MapRoute(null, "{controller}/{action}",
				defaults: new { action = "Index", controller = "Home" });
		}
	}
}