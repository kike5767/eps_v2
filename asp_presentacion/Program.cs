// Punto de entrada principal de la aplicación de presentación
// Configura servicios y el pipeline HTTP para Razor Pages
using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;

// Crea el constructor de la aplicación web
var builder = WebApplication.CreateBuilder(args);

// Agrega servicios de Razor Pages al contenedor de dependencias
builder.Services.AddRazorPages();

// Registra las interfaces de presentación para inyección de dependencias
// IAfiliadosPresentacion se resuelve con AfiliadosPresentacion
builder.Services.AddScoped<IAfiliadosPresentacion, AfiliadosPresentacion>();

// Construye la aplicación con todos los servicios configurados
var app = builder.Build();

// Configura el pipeline de procesamiento de peticiones HTTP
if (!app.Environment.IsDevelopment())
{
    // En producción, redirige errores a la página de error
    app.UseExceptionHandler("/Error");
    // HSTS (HTTP Strict Transport Security) por defecto 30 días
    app.UseHsts();
}

// Redirige peticiones HTTP a HTTPS
app.UseHttpsRedirection();

// Habilita el uso de archivos estáticos (CSS, JS, imágenes)
app.UseStaticFiles();

// Habilita el enrutamiento de peticiones
app.UseRouting();

// Habilita la autorización de usuarios
app.UseAuthorization();

// Mapea las páginas Razor a rutas
app.MapRazorPages();

// Ejecuta la aplicación
app.Run();
