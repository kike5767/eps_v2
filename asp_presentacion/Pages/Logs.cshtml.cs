// Página Razor para visualizar logs y auditoría
// Muestra los logs según el tipo seleccionado
using lib_dominio.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_presentacion.Pages
{
    public class LogsModel : PageModel
    {
        // Lista de logs a mostrar
        public List<LogInfo> Logs { get; set; } = new List<LogInfo>();

        // Clase para información de log
        public class LogInfo
        {
            public string Fecha { get; set; } = string.Empty;
            public string Operacion { get; set; } = string.Empty;
            public string Entidad { get; set; } = string.Empty;
            public string Resultado { get; set; } = string.Empty;
            public string Mensaje { get; set; } = string.Empty;
        }

        // Método GET: carga los logs según el tipo
        // tipo: Tipo de log (auditoria, validaciones, errores)
        public void OnGet(string? tipo = "auditoria")
        {
            // Carga los logs según el tipo
            CargarLogs(tipo ?? "auditoria");
        }

        // Carga los logs del tipo especificado
        private void CargarLogs(string tipo)
        {
            try
            {
                string logDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "Logs_Auditoria_CRUD");
                string nombreArchivo = "";
                
                // Selecciona el archivo según el tipo
                switch (tipo.ToLower())
                {
                    case "auditoria":
                        nombreArchivo = $"Auditoria_CRUD_{DateTime.Now:yyyyMMdd}.log";
                        break;
                    case "validaciones":
                        nombreArchivo = $"Validaciones_{DateTime.Now:yyyyMMdd}.log";
                        break;
                    case "errores":
                        nombreArchivo = $"Errores_{DateTime.Now:yyyyMMdd}.log";
                        break;
                    default:
                        nombreArchivo = $"Auditoria_CRUD_{DateTime.Now:yyyyMMdd}.log";
                        break;
                }
                
                string rutaCompleta = Path.Combine(logDir, nombreArchivo);
                
                if (System.IO.File.Exists(rutaCompleta))
                {
                    var lineas = System.IO.File.ReadAllLines(rutaCompleta);
                    
                    foreach (var linea in lineas.TakeLast(100)) // Últimas 100 líneas
                    {
                        // Parsea la línea del log
                        var logInfo = ParsearLineaLog(linea);
                        if (logInfo != null)
                        {
                            Logs.Add(logInfo);
                        }
                    }
                }
            }
            catch
            {
                // Si hay error, deja la lista vacía
            }
        }

        // Parsea una línea de log y extrae la información
        private LogInfo? ParsearLineaLog(string linea)
        {
            try
            {
                // Formato: [fecha] [operacion] [entidad] [resultado] ...
                var partes = linea.Split(']');
                
                if (partes.Length >= 4)
                {
                    var fecha = partes[0].TrimStart('[').Trim();
                    var operacion = partes[1].TrimStart('[').Trim();
                    var entidad = partes[2].TrimStart('[').Trim();
                    var resultado = partes[3].TrimStart('[').Trim();
                    
                    // Extrae el mensaje (después del resultado)
                    string mensaje = "";
                    if (partes.Length > 4)
                    {
                        mensaje = string.Join("]", partes.Skip(4)).Trim();
                    }
                    
                    return new LogInfo
                    {
                        Fecha = fecha,
                        Operacion = operacion,
                        Entidad = entidad,
                        Resultado = resultado,
                        Mensaje = mensaje
                    };
                }
            }
            catch { }
            
            return null;
        }
    }
}

