using Catalogo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.Controllers
{
	public class CatalogoController : Controller
	{
		
		public static List<Item> _menu = new()
		{new Item { Id = 1, Platillo = "Panucho Tradicional", Categoria = "Panuchos", Base = "Frijol y Pavo", Precio = 25, Descripcion = "Tortilla frita rellena de frijol, con pavo, repollo, tomate, pepino y cebolla." },
				new Item { Id = 2, Platillo = "Panucho de Huevo", Categoria = "Panuchos", Base = "Frijol y Huevo", Precio = 20, Descripcion = "Tortilla frita rellena de frijol, huevo cocido, repollo, tomate y cebolla." },

				new Item { Id = 3, Platillo = "Salbute de Pavo", Categoria = "Salbutes", Base = "Masa Frita", Precio = 25, Descripcion = "Lechuga, repollo, pavo, tomate, pepino, aguacate y cebolla." },
				new Item { Id = 4, Platillo = "Salbute de Relleno Negro", Categoria = "Salbutes", Base = "Masa Frita", Precio = 30, Descripcion = "Tradicional relleno negro yucateco con huevo y carne." },

				new Item { Id = 5, Platillo = "Torta de Carne Asada con Queso", Categoria = "Tortas", Base = "Pan Francés", Precio = 60, Descripcion = "Lechuga, carne asada, cebolla, aguacate y queso fundido." },
				new Item { Id = 6, Platillo = "Torta Especial Tía Caro", Categoria = "Tortas", Base = "Pan Francés", Precio = 70, Descripcion = "Carne asada, pavo, lechuga, cebolla, aguacate y queso." },

				new Item { Id = 7, Platillo = "Caldo Comensal", Categoria = "Caldos", Base = "Caldo de Pavo", Precio = 80, Descripcion = "Pavo, repollo, pepino, cebolla, cilantro y tostadas." },

				new Item { Id = 8, Platillo = "Agua de Chaya con Limón", Categoria = "Bebidas", Base = "Natural", Precio = 30, Descripcion = "Refrescante bebida tradicional yucateca." },
				new Item { Id = 9, Platillo = "Refresco Embotellado", Categoria = "Bebidas", Base = "Gasificada", Precio = 25, Descripcion = "Coca-Cola, Cristal o Sidral (600ml)." }
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