// Clase de configuración e inicio de la aplicación API
// Configura servicios, controladores, CORS y el pipeline de la aplicación
using asp_servicios.Controllers;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace asp_servicios
{
    public class Startup
    {
        // Constructor que recibe la configuración de la aplicación
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // Propiedad estática para acceder a la configuración
        public static IConfiguration? Configuration { set; get; }

        // Configura los servicios de la aplicación
        // builder: constructor de la aplicación web
        // services: colección de servicios para inyección de dependencias
        public void ConfigureServices(WebApplicationBuilder builder, IServiceCollection services)
        {
            // Permite operaciones síncronas de I/O (necesario para algunos casos)
            services.Configure<KestrelServerOptions>(x => {
                x.AllowSynchronousIO = true;
            });
            services.Configure<IISServerOptions>(x => { x.AllowSynchronousIO = true; });
            
            // Agrega controladores de la API
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            // Swagger deshabilitado por ahora (se puede habilitar si se necesita)
            //services.AddSwaggerGen();

            // Registro de repositorios e interfaces para inyección de dependencias
            services.AddScoped<IConexion, Conexion>();
            
            // Aplicaciones de cada entidad
            services.AddScoped<IAfiliadosAplicacion, AfiliadosAplicacion>();
            
            // Servicio de tokens
            services.AddScoped<TokenAplicacion, TokenAplicacion>();
            
            // Controlador de tokens
            services.AddScoped<TokenController, TokenController>();
            
            // Configuración de CORS para permitir peticiones desde cualquier origen
            services.AddCors(o => o.AddDefaultPolicy(b => b.AllowAnyOrigin()));
        }

        // Configura el pipeline de la aplicación HTTP
        // app: aplicación web construida
        // env: entorno de ejecución (Development, Production, etc.)
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            // En desarrollo se puede habilitar Swagger
            if (env.IsDevelopment())
            {
                //app.UseSwagger();
                //app.UseSwaggerUI();
            }
            
            // Redirección HTTPS
            app.UseHttpsRedirection();
            
            // Autorización
            app.UseAuthorization();
            
            // Mapeo de controladores
            app.MapControllers();
            
            // CORS
            app.UseCors();
            
            // Routing
            app.UseRouting();
            
            // Ejecuta la aplicación
            app.Run();
        }
    }
}

