using System;
using System.Collections.Generic;
using EPS.Entities;
namespace EPS.Services {
    public interface IDepartamentoService {
        void Guardar(Departamento obj);
        void Modificar(Departamento obj);
        void Actualizar(Departamento obj);
        void Borrar(int id);
        Departamento Obtener(int id);
        System.Collections.Generic.List<Departamento> Listar();
    }
}
