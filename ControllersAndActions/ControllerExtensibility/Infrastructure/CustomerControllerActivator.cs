using ControllerExtensibility.Controllers;
using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace ControllerExtensibility.Infrastructure
{
	public class CustomerControllerActivator : IControllerActivator
	{
		public IController Create(RequestContext requestContext, Type controllerType)
		{
			if (controllerType == typeof(ProductController))
			{
				controllerType = typeof(CustomerController);
			}
			return (IController)DependencyResolver.Current.GetService(controllerType);
		}
	}
}