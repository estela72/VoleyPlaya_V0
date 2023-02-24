using General.CrossCutting.Lib;

using Ligamania.Repository.Interfaces;
using Ligamania.Repository.Models;

namespace Ligamania.Repository.Repositories
{
    public class CambiosEquipoRepository : Repository<CambiosEquipoDTO>, ICambiosEquipoRepository
    {
        public CambiosEquipoRepository(LigamaniaDbContext context)
            : base(context)
        {
        }
    }
}