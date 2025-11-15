using System;
using System.Collections.Generic;
using EPS.Entities;
namespace EPS.Repositories {
    public interface ICategoriaRepository {
        void Guardar(Categoria obj);
        void Modificar(Categoria obj);
        void Actualizar(Categoria obj);
        void Borrar(int id);
        Categoria ObtenerPorId(int id);
        System.Collections.Generic.List<Categoria> ListarTodos();
    }
}
