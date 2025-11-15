using System.ComponentModel.DataAnnotations;

namespace EPS.DTOs
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int RolId { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
    }

    public class CreateUsuarioDto
    {
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Clave { get; set; } = string.Empty;

        [Required]
        public int RolId { get; set; }
    }

    public class UpdateUsuarioDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Clave { get; set; } = string.Empty;

        [Required]
        public int RolId { get; set; }

        public bool Activo { get; set; } = true;
    }
}


