using System;
using System.ComponentModel.DataAnnotations;

namespace EPS.Entities
{
    public class Contrato
    {
        [Key]
        public int Id { get; set; }
        
        public int AfiliadoId { get; set; }
        
        public int PlanEPSId { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime FechaInicio { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime FechaFin { get; set; }
    }
}


