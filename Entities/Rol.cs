using System;
using System.ComponentModel.DataAnnotations;

namespace EPS.Entities
{
    public class Rol
    {
        [Key]
        public int Id { get; set; }
        
        [StringLength(50)]
        public string Nombre { get; set; }
        
        [StringLength(200)]
        public string Descripcion { get; set; }
    }
}
