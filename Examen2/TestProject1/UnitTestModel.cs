
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Examen2.Models;

namespace Examen2.Tests
{
    [TestClass]
    public class VehiculosModelTests
    {
        [TestMethod]
        public void TestNombreValidation()
        {
            VehiculosModel vehiculo = new VehiculosModel();
            vehiculo.Nombre = "";
            var context = new System.ComponentModel.DataAnnotations.ValidationContext(vehiculo, null, null);
            var results = new System.Collections.Generic.List<System.ComponentModel.DataAnnotations.ValidationResult>();
            bool isValid = System.ComponentModel.DataAnnotations.Validator.TryValidateObject(vehiculo, context, results);
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void TestTipoValidation()
        {
            VehiculosModel vehiculo = new VehiculosModel();
            vehiculo.Tipo = "";
            var context = new System.ComponentModel.DataAnnotations.ValidationContext(vehiculo, null, null);
            var results = new System.Collections.Generic.List<System.ComponentModel.DataAnnotations.ValidationResult>();
            bool isValid = System.ComponentModel.DataAnnotations.Validator.TryValidateObject(vehiculo, context, results);
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void TestPopularidadValidation()
        {
            VehiculosModel vehiculo = new VehiculosModel();
            vehiculo.Popularidad = "";
            var context = new System.ComponentModel.DataAnnotations.ValidationContext(vehiculo, null, null);
            var results = new System.Collections.Generic.List<System.ComponentModel.DataAnnotations.ValidationResult>();
            bool isValid = System.ComponentModel.DataAnnotations.Validator.TryValidateObject(vehiculo, context, results);
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void TestPrecioValidation()
        {
            VehiculosModel vehiculo = new VehiculosModel();
            vehiculo.Precio = -1;
            var context = new System.ComponentModel.DataAnnotations.ValidationContext(vehiculo, null, null);
            var results = new System.Collections.Generic.List<System.ComponentModel.DataAnnotations.ValidationResult>();
            bool isValid = System.ComponentModel.DataAnnotations.Validator.TryValidateObject(vehiculo, context, results);
            Assert.IsFalse(isValid);
        }
    }
}
