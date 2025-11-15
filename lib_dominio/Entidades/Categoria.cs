using System.ComponentModel.DataAnnotations;

namespace lib_dominio.Entidades
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;
        
        [StringLength(200)]
        public string? Descripcion { get; set; }
        
        [StringLength(10)]
        public string? Codigo { get; set; }
        
        public bool Activo { get; set; } = true;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}
