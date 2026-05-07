using System.Diagnostics;
using Catalogo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> _logger)
		{
			_logger = _logger;
		}

		public IActionResult Index()
		{
			// Mantenemos tus 3 platillos dinámicos para el inicio
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
	}
}