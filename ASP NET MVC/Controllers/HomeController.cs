using ASP_NET_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_NET_MVC.Controllers
{
	public class HomeController : Controller
	{
		public ViewResult Index()
		{
			var isEven = DateTime.Now.Second % 2 == 0;
			ViewBag.IsEven = isEven;
			return View();
		}

		[HttpGet]
		public ViewResult RsvpForm()
		{
			return View();
		}

		[HttpPost]
		public ViewResult RsvpForm(GuestResponse guest)
		{
			if (ModelState.IsValid)
			{
				return View("Thanks", guest);
			}
			else
			{
				return View();
			}
		}
	}
}