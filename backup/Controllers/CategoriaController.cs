using System;
using System.ComponentModel.DataAnnotations;
using EPS.Entities;
using EPS.Services;
namespace EPS.Controllers {
    public class CategoriaController {
        private readonly ICategoriaService _service;
        public CategoriaController(ICategoriaService service) { _service = service; }
    }
}

