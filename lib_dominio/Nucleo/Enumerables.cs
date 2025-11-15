// Clase para definir enumeraciones y constantes del sistema
// Facilita el manejo de estados y tipos en toda la aplicación
namespace lib_dominio.Nucleo
{
    // Enumeración para tipos de ventanas/acciones en la UI
    public class Enumerables
    {
        public class Ventanas
        {
            public const string Listar = "Listar";
            public const string Editar = "Editar";
            public const string Nuevo = "Nuevo";
            public const string Eliminar = "Eliminar";
            public const string Ver = "Ver";
        }

        // Estados comunes para entidades
        public class Estados
        {
            public const string Activo = "Activo";
            public const string Inactivo = "Inactivo";
            public const string Pendiente = "Pendiente";
            public const string Completado = "Completado";
            public const string Cancelado = "Cancelado";
        }

        // Tipos de detalles para AfiliadoDetalle
        public class TiposDetalle
        {
            public const string Telefono = "Telefono";
            public const string Direccion = "Direccion";
            public const string Contacto = "Contacto";
            public const string Observacion = "Observacion";
        }
    }
}

