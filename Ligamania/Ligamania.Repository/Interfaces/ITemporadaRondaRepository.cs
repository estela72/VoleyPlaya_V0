using General.CrossCutting.Lib;

using Ligamania.Repository.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ligamania.Repository.Interfaces
{
    public interface ITemporadaRondaRepository : IRepository<TemporadaRondaDTO>
    {
        Task<List<TemporadaRondaDTO>> GetRondas(TemporadaDTO temporada, TemporadaCompeticionDTO temporadaCompeticion);

        Task<int> ActivarSiguienteRonda(TemporadaCompeticionDTO temporadaCompeticion);

        Task<List<string>> GetEquiposRondaActiva(TemporadaCompeticionDTO temporadaCompeticion);
    }
}