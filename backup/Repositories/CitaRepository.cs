using System;
using System.ComponentModel.DataAnnotations;
using EPS.Entities;
namespace EPS.Repositories {
    public class CitaRepository : ICitaRepository {
        public void Guardar(Cita obj) {}
        public void Modificar(Cita obj) {}
        public void Actualizar(Cita obj) {}
        public void Borrar(int id) {}
        public Cita ObtenerPorId(int id) { return null; }
        public System.Collections.Generic.List<Cita> ListarTodos() { return new System.Collections.Generic.List<Cita>(); }
    }
}

