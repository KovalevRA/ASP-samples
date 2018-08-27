using AsyncControllers.Models;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AsyncControllers.Controllers
{
	public class RemoteDataController : Controller
    {
        public async Task<ActionResult> Data()
        {
			var data = await Task<string>.Factory.StartNew(() =>
			{
				return new RemoteService().GetRemoteData();
			});
            return View((object)data);
        }
    }
}