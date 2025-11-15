using System;
using System.Collections.Generic;
using EPS.Entities;
namespace EPS.Services {
    public interface IIndicadorService {
        void Guardar(Indicador obj);
        void Modificar(Indicador obj);
        void Actualizar(Indicador obj);
        void Borrar(int id);
        Indicador Obtener(int id);
        System.Collections.Generic.List<Indicador> Listar();
    }
}
