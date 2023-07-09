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

        [HttpGet]
        public ActionResult CrearVehiculo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrearVehiculo(VehiculosModel vehiculo)
        {
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
            catch
            {
                ViewBag.Message = "Algo salio mal en la creacion";
                return View();
            }
        }
    }

}