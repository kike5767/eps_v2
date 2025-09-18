using System;
using System.ComponentModel.DataAnnotations;
using EPS.Entities;
using EPS.Repositories;
namespace EPS.Services {
    public class AfiliadoDetalleService : IAfiliadoDetalleService {
        private readonly IAfiliadoDetalleRepository _repo;
        public AfiliadoDetalleService(IAfiliadoDetalleRepository repo) { _repo = repo; }
        public void Guardar(AfiliadoDetalle obj) => _repo.Guardar(obj);
        public void Modificar(AfiliadoDetalle obj) => _repo.Modificar(obj);
        public void Actualizar(AfiliadoDetalle obj) => _repo.Actualizar(obj);
        public void Borrar(int id) => _repo.Borrar(id);
        public AfiliadoDetalle Obtener(int id) => _repo.ObtenerPorId(id);
        public System.Collections.Generic.List<AfiliadoDetalle> Listar() => _repo.ListarTodos();
    }
}

