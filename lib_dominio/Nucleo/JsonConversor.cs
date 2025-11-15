// Clase para convertir objetos a JSON y viceversa
// Utiliza Newtonsoft.Json para serialización y deserialización
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace lib_dominio.Nucleo
{
    public class JsonConversor
    {
        // Convierte una cadena JSON a un diccionario de objetos
        // Maneja objetos anidados recursivamente
        public static Dictionary<string, object> ConvertirAObjeto(string data)
        {
            // Deserializa el JSON a un diccionario
            var values = JsonConvert.DeserializeObject<Dictionary<string, object>>(data);
            var values2 = new Dictionary<string, object>();
            
            // Itera sobre cada par clave-valor
            foreach (KeyValuePair<string, object> item in values!)
            {
                // Si el valor es un JObject, lo convierte recursivamente
                if (item.Value is JObject)
                    values2.Add(item.Key, ConvertirAObjeto(item.Value.ToString()!));
                else
                    values2.Add(item.Key, item.Value);
            }
            return values2;
        }

        // Convierte un objeto a cadena JSON
        // ignore: si es true, ignora referencias circulares
        public static string ConvertirAString(object data, bool ignore = false)
        {
            if (!ignore)
                return JsonConvert.SerializeObject(data);

            // Serializa con formato indentado e ignorando referencias circulares
            return JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }
             );
        }

        // Convierte una cadena JSON a un objeto tipado genérico
        // check: si es true, limpia comillas dobles adicionales
        public static T ConvertirAObjeto<T>(string data, bool check = false)
        {
            if (check && data.Contains("\""))
                data = data.Replace("\"", "");
            return JsonConvert.DeserializeObject<T>(data)!;
        }
    }
}

