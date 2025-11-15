using System;
using System.ComponentModel.DataAnnotations;

namespace EPS.Entities
{
    public class Reporte
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Descripcion { get; set; }
        
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }
    }
}


