using System.Diagnostics;
using Catalogo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			// Ahora toma los datos de la lista _menu que contiene tus platillos
			// Usamos TakeLast(3) para que el inicio siempre sea dinámico
			var itemsParaHome = CatalogoController._menu.TakeLast(3).ToList();

			return View(itemsParaHome);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		public IActionResult Historia()
		{
			// Esta vista es principalmente informativa, así que no requiere un modelo complejo por ahora.
			return View();
		}
	}
}