using System;
using System.ComponentModel.DataAnnotations;
using EPS.Entities;
using EPS.Repositories;
namespace EPS.Services {
    public class DepartamentoService : IDepartamentoService {
        private readonly IDepartamentoRepository _repo;
        public DepartamentoService(IDepartamentoRepository repo) { _repo = repo; }
        public void Guardar(Departamento obj) => _repo.Guardar(obj);
        public void Modificar(Departamento obj) => _repo.Modificar(obj);
        public void Actualizar(Departamento obj) => _repo.Actualizar(obj);
        public void Borrar(int id) => _repo.Borrar(id);
        public Departamento Obtener(int id) => _repo.ObtenerPorId(id);
        public System.Collections.Generic.List<Departamento> Listar() => _repo.ListarTodos();
    }
}

