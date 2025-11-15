// Implementación de la lógica de aplicación para Afiliados
// Contiene las operaciones CRUD y validaciones de negocio
using lib_dominio.Entidades;
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

        // Borra un afiliado de la base de datos
        // entidad: afiliado a borrar (debe tener Id > 0)
        // Retorna el afiliado borrado
        public Afiliado? Borrar(Afiliado? entidad)
        {
            // Valida que la entidad no sea nula
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            
            // Valida que tenga un ID válido
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Elimina el afiliado de la base de datos
            this.IConexion!.Afiliados!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        // Guarda un nuevo afiliado en la base de datos
        // entidad: afiliado a guardar (debe tener Id = 0)
        // Retorna el afiliado guardado con su nuevo ID
        public Afiliado? Guardar(Afiliado? entidad)
        {
            // Valida que la entidad no sea nula
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            
            // Valida que no tenga ID (debe ser nuevo)
            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            // Agrega el afiliado a la base de datos
            this.IConexion!.Afiliados!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        // Lista todos los afiliados (máximo 50)
        // Retorna una lista de afiliados
        public List<Afiliado> Listar()
        {
            return this.IConexion!.Afiliados!.Take(50).ToList();
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
                throw new Exception("lbFaltaInformacion");
            
            // Valida que tenga un ID válido
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");

            // Marca la entidad como modificada y guarda cambios
            var entry = this.IConexion!.Entry<Afiliado>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}

