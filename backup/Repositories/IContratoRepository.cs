using System;
using System.Collections.Generic;
using EPS.Entities;
namespace EPS.Repositories {
    public interface IContratoRepository {
        void Guardar(Contrato obj);
        void Modificar(Contrato obj);
        void Actualizar(Contrato obj);
        void Borrar(int id);
        Contrato ObtenerPorId(int id);
        System.Collections.Generic.List<Contrato> ListarTodos();
    }
}
