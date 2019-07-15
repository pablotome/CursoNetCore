using System;

namespace Torneo.Models
{
    public class Equipo
    {
        public Guid CodEquipo { get; set; }

        public string Nombre { get; set; }

        public int Puntos { get; set; }

        /* public Equipo(Guid CodEquipo, int Puntos, string nombre)
        {
            this.CodEquipo = CodEquipo;
            this.Nombre = nombre;
        }*/
    }
}