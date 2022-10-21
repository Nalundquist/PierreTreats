using Microsoft.AspNetCore.Mvc;

namespace PierreTreats.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}
	}
}