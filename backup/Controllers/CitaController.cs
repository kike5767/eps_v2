using System;
using System.ComponentModel.DataAnnotations;
using EPS.Entities;
using EPS.Services;
namespace EPS.Controllers {
    public class CitaController {
        private readonly ICitaService _service;
        public CitaController(ICitaService service) { _service = service; }
    }
}

