using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Torneo.Models;
using EquiposAFA.Servicios;

namespace Torneo.Controllers
{
    public class EquipoController : Controller
    {
        protected readonly IServicioSistema _servicioSistema;

        public EquipoController(IServicioSistema servicioSistema)
        {
            _servicioSistema = servicioSistema;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _servicioSistema.ObtenerEquiposAsync();
      
            return View(new EquipoViewModel(){ Equipos = items });
        }
    }
}