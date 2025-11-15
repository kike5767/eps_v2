using System;
using System.ComponentModel.DataAnnotations;
using EPS.Entities;
namespace EPS.Repositories {
    public class AfiliadoDetalleRepository : IAfiliadoDetalleRepository {
        public void Guardar(AfiliadoDetalle obj) {}
        public void Modificar(AfiliadoDetalle obj) {}
        public void Actualizar(AfiliadoDetalle obj) {}
        public void Borrar(int id) {}
        public AfiliadoDetalle ObtenerPorId(int id) { return null; }
        public System.Collections.Generic.List<AfiliadoDetalle> ListarTodos() { return new System.Collections.Generic.List<AfiliadoDetalle>(); }
    }
}

