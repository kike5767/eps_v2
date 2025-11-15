// Página Razor para menú principal con opciones numeradas
// Permite ejecutar procesos del sistema mediante números
using lib_dominio.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_presentacion.Pages
{
    public class MenuPrincipalModel : PageModel
    {
        // Propiedades para mostrar información del sistema
        public int TotalAfiliados { get; set; } = 0;
        public int TotalBackups { get; set; } = 0;
        public int TotalLogs { get; set; } = 0;
        public string UltimaActualizacion { get; set; } = "N/A";

        // Método GET: carga la página con información del sistema
        public void OnGet()
        {
            // Carga información del sistema
            CargarInformacionSistema();
        }

        // Método POST: ejecuta una opción del menú
        // opcion: Número de la opción seleccionada (1-99)
        public IActionResult OnPostEjecutarOpcion(int opcion)
        {
            try
            {
                // Ejecuta la opción correspondiente
                switch (opcion)
                {
                    case 1:
                        // Listar Afiliados
                        return RedirectToPage("/Afiliados");
                    
                    case 2:
                        // Nuevo Afiliado
                        return RedirectToPage("/Afiliados", "Nuevo");
                    
                    case 3:
                        // Buscar Afiliado
                        TempData["Info"] = "Funcionalidad de búsqueda en desarrollo";
                        return Page();
                    
                    case 4:
                        // Reportes de Afiliados
                        TempData["Info"] = "Funcionalidad de reportes en desarrollo";
                        return Page();
                    
                    case 5:
                        // Backup Completo
                        return OnPostBackupCompleto();
                    
                    case 6:
                        // Backup SQL Server
                        return OnPostBackupSQL();
                    
                    case 7:
                        // Datos Generales
                        return OnPostBackupDatosGenerales();
                    
                    case 8:
                        // Sincronizar GitHub
                        return OnPostSincronizarGitHub();
                    
                    case 9:
                        // Ver Logs de Auditoría
                        return RedirectToPage("/Logs", new { tipo = "auditoria" });
                    
                    case 10:
                        // Ver Validaciones
                        return RedirectToPage("/Logs", new { tipo = "validaciones" });
                    
                    case 11:
                        // Ver Errores
                        return RedirectToPage("/Logs", new { tipo = "errores" });
                    
                    case 12:
                        // Exportar Logs
                        TempData["Success"] = "Exportando logs...";
                        return Page();
                    
                    case 13:
                        // Configuración del Sistema
                        TempData["Info"] = "Funcionalidad de configuración en desarrollo";
                        return Page();
                    
                    case 14:
                        // Usuarios y Permisos
                        TempData["Info"] = "Funcionalidad de usuarios en desarrollo";
                        return Page();
                    
                    case 15:
                        // Base de Datos
                        TempData["Info"] = "Funcionalidad de base de datos en desarrollo";
                        return Page();
                    
                    case 16:
                        // Guardado Automático
                        return OnPostGuardadoAutomatico();
                    
                    default:
                        TempData["Error"] = $"Opción {opcion} no válida. Por favor seleccione una opción del 1 al 16.";
                        CargarInformacionSistema();
                        return Page();
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error al ejecutar opción {opcion}: {ex.Message}";
                CargarInformacionSistema();
                return Page();
            }
        }

        // Método POST: genera backup completo
        public IActionResult OnPostBackupCompleto()
        {
            try
            {
                // Genera el backup completo
                string rutaBackup = SistemaBackup.GenerarBackupCompleto();
                
                TempData["Success"] = $"✅ Backup completo generado exitosamente: {Path.GetFileName(rutaBackup)}";
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"❌ Error al generar backup: {ex.Message}";
            }
            
            CargarInformacionSistema();
            return Page();
        }

        // Método POST: genera script SQL de backup
        public IActionResult OnPostBackupSQL()
        {
            try
            {
                // Genera y guarda el script SQL
                SistemaBackup.GuardarScriptSQLBackup();
                
                TempData["Success"] = "✅ Script SQL de backup generado exitosamente";
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"❌ Error al generar script SQL: {ex.Message}";
            }
            
            CargarInformacionSistema();
            return Page();
        }

        // Método POST: genera backup de datos generales
        public IActionResult OnPostBackupDatosGenerales()
        {
            try
            {
                // Crea un diccionario con datos generales
                var datosGenerales = new Dictionary<string, object>
                {
                    ["TotalAfiliados"] = TotalAfiliados,
                    ["TotalBackups"] = TotalBackups,
                    ["TotalLogs"] = TotalLogs,
                    ["FechaGeneracion"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                };
                
                // Genera el backup
                SistemaBackup.GenerarBackupDatosGenerales(datosGenerales);
                
                TempData["Success"] = "✅ Backup de datos generales generado exitosamente";
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"❌ Error al generar backup de datos: {ex.Message}";
            }
            
            CargarInformacionSistema();
            return Page();
        }

        // Método POST: sincroniza con GitHub
        public IActionResult OnPostSincronizarGitHub()
        {
            try
            {
                // Primero genera backup completo antes de sincronizar
                SistemaBackup.GenerarBackupCompleto();
                
                // Ejecuta git add, commit y push
                var proceso = new System.Diagnostics.Process
                {
                    StartInfo = new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = "git",
                        Arguments = "add .",
                        WorkingDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", ".."),
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    }
                };
                proceso.Start();
                proceso.WaitForExit();

                // Commit
                proceso.StartInfo.Arguments = $"commit -m \"Backup automático y actualización: {DateTime.Now:yyyy-MM-dd HH:mm:ss}\"";
                proceso.Start();
                proceso.WaitForExit();

                // Push
                proceso.StartInfo.Arguments = "push origin main";
                proceso.Start();
                proceso.WaitForExit();

                TempData["Success"] = "✅ Sincronización con GitHub completada exitosamente";
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"❌ Error al sincronizar con GitHub: {ex.Message}";
            }
            
            CargarInformacionSistema();
            return Page();
        }

        // Método POST: ejecuta guardado automático
        public IActionResult OnPostGuardadoAutomatico()
        {
            try
            {
                // Ejecuta el guardado automático completo
                GuardadoAutomatico.EjecutarGuardadoAutomatico();
                
                TempData["Success"] = "✅ Guardado automático completado exitosamente. Todos los cambios han sido guardados y sincronizados.";
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"❌ Error en guardado automático: {ex.Message}";
            }
            
            CargarInformacionSistema();
            return Page();
        }

        // Carga información del sistema para mostrar en el panel
        private void CargarInformacionSistema()
        {
            try
            {
                // Cuenta backups
                string rutaBackups = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "Backups_Automaticos");
                if (Directory.Exists(rutaBackups))
                {
                    TotalBackups = Directory.GetFiles(rutaBackups, "*.*")
                        .Where(f => !f.EndsWith(".log"))
                        .Count();
                }

                // Cuenta logs del día
                string logDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "Logs_Auditoria_CRUD");
                string nombreArchivo = $"Auditoria_CRUD_{DateTime.Now:yyyyMMdd}.log";
                string rutaCompleta = Path.Combine(logDir, nombreArchivo);
                
                if (System.IO.File.Exists(rutaCompleta))
                {
                    TotalLogs = System.IO.File.ReadAllLines(rutaCompleta).Length;
                }

                // Obtiene última actualización
                if (Directory.Exists(rutaBackups))
                {
                    var archivos = Directory.GetFiles(rutaBackups, "*.*")
                        .Where(f => !f.EndsWith(".log"))
                        .OrderByDescending(f => System.IO.File.GetCreationTime(f))
                        .FirstOrDefault();
                    
                    if (archivos != null)
                    {
                        UltimaActualizacion = System.IO.File.GetCreationTime(archivos).ToString("HH:mm:ss");
                    }
                }
            }
            catch
            {
                // Si hay error, deja valores por defecto
            }
        }
    }
}

