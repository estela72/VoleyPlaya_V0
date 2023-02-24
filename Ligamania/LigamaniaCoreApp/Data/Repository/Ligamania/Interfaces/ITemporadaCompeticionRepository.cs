using System.Collections.Generic;
using System.Threading.Tasks;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Base;

namespace LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces
{

    public interface ITemporadaCompeticionRepository : IGenericAuditableIdRepository<TemporadaCompeticionDTO>
    {
        Task<ICollection<TemporadaCompeticionDTO>> GetCompeticiones();
        Task<ICollection<TemporadaCompeticionDTO>> GetCompeticionesActivas();
        Task<ICollection<TemporadaCompeticionDTO>> GetCompeticionesActivas(TemporadaDTO temporada);   // en una temporada dada
        //Task<TemporadaCompeticionDTO> GetCompeticion(int temporadaId, LigamaniaEnum.eTipoCompeticion tipoCompeticion);
        Task<TemporadaCompeticionDTO> GetLiga(int temporadaId);
        Task<TemporadaCompeticionDTO> GetCompeticion(int temporadaId, int idCompeticion);
        Task<TemporadaCompeticionDTO> GetCompeticion(int temporadaId, string competicion);
        Task SetEstadoActualAsync(TemporadaCompeticionDTO temporadaCompeticion, EstadoCompeticionDTO regEstado, OperacionCompeticionDTO regOperacion, string descripcion);
    }
}
