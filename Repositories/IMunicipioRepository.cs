using System;
using System.Collections.Generic;
using EPS.Entities;
namespace EPS.Repositories {
    public interface IMunicipioRepository {
        void Guardar(Municipio obj);
        void Modificar(Municipio obj);
        void Actualizar(Municipio obj);
        void Borrar(int id);
        Municipio ObtenerPorId(int id);
        System.Collections.Generic.List<Municipio> ListarTodos();
    }
}
