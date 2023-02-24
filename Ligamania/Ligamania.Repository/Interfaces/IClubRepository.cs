using General.CrossCutting.Lib;

using Ligamania.Repository.Models;

using System.Threading.Tasks;

namespace Ligamania.Repository.Interfaces
{
    public interface IClubRepository : IRepository<ClubDTO>
    {
        ClubDTO GetByAlias(string alias);

        Task<ClubDTO> GetByAliasAsync(string alias);
        Task<ClubDTO> Baja(string alias);
        Task<ClubDTO> Alta(string alias);
    }
}