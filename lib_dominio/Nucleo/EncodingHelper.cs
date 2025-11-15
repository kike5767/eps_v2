// Clase auxiliar para conversión de datos binarios a texto y viceversa
// Utilizada para manejar imágenes y archivos en base64
using System.Text;

namespace lib_dominio.Nucleo
{
    public class EncodingHelper
    {
        // Convierte un arreglo de bytes a una cadena Base64
        // Utilizado para almacenar imágenes en la base de datos
        public static string ToString(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0)
                return string.Empty;
            return Convert.ToBase64String(bytes);
        }

        // Convierte una cadena Base64 a un arreglo de bytes
        // Utilizado para recuperar imágenes desde la base de datos
        public static byte[] ToBytes(string base64String)
        {
            if (string.IsNullOrEmpty(base64String))
                return Array.Empty<byte>();
            return Convert.FromBase64String(base64String);
        }
    }
}

