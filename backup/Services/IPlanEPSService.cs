using System;
using System.Collections.Generic;
using EPS.Entities;
namespace EPS.Services {
    public interface IPlanEPSService {
        void Guardar(PlanEPS obj);
        void Modificar(PlanEPS obj);
        void Actualizar(PlanEPS obj);
        void Borrar(int id);
        PlanEPS Obtener(int id);
        System.Collections.Generic.List<PlanEPS> Listar();
    }
}
