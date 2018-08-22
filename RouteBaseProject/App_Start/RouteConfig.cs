using RouteBaseProject.Infrustructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RouteBaseProject
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
			routes.MapMvcAttributeRoutes();
			routes.Add(new LegacyRoute(
				"~/articles/About_ASPNET_MVC",
				"~/old/NET_Framework_4"));
        }
    }
}
