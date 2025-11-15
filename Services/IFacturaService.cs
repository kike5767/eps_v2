using System;
using System.Collections.Generic;
using EPS.Entities;
namespace EPS.Services {
    public interface IFacturaService {
        void Guardar(Factura obj);
        void Modificar(Factura obj);
        void Actualizar(Factura obj);
        void Borrar(int id);
        Factura Obtener(int id);
        System.Collections.Generic.List<Factura> Listar();
    }
}
