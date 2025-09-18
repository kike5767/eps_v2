using System;
using System.Collections.Generic;
using EPS.Entities;
namespace EPS.Services {
    public interface IContratoService {
        void Guardar(Contrato obj);
        void Modificar(Contrato obj);
        void Actualizar(Contrato obj);
        void Borrar(int id);
        Contrato Obtener(int id);
        System.Collections.Generic.List<Contrato> Listar();
    }
}
