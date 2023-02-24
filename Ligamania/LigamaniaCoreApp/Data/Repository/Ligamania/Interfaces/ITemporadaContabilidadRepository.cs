using System.Collections.Generic;
using System.Threading.Tasks;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Base;

namespace LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces
{
    public interface ITemporadaContabilidadRepository : IGenericAuditableIdRepository<TemporadaContabilidadDTO>
    {
        Task<ICollection<TemporadaContabilidadDTO>> GetContabilidadByTemporada(int id);
    }
}
