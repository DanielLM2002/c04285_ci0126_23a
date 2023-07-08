using Examen2.Models;
using Examen2.Handlers;
using Microsoft.AspNetCore.Mvc;
namespace Examen2.Controllers
{
    public class VehiculosController : Controller
    {
        public IActionResult Index()
        {
            VehiculosHandler vehiculosHandler = new VehiculosHandler(); 
            var vehiculos = vehiculosHandler.ObtenerVehiculos();
            ViewBag.MainTittle = "Lista de vehiculos";
            return View(vehiculos);
        }
    }
}