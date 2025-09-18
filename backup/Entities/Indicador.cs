using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPS.Entities
{
    public class Indicador
    {
        [Key]
        public int Id { get; set; }
        
        [StringLength(50)]
        public string Nombre { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }
    }
}


