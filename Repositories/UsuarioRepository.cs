using System;
using System.ComponentModel.DataAnnotations;
using EPS.Entities;
namespace EPS.Repositories {
    public class UsuarioRepository : IUsuarioRepository {
        public void Guardar(Usuario obj) {}
        public void Modificar(Usuario obj) {}
        public void Actualizar(Usuario obj) {}
        public void Borrar(int id) {}
        public Usuario ObtenerPorId(int id) { return null; }
        public System.Collections.Generic.List<Usuario> ListarTodos() { return new System.Collections.Generic.List<Usuario>(); }
    }
}

