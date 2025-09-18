using System;
using System.ComponentModel.DataAnnotations;
using EPS.Entities;
namespace EPS.Repositories {
    public class DepartamentoRepository : IDepartamentoRepository {
        public void Guardar(Departamento obj) {}
        public void Modificar(Departamento obj) {}
        public void Actualizar(Departamento obj) {}
        public void Borrar(int id) {}
        public Departamento ObtenerPorId(int id) { return null; }
        public System.Collections.Generic.List<Departamento> ListarTodos() { return new System.Collections.Generic.List<Departamento>(); }
    }
}

