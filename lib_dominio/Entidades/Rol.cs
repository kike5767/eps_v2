using System.ComponentModel.DataAnnotations;

namespace lib_dominio.Entidades
{
    public class Rol
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;
        
        [Required]
        [StringLength(200)]
        public string Descripcion { get; set; } = string.Empty;
        
        public bool Activo { get; set; } = true;
        
        public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}
