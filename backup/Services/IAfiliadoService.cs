using System;
using System.Collections.Generic;
using EPS.Entities;

namespace EPS.Services
{
    public interface IAfiliadoService
    {
        void Guardar(Afiliado obj);
        void Modificar(Afiliado obj);
        void Actualizar(Afiliado obj);
        void Borrar(int id);
        Afiliado Obtener(int id);
        List<Afiliado> Listar();
    }
}
