// Clase para encriptar y desencriptar datos sensibles
// Utiliza un algoritmo simple de encriptación para el laboratorio
using System.Security.Cryptography;
using System.Text;

namespace lib_dominio.Nucleo
{
    public class EncriptarConversor
    {
        // Encripta una cadena de texto usando la clave de DatosGenerales
        // Retorna la cadena encriptada en Base64
        public static string Encriptar(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return string.Empty;

            byte[] textoBytes = Encoding.UTF8.GetBytes(texto);
            byte[] claveBytes = Encoding.UTF8.GetBytes(DatosGenerales.clave);
            
            // Algoritmo simple de XOR para encriptación
            for (int i = 0; i < textoBytes.Length; i++)
            {
                textoBytes[i] = (byte)(textoBytes[i] ^ claveBytes[i % claveBytes.Length]);
            }
            
            return Convert.ToBase64String(textoBytes);
        }

        // Desencripta una cadena previamente encriptada
        // Retorna el texto original
        public static string Desencriptar(string textoEncriptado)
        {
            if (string.IsNullOrEmpty(textoEncriptado))
                return string.Empty;

            byte[] textoBytes = Convert.FromBase64String(textoEncriptado);
            byte[] claveBytes = Encoding.UTF8.GetBytes(DatosGenerales.clave);
            
            // Algoritmo simple de XOR para desencriptación (es reversible)
            for (int i = 0; i < textoBytes.Length; i++)
            {
                textoBytes[i] = (byte)(textoBytes[i] ^ claveBytes[i % claveBytes.Length]);
            }
            
            return Encoding.UTF8.GetString(textoBytes);
        }
    }
}

