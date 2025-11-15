using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Pago
    {
        [Key]
        public int Id { get; set; }
        
        [Range(1, int.MaxValue)]
        public int ContratoId { get; set; }
        public virtual Contrato? Contrato { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Valor { get; set; }
        
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }
        
        [StringLength(50)]
        public string? MetodoPago { get; set; }
        
        [StringLength(100)]
        public string? Referencia { get; set; }
        
        [StringLength(50)]
        public string Estado { get; set; } = "Pendiente";
        
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        
        public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();
    }
}
