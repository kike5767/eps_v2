using System;
using System.ComponentModel.DataAnnotations;

namespace EPS.Entities
{
    public class HistoriaMedica
    {
        [Key]
        public int Id { get; set; }
        
        public int AfiliadoId { get; set; }
        
        [StringLength(100)]
        public string Diagnostico { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }
    }
}


