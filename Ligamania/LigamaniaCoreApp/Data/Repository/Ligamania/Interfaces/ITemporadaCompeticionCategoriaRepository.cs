using System.Collections.Generic;
using System.Threading.Tasks;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Base;

namespace LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces
{
    public interface ITemporadaCompeticionCategoriaRepository : IGenericAuditableIdRepository<TemporadaCompeticionCategoriaDTO>
    {
        Task<ICollection<TemporadaCompeticionCategoriaDTO>> GetCategorias(TemporadaCompeticionDTO temporadaCompeticion);
        Task<TemporadaCompeticionCategoriaDTO> GetCategoria(int idTemporada, int idCompeticion, int idCategoria);
    }
}
