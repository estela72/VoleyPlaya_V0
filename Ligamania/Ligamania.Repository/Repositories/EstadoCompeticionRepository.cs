using General.CrossCutting.Lib;

using Ligamania.Repository.Interfaces;
using Ligamania.Repository.Models;

namespace Ligamania.Repository.Repositories
{
    public class EstadoCompeticionRepository : Repository<EstadoCompeticionDTO>, IEstadoCompeticionRepository
    {
        public EstadoCompeticionRepository(LigamaniaDbContext context)
            : base(context)
        {
        }
    }
}