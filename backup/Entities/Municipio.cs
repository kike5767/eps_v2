using System;
using System.ComponentModel.DataAnnotations;

namespace EPS.Entities
{
    public class Municipio
    {
        [Key]
        public int Id { get; set; }
        
        [StringLength(100)]
        public string Nombre { get; set; }
        
        public int DepartamentoId { get; set; }
        
        [StringLength(10)]
        public string Codigo { get; set; }
    }
}
