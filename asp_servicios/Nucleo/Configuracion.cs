// Clase para cargar y obtener valores de configuración desde secrets.json
// Lee la cadena de conexión y otros parámetros del archivo de configuración
using lib_dominio.Nucleo;

namespace asp_servicios.Nucleo
{
    public class Configuracion
    {
        // Diccionario estático para almacenar los datos de configuración
        private static Dictionary<string, string>? datos = null;

        // Obtiene un valor de configuración por su clave
        // clave: nombre de la clave a buscar (ej: "StringConexion")
        // Retorna el valor asociado a la clave
        public static string ObtenerValor(string clave)
        {
            string respuesta = "";
            // Si los datos no están cargados, los carga primero
            if (datos == null)
                Cargar();
            respuesta = datos![clave].ToString();
            return respuesta;
        }

        // Carga los datos de configuración desde el archivo secrets.json
        // El archivo debe estar en la ruta definida en DatosGenerales.ruta_json
        public static void Cargar()
        {
            // Verifica si el archivo existe
            if (!File.Exists(DatosGenerales.ruta_json))
                return;
            
            // Lee el contenido del archivo JSON
            StreamReader jsonStream = File.OpenText(DatosGenerales.ruta_json);
            var json = jsonStream.ReadToEnd();
            
            // Convierte el JSON a un diccionario
            datos = JsonConversor.ConvertirAObjeto<Dictionary<string, string>>(json)!;
        }
    }
}

