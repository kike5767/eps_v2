// Clase para manejar comunicaciones HTTP con la API
// Proporciona métodos para realizar peticiones POST y obtener tokens
using lib_dominio.Nucleo;

namespace lib_presentaciones
{
    public class Comunicaciones
    {
        // URL base del servicio API
        private string? URL = string.Empty;
        
        // Llave de autenticación obtenida del token
        private string? llave = null;

        // Constructor que recibe la URL del servicio
        // url: URL base del API (por defecto: http://localhost:5047/)
        public Comunicaciones(string url = "http://localhost:5047/")
        {
            URL = url;
        }

        // Construye las URLs necesarias para la petición
        // data: diccionario con los datos de la petición
        // Metodo: método del controlador a llamar (ej: "Afiliados/Listar")
        // Retorna el diccionario con las URLs agregadas
        public Dictionary<string, object> ConstruirUrl(Dictionary<string, object> data, string Metodo)
        {
            // URL del método a llamar
            data["Url"] = URL + Metodo;
            
            // URL para obtener la llave de autenticación
            data["UrlLlave"] = URL + "Token/Llave";
            return data;
        }

        // Ejecuta una petición HTTP POST al API
        // datos: diccionario con los datos a enviar (debe incluir URLs)
        // Retorna un diccionario con la respuesta del servidor
        public async Task<Dictionary<string, object>> Ejecutar(Dictionary<string, object> datos)
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                // Primero obtiene la llave de autenticación
                respuesta = await Llave(datos);
                if (respuesta == null || respuesta.ContainsKey("Error"))
                    return respuesta!;
                respuesta.Clear();

                // Obtiene la URL del método a llamar
                var url = datos["Url"].ToString();
                datos.Remove("Url");
                datos.Remove("UrlLlave");
                
                // Agrega la llave a los datos
                datos["Llave"] = llave!;
                
                // Convierte los datos a JSON
                var stringData = JsonConversor.ConvertirAString(datos);

                // Crea el cliente HTTP
                var httpClient = new HttpClient();
                httpClient.Timeout = new TimeSpan(0, 4, 0);
                
                // Realiza la petición POST
                var message = await httpClient.PostAsync(url, new StringContent(stringData));
                if (!message.IsSuccessStatusCode)
                {
                    respuesta.Add("Error", "lbErrorComunicacion");
                    return respuesta;
                }

                // Lee la respuesta
                var resp = await message.Content.ReadAsStringAsync();
                httpClient.Dispose(); 
                httpClient = null;
                
                if (string.IsNullOrEmpty(resp))
                {
                    respuesta.Add("Error", "lbErrorComunicacion");
                    return respuesta;
                }

                // Limpia y parsea la respuesta
                resp = Replace(resp);
                respuesta = JsonConversor.ConvertirAObjeto(resp);
                return respuesta;
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.ToString();
                return respuesta;
            }
        }

        // Obtiene la llave de autenticación del servidor
        // datos: diccionario que debe contener "UrlLlave"
        // Retorna un diccionario con la llave obtenida
        private async Task<Dictionary<string, object>> Llave(Dictionary<string, object> datos)
        {
            var respuesta = new Dictionary<string, object>();
            try
            {
                // Obtiene la URL para obtener la llave
                var url = datos["UrlLlave"].ToString();
                
                // Prepara los datos para obtener la llave
                var temp = new Dictionary<string, object>();
                temp["Entidad"] = "Usuario.6546s5f465sd4f";
                var stringData = JsonConversor.ConvertirAString(temp);

                // Crea el cliente HTTP
                var httpClient = new HttpClient();
                httpClient.Timeout = new TimeSpan(0, 1, 0);
                
                // Realiza la petición POST
                var mensaje = await httpClient.PostAsync(url, new StringContent(stringData));
                if (!mensaje.IsSuccessStatusCode)
                {
                    respuesta.Add("Error", "lbErrorComunicacion");
                    return respuesta;
                }

                // Lee la respuesta
                var resp = await mensaje.Content.ReadAsStringAsync();
                httpClient.Dispose(); 
                httpClient = null;
                
                if (string.IsNullOrEmpty(resp))
                {
                    respuesta.Add("Error", "lbErrorComunicacion");
                    return respuesta;
                }

                // Limpia y parsea la respuesta
                resp = Replace(resp);
                respuesta = JsonConversor.ConvertirAObjeto(resp);
                
                // Guarda la llave obtenida
                llave = respuesta["Llave"].ToString();
                return respuesta;
            }
            catch (Exception ex)
            {
                respuesta["Error"] = ex.ToString();
                return respuesta;
            }
        }

        // Limpia y normaliza una cadena JSON
        // resp: cadena JSON a limpiar
        // Retorna la cadena limpia
        private string Replace(string resp)
        {
            return resp.Replace("\\\\r\\\\n", "")
            .Replace("\\r\\n", "")
            .Replace("\\", "")
            .Replace("\\\"", "\"")
            .Replace("\"", "'")
            .Replace("'[", "[")
            .Replace("]'", "]")
            .Replace("'{'", "{'")
            .Replace("\\\\", "\\")
            .Replace("'}'", "'}")
            .Replace("}'", "}")
            .Replace("\\n", "")
            .Replace("\\r", "")
            .Replace(" ", "")
            .Replace("'{", "{")
            .Replace("\"", "")
            .Replace(" ", "")
            .Replace("null", "''");
        }
    }
}

