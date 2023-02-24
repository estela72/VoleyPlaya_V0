using System;
using System.Threading.Tasks;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Base.Model;
using LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LigamaniaCoreApp.Data.Repository.Ligamania.Model
{

    public class ClubRepository : GenericAuditableNameRepository<Club>, IClubRepository
    {
        public ClubRepository(DbContext context)
            : base(context)
        {

        }
        public Club GetByAlias(string name)
        {
            //return _dbset.FirstOrDefault(x => x.Alias.Equals(name));
            return Find(c => c.Alias.ToLower().Equals(name.ToLower()));
        }

        public async Task<Club> GetByAliasAsync(string name)
        {
            //return await _dbset.FirstOrDefaultAsync(x => x.Alias.Equals(name));
            return await FindAsync(c => c.Alias.ToLower().Equals(name.ToLower()));
        }
    }
}
