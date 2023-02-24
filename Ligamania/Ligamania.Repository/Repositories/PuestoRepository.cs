using General.CrossCutting.Lib;

using Ligamania.Repository.Interfaces;
using Ligamania.Repository.Models;

namespace Ligamania.Repository.Repositories
{
    public class PuestoRepository : Repository<PuestoDTO>, IPuestoRepository
    {
        public PuestoRepository(LigamaniaDbContext context)
              : base(context)
        {
        }
    }
}