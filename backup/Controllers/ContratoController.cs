using System;
using System.ComponentModel.DataAnnotations;
using EPS.Entities;
using EPS.Services;
namespace EPS.Controllers {
    public class ContratoController {
        private readonly IContratoService _service;
        public ContratoController(IContratoService service) { _service = service; }
    }
}

