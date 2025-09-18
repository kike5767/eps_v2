using System;
using System.ComponentModel.DataAnnotations;
using EPS.Entities;
namespace EPS.Repositories {
    public class ContratoRepository : IContratoRepository {
        public void Guardar(Contrato obj) {}
        public void Modificar(Contrato obj) {}
        public void Actualizar(Contrato obj) {}
        public void Borrar(int id) {}
        public Contrato ObtenerPorId(int id) { return null; }
        public System.Collections.Generic.List<Contrato> ListarTodos() { return new System.Collections.Generic.List<Contrato>(); }
    }
}

