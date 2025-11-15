// Clase para almacenar datos generales de configuración del sistema
// Define rutas, claves y configuraciones globales
namespace lib_dominio.Nucleo
{
    public class DatosGenerales
    {
        // Ruta del archivo secrets.json que contiene la cadena de conexión
        // Se busca en la raíz del proyecto
        public static string ruta_json = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "secrets.json");
        
        // Indica si se usa Azure (para futuras implementaciones)
        public static bool usa_azure = false;
        
        // Clave de encriptación para datos sensibles
        public static string clave = "EVBgi345936456ghhVBJGtgnifytsidi3456678jhgUTytutyiiyi";
        
        // Usuario de datos encriptado (ejemplo)
        public static string usuario_datos = EncriptarConversor.Encriptar("Test.Trghhjsgdj");
    }
}

