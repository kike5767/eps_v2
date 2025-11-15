using System;
using System.Collections.Generic;
using EPS.Entities;
namespace EPS.Services {
    public interface ICitaService {
        void Guardar(Cita obj);
        void Modificar(Cita obj);
        void Actualizar(Cita obj);
        void Borrar(int id);
        Cita Obtener(int id);
        System.Collections.Generic.List<Cita> Listar();
    }
}
