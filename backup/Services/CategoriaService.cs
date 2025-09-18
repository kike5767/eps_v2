using System;
using System.ComponentModel.DataAnnotations;
using EPS.Entities;
using EPS.Repositories;
namespace EPS.Services {
    public class CategoriaService : ICategoriaService {
        private readonly ICategoriaRepository _repo;
        public CategoriaService(ICategoriaRepository repo) { _repo = repo; }
        public void Guardar(Categoria obj) => _repo.Guardar(obj);
        public void Modificar(Categoria obj) => _repo.Modificar(obj);
        public void Actualizar(Categoria obj) => _repo.Actualizar(obj);
        public void Borrar(int id) => _repo.Borrar(id);
        public Categoria Obtener(int id) => _repo.ObtenerPorId(id);
        public System.Collections.Generic.List<Categoria> Listar() => _repo.ListarTodos();
    }
}

