using System.Linq;
using System.Threading.Tasks;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Base;
using LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces;

using Microsoft.EntityFrameworkCore;
namespace LigamaniaCoreApp.Data.Repository.Ligamania.Model
{
    public class NoticiaRepository : GenericAuditableRepository<NoticiaDTO>, INoticiaRepository
    {
        public NoticiaRepository(ApplicationDbContext context)
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
