using System.ComponentModel.DataAnnotations;

namespace lib_dominio.Entidades
{
    public class Factura
    {
        [Key]
        public int Id { get; set; }
        
        [Range(1, int.MaxValue)]
        public int PagoId { get; set; }
        public virtual Pago? Pago { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Numero { get; set; } = string.Empty;
        
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }
        
        [StringLength(500)]
        public string? Descripcion { get; set; }
        
        public decimal Subtotal { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Total { get; set; }
        
        [StringLength(50)]
        public string Estado { get; set; } = "Generada";
        
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}
