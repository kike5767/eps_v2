using System;
using System.ComponentModel.DataAnnotations;

namespace EPS.Entities
{
    public class PlanEPS
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Cobertura { get; set; }
    }
}


