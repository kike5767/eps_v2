// Implementación de la lógica de aplicación para Afiliados
// Contiene las operaciones CRUD y validaciones de negocio
// Graba todas las operaciones en archivos de auditoría
using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class AfiliadosAplicacion : IAfiliadosAplicacion
    {
        // Conexión a la base de datos
        private IConexion? IConexion = null;

        // Constructor que recibe la conexión por inyección de dependencias
        public AfiliadosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        // Configura la cadena de conexión
        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        // Valida las reglas de negocio de un afiliado
        // entidad: Afiliado a validar
        // operacion: Tipo de operación (Guardar, Modificar)
        // Retorna true si pasa todas las validaciones
        private bool ValidarLogicaNegocio(Afiliado? entidad, string operacion)
        {
            // Valida que la entidad no sea nula
            if (entidad == null)
            {
                // Graba el error de validación
                AuditoriaLogicaNegocio.GrabarError("Afiliado", operacion, "Entidad nula", null);
                throw new Exception("lbFaltaInformacion");
            }

            // Valida que el nombre no esté vacío
            if (string.IsNullOrWhiteSpace(entidad.Nombre))
            {
                // Graba la validación fallida
                AuditoriaLogicaNegocio.GrabarValidacion("Afiliado", "NombreRequerido", false, "El nombre es requerido");
                AuditoriaLogicaNegocio.GrabarError("Afiliado", operacion, "Nombre requerido", JsonConversor.ConvertirAString(entidad));
                throw new Exception("lbNombreRequerido");
            }

            // Valida que el documento no esté vacío
            if (string.IsNullOrWhiteSpace(entidad.Documento))
            {
                // Graba la validación fallida
                AuditoriaLogicaNegocio.GrabarValidacion("Afiliado", "DocumentoRequerido", false, "El documento es requerido");
                AuditoriaLogicaNegocio.GrabarError("Afiliado", operacion, "Documento requerido", JsonConversor.ConvertirAString(entidad));
                throw new Exception("lbDocumentoRequerido");
            }

            // Valida formato de email si se proporciona
            if (!string.IsNullOrWhiteSpace(entidad.Email))
            {
                // Valida formato básico de email
                if (!entidad.Email.Contains("@") || !entidad.Email.Contains("."))
                {
                    // Graba la validación fallida
                    AuditoriaLogicaNegocio.GrabarValidacion("Afiliado", "EmailInvalido", false, $"Email inválido: {entidad.Email}");
                    AuditoriaLogicaNegocio.GrabarError("Afiliado", operacion, "Email inválido", JsonConversor.ConvertirAString(entidad));
                    throw new Exception("lbEmailInvalido");
                }
            }

            // Valida que la fecha de nacimiento sea válida
            if (entidad.FechaNacimiento > DateTime.Now)
            {
                // Graba la validación fallida
                AuditoriaLogicaNegocio.GrabarValidacion("Afiliado", "FechaNacimientoInvalida", false, "La fecha de nacimiento no puede ser futura");
                AuditoriaLogicaNegocio.GrabarError("Afiliado", operacion, "Fecha de nacimiento inválida", JsonConversor.ConvertirAString(entidad));
                throw new Exception("lbFechaNacimientoInvalida");
            }

            // Valida que el municipio exista (si se proporciona)
            if (entidad.MunicipioId > 0)
            {
                // Verifica que el municipio exista en la base de datos
                var municipioExiste = this.IConexion!.Municipios!.Any(m => m.Id == entidad.MunicipioId);
                if (!municipioExiste)
                {
                    // Graba la validación fallida
                    AuditoriaLogicaNegocio.GrabarValidacion("Afiliado", "MunicipioNoExiste", false, $"Municipio ID {entidad.MunicipioId} no existe");
                    AuditoriaLogicaNegocio.GrabarError("Afiliado", operacion, "Municipio no existe", JsonConversor.ConvertirAString(entidad));
                    throw new Exception("lbMunicipioNoExiste");
                }
            }

            // Todas las validaciones pasaron
            // Graba la validación exitosa
            AuditoriaLogicaNegocio.GrabarValidacion("Afiliado", "ValidacionCompleta", true, "Todas las validaciones pasaron");
            return true;
        }

        // Borra un afiliado de la base de datos
        // entidad: afiliado a borrar (debe tener Id > 0)
        // Retorna el afiliado borrado
        public Afiliado? Borrar(Afiliado? entidad)
        {
            // Valida que la entidad no sea nula
            if (entidad == null)
            {
                // Graba el error
                AuditoriaLogicaNegocio.GrabarError("Afiliado", "Borrar", "Entidad nula", null);
                throw new Exception("lbFaltaInformacion");
            }
            
            // Valida que tenga un ID válido
            if (entidad!.Id == 0)
            {
                // Graba el error
                AuditoriaLogicaNegocio.GrabarError("Afiliado", "Borrar", "ID inválido (debe ser > 0)", JsonConversor.ConvertirAString(entidad));
                throw new Exception("lbNoSeGuardo");
            }

            try
            {
                // Obtiene el afiliado de la base de datos para grabar los datos antes de borrar
                var entidadABorrar = this.IConexion!.Afiliados!.FirstOrDefault(a => a.Id == entidad.Id);
                
                // Si no existe, graba error
                if (entidadABorrar == null)
                {
                    AuditoriaLogicaNegocio.GrabarError("Afiliado", "Borrar", $"Afiliado con ID {entidad.Id} no existe", JsonConversor.ConvertirAString(entidad));
                    throw new Exception("lbAfiliadoNoExiste");
                }

                // Datos antes de borrar (para auditoría)
                string datosAntes = JsonConversor.ConvertirAString(entidadABorrar);
                
                // Graba la operación antes de ejecutarla
                AuditoriaLogicaNegocio.GrabarOperacion("DELETE", "Afiliado", datosAntes, null, "INICIANDO", $"Iniciando borrado del afiliado ID: {entidad.Id}");

                // Elimina el afiliado de la base de datos
                this.IConexion!.Afiliados!.Remove(entidadABorrar);
                this.IConexion.SaveChanges();
                
                // Graba la operación exitosa después de borrar
                AuditoriaLogicaNegocio.GrabarOperacion("DELETE", "Afiliado", datosAntes, null, "OK", $"Afiliado ID {entidad.Id} borrado exitosamente");
                
                return entidadABorrar;
            }
            catch (Exception ex)
            {
                // Graba el error si falla
                string datosAntes = JsonConversor.ConvertirAString(entidad);
                AuditoriaLogicaNegocio.GrabarOperacion("DELETE", "Afiliado", datosAntes, null, "ERROR", ex.Message);
                AuditoriaLogicaNegocio.GrabarError("Afiliado", "Borrar", ex.Message, datosAntes);
                throw;
            }
        }

        // Guarda un nuevo afiliado en la base de datos
        // entidad: afiliado a guardar (debe tener Id = 0)
        // Retorna el afiliado guardado con su nuevo ID
        public Afiliado? Guardar(Afiliado? entidad)
        {
            // Datos antes de la operación (null porque es nuevo)
            string? datosAntes = null;
            
            // Valida que la entidad no sea nula
            if (entidad == null)
            {
                // Graba el error
                AuditoriaLogicaNegocio.GrabarError("Afiliado", "Guardar", "Entidad nula", null);
                throw new Exception("lbFaltaInformacion");
            }
            
            // Valida que no tenga ID (debe ser nuevo)
            if (entidad.Id != 0)
            {
                // Graba el error
                AuditoriaLogicaNegocio.GrabarError("Afiliado", "Guardar", "Ya tiene ID", JsonConversor.ConvertirAString(entidad));
                throw new Exception("lbYaSeGuardo");
            }

            // Valida la lógica de negocio antes de guardar
            // Esto incluye validaciones de nombre, documento, email, etc.
            ValidarLogicaNegocio(entidad, "Guardar");

            // Graba la operación antes de ejecutarla
            string datosDespues = JsonConversor.ConvertirAString(entidad);
            AuditoriaLogicaNegocio.GrabarOperacion("CREATE", "Afiliado", datosAntes, datosDespues, "INICIANDO", "Iniciando operación de guardado");

            try
            {
                // Agrega el afiliado a la base de datos
                this.IConexion!.Afiliados!.Add(entidad);
                this.IConexion.SaveChanges();
                
                // Graba la operación exitosa después de guardar
                datosDespues = JsonConversor.ConvertirAString(entidad);
                AuditoriaLogicaNegocio.GrabarOperacion("CREATE", "Afiliado", datosAntes, datosDespues, "OK", $"Afiliado guardado con ID: {entidad.Id}");
                
                return entidad;
            }
            catch (Exception ex)
            {
                // Graba el error si falla
                AuditoriaLogicaNegocio.GrabarOperacion("CREATE", "Afiliado", datosAntes, datosDespues, "ERROR", ex.Message);
                AuditoriaLogicaNegocio.GrabarError("Afiliado", "Guardar", ex.Message, datosDespues);
                throw;
            }
        }

        // Lista todos los afiliados (máximo 50)
        // Retorna una lista de afiliados
        public List<Afiliado> Listar()
        {
            try
            {
                // Graba la operación de lectura
                AuditoriaLogicaNegocio.GrabarOperacion("READ", "Afiliado", null, null, "INICIANDO", "Iniciando operación de listado");
                
                // Obtiene la lista de afiliados
                var lista = this.IConexion!.Afiliados!.Take(50).ToList();
                
                // Graba la operación exitosa
                string datosDespues = $"Total de registros: {lista.Count}";
                AuditoriaLogicaNegocio.GrabarOperacion("READ", "Afiliado", null, datosDespues, "OK", $"Se listaron {lista.Count} afiliados");
                
                return lista;
            }
            catch (Exception ex)
            {
                // Graba el error si falla
                AuditoriaLogicaNegocio.GrabarOperacion("READ", "Afiliado", null, null, "ERROR", ex.Message);
                AuditoriaLogicaNegocio.GrabarError("Afiliado", "Listar", ex.Message, null);
                throw;
            }
        }

        // Obtiene afiliados filtrados por municipio
        // entidad: afiliado con el MunicipioId a buscar
        // Retorna lista de afiliados del municipio (máximo 50)
        public List<Afiliado> PorMunicipio(Afiliado? entidad)
        {
            return this.IConexion!.Afiliados!
                .Where(x => x.MunicipioId == entidad!.MunicipioId)
                .Take(50)
                .ToList();
        }

        // Modifica un afiliado existente
        // entidad: afiliado con los datos actualizados (debe tener Id > 0)
        // Retorna el afiliado modificado
        public Afiliado? Modificar(Afiliado? entidad)
        {
            // Valida que la entidad no sea nula
            if (entidad == null)
            {
                // Graba el error
                AuditoriaLogicaNegocio.GrabarError("Afiliado", "Modificar", "Entidad nula", null);
                throw new Exception("lbFaltaInformacion");
            }
            
            // Valida que tenga un ID válido
            if (entidad!.Id == 0)
            {
                // Graba el error
                AuditoriaLogicaNegocio.GrabarError("Afiliado", "Modificar", "ID inválido (debe ser > 0)", JsonConversor.ConvertirAString(entidad));
                throw new Exception("lbNoSeGuardo");
            }

            try
            {
                // Obtiene el afiliado original de la base de datos para comparar
                var entidadOriginal = this.IConexion!.Afiliados!.FirstOrDefault(a => a.Id == entidad.Id);
                
                // Si no existe, graba error
                if (entidadOriginal == null)
                {
                    AuditoriaLogicaNegocio.GrabarError("Afiliado", "Modificar", $"Afiliado con ID {entidad.Id} no existe", JsonConversor.ConvertirAString(entidad));
                    throw new Exception("lbAfiliadoNoExiste");
                }

                // Datos antes de la modificación
                string datosAntes = JsonConversor.ConvertirAString(entidadOriginal);
                
                // Valida la lógica de negocio antes de modificar
                ValidarLogicaNegocio(entidad, "Modificar");

                // Graba la operación antes de ejecutarla
                string datosDespues = JsonConversor.ConvertirAString(entidad);
                AuditoriaLogicaNegocio.GrabarOperacion("UPDATE", "Afiliado", datosAntes, datosDespues, "INICIANDO", $"Iniciando modificación del afiliado ID: {entidad.Id}");

                // Marca la entidad como modificada y guarda cambios
                var entry = this.IConexion!.Entry<Afiliado>(entidad);
                entry.State = EntityState.Modified;
                this.IConexion.SaveChanges();
                
                // Graba la operación exitosa después de modificar
                datosDespues = JsonConversor.ConvertirAString(entidad);
                AuditoriaLogicaNegocio.GrabarOperacion("UPDATE", "Afiliado", datosAntes, datosDespues, "OK", $"Afiliado ID {entidad.Id} modificado exitosamente");
                
                return entidad;
            }
            catch (Exception ex)
            {
                // Graba el error si falla
                string datosDespues = JsonConversor.ConvertirAString(entidad);
                AuditoriaLogicaNegocio.GrabarOperacion("UPDATE", "Afiliado", null, datosDespues, "ERROR", ex.Message);
                AuditoriaLogicaNegocio.GrabarError("Afiliado", "Modificar", ex.Message, datosDespues);
                throw;
            }
        }
    }
}

