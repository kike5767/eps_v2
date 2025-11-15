using System;
using System.Collections.Generic;
using EPS.Entities;
namespace EPS.Services {
    public interface IAfiliadoDetalleService {
        void Guardar(AfiliadoDetalle obj);
        void Modificar(AfiliadoDetalle obj);
        void Actualizar(AfiliadoDetalle obj);
        void Borrar(int id);
        AfiliadoDetalle Obtener(int id);
        System.Collections.Generic.List<AfiliadoDetalle> Listar();
    }
}
