using Examen2.Controllers;
using Examen2.Models;
using Examen2.Handlers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace Examen2.Tests
{
    [TestClass]
    public class VehiculosControllerTests
    {
        private VehiculosController _vehiculosController;
        private Mock<VehiculosHandler> _mockVehiculosHandler;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockVehiculosHandler = new Mock<VehiculosHandler>();
            _vehiculosController = new VehiculosController();
        }



        [TestMethod]
        public void CrearVehiculo_ReturnsAViewResult_WithAVehiculosModel()
        {
            // Act
            var result = _vehiculosController.CrearVehiculo();
            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            var viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.Model, typeof(VehiculosModel));
        }
    }
}

