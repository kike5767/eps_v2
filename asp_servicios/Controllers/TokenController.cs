// Controlador para manejo de tokens de autenticación
// Proporciona endpoints para obtener y validar llaves de acceso
using asp_servicios.Nucleo;
using lib_dominio.Nucleo;
using lib_repositorios.Implementaciones;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    // Marca esta clase como un controlador de API
    [ApiController]
    // Define la ruta base: /Token/[action]
    [Route("[controller]/[action]")]
    public class TokenController : ControllerBase
    {
        // Instancia de la aplicación de tokens
        private TokenAplicacion? iAplicacion = null;
        
        // Constructor que recibe la aplicación de tokens por inyección de dependencias
        public TokenController(TokenAplicacion? iAplicacion)
        {
            this.iAplicacion = iAplicacion;
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

        // Endpoint POST para obtener una llave de autenticación
        // El cuerpo debe contener: { "Entidad": "Usuario.6546s5f465sd4f" }
        // Retorna: { "Llave": "...", "Respuesta": "OK", "Fecha": "..." }
        [HttpPost]
        public string Llave()
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                // Obtiene los datos de la petición
                var datos = ObtenerDatos();
                
                // Configura la conexión usando la cadena desde secrets.json
                this.iAplicacion!.Configurar(Configuracion.ObtenerValor("StringConexion"));
                
                // Obtiene el usuario del cuerpo de la petición
                var usuario = datos["Entidad"].ToString();
                
                // Obtiene la llave para el usuario
                respuesta["Llave"] = this.iAplicacion!.Llave(usuario);
                respuesta["Respuesta"] = "OK";
                respuesta["Fecha"] = DateTime.Now.ToString();
                
                // Retorna la respuesta en formato JSON
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
    }
}

