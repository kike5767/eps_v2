using System;
using System.ComponentModel.DataAnnotations;
using EPS.Entities;
using EPS.Services;
namespace EPS.Controllers {
    public class ReporteController {
        private readonly IReporteService _service;
        public ReporteController(IReporteService service) { _service = service; }
    }
}

