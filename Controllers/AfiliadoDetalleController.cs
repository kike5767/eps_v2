using System;
using System.ComponentModel.DataAnnotations;
using EPS.Entities;
using EPS.Services;
namespace EPS.Controllers {
    public class AfiliadoDetalleController {
        private readonly IAfiliadoDetalleService _service;
        public AfiliadoDetalleController(IAfiliadoDetalleService service) { _service = service; }
    }
}

