using System;
using System.ComponentModel.DataAnnotations;
using EPS.Entities;
namespace EPS.Repositories {
    public class ReporteRepository : IReporteRepository {
        public void Guardar(Reporte obj) {}
        public void Modificar(Reporte obj) {}
        public void Actualizar(Reporte obj) {}
        public void Borrar(int id) {}
        public Reporte ObtenerPorId(int id) { return null; }
        public System.Collections.Generic.List<Reporte> ListarTodos() { return new System.Collections.Generic.List<Reporte>(); }
    }
}

