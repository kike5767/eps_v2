// Página Razor para opciones de salida del sistema
// Permite grabar local, nube, o ambos, y subir a servidor gratuito
using lib_dominio.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace asp_presentacion.Pages
{
    public class OpcionesSalidaModel : PageModel
    {
        // Método GET: carga la página
        public void OnGet()
        {
        }

        // Método POST: grabar solo local
        public IActionResult OnPostGrabarLocal()
        {
            try
            {
                // Genera backup local
                string rutaBackup = SistemaBackup.GenerarBackupCompleto();
                SistemaBackup.GenerarBackupDatosGenerales(new Dictionary<string, object>
                {
                    ["Tipo"] = "GrabadoLocal",
                    ["Fecha"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                });

                TempData["Success"] = $"✅ Grabado local completado exitosamente. Backup: {Path.GetFileName(rutaBackup)}";
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"❌ Error al grabar local: {ex.Message}";
            }

            return Page();
        }

        // Método POST: grabar solo nube
        public IActionResult OnPostGrabarNube()
        {
            try
            {
                // Actualiza GitHub
                EjecutarGitComandos();

                TempData["Success"] = "✅ Grabado en la nube (GitHub) completado exitosamente.";
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"❌ Error al grabar en la nube: {ex.Message}";
            }

            return Page();
        }

        // Método POST: grabar local y nube
        public IActionResult OnPostGrabarLocalYNube()
        {
            try
            {
                // Graba local
                string rutaBackup = SistemaBackup.GenerarBackupCompleto();
                SistemaBackup.GenerarBackupDatosGenerales(new Dictionary<string, object>
                {
                    ["Tipo"] = "GrabadoLocalYNube",
                    ["Fecha"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                });

                // Graba en nube
                EjecutarGitComandos();

                TempData["Success"] = $"✅ Grabado local y nube completado exitosamente. Backup: {Path.GetFileName(rutaBackup)}";
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"❌ Error al grabar: {ex.Message}";
            }

            return Page();
        }

        // Método POST: subir a servidor gratuito
        public IActionResult OnPostSubirServidorGratuito()
        {
            try
            {
                // Primero actualiza GitHub
                EjecutarGitComandos();

                // Genera información de deploy
                var infoDeploy = new Dictionary<string, object>
                {
                    ["Fecha"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    ["Tipo"] = "ServidorGratuito",
                    ["Servicios"] = new[] { "Netlify", "Vercel", "GitHub Pages", "Render" },
                    ["Instrucciones"] = "El proyecto está listo para deploy en cualquier servidor gratuito"
                };

                SistemaBackup.GenerarBackupDatosGenerales(infoDeploy);

                TempData["Success"] = "✅ Proyecto actualizado en GitHub. Listo para deploy en servidores gratuitos. " +
                    "Visita: https://github.com/kike5767/eps_v2 para configurar el deploy automático.";
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"❌ Error al subir a servidor: {ex.Message}";
            }

            return Page();
        }

        // Ejecuta comandos Git para actualizar GitHub
        private void EjecutarGitComandos()
        {
            string rutaProyecto = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..");

            // Git add
            EjecutarComando("git", "add .", rutaProyecto);

            // Git commit
            EjecutarComando("git", $"commit -m \"Actualización automática: {DateTime.Now:yyyy-MM-dd HH:mm:ss}\"", rutaProyecto);

            // Git push
            EjecutarComando("git", "push origin main", rutaProyecto);
        }

        // Ejecuta un comando del sistema
        private void EjecutarComando(string comando, string argumentos, string directorio)
        {
            var proceso = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = comando,
                    Arguments = argumentos,
                    WorkingDirectory = directorio,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };

            proceso.Start();
            proceso.WaitForExit();

            if (proceso.ExitCode != 0)
            {
                string error = proceso.StandardError.ReadToEnd();
                throw new Exception($"Error en comando '{comando} {argumentos}': {error}");
            }
        }
    }
}

