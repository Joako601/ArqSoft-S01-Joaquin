using Microsoft.AspNetCore.Mvc;

namespace Catalogo.Controllers
{
	public class InfoController : Controller
	{
		public IActionResult Historia()
		{
			return View();
		}

		public IActionResult Ubicacion()
		{
			return View();
		}
	}
}