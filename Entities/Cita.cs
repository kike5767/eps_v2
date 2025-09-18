using System;
using System.ComponentModel.DataAnnotations;

namespace EPS.Entities
{
    public class Cita
    {
        [Key]
        public int Id { get; set; }
        
        [Range(1, int.MaxValue)]
        public int AfiliadoId { get; set; }
        
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }
        
        [Required]
        public TimeSpan Hora { get; set; }
    }
}


