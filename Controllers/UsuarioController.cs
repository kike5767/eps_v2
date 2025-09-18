using System;
using System.ComponentModel.DataAnnotations;
using EPS.Entities;
using EPS.Services;
namespace EPS.Controllers {
    public class UsuarioController {
        private readonly IUsuarioService _service;
        public UsuarioController(IUsuarioService service) { _service = service; }
    }
}

