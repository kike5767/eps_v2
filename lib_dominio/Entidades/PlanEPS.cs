using System.ComponentModel.DataAnnotations;

namespace lib_dominio.Entidades
{
    public class PlanEPS
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;
        
        [Required]
        [StringLength(50)]
        public string Cobertura { get; set; } = string.Empty;
        
        [StringLength(500)]
        public string? Descripcion { get; set; }
        
        [Range(0, double.MaxValue)]
        public decimal Precio { get; set; }
        
        public bool Activo { get; set; } = true;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        
        public virtual ICollection<Contrato> Contratos { get; set; } = new List<Contrato>();
    }
}
