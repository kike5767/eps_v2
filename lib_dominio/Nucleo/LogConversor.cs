// Clase para manejo de logs y registro de eventos
// Permite registrar información, errores y advertencias del sistema
using System.IO;

namespace lib_dominio.Nucleo
{
    public class LogConversor
    {
        // Ruta del archivo de log
        private static string rutaLog = @"C:\EPS_V2_FINAL\logs\";

        // Registra un mensaje en el archivo de log
        // tipo: tipo de log (Info, Error, Warning)
        // mensaje: mensaje a registrar
        public static void Registrar(string tipo, string mensaje)
        {
            try
            {
                // Crea el directorio si no existe
                if (!Directory.Exists(rutaLog))
                    Directory.CreateDirectory(rutaLog);

                // Nombre del archivo con fecha actual
                string archivo = Path.Combine(rutaLog, $"log_{DateTime.Now:yyyyMMdd}.txt");
                
                // Formato del mensaje: [Fecha] [Tipo] Mensaje
                string logMensaje = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{tipo}] {mensaje}{Environment.NewLine}";
                
                // Escribe en el archivo
                File.AppendAllText(archivo, logMensaje);
            }
            catch
            {
                // Si falla el registro, no interrumpe la ejecución
            }
        }

        // Registra un error con excepción
        public static void RegistrarError(string mensaje, Exception ex)
        {
            Registrar("ERROR", $"{mensaje} - {ex.Message} - {ex.StackTrace}");
        }

        // Registra información general
        public static void RegistrarInfo(string mensaje)
        {
            Registrar("INFO", mensaje);
        }

        // Registra una advertencia
        public static void RegistrarWarning(string mensaje)
        {
            Registrar("WARNING", mensaje);
        }
    }
}

