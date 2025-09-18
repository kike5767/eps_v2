using System;
using System.ComponentModel.DataAnnotations;
using EPS.Entities;
namespace EPS.Repositories {
    public class MunicipioRepository : IMunicipioRepository {
        public void Guardar(Municipio obj) {}
        public void Modificar(Municipio obj) {}
        public void Actualizar(Municipio obj) {}
        public void Borrar(int id) {}
        public Municipio ObtenerPorId(int id) { return null; }
        public System.Collections.Generic.List<Municipio> ListarTodos() { return new System.Collections.Generic.List<Municipio>(); }
    }
}

