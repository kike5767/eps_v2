using System;
using System.ComponentModel.DataAnnotations;
using EPS.Entities;
using EPS.Repositories;
namespace EPS.Services {
    public class UsuarioService : IUsuarioService {
        private readonly IUsuarioRepository _repo;
        public UsuarioService(IUsuarioRepository repo) { _repo = repo; }
        public void Guardar(Usuario obj) => _repo.Guardar(obj);
        public void Modificar(Usuario obj) => _repo.Modificar(obj);
        public void Actualizar(Usuario obj) => _repo.Actualizar(obj);
        public void Borrar(int id) => _repo.Borrar(id);
        public Usuario Obtener(int id) => _repo.ObtenerPorId(id);
        public System.Collections.Generic.List<Usuario> Listar() => _repo.ListarTodos();
    }
}

