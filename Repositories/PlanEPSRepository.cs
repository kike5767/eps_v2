using System;
using System.ComponentModel.DataAnnotations;
using EPS.Entities;
namespace EPS.Repositories {
    public class PlanEPSRepository : IPlanEPSRepository {
        public void Guardar(PlanEPS obj) {}
        public void Modificar(PlanEPS obj) {}
        public void Actualizar(PlanEPS obj) {}
        public void Borrar(int id) {}
        public PlanEPS ObtenerPorId(int id) { return null; }
        public System.Collections.Generic.List<PlanEPS> ListarTodos() { return new System.Collections.Generic.List<PlanEPS>(); }
    }
}

