using System;
using System.Collections.Generic;
using EPS.Entities;
namespace EPS.Repositories {
    public interface IIndicadorRepository {
        void Guardar(Indicador obj);
        void Modificar(Indicador obj);
        void Actualizar(Indicador obj);
        void Borrar(int id);
        Indicador ObtenerPorId(int id);
        System.Collections.Generic.List<Indicador> ListarTodos();
    }
}
