using General.CrossCutting.Lib;

using Ligamania.Repository.Interfaces;
using Ligamania.Repository.Models;

namespace Ligamania.Repository.Repositories
{
    public class OperacionCompeticionRepository : Repository<OperacionCompeticionDTO>, IOperacionCompeticionRepository
    {
        public OperacionCompeticionRepository(LigamaniaDbContext context)
            : base(context)
        {
        }
    }
}