using System.ComponentModel.DataAnnotations;

namespace lib_dominio.Entidades
{
    public class Usuario
    {
        [Key]
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
        
        public int RolId { get; set; }
        public virtual Rol? Rol { get; set; }
        
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public bool Activo { get; set; } = true;
    }
}
