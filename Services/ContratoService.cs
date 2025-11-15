using System;
using System.ComponentModel.DataAnnotations;
using EPS.Entities;
using EPS.Repositories;
namespace EPS.Services {
    public class ContratoService : IContratoService {
        private readonly IContratoRepository _repo;
        public ContratoService(IContratoRepository repo) { _repo = repo; }
        public void Guardar(Contrato obj) => _repo.Guardar(obj);
        public void Modificar(Contrato obj) => _repo.Modificar(obj);
        public void Actualizar(Contrato obj) => _repo.Actualizar(obj);
        public void Borrar(int id) => _repo.Borrar(id);
        public Contrato Obtener(int id) => _repo.ObtenerPorId(id);
        public System.Collections.Generic.List<Contrato> Listar() => _repo.ListarTodos();
    }
}

