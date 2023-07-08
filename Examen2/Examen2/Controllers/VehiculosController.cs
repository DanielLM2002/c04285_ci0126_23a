using Examen2.Models;
using Microsoft.AspNetCore.Mvc;
namespace laboratorio3.Controllers
{
    public class VehiculosController : Controller
    {
        public IActionResult Index()
        {
            var vehiculos = GetListOfVehiculos();
            ViewBag.MainTitle = "These are my favorite movies"; return View(vehiculos);
        }
        private List<VehiculosModel> GetListOfVehiculos()
        {
            List<VehiculosModel> vehiculos = new List<VehiculosModel>(); vehiculos.Add(new VehiculosModel
            {
                Nombre = "Toyota Camry",
                Tipo = "Terrestre",
                Popularidad = "Alta",
                Precio = 50000,
                NecesitaLicencia = true
            });
            vehiculos.Add(new VehiculosModel
            {
                Nombre = "Toyota Corolla",
                Tipo = "Terrestre",
                Popularidad = "Alta",
                Precio = 40000,
                NecesitaLicencia = true
            });
            vehiculos.Add(new VehiculosModel
            {
                Nombre = "Bote simple",
                Tipo = "Acuatico",
                Popularidad = "baja",
                Precio = 10000,
                NecesitaLicencia = false
            });
            return vehiculos;

        }
    }
}