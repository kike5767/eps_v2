// Página Razor para gestión de backups y sincronización con GitHub
// Permite generar backups y actualizar GitHub automáticamente
using lib_dominio.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_presentacion.Pages
{
    public class BackupModel : PageModel
    {
        // Lista de backups disponibles
        public List<BackupInfo> Backups { get; set; } = new List<BackupInfo>();

        // Clase para información de backup
        public class BackupInfo
        {
            public string Nombre { get; set; } = string.Empty;
            public string Fecha { get; set; } = string.Empty;
            public string Tamaño { get; set; } = string.Empty;
            public string Ruta { get; set; } = string.Empty;
        }

        // Método GET: carga la lista de backups
        public void OnGet()
        {
            // Carga la lista de backups disponibles
            CargarBackups();
        }

        // Método POST: genera backup completo
        public IActionResult OnPostBackupCompleto()
        {
            try
            {
                // Genera el backup completo
                string rutaBackup = SistemaBackup.GenerarBackupCompleto();
                
                TempData["Success"] = $"Backup completo generado exitosamente: {Path.GetFileName(rutaBackup)}";
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error al generar backup: {ex.Message}";
            }
            
            CargarBackups();
            return Page();
        }

        // Método POST: genera script SQL de backup
        public IActionResult OnPostBackupSQL()
        {
            try
            {
                // Genera y guarda el script SQL
                SistemaBackup.GuardarScriptSQLBackup();
                
                TempData["Success"] = "Script SQL de backup generado exitosamente";
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error al generar script SQL: {ex.Message}";
            }
            
            CargarBackups();
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
                    ["TotalAfiliados"] = 0, // Se puede obtener de la BD
                    ["TotalContratos"] = 0,
                    ["TotalCitas"] = 0,
                    ["FechaGeneracion"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                };
                
                // Genera el backup
                SistemaBackup.GenerarBackupDatosGenerales(datosGenerales);
                
                TempData["Success"] = "Backup de datos generales generado exitosamente";
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error al generar backup de datos: {ex.Message}";
            }
            
            CargarBackups();
            return Page();
        }

        // Método POST: sincroniza con GitHub
        public async Task<IActionResult> OnPostSincronizarGitHub()
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

                TempData["Success"] = "Sincronización con GitHub completada exitosamente";
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error al sincronizar con GitHub: {ex.Message}";
            }
            
            CargarBackups();
            return Page();
        }

        // Carga la lista de backups disponibles
        private void CargarBackups()
        {
            try
            {
                string rutaBackups = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "Backups_Automaticos");
                
                if (Directory.Exists(rutaBackups))
                {
                    var archivos = Directory.GetFiles(rutaBackups, "*.*")
                        .Where(f => !f.EndsWith(".log"))
                        .OrderByDescending(f => System.IO.File.GetCreationTime(f))
                        .Take(10);
                    
                    foreach (var archivo in archivos)
                    {
                        var info = new FileInfo(archivo);
                        Backups.Add(new BackupInfo
                        {
                            Nombre = info.Name,
                            Fecha = info.CreationTime.ToString("yyyy-MM-dd HH:mm:ss"),
                            Tamaño = $"{info.Length / 1024.0:F2} KB",
                            Ruta = archivo
                        });
                    }
                }
            }
            catch
            {
                // Si hay error, deja la lista vacía
            }
        }
    }
}

