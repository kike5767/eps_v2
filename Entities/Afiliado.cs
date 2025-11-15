using System;
using System.ComponentModel.DataAnnotations;

namespace EPS.Entities
{
    public class Afiliado
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        
        [Required]
        [StringLength(20)]
        [RegularExpression("^[A-Za-z0-9_-]+$")]
        public string Documento { get; set; }
        
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime FechaNacimiento { get; set; }
    }
}


