using Microsoft.AspNetCore.Mvc;
using Catalogo.Models; 
using System.Collections.Generic;

namespace Catalogo.Controllers
{
	public class GaleriaController : Controller
	{
		public IActionResult Index()
		{
			
			var fotos = new List<GaleriaItem>
			{
				new GaleriaItem { Url = "/img/galeria/foto1.jpg", Titulo = "Panuchos Tradicionales", Categoria = "Cena" },
				new GaleriaItem { Url = "/img/galeria/foto2.jpg", Titulo = "Fachada San Pedro Uxmal", Categoria = "Local" },
				new GaleriaItem { Url = "/img/galeria/foto3.jpg", Titulo = "El Fogón de la Tía", Categoria = "Cocina" }
			};

			return View(fotos);
		}
	}
}