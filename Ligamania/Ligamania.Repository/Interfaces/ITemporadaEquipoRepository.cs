using General.CrossCutting.Lib;

using Ligamania.Repository.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ligamania.Repository.Interfaces
{
    public interface ITemporadaEquipoRepository : IRepository<TemporadaEquipoDTO>
    {
        Task<ICollection<TemporadaEquipoDTO>> GetEquiposCompeticion(TemporadaCompeticionDTO temporadaCompeticion);

        Task<ICollection<TemporadaEquipoDTO>> GetEquiposTemporada(int temporadaId);

        Task<ICollection<TemporadaEquipoDTO>> GetEquiposTemporadaNoEnCompeticion(int temporadaId, string competicion);

        Task<ICollection<TemporadaEquipoDTO>> GetEquiposActivosUser(int temporadaId, string user);

        Task<TemporadaEquipoDTO> GetEquipoTemporada(int temporadaId, int competicionId, int categoriaId, int? equipoId);
    }
}