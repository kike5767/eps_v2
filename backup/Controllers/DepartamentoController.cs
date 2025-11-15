using System;
using System.ComponentModel.DataAnnotations;
using EPS.Entities;
using EPS.Services;
namespace EPS.Controllers {
    public class DepartamentoController {
        private readonly IDepartamentoService _service;
        public DepartamentoController(IDepartamentoService service) { _service = service; }
    }
}

