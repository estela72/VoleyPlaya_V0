using General.CrossCutting.Lib;

using Ligamania.Repository.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ligamania.Repository.Interfaces
{
    public interface ITemporadaPartidoRepository : IRepository<TemporadaPartidoDTO>
    {
        Task<ICollection<TemporadaPartidoDTO>> GetPartidos(TemporadaDTO temporada, TemporadaCompeticionDTO competicion, TemporadaCompeticionJornadaDTO jornada = null);
    }
}