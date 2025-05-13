using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace prueba_soltec.DTOs.Usuarios
{
    public class UsuariosDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(255)]
        public string PrimerApellido { get; set; }

        [AllowNull]
        [MaxLength(255)]
        public string SegundoApellido { get; set; }

        [MaxLength(150)]
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
