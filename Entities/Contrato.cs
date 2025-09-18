using System;
using System.ComponentModel.DataAnnotations;

namespace EPS.Entities
{
    public class Contrato
    {
        [Key]
        public int Id { get; set; }
        
        [Range(1, int.MaxValue)]
        public int AfiliadoId { get; set; }
        
        [Range(1, int.MaxValue)]
        public int PlanEPSId { get; set; }
        
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime FechaInicio { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime FechaFin { get; set; }
    }
}


