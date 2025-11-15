// Sistema de backup automático para datos y operaciones
// Genera backups en SQL Server y en archivos del proyecto
// Se ejecuta automáticamente antes de salir del programa
using lib_dominio.Nucleo;

namespace lib_dominio.Nucleo
{
    // Clase estática para manejar backups automáticos
    public static class SistemaBackup
    {
        // Ruta del directorio de backups
        // Se crea en la raíz del proyecto
        private static string RutaBackups = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "Backups_Automaticos");
        
        // Ruta del archivo general de datos
        private static string ArchivoGeneralDatos = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "Datos_Generales_EPS.json");

        // Asegura que el directorio de backups exista
        // Si no existe, lo crea automáticamente
        private static void AsegurarDirectorio()
        {
            // Verifica si el directorio existe
            if (!Directory.Exists(RutaBackups))
            {
                // Crea el directorio si no existe
                Directory.CreateDirectory(RutaBackups);
            }
        }

        // Genera un backup completo de todas las operaciones CRUD
        // Incluye todos los logs de auditoría del día
        // Retorna la ruta del archivo de backup generado
        public static string GenerarBackupCompleto()
        {
            try
            {
                // Asegura que el directorio exista
                AsegurarDirectorio();
                
                // Crea el nombre del archivo de backup con fecha y hora
                // Formato: Backup_Completo_YYYYMMDD_HHMMSS.json
                string nombreBackup = $"Backup_Completo_{DateTime.Now:yyyyMMdd_HHmmss}.json";
                string rutaBackup = Path.Combine(RutaBackups, nombreBackup);
                
                // Crea un objeto con toda la información del backup
                var backupData = new Dictionary<string, object>
                {
                    ["FechaBackup"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    ["TipoBackup"] = "Completo",
                    ["OperacionesCRUD"] = ObtenerOperacionesDelDia(),
                    ["Validaciones"] = ObtenerValidacionesDelDia(),
                    ["Errores"] = ObtenerErroresDelDia()
                };
                
                // Convierte a JSON y guarda
                string jsonBackup = JsonConversor.ConvertirAString(backupData, true);
                File.WriteAllText(rutaBackup, jsonBackup);
                
                // Graba en el log de auditoría
                AuditoriaLogicaNegocio.GrabarOperacion("BACKUP", "Sistema", null, jsonBackup, "OK", $"Backup completo generado: {nombreBackup}");
                
                return rutaBackup;
            }
            catch (Exception ex)
            {
                // Si hay error, intenta grabar en log de errores
                try
                {
                    string errorLog = Path.Combine(RutaBackups, "Error_Backup.log");
                    File.AppendAllText(errorLog, $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Error al generar backup: {ex.Message}" + Environment.NewLine);
                }
                catch { }
                throw;
            }
        }

        // Genera backup de datos generales
        // Crea un archivo JSON con todos los datos importantes
        public static void GenerarBackupDatosGenerales(Dictionary<string, object> datos)
        {
            try
            {
                // Asegura que el directorio exista
                AsegurarDirectorio();
                
                // Agrega metadatos al backup
                datos["FechaBackup"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                datos["TipoBackup"] = "DatosGenerales";
                
                // Convierte a JSON y guarda
                string jsonDatos = JsonConversor.ConvertirAString(datos, true);
                File.WriteAllText(ArchivoGeneralDatos, jsonDatos);
                
                // También guarda una copia en el directorio de backups
                string nombreBackup = $"Datos_Generales_{DateTime.Now:yyyyMMdd_HHmmss}.json";
                string rutaBackup = Path.Combine(RutaBackups, nombreBackup);
                File.WriteAllText(rutaBackup, jsonDatos);
                
                // Graba en el log de auditoría
                AuditoriaLogicaNegocio.GrabarOperacion("BACKUP", "DatosGenerales", null, jsonDatos, "OK", $"Backup de datos generales generado");
            }
            catch (Exception ex)
            {
                // Manejo de errores silencioso
                try
                {
                    string errorLog = Path.Combine(RutaBackups, "Error_Backup.log");
                    File.AppendAllText(errorLog, $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Error al generar backup de datos: {ex.Message}" + Environment.NewLine);
                }
                catch { }
            }
        }

        // Obtiene todas las operaciones CRUD del día actual
        // Retorna lista de operaciones desde los logs
        private static List<string> ObtenerOperacionesDelDia()
        {
            // Usa el método de AuditoriaLogicaNegocio para obtener logs
            return AuditoriaLogicaNegocio.ObtenerLogsDelDia();
        }

        // Obtiene todas las validaciones del día actual
        // Retorna lista de validaciones desde los logs
        private static List<string> ObtenerValidacionesDelDia()
        {
            try
            {
                string logDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "Logs_Auditoria_CRUD");
                string nombreArchivo = $"Validaciones_{DateTime.Now:yyyyMMdd}.log";
                string rutaCompleta = Path.Combine(logDir, nombreArchivo);
                
                if (File.Exists(rutaCompleta))
                {
                    return File.ReadAllLines(rutaCompleta).ToList();
                }
            }
            catch { }
            
            return new List<string>();
        }

        // Obtiene todos los errores del día actual
        // Retorna lista de errores desde los logs
        private static List<string> ObtenerErroresDelDia()
        {
            try
            {
                string logDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "Logs_Auditoria_CRUD");
                string nombreArchivo = $"Errores_{DateTime.Now:yyyyMMdd}.log";
                string rutaCompleta = Path.Combine(logDir, nombreArchivo);
                
                if (File.Exists(rutaCompleta))
                {
                    return File.ReadAllLines(rutaCompleta).ToList();
                }
            }
            catch { }
            
            return new List<string>();
        }

        // Genera script SQL de backup para SQL Server
        // Retorna el contenido del script SQL
        public static string GenerarScriptSQLBackup()
        {
            // Script SQL para hacer backup de la base de datos
            string script = $@"
-- Backup automático de EPSDB
-- Generado el: {DateTime.Now:yyyy-MM-dd HH:mm:ss}

USE [master];
GO

-- Backup completo de la base de datos
BACKUP DATABASE [EPSDB]
TO DISK = 'C:\EPS_V2_FINAL\Backups_Automaticos\EPSDB_Backup_{DateTime.Now:yyyyMMdd_HHmmss}.bak'
WITH FORMAT, INIT, NAME = 'EPSDB-Full Database Backup', SKIP, NOREWIND, NOUNLOAD, STATS = 10;
GO

PRINT 'Backup completado exitosamente';
GO
";
            return script;
        }

        // Guarda el script SQL de backup en un archivo
        public static void GuardarScriptSQLBackup()
        {
            try
            {
                // Asegura que el directorio exista
                AsegurarDirectorio();
                
                // Genera el script SQL
                string script = GenerarScriptSQLBackup();
                
                // Guarda el script en un archivo
                string nombreScript = $"Backup_SQL_{DateTime.Now:yyyyMMdd_HHmmss}.sql";
                string rutaScript = Path.Combine(RutaBackups, nombreScript);
                File.WriteAllText(rutaScript, script);
            }
            catch (Exception ex)
            {
                // Manejo de errores silencioso
                try
                {
                    string errorLog = Path.Combine(RutaBackups, "Error_Backup.log");
                    File.AppendAllText(errorLog, $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Error al guardar script SQL: {ex.Message}" + Environment.NewLine);
                }
                catch { }
            }
        }
    }
}

