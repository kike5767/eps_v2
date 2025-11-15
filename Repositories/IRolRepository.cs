using System;
using System.Collections.Generic;
using EPS.Entities;
namespace EPS.Repositories {
    public interface IRolRepository {
        void Guardar(Rol obj);
        void Modificar(Rol obj);
        void Actualizar(Rol obj);
        void Borrar(int id);
        Rol ObtenerPorId(int id);
        System.Collections.Generic.List<Rol> ListarTodos();
    }
}
