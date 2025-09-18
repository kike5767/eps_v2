using System;
using System.ComponentModel.DataAnnotations;
using EPS.Entities;
using EPS.Services;
namespace EPS.Controllers {
    public class MunicipioController {
        private readonly IMunicipioService _service;
        public MunicipioController(IMunicipioService service) { _service = service; }
    }
}

