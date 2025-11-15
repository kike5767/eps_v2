using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Indicador
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;
        
        [Column(TypeName = "decimal(18,2)")]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Valor { get; set; }
        
        [StringLength(200)]
        public string? Descripcion { get; set; }
        
        [StringLength(50)]
        public string? Unidad { get; set; }
        
        [StringLength(50)]
        public string? Categoria { get; set; }
        
        public DateTime FechaActualizacion { get; set; } = DateTime.Now;
        public bool Activo { get; set; } = true;
    }
}
