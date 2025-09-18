using System;
using System.ComponentModel.DataAnnotations;

namespace EPS.Entities
{
    public class Factura
    {
        [Key]
        public int Id { get; set; }
        
        public int PagoId { get; set; }
        
        [StringLength(50)]
        public string Numero { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }
    }
}


