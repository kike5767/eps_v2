using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPS.Entities
{
    public class Indicador
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Valor { get; set; }
    }
}


