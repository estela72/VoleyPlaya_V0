using System.Collections.Generic;
using System.Threading.Tasks;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.DataModels.Base.Model;
using LigamaniaCoreApp.Data.Repository.Base;

namespace LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces
{
    public interface IAlineacionRepository : IAlineacionGenericAuditableRepository<AlineacionDTO>
    {
        Task<ICollection<AlineacionDTO>> GetAlineaciones(TemporadaDTO temporada, TemporadaCompeticionDTO temporadaCompeticion, TemporadaCompeticionJornadaDTO jornada);
        Task<ICollection<AlineacionDTO>> GetAlineacionesEquipo(TemporadaCompeticionJornadaDTO jornada, int temporadaEquipoId);
        Task<ICollection<AlineacionDTO>> GetAlineaciones(TemporadaDTO temporada, TemporadaCompeticionDTO temporadaCompeticion, TemporadaCompeticionJornadaDTO jornada, List<string> equipos);
        Task<List<AlineacionDTO>> GetAllAlineacionesEquipo(int competicionId, string nombreEquipo);
    }
}
