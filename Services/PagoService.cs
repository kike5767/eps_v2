using System;
using System.ComponentModel.DataAnnotations;
using EPS.Entities;
using EPS.Repositories;
namespace EPS.Services {
    public class PagoService : IPagoService {
        private readonly IPagoRepository _repo;
        public PagoService(IPagoRepository repo) { _repo = repo; }
        public void Guardar(Pago obj) => _repo.Guardar(obj);
        public void Modificar(Pago obj) => _repo.Modificar(obj);
        public void Actualizar(Pago obj) => _repo.Actualizar(obj);
        public void Borrar(int id) => _repo.Borrar(id);
        public Pago Obtener(int id) => _repo.ObtenerPorId(id);
        public System.Collections.Generic.List<Pago> Listar() => _repo.ListarTodos();
    }
}

