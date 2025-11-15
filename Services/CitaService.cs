using System;
using System.ComponentModel.DataAnnotations;
using EPS.Entities;
using EPS.Repositories;
namespace EPS.Services {
    public class CitaService : ICitaService {
        private readonly ICitaRepository _repo;
        public CitaService(ICitaRepository repo) { _repo = repo; }
        public void Guardar(Cita obj) => _repo.Guardar(obj);
        public void Modificar(Cita obj) => _repo.Modificar(obj);
        public void Actualizar(Cita obj) => _repo.Actualizar(obj);
        public void Borrar(int id) => _repo.Borrar(id);
        public Cita Obtener(int id) => _repo.ObtenerPorId(id);
        public System.Collections.Generic.List<Cita> Listar() => _repo.ListarTodos();
    }
}

