using Catalogo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.Controllers
{
	public class CatalogoController : Controller
	{
		private static List<Item> _items = new()
		{
			new Item {
				Id = 1,
				Titulo = "Devil May Cry",
				Genero = "Hack and Slash",
				Ano = 2001,
				Consola = "PlayStation 2",
				Descripcion = "VideoJuego que trata de un cazador... "
			},
			new Item{
				Id = 2,
				Titulo = "God of war",
				Genero = "Hack and Slash",
				Ano = 2005,
				Consola = "PlayStation 2",
				Descripcion = "VideoJuego que trata de un pelado enojado... "
			}
		};

		public IActionResult Index(string? genero){
			var resultado = string.IsNullOrEmpty(genero)
			? _items
			: _items.Where(i => i.Genero == genero).ToList();

			ViewBag.Generos = _items.Select(i => i.Genero).Distinct().ToList();
			ViewBag.GeneroActual = genero;

			return View(resultado);
		}

		public IActionResult Detalle(int id){
			var item = _items.FirstOrDefault(i => i.Id == id);
			return item == null ? NotFound() : View(item);

		}

		public IActionResult Agregar(){
			return View();
		}

		[HttpPost]
		public IActionResult Agregar(Item item){
			item.Id = _items.Count + 1;
			_items.Add(item);
			return RedirectToAction("Index");
		}
	}
}
