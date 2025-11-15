using System;
using System.ComponentModel.DataAnnotations;
using EPS.Entities;
using EPS.Repositories;
namespace EPS.Services {
    public class FacturaService : IFacturaService {
        private readonly IFacturaRepository _repo;
        public FacturaService(IFacturaRepository repo) { _repo = repo; }
        public void Guardar(Factura obj) => _repo.Guardar(obj);
        public void Modificar(Factura obj) => _repo.Modificar(obj);
        public void Actualizar(Factura obj) => _repo.Actualizar(obj);
        public void Borrar(int id) => _repo.Borrar(id);
        public Factura Obtener(int id) => _repo.ObtenerPorId(id);
        public System.Collections.Generic.List<Factura> Listar() => _repo.ListarTodos();
    }
}

