// Clase para auditoría y logging de operaciones CRUD
// Graba todos los cambios, modificaciones y validaciones en archivos
// Utilizada para rastrear todas las operaciones del sistema
using lib_dominio.Entidades;
using lib_dominio.Nucleo;

namespace lib_dominio.Nucleo
{
    // Clase estática para manejar la auditoría de lógica de negocio
    public static class AuditoriaLogicaNegocio
    {
        // Ruta del directorio donde se guardan los logs de auditoría
        // Se crea en la raíz del proyecto
        private static string RutaLogs = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "Logs_Auditoria_CRUD");
        
        // Asegura que el directorio de logs exista
        // Si no existe, lo crea automáticamente
        private static void AsegurarDirectorio()
        {
            // Verifica si el directorio existe
            if (!Directory.Exists(RutaLogs))
            {
                // Crea el directorio si no existe
                Directory.CreateDirectory(RutaLogs);
            }
        }

        // Graba una operación CRUD en el archivo de log
        // operacion: Tipo de operación (CREATE, READ, UPDATE, DELETE)
        // entidad: Nombre de la entidad (ej: "Afiliado")
        // datosAntes: Datos antes de la operación (null para CREATE)
        // datosDespues: Datos después de la operación (null para DELETE)
        // resultado: Resultado de la operación (OK, ERROR, etc.)
        // mensaje: Mensaje adicional o error
        public static void GrabarOperacion(string operacion, string entidad, string? datosAntes, string? datosDespues, string resultado, string? mensaje = null)
        {
            try
            {
                // Asegura que el directorio exista
                AsegurarDirectorio();
                
                // Crea el nombre del archivo con fecha
                // Formato: Auditoria_CRUD_YYYYMMDD.log
                string nombreArchivo = $"Auditoria_CRUD_{DateTime.Now:yyyyMMdd}.log";
                string rutaCompleta = Path.Combine(RutaLogs, nombreArchivo);
                
                // Crea la línea de log con toda la información
                string lineaLog = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] " +
                                 $"[{operacion}] " +
                                 $"[{entidad}] " +
                                 $"[{resultado}] " +
                                 $"Antes: {(datosAntes ?? "N/A")} | " +
                                 $"Después: {(datosDespues ?? "N/A")} | " +
                                 $"Mensaje: {(mensaje ?? "OK")}";
                
                // Agrega la línea al archivo (append)
                File.AppendAllText(rutaCompleta, lineaLog + Environment.NewLine);
            }
            catch (Exception ex)
            {
                // Si hay error al grabar, intenta grabar en un archivo de error
                try
                {
                    string errorLog = Path.Combine(RutaLogs, "Error_Auditoria.log");
                    File.AppendAllText(errorLog, $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Error al grabar auditoría: {ex.Message}" + Environment.NewLine);
                }
                catch
                {
                    // Si no se puede grabar el error, se ignora para no interrumpir la operación
                }
            }
        }

        // Graba una validación de negocio
        // entidad: Nombre de la entidad
        // validacion: Tipo de validación realizada
        // resultado: Si pasó o falló
        // detalle: Detalle de la validación
        public static void GrabarValidacion(string entidad, string validacion, bool resultado, string detalle)
        {
            try
            {
                // Asegura que el directorio exista
                AsegurarDirectorio();
                
                // Crea el nombre del archivo con fecha
                string nombreArchivo = $"Validaciones_{DateTime.Now:yyyyMMdd}.log";
                string rutaCompleta = Path.Combine(RutaLogs, nombreArchivo);
                
                // Crea la línea de log
                string lineaLog = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] " +
                                 $"[{entidad}] " +
                                 $"[{validacion}] " +
                                 $"[{(resultado ? "PASO" : "FALLO")}] " +
                                 $"Detalle: {detalle}";
                
                // Agrega la línea al archivo
                File.AppendAllText(rutaCompleta, lineaLog + Environment.NewLine);
            }
            catch (Exception ex)
            {
                // Manejo de errores silencioso
                try
                {
                    string errorLog = Path.Combine(RutaLogs, "Error_Auditoria.log");
                    File.AppendAllText(errorLog, $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Error al grabar validación: {ex.Message}" + Environment.NewLine);
                }
                catch { }
            }
        }

        // Graba un error de lógica de negocio
        // entidad: Nombre de la entidad
        // operacion: Operación que falló
        // error: Mensaje de error
        // datos: Datos relacionados al error
        public static void GrabarError(string entidad, string operacion, string error, string? datos = null)
        {
            try
            {
                // Asegura que el directorio exista
                AsegurarDirectorio();
                
                // Crea el nombre del archivo con fecha
                string nombreArchivo = $"Errores_{DateTime.Now:yyyyMMdd}.log";
                string rutaCompleta = Path.Combine(RutaLogs, nombreArchivo);
                
                // Crea la línea de log de error
                string lineaLog = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] " +
                                 $"[ERROR] " +
                                 $"[{entidad}] " +
                                 $"[{operacion}] " +
                                 $"Error: {error} | " +
                                 $"Datos: {(datos ?? "N/A")}";
                
                // Agrega la línea al archivo
                File.AppendAllText(rutaCompleta, lineaLog + Environment.NewLine);
            }
            catch
            {
                // Manejo de errores silencioso
            }
        }

        // Obtiene todas las operaciones de un día específico
        // fecha: Fecha de la que se quieren obtener los logs (null = hoy)
        // Retorna lista de líneas de log
        public static List<string> ObtenerLogsDelDia(DateTime? fecha = null)
        {
            // Usa la fecha proporcionada o la fecha actual
            DateTime fechaBusqueda = fecha ?? DateTime.Now;
            
            // Crea el nombre del archivo
            string nombreArchivo = $"Auditoria_CRUD_{fechaBusqueda:yyyyMMdd}.log";
            string rutaCompleta = Path.Combine(RutaLogs, nombreArchivo);
            
            // Si el archivo existe, lee todas las líneas
            if (File.Exists(rutaCompleta))
            {
                return File.ReadAllLines(rutaCompleta).ToList();
            }
            
            // Si no existe, retorna lista vacía
            return new List<string>();
        }
    }
}

