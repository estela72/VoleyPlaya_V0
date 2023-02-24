using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces
{
    public interface ITemporadaRondaRepository : IGenericAuditableIdRepository<TemporadaRondaDTO>
    {
        Task<List<TemporadaRondaDTO>> GetRondas(TemporadaDTO temporada, TemporadaCompeticionDTO temporadaCompeticion);
        Task<int> ActivarSiguienteRonda(TemporadaCompeticionDTO temporadaCompeticion);
        Task<List<string>> GetEquiposRondaActiva(TemporadaCompeticionDTO temporadaCompeticion);
    }
}
