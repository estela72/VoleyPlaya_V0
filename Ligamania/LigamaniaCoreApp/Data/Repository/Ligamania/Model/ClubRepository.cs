using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Base;
using LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces;

using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Data.Repository.Ligamania.Model
{
    public class ClubRepository : GenericAuditableNameRepository<ClubDTO>, IClubRepository
    {
        public ClubRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        public ClubDTO GetByAlias(string alias)
        {
            var club = Find(c => c.Alias.Equals(alias));
            return club;
        }

        public async Task<ClubDTO> GetByAliasAsync(string alias)
        {
            var club = await FindAsync(c => c.Alias.Equals(alias)).ConfigureAwait(false);
            return club;
        }
    }
}
