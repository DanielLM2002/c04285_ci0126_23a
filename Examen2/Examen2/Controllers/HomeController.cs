using Examen2.Handlers;
using Examen2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Examen2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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

        [HttpGet]
        public ActionResult CrearVehiculo() { 
            return View();
        }

        [HttpPost]
        public ActionResult CrearVehiculo(VehiculosModel vehiculo) {
            ViewBag.ExitoAlCrear = false;
            try
            {
                if (ModelState.IsValid)
                {
                    VehiculosHandler vehiculosHandler = new VehiculosHandler();
                    ViewBag.ExitoAlCrear = vehiculosHandler.CrearVehiculo(vehiculo);

                    if (ViewBag.ExitoAlCrear)
                    {
                        ViewBag.Message = "El Vehiculo " + vehiculo.Nombre + " fue creado.";
                    }
                }
                return View();
            }
            catch {
                ViewBag.Message = "Algo salio mal en la creacion";
                return View();
            }
        }
    }
}