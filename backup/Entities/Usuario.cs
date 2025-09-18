using System;
using System.ComponentModel.DataAnnotations;

namespace EPS.Entities
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        
        [StringLength(50)]
        public string Nombre { get; set; }
        
        [StringLength(50)]
        public string Email { get; set; }
        
        [StringLength(50)]
        public string Clave { get; set; }
    }
}


