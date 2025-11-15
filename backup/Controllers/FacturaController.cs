using System;
using System.ComponentModel.DataAnnotations;
using EPS.Entities;
using EPS.Services;
namespace EPS.Controllers {
    public class FacturaController {
        private readonly IFacturaService _service;
        public FacturaController(IFacturaService service) { _service = service; }
    }
}

