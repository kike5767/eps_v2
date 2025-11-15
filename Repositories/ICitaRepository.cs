using System;
using System.Collections.Generic;
using EPS.Entities;
namespace EPS.Repositories {
    public interface ICitaRepository {
        void Guardar(Cita obj);
        void Modificar(Cita obj);
        void Actualizar(Cita obj);
        void Borrar(int id);
        Cita ObtenerPorId(int id);
        System.Collections.Generic.List<Cita> ListarTodos();
    }
}
