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
                        ViewBag.Message = "El vehículo " + vehiculo.Nombre + " fue creado.";
                    }
                }
                return View();
            }
            catch
            {
                ViewBag.Message = "Algo salió mal en la creacion";
                return View();
            }
        }

        [HttpGet]
        public ActionResult EditarVehiculo(int? id) 
        {
            ActionResult vista;
            try
            {
                var vehiculosHandler = new VehiculosHandler();
                var vehiculo = vehiculosHandler.ObtenerVehiculos().Find(model => model.ID == id);
                if (vehiculo == null)
                {
                    vista = RedirectToAction("Index");
                }
                else
                {
                    vista = View(vehiculo);
                }
            }
            catch 
            {
                vista = RedirectToAction("Index");
            }
            return vista;
        }

        [HttpPost]
        public ActionResult EditarVehiculo(VehiculosModel vehiculo) 
        {
            try 
            {
                var vehiculosHandler = new VehiculosHandler();
                vehiculosHandler.EditarVehiculo(vehiculo);
                return RedirectToAction("Index","Vehiculos");
            }
            catch
            {
                return View();
            }

        }

        [HttpGet]
        public ActionResult EliminarVehiculo(int? id)
        {
            ActionResult vista;
            try
            {
                var vehiculosHandler = new VehiculosHandler();
                var vehiculo = vehiculosHandler.ObtenerVehiculos().Find(model => model.ID == id);
                if (vehiculo == null)
                {
                    vista = RedirectToAction("Index");
                }
                else
                {
                    vehiculosHandler.EliminarVehiculo(vehiculo);
                    vista = RedirectToAction("Index", "Vehiculos");
                }
            }
            catch
            {
                vista = RedirectToAction("Index");
            }
            return vista;
        }

        [HttpPost]
        public ActionResult EliminarVehiculo(VehiculosModel vehiculo)
        {
            try
            {
                var vehiculosHandler = new VehiculosHandler();
                vehiculosHandler.EliminarVehiculo(vehiculo);
                return RedirectToAction("Index", "Vehiculos");
            }
            catch
            {
                return View();
            }
        }

    }

}