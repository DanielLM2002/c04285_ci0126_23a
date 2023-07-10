
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Examen2.Models;

namespace Examen2.UnitTestModel
{
    [TestClass]
    public class VehiculosModelTests
    {
        //[TestMethod]
        //public void TestNombreValidation()
        //{
        //    VehiculosModel vehiculo = new VehiculosModel();
        //    vehiculo.Nombre = "";
        //    var context = new System.ComponentModel.DataAnnotations.ValidationContext(vehiculo, null, null);
        //    var results = new System.Collections.Generic.List<System.ComponentModel.DataAnnotations.ValidationResult>();
        //    bool isValid = System.ComponentModel.DataAnnotations.Validator.TryValidateObject(vehiculo, context, results);
        //    Assert.IsFalse(isValid);
        //}

        //[TestMethod]
        //public void TestTipoValidation()
        //{
        //    VehiculosModel vehiculo = new VehiculosModel();
        //    vehiculo.Tipo = "";
        //    var context = new System.ComponentModel.DataAnnotations.ValidationContext(vehiculo, null, null);
        //    var results = new System.Collections.Generic.List<System.ComponentModel.DataAnnotations.ValidationResult>();
        //    bool isValid = System.ComponentModel.DataAnnotations.Validator.TryValidateObject(vehiculo, context, results);
        //    Assert.IsFalse(isValid);
        //}

        /// <summary>
        /// Esta prueba busca validar que se cumpla A) que el espacio es requerido para completar el formulario ya ue el valor en no nulo en la BD y B) que se
        /// cumplen las condiciones del regex de que no se vale ingresar numeros en este espacio.
        /// </summary>
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


        /// <summary>
        /// Esta prueba busca revisar que la expresion regular que realizamos para esta validacion sea capaz
        /// de evitar que datos que la BD no puede aceptar sean pasados a ella. La preuba recive como argumento un -1
        /// ya que el regex especifica que solo puede aceptar numeros positivos y con decimales (para tomar en cuenta caso de .99 centavos)
        /// por que los precios son en dólares.
        /// </summary>
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
