using System;
using System.Collections.Generic;
using EPS.Entities;
namespace EPS.Repositories {
    public interface IHistoriaMedicaRepository {
        void Guardar(HistoriaMedica obj);
        void Modificar(HistoriaMedica obj);
        void Actualizar(HistoriaMedica obj);
        void Borrar(int id);
        HistoriaMedica ObtenerPorId(int id);
        System.Collections.Generic.List<HistoriaMedica> ListarTodos();
    }
}
