using General.CrossCutting.Lib;

using Ligamania.Repository.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ligamania.Repository.Interfaces
{
    public interface ITemporadaCompeticionRepository : IBaseRepository<TemporadaCompeticionDTO>
    {
        Task<ICollection<TemporadaCompeticionDTO>> GetCompeticiones();

        Task<ICollection<TemporadaCompeticionDTO>> GetCompeticionesActivas();

        Task<ICollection<TemporadaCompeticionDTO>> GetCompeticionesActivas(TemporadaDTO temporada);   // en una temporada dada

        //Task<TemporadaCompeticionDTO> GetCompeticion(int temporadaId, LigamaniaEnum.eTipoCompeticion tipoCompeticion);
        Task<TemporadaCompeticionDTO> GetLiga(int temporadaId);

        Task<TemporadaCompeticionDTO> GetCompeticion(int temporadaId, int idCompeticion);

        Task<TemporadaCompeticionDTO> GetCompeticion(int temporadaId, string competicion);

        Task SetEstadoActualAsync(TemporadaCompeticionDTO temporadaCompeticion, EstadoCompeticionDTO regEstado, OperacionCompeticionDTO regOperacion, string descripcion);
        Task<ICollection<TemporadaCompeticionDTO>> GetCompeticionesByTemporada(int idTemporada);
    }
}