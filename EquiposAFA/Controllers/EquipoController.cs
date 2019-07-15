using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Torneo.Models;

namespace Torneo.Controllers
{
    public class EquipoController : Controller
    {
        public IActionResult Index()
        {
            EquipoViewModel evm = new EquipoViewModel();
            evm.Equipos = GetEquipos();
            return View(evm);
        }

        protected List<Equipo> GetEquipos()
        {
            List<Equipo> equipos = new List<Equipo>();

            equipos.Add(new Equipo(){ CodEquipo = Guid.NewGuid(), Puntos = 0, Nombre = "Club Atlético Aldosivi"});
            equipos.Add(new Equipo(){ CodEquipo = Guid.NewGuid(), Puntos = 0, Nombre = "Asociación Atlética Argentinos Juniors"});
            equipos.Add(new Equipo(){ CodEquipo = Guid.NewGuid(), Puntos = 0, Nombre = "Arsenal Fútbol Club"});
            equipos.Add(new Equipo(){ CodEquipo = Guid.NewGuid(), Puntos = 0, Nombre = "Club Atlético Tucumán"});
            equipos.Add(new Equipo(){ CodEquipo = Guid.NewGuid(), Puntos = 0, Nombre = "Club Atlético Banfield"});
            equipos.Add(new Equipo(){ CodEquipo = Guid.NewGuid(), Puntos = 0, Nombre = "Club Atlético Boca Juniors"});
            equipos.Add(new Equipo(){ CodEquipo = Guid.NewGuid(), Puntos = 0, Nombre = "Club Atlético Central Córdoba"});
            equipos.Add(new Equipo(){ CodEquipo = Guid.NewGuid(), Puntos = 0, Nombre = "Club Atlético Colón"});
            equipos.Add(new Equipo(){ CodEquipo = Guid.NewGuid(), Puntos = 0, Nombre = "Club Social y Deportivo Defensa y Justicia"});
            equipos.Add(new Equipo(){ CodEquipo = Guid.NewGuid(), Puntos = 0, Nombre = "Club Estudiantes de La Plata"});
            equipos.Add(new Equipo(){ CodEquipo = Guid.NewGuid(), Puntos = 0, Nombre = "Club de Gimnasia y Esgrima La Plata"});
            equipos.Add(new Equipo(){ CodEquipo = Guid.NewGuid(), Puntos = 0, Nombre = "Club Deportivo Godoy Cruz Antonio Tomba"});
            equipos.Add(new Equipo(){ CodEquipo = Guid.NewGuid(), Puntos = 0, Nombre = "Club Atlético Huracán"});
            equipos.Add(new Equipo(){ CodEquipo = Guid.NewGuid(), Puntos = 0, Nombre = "Club Atlético Independiente"});
            equipos.Add(new Equipo(){ CodEquipo = Guid.NewGuid(), Puntos = 0, Nombre = "Club Atlético Lanús"});
            equipos.Add(new Equipo(){ CodEquipo = Guid.NewGuid(), Puntos = 0, Nombre = "Club Atlético Newell's Old Boys"});
            equipos.Add(new Equipo(){ CodEquipo = Guid.NewGuid(), Puntos = 0, Nombre = "Club Atlético Patronato de la Juventud Católica"});
            equipos.Add(new Equipo(){ CodEquipo = Guid.NewGuid(), Puntos = 0, Nombre = "Racing Club"});
            equipos.Add(new Equipo(){ CodEquipo = Guid.NewGuid(), Puntos = 0, Nombre = "Club Atlético River Plate"});
            equipos.Add(new Equipo(){ CodEquipo = Guid.NewGuid(), Puntos = 0, Nombre = "Club Atlético Rosario Central"});
            equipos.Add(new Equipo(){ CodEquipo = Guid.NewGuid(), Puntos = 0, Nombre = "Club Atlético San Lorenzo de Almagro"});
            equipos.Add(new Equipo(){ CodEquipo = Guid.NewGuid(), Puntos = 0, Nombre = "Club Atlético Talleres"});
            equipos.Add(new Equipo(){ CodEquipo = Guid.NewGuid(), Puntos = 0, Nombre = "Club Atlético Unión"});
            equipos.Add(new Equipo(){ CodEquipo = Guid.NewGuid(), Puntos = 0, Nombre = "Club Atlético Vélez Sarsfield"});

            return equipos;
        }
    }
}