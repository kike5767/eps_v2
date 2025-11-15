// Sistema de guardado automático
// Se ejecuta automáticamente antes de salir del programa
// Graba todos los cambios y actualiza GitHub
using System.Diagnostics;

namespace lib_dominio.Nucleo
{
    // Clase estática para manejar el guardado automático
    public static class GuardadoAutomatico
    {
        // Ruta del directorio del proyecto
        private static string RutaProyecto = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..");

        // Ejecuta el guardado automático completo
        // Incluye: backup, guardado de cambios y actualización de GitHub
        public static void EjecutarGuardadoAutomatico()
        {
            try
            {
                // 1. Genera backup completo
                string rutaBackup = SistemaBackup.GenerarBackupCompleto();
                
                // 2. Genera backup de datos generales
                var datosGenerales = new Dictionary<string, object>
                {
                    ["FechaGuardado"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    ["TipoOperacion"] = "GuardadoAutomatico",
                    ["BackupGenerado"] = rutaBackup
                };
                SistemaBackup.GenerarBackupDatosGenerales(datosGenerales);
                
                // 3. Actualiza GitHub
                ActualizarGitHub();
                
                // 4. Graba en log de auditoría
                AuditoriaLogicaNegocio.GrabarOperacion("GUARDADO_AUTOMATICO", "Sistema", null, JsonConversor.ConvertirAString(datosGenerales), "OK", "Guardado automático completado exitosamente");
            }
            catch (Exception ex)
            {
                // Graba el error en el log
                AuditoriaLogicaNegocio.GrabarError("Sistema", "GuardadoAutomatico", ex.Message, null);
                throw;
            }
        }

        // Actualiza el repositorio en GitHub
        // Ejecuta: git add, commit y push
        private static void ActualizarGitHub()
        {
            try
            {
                // Verifica que sea un repositorio Git
                if (!Directory.Exists(Path.Combine(RutaProyecto, ".git")))
                {
                    throw new Exception("No es un repositorio Git");
                }

                // Ejecuta git add .
                EjecutarComandoGit("add .");
                
                // Ejecuta git commit
                string mensajeCommit = $"Guardado automático: {DateTime.Now:yyyy-MM-dd HH:mm:ss}";
                EjecutarComandoGit($"commit -m \"{mensajeCommit}\"");
                
                // Ejecuta git push
                EjecutarComandoGit("push origin main");
            }
            catch (Exception ex)
            {
                // Graba el error pero no lanza excepción para no interrumpir el guardado
                AuditoriaLogicaNegocio.GrabarError("Sistema", "ActualizarGitHub", ex.Message, null);
            }
        }

        // Ejecuta un comando Git
        // comando: Comando Git a ejecutar (sin "git")
        private static void EjecutarComandoGit(string comando)
        {
            try
            {
                var proceso = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "git",
                        Arguments = comando,
                        WorkingDirectory = RutaProyecto,
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
                    throw new Exception($"Error en comando Git '{comando}': {error}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al ejecutar comando Git: {ex.Message}", ex);
            }
        }

        // Registra el evento de cierre de aplicación
        // Se debe llamar desde el evento de cierre de la aplicación
        public static void RegistrarCierreAplicacion()
        {
            try
            {
                // Ejecuta el guardado automático antes de cerrar
                EjecutarGuardadoAutomatico();
            }
            catch
            {
                // Si hay error, se ignora para permitir el cierre
            }
        }
    }
}

