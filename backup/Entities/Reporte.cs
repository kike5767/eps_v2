using System;
using System.ComponentModel.DataAnnotations;

namespace EPS.Entities
{
    public class Reporte
    {
        [Key]
        public int Id { get; set; }
        
        [StringLength(100)]
        public string Descripcion { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }
    }
}


