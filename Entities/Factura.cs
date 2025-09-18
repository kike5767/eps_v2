using System;
using System.ComponentModel.DataAnnotations;

namespace EPS.Entities
{
    public class Factura
    {
        [Key]
        public int Id { get; set; }
        
        [Range(1, int.MaxValue)]
        public int PagoId { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Numero { get; set; }
        
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }
    }
}


