using System.Collections.Generic;
using Torneo.Models;
using System.Threading.Tasks;

namespace EquiposAFA.Servicios
{
    public interface IServicioSistema
    {
        Task<List<Equipo>> ObtenerEquiposAsync();
    }
}