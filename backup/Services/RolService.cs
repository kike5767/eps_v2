using System;
using System.ComponentModel.DataAnnotations;
using EPS.Entities;
using EPS.Repositories;
namespace EPS.Services {
    public class RolService : IRolService {
        private readonly IRolRepository _repo;
        public RolService(IRolRepository repo) { _repo = repo; }
        public void Guardar(Rol obj) => _repo.Guardar(obj);
        public void Modificar(Rol obj) => _repo.Modificar(obj);
        public void Actualizar(Rol obj) => _repo.Actualizar(obj);
        public void Borrar(int id) => _repo.Borrar(id);
        public Rol Obtener(int id) => _repo.ObtenerPorId(id);
        public System.Collections.Generic.List<Rol> Listar() => _repo.ListarTodos();
    }
}

