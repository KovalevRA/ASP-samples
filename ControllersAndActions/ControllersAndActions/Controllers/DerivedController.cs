using ControllersAndActions.Infrastructure;
using System.Web.Mvc;

namespace ControllersAndActions.Controllers
{
	public class DerivedController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult ProduceOutput()
		{
			if (Server.MachineName == "MyMachineName")
				return new CustomRedirectResult { Url = "Basic/Index" };
			else
			{
				Response.Write("Контроллер: Derived, Метод действия: ProduceOutput");
				return null;
			}
		}
    }
}