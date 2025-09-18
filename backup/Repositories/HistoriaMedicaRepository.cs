using System;
using System.ComponentModel.DataAnnotations;
using EPS.Entities;
namespace EPS.Repositories {
    public class HistoriaMedicaRepository : IHistoriaMedicaRepository {
        public void Guardar(HistoriaMedica obj) {}
        public void Modificar(HistoriaMedica obj) {}
        public void Actualizar(HistoriaMedica obj) {}
        public void Borrar(int id) {}
        public HistoriaMedica ObtenerPorId(int id) { return null; }
        public System.Collections.Generic.List<HistoriaMedica> ListarTodos() { return new System.Collections.Generic.List<HistoriaMedica>(); }
    }
}

