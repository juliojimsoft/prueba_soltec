using System.ComponentModel.DataAnnotations;

namespace prueba_soltec.DTOs.Usuarios
{
    public class UsuariosActualizarDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(255)]
        public string PrimerApellido { get; set; }

        [MaxLength(255)]
        public string? SegundoApellido { get; set; }

        [Required]
        [MaxLength(150)]
        [EmailAddress]
        public string Email { get; set; }

        public bool Activo { get; set; }
    }

}
