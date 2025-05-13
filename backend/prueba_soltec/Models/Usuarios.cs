using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace prueba_soltec.Models
{
    public class Usuarios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(255)]
        public string PrimerApellido { get; set; }

        [AllowNull]
        [MaxLength(255)]
        public string? SegundoApellido { get; set; }

        [MaxLength(150)]
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Contrasenia { get;set;}

        public bool Activo { get; set; } = true;

        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    }
}
