using System;
using System.ComponentModel.DataAnnotations;

namespace EPS.Entities
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Clave { get; set; }
    }
}


