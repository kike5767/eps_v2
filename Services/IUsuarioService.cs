using System;
using System.Collections.Generic;
using EPS.Entities;
namespace EPS.Services {
    public interface IUsuarioService {
        void Guardar(Usuario obj);
        void Modificar(Usuario obj);
        void Actualizar(Usuario obj);
        void Borrar(int id);
        Usuario Obtener(int id);
        System.Collections.Generic.List<Usuario> Listar();
    }
}
