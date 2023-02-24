using General.CrossCutting.Lib;

using Ligamania.Repository.Interfaces;
using Ligamania.Repository.Models;

using System.Threading.Tasks;

namespace Ligamania.Repository.Repositories
{
    public class ClubRepository : Repository<ClubDTO>, IClubRepository
    {
        public ClubRepository(LigamaniaDbContext context)
            : base(context)
        {
        }

        public async Task<ClubDTO> Alta(string alias)
        {
            var club = await GetByAliasAsync(alias);
            if (club != null && club.Baja)
            {
                club.Baja = false;
                return await UpdateAsyn(club, club.Id);
            }
            return null;
        }

        public async Task<ClubDTO> Baja(string alias)
        {
            var club = await GetByAliasAsync(alias);
            if (club != null && !club.Baja)
            {
                club.Baja = true;
                return await UpdateAsyn(club, club.Id);
            }
            return null;
        }

        public ClubDTO GetByAlias(string alias)
        {
            var club = GetAsync(c => c.Alias.Equals(alias)).Result;
            return club;
        }

        public async Task<ClubDTO> GetByAliasAsync(string alias)
        {
            var club = await FindAsync(c => c.Alias.Equals(alias)).ConfigureAwait(false);
            return club;
        }
    }
}