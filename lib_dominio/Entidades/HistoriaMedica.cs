using System.ComponentModel.DataAnnotations;

namespace lib_dominio.Entidades
{
    public class HistoriaMedica
    {
        [Key]
        public int Id { get; set; }
        
        [Range(1, int.MaxValue)]
        public int AfiliadoId { get; set; }
        public virtual Afiliado? Afiliado { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Diagnostico { get; set; } = string.Empty;
        
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }
        
        [StringLength(500)]
        public string? Tratamiento { get; set; }
        
        [StringLength(50)]
        public string? Medico { get; set; }
        
        [StringLength(1000)]
        public string? Observaciones { get; set; }
        
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}
