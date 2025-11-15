// Punto de entrada principal de la aplicación API
// Inicializa y configura la aplicación ASP.NET Core
using asp_servicios;

// Crea el constructor de la aplicación web
var builder = WebApplication.CreateBuilder(args);

// Crea una instancia de Startup con la configuración
var startup = new Startup(builder.Configuration);

// Configura los servicios de la aplicación
startup.ConfigureServices(builder, builder.Services);

// Construye la aplicación
var app = builder.Build();

// Configura el pipeline HTTP de la aplicación
startup.Configure(app, app.Environment);

// Ejecuta la aplicación
app.Run();
