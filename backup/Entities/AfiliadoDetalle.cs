using System;
using System.ComponentModel.DataAnnotations;

namespace EPS.Entities
{
    public class AfiliadoDetalle
    {
        [Key]
        public int Id { get; set; }
        
        public int AfiliadoId { get; set; }
        
        [StringLength(50)]
        public string TipoDetalle { get; set; }
        
        [StringLength(100)]
        public string Valor { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime FechaRegistro { get; set; }
    }
}


