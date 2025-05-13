using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace prueba_soltec.DTOs.Usuarios
{
    public class UsuariosCrearDto
    {
        [Required]
        [MaxLength(255)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(255)]
        public string PrimerApellido { get; set; }

        [MaxLength(255)]
        public string? SegundoApellido { get; set; } = null;

        [Required]
        [MaxLength(150)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Contrasenia { get; set; }

        public bool Activo { get; set; } = true;

        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    }

}
