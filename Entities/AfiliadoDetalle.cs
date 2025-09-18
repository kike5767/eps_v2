using System;
using System.ComponentModel.DataAnnotations;

namespace EPS.Entities
{
    public class AfiliadoDetalle
    {
        [Key]
        public int Id { get; set; }
        
        [Range(1, int.MaxValue)]
        public int AfiliadoId { get; set; }
        
        [Required]
        [StringLength(50)]
        public string TipoDetalle { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Valor { get; set; }
        
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime FechaRegistro { get; set; }
    }
}


