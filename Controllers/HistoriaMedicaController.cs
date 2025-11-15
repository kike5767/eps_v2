using System;
using System.ComponentModel.DataAnnotations;
using EPS.Entities;
using EPS.Services;
namespace EPS.Controllers {
    public class HistoriaMedicaController {
        private readonly IHistoriaMedicaService _service;
        public HistoriaMedicaController(IHistoriaMedicaService service) { _service = service; }
    }
}

