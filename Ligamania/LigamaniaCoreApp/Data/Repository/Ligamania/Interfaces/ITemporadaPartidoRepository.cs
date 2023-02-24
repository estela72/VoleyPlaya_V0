using System.Collections.Generic;
using System.Threading.Tasks;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Base;
using LigamaniaCoreApp.Models.ManagerViewModels;

namespace LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces
{
    public interface ITemporadaPartidoRepository : IGenericAuditableIdRepository<TemporadaPartidoDTO>
    {
        Task<ICollection<TemporadaPartidoDTO>> GetPartidos(TemporadaDTO temporada, TemporadaCompeticionDTO competicion, TemporadaCompeticionJornadaDTO jornada=null);
    }
}
