using System;
using System.ComponentModel.DataAnnotations;
using EPS.Entities;
using EPS.Repositories;
namespace EPS.Services {
    public class AfiliadoService : IAfiliadoService {
        private readonly IAfiliadoRepository _repo;
        public AfiliadoService(IAfiliadoRepository repo) { _repo = repo; }
        public void Guardar(Afiliado obj) => _repo.Guardar(obj);
        public void Modificar(Afiliado obj) => _repo.Modificar(obj);
        public void Actualizar(Afiliado obj) => _repo.Actualizar(obj);
        public void Borrar(int id) => _repo.Borrar(id);
        public Afiliado Obtener(int id) => _repo.ObtenerPorId(id);
        public System.Collections.Generic.List<Afiliado> Listar() => _repo.ListarTodos();
    }
}

