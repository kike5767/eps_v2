using System;
using System.Collections.Generic;
using EPS.Entities;
namespace EPS.Repositories {
    public interface IReporteRepository {
        void Guardar(Reporte obj);
        void Modificar(Reporte obj);
        void Actualizar(Reporte obj);
        void Borrar(int id);
        Reporte ObtenerPorId(int id);
        System.Collections.Generic.List<Reporte> ListarTodos();
    }
}
