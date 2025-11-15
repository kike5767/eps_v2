// Implementación de IConexion usando Entity Framework Core
// Proporciona acceso a todas las entidades de la base de datos EPSDB
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public partial class Conexion : DbContext, IConexion
    {
        // Propiedad para la cadena de conexión
        public string? StringConexion { get; set; }

        // Configuración de la conexión a SQL Server
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Usa SQL Server con la cadena de conexión proporcionada
            optionsBuilder.UseSqlServer(this.StringConexion!, p => { });
            
            // Desactiva el seguimiento de cambios para mejorar rendimiento
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        // DbSets para todas las entidades
        public DbSet<Usuario>? Usuarios { get; set; }
        public DbSet<Rol>? Roles { get; set; }
        public DbSet<Afiliado>? Afiliados { get; set; }
        public DbSet<AfiliadoDetalle>? AfiliadoDetalles { get; set; }
        public DbSet<Contrato>? Contratos { get; set; }
        public DbSet<PlanEPS>? PlanesEPS { get; set; }
        public DbSet<Cita>? Citas { get; set; }
        public DbSet<HistoriaMedica>? HistoriasMedicas { get; set; }
        public DbSet<Departamento>? Departamentos { get; set; }
        public DbSet<Municipio>? Municipios { get; set; }
        public DbSet<Factura>? Facturas { get; set; }
        public DbSet<Pago>? Pagos { get; set; }
        public DbSet<Indicador>? Indicadores { get; set; }
        public DbSet<Reporte>? Reportes { get; set; }
        public DbSet<Categoria>? Categorias { get; set; }

        // Configuración del modelo de datos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Configuración de relaciones entre entidades
            // Usuario - Rol
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Rol)
                .WithMany(r => r.Usuarios)
                .HasForeignKey(u => u.RolId)
                .OnDelete(DeleteBehavior.Restrict);

            // Afiliado - Municipio
            modelBuilder.Entity<Afiliado>()
                .HasOne(a => a.Municipio)
                .WithMany(m => m.Afiliados)
                .HasForeignKey(a => a.MunicipioId)
                .OnDelete(DeleteBehavior.Restrict);

            // Municipio - Departamento
            modelBuilder.Entity<Municipio>()
                .HasOne(m => m.Departamento)
                .WithMany(d => d.Municipios)
                .HasForeignKey(m => m.DepartamentoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Contrato - Afiliado
            modelBuilder.Entity<Contrato>()
                .HasOne(c => c.Afiliado)
                .WithMany(a => a.Contratos)
                .HasForeignKey(c => c.AfiliadoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Contrato - PlanEPS
            modelBuilder.Entity<Contrato>()
                .HasOne(c => c.PlanEPS)
                .WithMany(p => p.Contratos)
                .HasForeignKey(c => c.PlanEPSId)
                .OnDelete(DeleteBehavior.Restrict);

            // Cita - Afiliado
            modelBuilder.Entity<Cita>()
                .HasOne(c => c.Afiliado)
                .WithMany(a => a.Citas)
                .HasForeignKey(c => c.AfiliadoId)
                .OnDelete(DeleteBehavior.Restrict);

            // HistoriaMedica - Afiliado
            modelBuilder.Entity<HistoriaMedica>()
                .HasOne(h => h.Afiliado)
                .WithMany()
                .HasForeignKey(h => h.AfiliadoId)
                .OnDelete(DeleteBehavior.Restrict);

            // AfiliadoDetalle - Afiliado
            modelBuilder.Entity<AfiliadoDetalle>()
                .HasOne(ad => ad.Afiliado)
                .WithMany()
                .HasForeignKey(ad => ad.AfiliadoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Pago - Contrato
            modelBuilder.Entity<Pago>()
                .HasOne(p => p.Contrato)
                .WithMany()
                .HasForeignKey(p => p.ContratoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Factura - Pago
            modelBuilder.Entity<Factura>()
                .HasOne(f => f.Pago)
                .WithMany(p => p.Facturas)
                .HasForeignKey(f => f.PagoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuración de propiedades decimales
            modelBuilder.Entity<Pago>()
                .Property(p => p.Valor)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<PlanEPS>()
                .Property(p => p.Precio)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Factura>()
                .Property(f => f.Subtotal)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Factura>()
                .Property(f => f.Impuesto)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Factura>()
                .Property(f => f.Total)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Indicador>()
                .Property(i => i.Valor)
                .HasColumnType("decimal(18,2)");
        }
    }
}
