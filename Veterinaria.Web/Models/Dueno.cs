using System.ComponentModel.DataAnnotations;

namespace Veterinaria.Web.Models
{
    public class Dueno
    {
        [Required][Key]
        [MaxLength(50, ErrorMessage = "El campo {0} debe contener almenos un caracter")]
        public string Documento { get; set; }

        [Required][MaxLength(50, ErrorMessage ="El campo {0} debe contener almenos un caracter")]
        public string Nombre { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string Correo { get; set; }

        public string Barrio { get; set; }

    }
}
