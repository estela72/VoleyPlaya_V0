using General.CrossCutting.Lib;

using Ligamania.Repository.Interfaces;
using Ligamania.Repository.Models;

namespace Ligamania.Repository.Repositories
{
    public class TemporadaCompeticionOperacionRepository : Repository<TemporadaCompeticionOperacionDTO>, ITemporadaCompeticionOperacionRepository
    {
        public TemporadaCompeticionOperacionRepository(LigamaniaDbContext context)
            : base(context)
        {
        }
    }
}