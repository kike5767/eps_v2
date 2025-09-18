using System;
using System.ComponentModel.DataAnnotations;
using EPS.Entities;
using EPS.Repositories;
namespace EPS.Services {
    public class HistoriaMedicaService : IHistoriaMedicaService {
        private readonly IHistoriaMedicaRepository _repo;
        public HistoriaMedicaService(IHistoriaMedicaRepository repo) { _repo = repo; }
        public void Guardar(HistoriaMedica obj) => _repo.Guardar(obj);
        public void Modificar(HistoriaMedica obj) => _repo.Modificar(obj);
        public void Actualizar(HistoriaMedica obj) => _repo.Actualizar(obj);
        public void Borrar(int id) => _repo.Borrar(id);
        public HistoriaMedica Obtener(int id) => _repo.ObtenerPorId(id);
        public System.Collections.Generic.List<HistoriaMedica> Listar() => _repo.ListarTodos();
    }
}

