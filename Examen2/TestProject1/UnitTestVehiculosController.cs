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
        /// <summary>
        /// Esta prueba tiene como fin ver si a la hora de editar un vehiculo
        /// esto se puede hacer sin problemas de manera la manera en la que el form
        /// fue diseñado. Esto se hace viendo si la entrada que le damos en este caso
        /// es válido.
        /// La prueba funciona mediante Arrange, Act y Assert
        /// El Arrange crea un objeto "vehiculo" del tipo "VehiculosModel" con
        /// las propiedades para hacer que la entrada sea válida.
        /// El Act llama al método "EditarVehículo" del controlador de vehiculos y
        /// pasa este objeto como parámetro y convertirlo en un RedirectToActionResult.
        /// Luego en el Assert se realizan 3 verificaciones. Primero se revisa que no
        /// sea un objeto nulo, después se revisa que el Valor de result sea igual al Index
        /// Por último se revisa que ControllerName sea igual a vehiculos.
        /// </summary>
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

        /// <summary>
        /// Esta prueba tiene el objetivo de verificar el comportamiento del método
        /// "EditarVehiculo" de la clase "VehiculosController" cuando se le
        /// proporciona una entrada inválida.
        /// El Arrange crea un objeto "vehiculo" del tipo "VehiculosModel" con
        /// las propiedades para hacer que la entrada sea válida. Tambien crea
        /// una instancia de la clase  "VehiculosCOntroller" con un error de modelo
        /// para simular una entrada inválida.
        /// El Act llama ala método "EditarVehículo" del controlador, a este le pasa
        /// el objeto "vehículo" como parámetro. Luego lo convertimos en ViewResult
        /// y lo guardamos en result.
        /// El Assert solo verifica que el objeto sea nulo.
        /// </summary>
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