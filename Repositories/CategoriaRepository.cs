using System;
using System.ComponentModel.DataAnnotations;
using EPS.Entities;
namespace EPS.Repositories {
    public class CategoriaRepository : ICategoriaRepository {
        public void Guardar(Categoria obj) {}
        public void Modificar(Categoria obj) {}
        public void Actualizar(Categoria obj) {}
        public void Borrar(int id) {}
        public Categoria ObtenerPorId(int id) { return null; }
        public System.Collections.Generic.List<Categoria> ListarTodos() { return new System.Collections.Generic.List<Categoria>(); }
    }
}

