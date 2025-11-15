using System;
using System.ComponentModel.DataAnnotations;
using EPS.Entities;
namespace EPS.Repositories {
    public class AfiliadoRepository : IAfiliadoRepository {
        public void Guardar(Afiliado obj) {}
        public void Modificar(Afiliado obj) {}
        public void Actualizar(Afiliado obj) {}
        public void Borrar(int id) {}
        public Afiliado ObtenerPorId(int id) { return null; }
        public System.Collections.Generic.List<Afiliado> ListarTodos() { return new System.Collections.Generic.List<Afiliado>(); }
    }
}

