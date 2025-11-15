using System;
using System.Collections.Generic;
using EPS.Entities;

namespace EPS.Repositories
{
    public interface IAfiliadoRepository
    {
        void Guardar(Afiliado obj);
        void Modificar(Afiliado obj);
        void Actualizar(Afiliado obj);
        void Borrar(int id);
        Afiliado ObtenerPorId(int id);
        List<Afiliado> ListarTodos();
    }
}
