using System;
using System.ComponentModel.DataAnnotations;

namespace EPS.Entities
{
    public class Municipio
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        
        [Range(1, int.MaxValue)]
        public int DepartamentoId { get; set; }
        
        [Required]
        [StringLength(10)]
        public string Codigo { get; set; }
    }
}
