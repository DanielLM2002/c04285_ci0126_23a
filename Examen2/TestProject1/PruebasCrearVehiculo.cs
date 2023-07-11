using System.Collections.Generic;
using Examen2.Controllers;
using Examen2.Models;
using Examen2.Handlers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Examen2Tests
{
    [TestClass]
    public class VehiculosControllerTests
    {
        [TestMethod]
        public void Index_ReturnsViewResult_WithListOfVehiculos()
        {
            // Arrange
            var vehiculosController = new VehiculosController();

            // Act
            var result = vehiculosController.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.Model, typeof(List<VehiculosModel>));
        }

        [TestMethod]
        public void CrearVehiculo_ReturnsViewResult_WhenModelStateIsInvalid()
        {
            // Arrange
            var vehiculosController = new VehiculosController();
            vehiculosController.ModelState.AddModelError("Nombre", "El nombre es requerido");

            // Act
            var result = vehiculosController.CrearVehiculo(new VehiculosModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var viewResult = (ViewResult)result;
            Assert.AreEqual(false, viewResult.ViewData["ExitoAlCrear"]);
        }
    }
}

