using System;
using System.ComponentModel.DataAnnotations;
using EPS.Entities;
namespace EPS.Repositories {
    public class FacturaRepository : IFacturaRepository {
        public void Guardar(Factura obj) {}
        public void Modificar(Factura obj) {}
        public void Actualizar(Factura obj) {}
        public void Borrar(int id) {}
        public Factura ObtenerPorId(int id) { return null; }
        public System.Collections.Generic.List<Factura> ListarTodos() { return new System.Collections.Generic.List<Factura>(); }
    }
}

