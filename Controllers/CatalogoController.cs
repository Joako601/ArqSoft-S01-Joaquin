using Catalogo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.Controllers
{
	public class CatalogoController : Controller
	{
		
		public static List<Item> _menu = new()
		{
			new Item {
				Id = 1, Platillo = "Panuchos", Categoria = "Cena",
				Precio = 18.00m, Ingredientes = "Cochinita", Descripcion = "Clásicos de Mérida."
			},
			new Item {
				Id = 2, Platillo = "Torta de Asado", Categoria = "Especialidad",
				Precio = 45.00m, Ingredientes = "Cerdo", Descripcion = "Con pan francés local."
			}
		};

		public IActionResult Index(string? categoria)
		{
			var resultado = string.IsNullOrEmpty(categoria) ? _menu : _menu.Where(i => i.Categoria == categoria).ToList();
			ViewBag.Categorias = _menu.Select(i => i.Categoria).Distinct().ToList();
			ViewBag.CategoriaActual = categoria;
			return View(resultado);
		}

		public IActionResult Detalle(int id)
		{
			var platillo = _menu.FirstOrDefault(i => i.Id == id);
			return platillo == null ? NotFound() : View(platillo);
		}

		public IActionResult Agregar() => View();

		[HttpPost]
		public IActionResult Agregar(Item nuevo)
		{
			nuevo.Id = _menu.Count > 0 ? _menu.Max(i => i.Id) + 1 : 1;
			_menu.Add(nuevo);
			
			return RedirectToAction("Index");
		}
	}
}