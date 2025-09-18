using System;
using System.ComponentModel.DataAnnotations;
using EPS.Entities;
using EPS.Services;
namespace EPS.Controllers {
    public class PlanEPSController {
        private readonly IPlanEPSService _service;
        public PlanEPSController(IPlanEPSService service) { _service = service; }
    }
}

