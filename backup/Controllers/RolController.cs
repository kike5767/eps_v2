using System;
using System.ComponentModel.DataAnnotations;
using EPS.Entities;
using EPS.Services;
namespace EPS.Controllers {
    public class RolController {
        private readonly IRolService _service;
        public RolController(IRolService service) { _service = service; }
    }
}

