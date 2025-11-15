using System.ComponentModel.DataAnnotations;

namespace lib_dominio.Entidades
{
    public class Municipio
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;
        
        [Range(1, int.MaxValue)]
        public int DepartamentoId { get; set; }
        public virtual Departamento? Departamento { get; set; }
        
        [Required]
        [StringLength(10)]
        public string Codigo { get; set; } = string.Empty;
        
        public bool Activo { get; set; } = true;
        
        public virtual ICollection<Afiliado> Afiliados { get; set; } = new List<Afiliado>();
    }
}
