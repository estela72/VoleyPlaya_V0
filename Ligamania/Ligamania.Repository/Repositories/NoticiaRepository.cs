using General.CrossCutting.Lib;

using Ligamania.Repository.Interfaces;
using Ligamania.Repository.Models;

using Microsoft.EntityFrameworkCore;

using System.Linq;
using System.Threading.Tasks;

namespace Ligamania.Repository.Repositories
{
    public class NoticiaRepository : Repository<NoticiaDTO>, INoticiaRepository
    {
        public NoticiaRepository(LigamaniaDbContext context)
            : base(context)
        {
        }

        public async Task<NoticiaDTO> GetLastNew()
        {
            var noticiasActivas = FindAllQueryable(n => n.Activa);
            if (noticiasActivas.Any())
            {
                var lastDate = await noticiasActivas.MaxAsync(n => n.Fecha).ConfigureAwait(false);
                var noticias = await FindAllAsync(n => n.Fecha.Equals(lastDate)).ConfigureAwait(false);
                return noticias.LastOrDefault();
            }
            return null;
        }
    }
}