// Clase para manejo de tokens de autenticación
// Valida usuarios y genera llaves de acceso para las peticiones API
using lib_repositorios.Interfaces;

namespace lib_repositorios.Implementaciones
{
    public class TokenAplicacion
    {
        // Conexión a la base de datos
        private IConexion? IConexion = null;
        
        // Usuario válido para obtener token (solo para laboratorio)
        // En producción esto debe venir de la base de datos
        private string usuario = "Usuario.6546s5f465sd4f";
        
        // Llave de autenticación (solo para laboratorio)
        // En producción debe generarse dinámicamente
        private string llave = "KJGjkhdjkfgkjf54fs65d4f65sd4f";

        // Constructor que recibe la conexión a la base de datos
        public TokenAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        // Configura la cadena de conexión
        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        // Obtiene la llave de autenticación si el usuario es válido
        // usuario: nombre de usuario a validar
        // Retorna la llave si es válido, cadena vacía si no
        public string Llave(string? usuario)
        {
            if (usuario != this.usuario)
                return string.Empty;
            return llave;
        }

        // Valida si la llave proporcionada es correcta
        // datos: diccionario que debe contener la clave "Llave"
        // Retorna true si la llave es válida, false en caso contrario
        public bool Validar(Dictionary<string, object> datos)
        {
            if (!datos.ContainsKey("Llave"))
                return false;
            return this.llave == datos["Llave"].ToString();
        }
    }
}

