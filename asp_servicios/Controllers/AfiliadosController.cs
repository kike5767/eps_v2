// Controlador para operaciones CRUD de Afiliados
// Proporciona endpoints para listar, guardar, modificar y borrar afiliados
using asp_servicios.Nucleo;
using lib_dominio.Entidades;
using lib_dominio.Nucleo;
using lib_repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using lib_repositorios.Implementaciones;

namespace asp_servicios.Controllers
{
    // Marca esta clase como un controlador de API
    [ApiController]
    // Define la ruta base: /Afiliados/[action]
    [Route("[controller]/[action]")]
    public class AfiliadosController : ControllerBase
    {
        // Instancia de la aplicación de afiliados
        private IAfiliadosAplicacion? iAplicacion = null;
        
        // Instancia de la aplicación de tokens para validación
        private TokenAplicacion? iAplicacionToken = null;

        // Constructor que recibe las aplicaciones por inyección de dependencias
        public AfiliadosController(IAfiliadosAplicacion? iAplicacion, TokenAplicacion iAplicacionToken)
        {
            this.iAplicacion = iAplicacion;
            this.iAplicacionToken = iAplicacionToken;
        }

        // Lee los datos del cuerpo de la petición HTTP
        // Retorna un diccionario con los datos parseados desde JSON
        private Dictionary<string, object> ObtenerDatos()
        {
            var datos = new StreamReader(Request.Body).ReadToEnd().ToString();
            if (string.IsNullOrEmpty(datos))
                datos = "{}";
            return JsonConversor.ConvertirAObjeto(datos);
        }

        // Endpoint POST para listar todos los afiliados
        // Retorna: { "Entidades": [...], "Respuesta": "OK", "Fecha": "..." }
        [HttpPost]
        public string Listar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                // Obtiene los datos de la petición
                var datos = ObtenerDatos();
                
                // Valida el token de autenticación
                if (!iAplicacionToken!.Validar(datos))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }
                
                // Configura la conexión usando la cadena desde secrets.json
                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));

                // Obtiene la lista de afiliados
                respuesta["Entidades"] = this.iAplicacion!.Listar();
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                // En caso de error, retorna un mensaje de error
                respuesta["Error"] = ex.Message.ToString();
                respuesta["Respuesta"] = "Error";
                return JsonConversor.ConvertirAString(respuesta);
            }
        }

        // Endpoint POST para obtener afiliados por municipio
        // El cuerpo debe contener: { "Entidad": { "MunicipioId": 1 } }
        // Retorna: { "Entidades": [...], "Respuesta": "OK", "Fecha": "..." }
        [HttpPost]
        public string PorMunicipio()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                // Obtiene los datos de la petición
                var datos = ObtenerDatos();
                
                // Valida el token de autenticación
                if (!iAplicacionToken!.Validar(datos))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }
                
                // Convierte la entidad del diccionario a un objeto Afiliado
                var entidad = JsonConversor.ConvertirAObjeto<Afiliado>(
                    JsonConversor.ConvertirAString(datos["Entidad"]));
                
                // Configura la conexión
                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));

                // Obtiene los afiliados del municipio
                respuesta["Entidades"] = this.iAplicacion!.PorMunicipio(entidad);
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                respuesta["Respuesta"] = "Error";
                return JsonConversor.ConvertirAString(respuesta);
            }
        }

        // Endpoint POST para guardar un nuevo afiliado
        // El cuerpo debe contener: { "Entidad": { ...datos del afiliado... } }
        // Retorna: { "Entidad": {...}, "Respuesta": "OK", "Fecha": "..." }
        [HttpPost]
        public string Guardar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                // Obtiene los datos de la petición
                var datos = ObtenerDatos();
                
                // Valida el token de autenticación
                if (!iAplicacionToken!.Validar(datos))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }
                
                // Convierte la entidad del diccionario a un objeto Afiliado
                var entidad = JsonConversor.ConvertirAObjeto<Afiliado>(
                    JsonConversor.ConvertirAString(datos["Entidad"]));
                
                // Configura la conexión
                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));

                // Guarda el afiliado
                entidad = this.iAplicacion!.Guardar(entidad);
                respuesta["Entidad"] = entidad!;
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                respuesta["Respuesta"] = "Error";
                return JsonConversor.ConvertirAString(respuesta);
            }
        }

        // Endpoint POST para modificar un afiliado existente
        // El cuerpo debe contener: { "Entidad": { "Id": 1, ...datos actualizados... } }
        // Retorna: { "Entidad": {...}, "Respuesta": "OK", "Fecha": "..." }
        [HttpPost]
        public string Modificar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                // Obtiene los datos de la petición
                var datos = ObtenerDatos();
                
                // Valida el token de autenticación
                if (!iAplicacionToken!.Validar(datos))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }
                
                // Convierte la entidad del diccionario a un objeto Afiliado
                var entidad = JsonConversor.ConvertirAObjeto<Afiliado>(
                    JsonConversor.ConvertirAString(datos["Entidad"]));
                
                // Configura la conexión
                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));

                // Modifica el afiliado
                entidad = this.iAplicacion!.Modificar(entidad);
                respuesta["Entidad"] = entidad!;
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                respuesta["Respuesta"] = "Error";
                return JsonConversor.ConvertirAString(respuesta);
            }
        }

        // Endpoint POST para borrar un afiliado
        // El cuerpo debe contener: { "Entidad": { "Id": 1 } }
        // Retorna: { "Entidad": {...}, "Respuesta": "OK", "Fecha": "..." }
        [HttpPost]
        public string Borrar()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                // Obtiene los datos de la petición
                var datos = ObtenerDatos();
                
                // Valida el token de autenticación
                if (!iAplicacionToken!.Validar(datos))
                {
                    respuesta["Error"] = "lbNoAutenticacion";
                    return JsonConversor.ConvertirAString(respuesta);
                }
                
                // Convierte la entidad del diccionario a un objeto Afiliado
                var entidad = JsonConversor.ConvertirAObjeto<Afiliado>(
                    JsonConversor.ConvertirAString(datos["Entidad"]));
                
                // Configura la conexión
                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));

                // Borra el afiliado
                entidad = this.iAplicacion!.Borrar(entidad);
                respuesta["Entidad"] = entidad!;
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
                return JsonConversor.ConvertirAString(respuesta);
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.Message.ToString();
                respuesta["Respuesta"] = "Error";
                return JsonConversor.ConvertirAString(respuesta);
            }
        }
    }
}

