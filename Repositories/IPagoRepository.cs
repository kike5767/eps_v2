using System;
using System.Collections.Generic;
using EPS.Entities;
namespace EPS.Repositories {
    public interface IPagoRepository {
        void Guardar(Pago obj);
        void Modificar(Pago obj);
        void Actualizar(Pago obj);
        void Borrar(int id);
        Pago ObtenerPorId(int id);
        System.Collections.Generic.List<Pago> ListarTodos();
    }
}
