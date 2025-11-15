using System;
using System.ComponentModel.DataAnnotations;
using EPS.Entities;
namespace EPS.Repositories {
    public class RolRepository : IRolRepository {
        public void Guardar(Rol obj) {}
        public void Modificar(Rol obj) {}
        public void Actualizar(Rol obj) {}
        public void Borrar(int id) {}
        public Rol ObtenerPorId(int id) { return null; }
        public System.Collections.Generic.List<Rol> ListarTodos() { return new System.Collections.Generic.List<Rol>(); }
    }
}

