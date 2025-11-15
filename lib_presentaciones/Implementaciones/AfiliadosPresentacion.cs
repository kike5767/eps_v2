// Implementación de la capa de presentación para Afiliados
// Se comunica con el API mediante la clase Comunicaciones
using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_presentaciones.Interfaces;

namespace lib_presentaciones.Implementaciones
{
    public class AfiliadosPresentacion : IAfiliadosPresentacion
    {
        // Instancia de Comunicaciones para realizar peticiones HTTP
        private Comunicaciones? comunicaciones = null;

        // Lista todos los afiliados desde el API
        // Retorna una lista de afiliados
        public async Task<List<Afiliado>> Listar()
        {
            var lista = new List<Afiliado>();
            var datos = new Dictionary<string, object>();

            // Crea una instancia de Comunicaciones
            comunicaciones = new Comunicaciones();
            
            // Construye la URL del endpoint
            datos = comunicaciones.ConstruirUrl(datos, "Afiliados/Listar");
            
            // Ejecuta la petición al API
            var respuesta = await comunicaciones!.Ejecutar(datos);

            // Si hay un error, lanza una excepción
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            
            // Convierte la respuesta a una lista de Afiliados
            lista = JsonConversor.ConvertirAObjeto<List<Afiliado>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }

        // Obtiene afiliados filtrados por municipio
        // entidad: afiliado con el MunicipioId a buscar
        // Retorna lista de afiliados del municipio
        public async Task<List<Afiliado>> PorMunicipio(Afiliado? entidad)
        {
            var lista = new List<Afiliado>();
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad!;

            // Crea una instancia de Comunicaciones
            comunicaciones = new Comunicaciones();
            
            // Construye la URL del endpoint
            datos = comunicaciones.ConstruirUrl(datos, "Afiliados/PorMunicipio");
            
            // Ejecuta la petición al API
            var respuesta = await comunicaciones!.Ejecutar(datos);

            // Si hay un error, lanza una excepción
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            
            // Convierte la respuesta a una lista de Afiliados
            lista = JsonConversor.ConvertirAObjeto<List<Afiliado>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }

        // Guarda un nuevo afiliado en el API
        // entidad: afiliado a guardar (debe tener Id = 0)
        // Retorna el afiliado guardado con su nuevo ID
        public async Task<Afiliado?> Guardar(Afiliado? entidad)
        {
            // Valida que el Id sea 0 (nuevo registro)
            if (entidad!.Id != 0)
            {
                throw new Exception("lbFaltaInformacion");
            }
            
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            // Crea una instancia de Comunicaciones
            comunicaciones = new Comunicaciones();
            
            // Construye la URL del endpoint
            datos = comunicaciones.ConstruirUrl(datos, "Afiliados/Guardar");
            
            // Ejecuta la petición al API
            var respuesta = await comunicaciones!.Ejecutar(datos);

            // Si hay un error, lanza una excepción
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            
            // Convierte la respuesta a un objeto Afiliado
            entidad = JsonConversor.ConvertirAObjeto<Afiliado>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }

        // Modifica un afiliado existente en el API
        // entidad: afiliado con los datos actualizados (debe tener Id > 0)
        // Retorna el afiliado modificado
        public async Task<Afiliado?> Modificar(Afiliado? entidad)
        {
            // Valida que el Id sea mayor a 0 (registro existente)
            if (entidad!.Id == 0)
            {
                throw new Exception("lbFaltaInformacion");
            }
            
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            // Crea una instancia de Comunicaciones
            comunicaciones = new Comunicaciones();
            
            // Construye la URL del endpoint
            datos = comunicaciones.ConstruirUrl(datos, "Afiliados/Modificar");

            // Ejecuta la petición al API
            var respuesta = await comunicaciones!.Ejecutar(datos);
            
            // Si hay un error, lanza una excepción
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            
            // Convierte la respuesta a un objeto Afiliado
            entidad = JsonConversor.ConvertirAObjeto<Afiliado>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }

        // Borra un afiliado del API
        // entidad: afiliado a borrar (debe tener Id > 0)
        // Retorna el afiliado borrado
        public async Task<Afiliado?> Borrar(Afiliado? entidad)
        {
            // Valida que el Id sea mayor a 0 (registro existente)
            if (entidad!.Id == 0)
            {
                throw new Exception("lbFaltaInformacion");
            }
            
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;

            // Crea una instancia de Comunicaciones
            comunicaciones = new Comunicaciones();
            
            // Construye la URL del endpoint
            datos = comunicaciones.ConstruirUrl(datos, "Afiliados/Borrar");
            
            // Ejecuta la petición al API
            var respuesta = await comunicaciones!.Ejecutar(datos);

            // Si hay un error, lanza una excepción
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            
            // Convierte la respuesta a un objeto Afiliado
            entidad = JsonConversor.ConvertirAObjeto<Afiliado>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }
    }
}

