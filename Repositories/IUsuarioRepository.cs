using System;
using System.Collections.Generic;
using EPS.Entities;
namespace EPS.Repositories {
    public interface IUsuarioRepository {
        void Guardar(Usuario obj);
        void Modificar(Usuario obj);
        void Actualizar(Usuario obj);
        void Borrar(int id);
        Usuario ObtenerPorId(int id);
        System.Collections.Generic.List<Usuario> ListarTodos();
    }
}
