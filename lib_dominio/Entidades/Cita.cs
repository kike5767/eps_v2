using System.ComponentModel.DataAnnotations;

namespace lib_dominio.Entidades
{
    public class Cita
    {
        [Key]
        public int Id { get; set; }
        
        [Range(1, int.MaxValue)]
        public int AfiliadoId { get; set; }
        public virtual Afiliado? Afiliado { get; set; }
        
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }
        
        [Required]
        public TimeSpan Hora { get; set; }
        
        [StringLength(100)]
        public string? Motivo { get; set; }
        
        [StringLength(50)]
        public string? Medico { get; set; }
        
        [StringLength(50)]
        public string Estado { get; set; } = "Programada";
        
        [StringLength(500)]
        public string? Observaciones { get; set; }
        
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}
