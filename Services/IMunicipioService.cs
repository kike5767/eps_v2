using System;
using System.Collections.Generic;
using EPS.Entities;
namespace EPS.Services {
    public interface IMunicipioService {
        void Guardar(Municipio obj);
        void Modificar(Municipio obj);
        void Actualizar(Municipio obj);
        void Borrar(int id);
        Municipio Obtener(int id);
        System.Collections.Generic.List<Municipio> Listar();
    }
}
