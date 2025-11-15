using System;
using System.Collections.Generic;
using EPS.Entities;
namespace EPS.Services {
    public interface IHistoriaMedicaService {
        void Guardar(HistoriaMedica obj);
        void Modificar(HistoriaMedica obj);
        void Actualizar(HistoriaMedica obj);
        void Borrar(int id);
        HistoriaMedica Obtener(int id);
        System.Collections.Generic.List<HistoriaMedica> Listar();
    }
}
