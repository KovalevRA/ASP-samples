using System.Web.Mvc;

namespace UrlsAndRoutes.Controllers
{
	public class HomeController : Controller
    {
		public ActionResult List()
		{
			ViewBag.Controller = "Home";
			ViewBag.Action = "List";
			return View("ActionName");
		}

		public ActionResult Index()
		{
			ViewBag.Controller = "Home";
			ViewBag.Action = "Index";
			return View("ActionName");
		}

		public ActionResult CustomVariable(string id)
		{
			ViewBag.Controller = "Home";
			ViewBag.Action = "CustomVariable";
			ViewBag.CustomVariable = id;
			return View();
		}
	}
}