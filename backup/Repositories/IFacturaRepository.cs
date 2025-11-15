using System;
using System.Collections.Generic;
using EPS.Entities;
namespace EPS.Repositories {
    public interface IFacturaRepository {
        void Guardar(Factura obj);
        void Modificar(Factura obj);
        void Actualizar(Factura obj);
        void Borrar(int id);
        Factura ObtenerPorId(int id);
        System.Collections.Generic.List<Factura> ListarTodos();
    }
}
