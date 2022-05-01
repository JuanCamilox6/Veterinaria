using System.ComponentModel.DataAnnotations;

namespace Veterinaria.Web.Models
{
    public class Mascota
    {
        [Required][Key]
        [MaxLength(50, ErrorMessage = "El campo {0} debe contener almenos un caracter")]
        public string Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "El campo {0} debe contener almenos un caracter")]
        public string FechaIngreso { get; set; }
        [Required]
        public string NombreMascota { get; set; }

        public string TipoMascota { get; set; }

        public int Edad { get; set; }

        public string Alergias { get; set; }

        public string Genero { get; set; }

        public string Raza { get; set; }

        public float Peso { get; set; }

        public string Color { get; set; }

        public string Observaciones { get; set; }





    }
}
