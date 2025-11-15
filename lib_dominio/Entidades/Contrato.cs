using System.ComponentModel.DataAnnotations;

namespace lib_dominio.Entidades
{
    public class Contrato
    {
        [Key]
        public int Id { get; set; }
        
        [Range(1, int.MaxValue)]
        public int AfiliadoId { get; set; }
        public virtual Afiliado? Afiliado { get; set; }
        
        [Range(1, int.MaxValue)]
        public int PlanEPSId { get; set; }
        public virtual PlanEPS? PlanEPS { get; set; }
        
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime FechaInicio { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime? FechaFin { get; set; }
        
        public bool Activo { get; set; } = true;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}
