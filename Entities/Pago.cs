using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPS.Entities
{
    public class Pago
    {
        [Key]
        public int Id { get; set; }
        
        [Range(1, int.MaxValue)]
        public int ContratoId { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Valor { get; set; }
        
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? Fecha { get; set; }
    }
}


