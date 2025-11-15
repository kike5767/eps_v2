using System;
using System.Collections.Generic;
using EPS.Entities;
namespace EPS.Repositories {
    public interface IDepartamentoRepository {
        void Guardar(Departamento obj);
        void Modificar(Departamento obj);
        void Actualizar(Departamento obj);
        void Borrar(int id);
        Departamento ObtenerPorId(int id);
        System.Collections.Generic.List<Departamento> ListarTodos();
    }
}
