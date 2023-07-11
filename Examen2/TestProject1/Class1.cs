
using System;
using Examen2.Controllers;
using Examen2.Models;
using Examen2.Handlers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Examen2.Tests
{
    [TestClass]
    public class VehiculosControllerTests
    {
        [TestMethod]
        public void EliminarVehiculo_IdNull_RedirectsToIndex()
        {
            // Arrange
            var controller = new VehiculosController();
            int? id = null;

            // Act
            var result = controller.EliminarVehiculo(id) as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual(null, result.ControllerName);
        }

        [TestMethod]
        public void EliminarVehiculo_VehiculoExists_RedirectsToIndex()
        {
            // Arrange
            var controller = new VehiculosController();
            var vehiculosHandler = new VehiculosHandler();
            var vehiculo = new VehiculosModel() { ID = 1, Nombre = "Test vehiculo" };
            var created = vehiculosHandler.CrearVehiculo(vehiculo);

            // Act
            var result = controller.EliminarVehiculo(vehiculo.ID) as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual("Vehiculos", result.ControllerName);
        }
    }
}
