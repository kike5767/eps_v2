using System;
using System.ComponentModel.DataAnnotations;
using EPS.Entities;
namespace EPS.Repositories {
    public class IndicadorRepository : IIndicadorRepository {
        public void Guardar(Indicador obj) {}
        public void Modificar(Indicador obj) {}
        public void Actualizar(Indicador obj) {}
        public void Borrar(int id) {}
        public Indicador ObtenerPorId(int id) { return null; }
        public System.Collections.Generic.List<Indicador> ListarTodos() { return new System.Collections.Generic.List<Indicador>(); }
    }
}

