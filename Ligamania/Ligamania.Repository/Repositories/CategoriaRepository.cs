using General.CrossCutting.Lib;

using Ligamania.Repository.Interfaces;
using Ligamania.Repository.Models;

namespace Ligamania.Repository.Repositories
{
    public class CategoriaRepository : Repository<CategoriaDTO>, ICategoriaRepository
    {
        public CategoriaRepository(LigamaniaDbContext context)
            : base(context)
        {
        }
    }
}