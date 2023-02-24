using General.CrossCutting.Lib;

using Ligamania.Repository.Interfaces;
using Ligamania.Repository.Models;

namespace Ligamania.Repository.Repositories
{
    public class CompeticionRepository : Repository<CompeticionDTO>, ICompeticionRepository
    {
        public CompeticionRepository(LigamaniaDbContext context)
            : base(context)
        {
        }
    }
}