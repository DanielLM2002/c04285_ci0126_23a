using Lab5.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace Lab5.Controllers
{
    public class PeliculasController : Controller
    {
        public IActionResult Index()
        {
            PeliculasHandler peliculasHandler = new PeliculasHandler();
            var peliculas = peliculasHandler.ObtenerPeliculas();
            ViewBag.MainTitle = "Lista de peliculas";
            return View(peliculas);
        }
    }
}
