using System.Collections.Generic;
using System.Threading.Tasks;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Base;

namespace LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces
{
    public interface ITemporadaCompeticionCategoriaReferenciaRepository : IGenericAuditableIdRepository<TemporadaCompeticionCategoriaReferenciaDTO>
    {
        Task<ICollection<TemporadaCompeticionCategoriaReferenciaDTO>> GetReferencias(int competicion_Id, int categoria_Id, bool usarMarca=true, string descripcionContains="");
    }
}
