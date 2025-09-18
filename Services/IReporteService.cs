using System;
using System.Collections.Generic;
using EPS.Entities;
namespace EPS.Services {
    public interface IReporteService {
        void Guardar(Reporte obj);
        void Modificar(Reporte obj);
        void Actualizar(Reporte obj);
        void Borrar(int id);
        Reporte Obtener(int id);
        System.Collections.Generic.List<Reporte> Listar();
    }
}
