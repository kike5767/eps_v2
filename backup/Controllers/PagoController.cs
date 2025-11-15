using System;
using System.ComponentModel.DataAnnotations;
using EPS.Entities;
using EPS.Services;
namespace EPS.Controllers {
    public class PagoController {
        private readonly IPagoService _service;
        public PagoController(IPagoService service) { _service = service; }
    }
}

