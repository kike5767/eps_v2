using System;
using System.Collections.Generic;
using EPS.Entities;
namespace EPS.Repositories {
    public interface IPlanEPSRepository {
        void Guardar(PlanEPS obj);
        void Modificar(PlanEPS obj);
        void Actualizar(PlanEPS obj);
        void Borrar(int id);
        PlanEPS ObtenerPorId(int id);
        System.Collections.Generic.List<PlanEPS> ListarTodos();
    }
}
