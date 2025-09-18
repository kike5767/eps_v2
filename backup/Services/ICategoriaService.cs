using System;
using System.Collections.Generic;
using EPS.Entities;
namespace EPS.Services {
    public interface ICategoriaService {
        void Guardar(Categoria obj);
        void Modificar(Categoria obj);
        void Actualizar(Categoria obj);
        void Borrar(int id);
        Categoria Obtener(int id);
        System.Collections.Generic.List<Categoria> Listar();
    }
}
