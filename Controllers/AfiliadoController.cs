using System;
using System.ComponentModel.DataAnnotations;
using EPS.Entities;
using EPS.Services;
namespace EPS.Controllers {
    public class AfiliadoController {
        private readonly IAfiliadoService _service;
        public AfiliadoController(IAfiliadoService service) { _service = service; }
    }
}

