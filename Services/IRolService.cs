using System;
using System.Collections.Generic;
using EPS.Entities;
namespace EPS.Services {
    public interface IRolService {
        void Guardar(Rol obj);
        void Modificar(Rol obj);
        void Actualizar(Rol obj);
        void Borrar(int id);
        Rol Obtener(int id);
        System.Collections.Generic.List<Rol> Listar();
    }
}
