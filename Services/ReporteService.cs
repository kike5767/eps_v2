using System;
using System.ComponentModel.DataAnnotations;
using EPS.Entities;
using EPS.Repositories;
namespace EPS.Services {
    public class ReporteService : IReporteService {
        private readonly IReporteRepository _repo;
        public ReporteService(IReporteRepository repo) { _repo = repo; }
        public void Guardar(Reporte obj) => _repo.Guardar(obj);
        public void Modificar(Reporte obj) => _repo.Modificar(obj);
        public void Actualizar(Reporte obj) => _repo.Actualizar(obj);
        public void Borrar(int id) => _repo.Borrar(id);
        public Reporte Obtener(int id) => _repo.ObtenerPorId(id);
        public System.Collections.Generic.List<Reporte> Listar() => _repo.ListarTodos();
    }
}

