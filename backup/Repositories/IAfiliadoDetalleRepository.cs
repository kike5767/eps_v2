using System;
using System.Collections.Generic;
using EPS.Entities;
namespace EPS.Repositories {
    public interface IAfiliadoDetalleRepository {
        void Guardar(AfiliadoDetalle obj);
        void Modificar(AfiliadoDetalle obj);
        void Actualizar(AfiliadoDetalle obj);
        void Borrar(int id);
        AfiliadoDetalle ObtenerPorId(int id);
        System.Collections.Generic.List<AfiliadoDetalle> ListarTodos();
    }
}
