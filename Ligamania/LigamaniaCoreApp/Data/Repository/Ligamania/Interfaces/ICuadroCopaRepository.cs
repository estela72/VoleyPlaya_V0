using System.Collections.Generic;
using System.Threading.Tasks;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.DataModels.Base.Model;
using LigamaniaCoreApp.Data.Repository.Base;

namespace LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces
{
    public interface ICuadroCopaRepository : IGenericAuditableIdRepository<CuadroCopaDTO>
    {
        Task<List<CuadroCopaDTO>> GetCuadro();
    }
}
