using Microsoft.VisualStudio.TestTools.UnitTesting;
using Examen2.Controllers;
using Examen2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
using Examen2.Handlers;
using Moq;

namespace Examen2.UnitTestsVehiculosController
{
    [TestClass]
    public class VehiculosControllerTests
    {
        [TestMethod]
        public void EditarVehiculo_ValidInput_ReturnsRedirectToActionResult()
        {
            //Arrange
            var vehiculo = new VehiculosModel { ID = 1, Nombre = "Vehiculo1" };
            var controller = new VehiculosController();

            //Act
            var result = controller.EditarVehiculo(vehiculo) as RedirectToActionResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual("Vehiculos", result.ControllerName);
        }

        [TestMethod]
        public void EditarVehiculo_InvalidInput_ReturnsViewResult()
        {
            //Arrange
            var vehiculo = new VehiculosModel { ID = 1, Nombre = "Vehiculo1" };
            var controller = new VehiculosController();
            controller.ModelState.AddModelError("Nombre", "El nombre es requerido");

            //Act
            var result = controller.EditarVehiculo(vehiculo) as ViewResult;

            //Assert
            Assert.IsNull(result);
        }
    }
    
}