using System;
using System.ComponentModel.DataAnnotations;

namespace EPS.Entities
{
    public class Afiliado
    {
        [Key]
        public int Id { get; set; }
        
        [StringLength(50)]
        public string Nombre { get; set; }
        
        [StringLength(20)]
        public string Documento { get; set; }
        
        [StringLength(50)]
        public string Email { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime FechaNacimiento { get; set; }
    }
}


