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
        /// <summary>
        /// Esta prueba busca verificar si el método Index devuelve un objeto ViewResult
        /// y si el modelo de ese objeto cuenta con una lista del tipo VehiculosModel.
        /// Al principio en el Arrange la prueba crea una instancia de la clase VehiculosController
        /// para poder llamar al método Index.
        /// Mas adelante en el Act se llama el método Index y el resultado es almacenado en
        /// la variable resultado.
        /// Por ultimo en los assert se realizan las verificaciones para ver si
        /// lo que se encuentra en result es una instancia de ViewResult
        /// </summary>
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

        /// <summary>
        /// Este test probar que el método CrearVehiculos retorne un ViewResult
        /// Para ello en el Arrange se crea una instancia de la clase "VehiculosController" y
        /// se agrega un error con el método "AddModelError" del objeto "ModelState".
        /// Esto simula un estado de modelo inválido donde se requiere el campo "Nombre" pero no se proporciona.
        /// Mas adelante en el Act se llama a CrearVehiculo con el fin de pasar un nuevo
        /// objeto llamado VehiculosModel como parámetro. Este estará vacío y lo almacena en la variable result.
        /// En el Assert se revisa si es una instancia de ViewModel y si el resultado es igual al ViewData.
        /// Si ambos son positivos la prueba es exitosa.
        /// </summary>
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

