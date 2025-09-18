using System;
using System.ComponentModel.DataAnnotations;

namespace EPS.Entities
{
    public class Cita
    {
        [Key]
        public int Id { get; set; }
        
        public int AfiliadoId { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }
        
        public TimeSpan Hora { get; set; }
    }
}


