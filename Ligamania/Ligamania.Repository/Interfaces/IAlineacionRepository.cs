using General.CrossCutting.Lib;

using Ligamania.Repository.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ligamania.Repository.Interfaces
{
    public interface IAlineacionRepository : IRepository<AlineacionDTO>
    {
        Task<ICollection<AlineacionDTO>> GetAlineaciones(TemporadaDTO temporada, TemporadaCompeticionDTO temporadaCompeticion, TemporadaCompeticionJornadaDTO jornada);

        Task<ICollection<AlineacionDTO>> GetAlineacionesEquipo(TemporadaCompeticionJornadaDTO jornada, int temporadaEquipoId);

        Task<ICollection<AlineacionDTO>> GetAlineaciones(TemporadaDTO temporada, TemporadaCompeticionDTO temporadaCompeticion, TemporadaCompeticionJornadaDTO jornada, List<string> equipos);

        Task<List<AlineacionDTO>> GetAllAlineacionesEquipo(int competicionId, string nombreEquipo);
    }
}