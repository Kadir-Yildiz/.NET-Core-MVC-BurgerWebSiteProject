using Microsoft.AspNetCore.Mvc;

namespace MVCHamburgerProjesi.Controllers
{
	public class MenuEkstraController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
