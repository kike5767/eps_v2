using System;
using System.ComponentModel.DataAnnotations;
using EPS.Entities;
using EPS.Repositories;
namespace EPS.Services {
    public class IndicadorService : IIndicadorService {
        private readonly IIndicadorRepository _repo;
        public IndicadorService(IIndicadorRepository repo) { _repo = repo; }
        public void Guardar(Indicador obj) => _repo.Guardar(obj);
        public void Modificar(Indicador obj) => _repo.Modificar(obj);
        public void Actualizar(Indicador obj) => _repo.Actualizar(obj);
        public void Borrar(int id) => _repo.Borrar(id);
        public Indicador Obtener(int id) => _repo.ObtenerPorId(id);
        public System.Collections.Generic.List<Indicador> Listar() => _repo.ListarTodos();
    }
}

