﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Examen2.Models
{
    public class VehiculosModel
    {
        [Required(ErrorMessage = "Debe de ingresar un nombre")]
        [DisplayName("Nombre del vehiculo")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "No puede ingresar numeros")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe de ingresar el tipo de vehiculo (terrestre, acuatico u anfibio)")]
        [DisplayName("Tipo de vehiculo")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "No puede ingresar numeros")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "Debe de ingresar la popularidad del vehiculo (baja, media o alta)")]
        [DisplayName("Popularidad de vehiculo")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "No puede ingresar numeros")]
        public string Popularidad { get; set; }

        [Required(ErrorMessage = "Ingrese el precio en dolares")]
        [DisplayName("Precio de la unidad")]
        [RegularExpression("^\\d*(\\.\\d+)?$", ErrorMessage = "Ingrese un precio valido")]
        public float Precio { get; set; }

        [Required(ErrorMessage = "Asegurese de especificar si se ocupa licensia")]
        [DisplayName("Requerimiento de licencia")]
        public bool NecesitaLicencia { get; set; }


        [Required(ErrorMessage = "Debe de ingresar un ID valido")]
        [DisplayName("Id del vehiculo, ingrese un numero entero")]
        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "Ingrese un ID valido")]
        public int ID { get; set; }
    }
}
