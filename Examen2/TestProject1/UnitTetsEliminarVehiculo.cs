
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
        /// <summary>
        /// Esta prueba verifica el comportamiento de eliminar vehiculo cuando
        /// le pasamos un ID nulo
        /// Arrange:Se crea una instancia del onjeto pero con un ID nulo
        /// Act: Se llama al método EliminarVehiculo del controlador y le pasamos
        /// el valor nulo del ID como parámetro. Luego lo convertimos en un
        /// RedirectToActionResult para los assert
        /// Assert: Se verifica que result  sea igual al index y tambien revisamos que el
        /// id sea nulo comparandolo con el ControllerName 
        /// </summary>
        [TestMethod]
        public void EliminarVehiculo_IdNull_RedirectsToIndex()
        {
            // Arrange
            var controller = new VehiculosController();
            int? id = null;

            // Act
            var result = controller.EliminarVehiculo(id) as RedirectToActionResult;

            // Assert
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual(null, result.ControllerName);
        }

        /// <summary>
        /// El propósito de esta prueba es verificar el comportamiento del método
        /// "EliminarVehiculo" de la clase "VehiculosController" cuando se
        /// le proporciona un ID de vehículo que existe. Para ello tenemos que
        /// en el arrange se crea una instancia del controller y una del handler. Luego
        /// hacemos una instancia del modelo con parametros especificos y creamos un vehiculo
        /// Mas adelante en el act eliminamos el vehiculo que acabamos de crear
        /// y en el assert verificamos que este no exista.
        /// </summary>
        [TestMethod]
        public void EliminarVehiculo_VehiculoExists_RedirectsToIndex()
        {
            // Arrange
            var controller = new VehiculosController();
            var vehiculosHandler = new VehiculosHandler();
            var vehiculo = new VehiculosModel() { ID = 2123, Nombre = "Test vehiculo" };
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
