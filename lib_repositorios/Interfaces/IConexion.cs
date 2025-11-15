// Interfaz para la conexión a la base de datos
// Define los DbSets y métodos necesarios para acceso a datos
using lib_dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace lib_repositorios.Interfaces
{
    public interface IConexion
    {
        // Cadena de conexión a la base de datos
        string? StringConexion { get; set; }

        // DbSets para todas las entidades del dominio
        DbSet<Usuario>? Usuarios { get; set; }
        DbSet<Rol>? Roles { get; set; }
        DbSet<Afiliado>? Afiliados { get; set; }
        DbSet<AfiliadoDetalle>? AfiliadoDetalles { get; set; }
        DbSet<Contrato>? Contratos { get; set; }
        DbSet<PlanEPS>? PlanesEPS { get; set; }
        DbSet<Cita>? Citas { get; set; }
        DbSet<HistoriaMedica>? HistoriasMedicas { get; set; }
        DbSet<Departamento>? Departamentos { get; set; }
        DbSet<Municipio>? Municipios { get; set; }
        DbSet<Factura>? Facturas { get; set; }
        DbSet<Pago>? Pagos { get; set; }
        DbSet<Indicador>? Indicadores { get; set; }
        DbSet<Reporte>? Reportes { get; set; }
        DbSet<Categoria>? Categorias { get; set; }

        // Método para obtener el EntityEntry de una entidad
        EntityEntry<T> Entry<T>(T entity) where T : class;
        
        // Método para guardar cambios en la base de datos
        int SaveChanges();
    }
}

