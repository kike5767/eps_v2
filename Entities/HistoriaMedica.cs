using System;
using System.ComponentModel.DataAnnotations;

namespace EPS.Entities
{
    public class HistoriaMedica
    {
        [Key]
        public int Id { get; set; }
        
        [Range(1, int.MaxValue)]
        public int AfiliadoId { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Diagnostico { get; set; }
        
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }
    }
}


