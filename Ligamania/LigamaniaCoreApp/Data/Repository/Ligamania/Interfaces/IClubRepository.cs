using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Base;

using System.Threading.Tasks;

namespace LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces
{

    public interface IClubRepository : IGenericAuditableNameRepository<ClubDTO>
    {
        ClubDTO GetByAlias(string alias);
        Task<ClubDTO> GetByAliasAsync(string alias);
    }
}
