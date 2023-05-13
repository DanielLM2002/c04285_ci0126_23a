using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace laboratorio6.Models;

public class PeliculaModel
{
    public int ID { get; set; }

    [Required(ErrorMessage = "Debe de ingresar un nombre.")]
    [DisplayName("Nombre de la película:")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "Debe de ingresar un año.")]
    [DisplayName("Año:")]
    [RegularExpression("^(18|19|20)[0-9]{2}$", ErrorMessage = "Ingrese un año válido")]
    public int Año { get; set; }
}