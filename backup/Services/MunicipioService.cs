using System;
using System.ComponentModel.DataAnnotations;
using EPS.Entities;
using EPS.Repositories;
namespace EPS.Services {
    public class MunicipioService : IMunicipioService {
        private readonly IMunicipioRepository _repo;
        public MunicipioService(IMunicipioRepository repo) { _repo = repo; }
        public void Guardar(Municipio obj) => _repo.Guardar(obj);
        public void Modificar(Municipio obj) => _repo.Modificar(obj);
        public void Actualizar(Municipio obj) => _repo.Actualizar(obj);
        public void Borrar(int id) => _repo.Borrar(id);
        public Municipio Obtener(int id) => _repo.ObtenerPorId(id);
        public System.Collections.Generic.List<Municipio> Listar() => _repo.ListarTodos();
    }
}

