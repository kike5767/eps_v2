using System;
using System.ComponentModel.DataAnnotations;
using EPS.Entities;
using EPS.Services;
namespace EPS.Controllers {
    public class IndicadorController {
        private readonly IIndicadorService _service;
        public IndicadorController(IIndicadorService service) { _service = service; }
    }
}

