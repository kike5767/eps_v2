using System;
using System.ComponentModel.DataAnnotations;
using EPS.Entities;
using EPS.Repositories;
namespace EPS.Services {
    public class PlanEPSService : IPlanEPSService {
        private readonly IPlanEPSRepository _repo;
        public PlanEPSService(IPlanEPSRepository repo) { _repo = repo; }
        public void Guardar(PlanEPS obj) => _repo.Guardar(obj);
        public void Modificar(PlanEPS obj) => _repo.Modificar(obj);
        public void Actualizar(PlanEPS obj) => _repo.Actualizar(obj);
        public void Borrar(int id) => _repo.Borrar(id);
        public PlanEPS Obtener(int id) => _repo.ObtenerPorId(id);
        public System.Collections.Generic.List<PlanEPS> Listar() => _repo.ListarTodos();
    }
}

