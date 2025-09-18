using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPS.Entities
{
    public class Pago
    {
        [Key]
        public int Id { get; set; }
        
        public int ContratoId { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }
    }
}


