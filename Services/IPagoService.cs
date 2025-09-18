using System;
using System.Collections.Generic;
using EPS.Entities;
namespace EPS.Services {
    public interface IPagoService {
        void Guardar(Pago obj);
        void Modificar(Pago obj);
        void Actualizar(Pago obj);
        void Borrar(int id);
        Pago Obtener(int id);
        System.Collections.Generic.List<Pago> Listar();
    }
}
