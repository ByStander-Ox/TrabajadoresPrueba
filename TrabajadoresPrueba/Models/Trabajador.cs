using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabajadoresPrueba.Models
{
    [Table("Trabajadores")]
    public class Trabajador
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [StringLength(100)]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un tipo de documento")]
        [StringLength(50)]
        public string TipoDocumento { get; set; }

        [Required(ErrorMessage = "El número de documento es obligatorio")]
        [StringLength(20)]
        public string NumeroDocumento { get; set; }

        [Required(ErrorMessage = "Debe seleccionar el sexo")]
        [StringLength(10)]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        [StringLength(255)]
        [Display(Name = "Foto (URL o ruta)")]
        public string Foto { get; set; }

        [StringLength(255)]
        public string Direccion { get; set; }
    }
}
