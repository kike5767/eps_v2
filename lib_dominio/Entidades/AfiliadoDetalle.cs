using System.ComponentModel.DataAnnotations;

namespace lib_dominio.Entidades
{
    public class AfiliadoDetalle
    {
        [Key]
        public int Id { get; set; }
        
        [Range(1, int.MaxValue)]
        public int AfiliadoId { get; set; }
        public virtual Afiliado? Afiliado { get; set; }
        
        [Required]
        [StringLength(50)]
        public string TipoDetalle { get; set; } = string.Empty;
        
        [Required]
        [StringLength(100)]
        public string Valor { get; set; } = string.Empty;
        
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime FechaRegistro { get; set; }
        
        [StringLength(500)]
        public string? Observaciones { get; set; }
        
        public bool Activo { get; set; } = true;
    }
}
