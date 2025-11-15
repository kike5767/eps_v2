using System;
using System.ComponentModel.DataAnnotations;
using EPS.Entities;
namespace EPS.Repositories {
    public class PagoRepository : IPagoRepository {
        public void Guardar(Pago obj) {}
        public void Modificar(Pago obj) {}
        public void Actualizar(Pago obj) {}
        public void Borrar(int id) {}
        public Pago ObtenerPorId(int id) { return null; }
        public System.Collections.Generic.List<Pago> ListarTodos() { return new System.Collections.Generic.List<Pago>(); }
    }
}

