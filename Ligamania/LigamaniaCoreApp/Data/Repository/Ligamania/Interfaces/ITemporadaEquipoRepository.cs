using System.Collections.Generic;
using System.Threading.Tasks;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Base;

namespace LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces
{
    public interface ITemporadaEquipoRepository : IGenericAuditableIdRepository<TemporadaEquipoDTO>
    {
        Task<ICollection<TemporadaEquipoDTO>> GetEquiposCompeticion(TemporadaCompeticionDTO temporadaCompeticion);
        Task<ICollection<TemporadaEquipoDTO>> GetEquiposTemporada(int temporadaId);
        Task<ICollection<TemporadaEquipoDTO>> GetEquiposTemporadaNoEnCompeticion(int temporadaId, string competicion);
        Task<ICollection<TemporadaEquipoDTO>> GetEquiposActivosUser(int temporadaId, string user);
        Task<TemporadaEquipoDTO> GetEquipoTemporada(int temporadaId, int competicionId, int categoriaId, int? equipoId);
    }
}
