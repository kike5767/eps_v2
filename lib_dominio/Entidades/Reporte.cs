using System.ComponentModel.DataAnnotations;

namespace lib_dominio.Entidades
{
    public class Reporte
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Descripcion { get; set; } = string.Empty;
        
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }
        
        [StringLength(50)]
        public string? Tipo { get; set; }
        
        [StringLength(1000)]
        public string? Contenido { get; set; }
        
        [StringLength(50)]
        public string? GeneradoPor { get; set; }
        
        [StringLength(50)]
        public string Estado { get; set; } = "Generado";
        
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}
