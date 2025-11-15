using System.ComponentModel.DataAnnotations;

namespace lib_dominio.Entidades
{
    public class Afiliado
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;
        
        [Required]
        [StringLength(20)]
        [RegularExpression("^[A-Za-z0-9_-]+$")]
        public string Documento { get; set; } = string.Empty;
        
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime FechaNacimiento { get; set; }
        
        [StringLength(15)]
        public string? Telefono { get; set; }
        
        [StringLength(200)]
        public string? Direccion { get; set; }
        
        public int MunicipioId { get; set; }
        public virtual Municipio? Municipio { get; set; }
        
        public bool Activo { get; set; } = true;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        
        public virtual ICollection<Contrato> Contratos { get; set; } = new List<Contrato>();
        public virtual ICollection<Cita> Citas { get; set; } = new List<Cita>();
    }
}
