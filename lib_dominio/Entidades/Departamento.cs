using System.ComponentModel.DataAnnotations;

namespace lib_dominio.Entidades
{
    public class Departamento
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;
        
        [StringLength(10)]
        public string? Codigo { get; set; }
        
        public bool Activo { get; set; } = true;
        
        public virtual ICollection<Municipio> Municipios { get; set; } = new List<Municipio>();
    }
}
