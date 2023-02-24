using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Base;
using LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Data.Repository.Ligamania.Model
{
    public class TemporadaPremiosRepository : GenericAuditableRepository<TemporadaPremiosDTO>, ITemporadaPremiosRepository
    {
        public TemporadaPremiosRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<ICollection<TemporadaPremiosDTO>> GetPremiosByTemporada(int id)
        {
            IQueryable<TemporadaPremiosDTO> premios = FindAllQueryable(tp => tp.Categoria.TemporadaId.Equals(id));
            if (premios.Any())
            {
                premios = premios
                    .Include(tp => tp.Categoria).ThenInclude(tcc => tcc.Competicion)
                    .Include(tp => tp.Categoria).ThenInclude(tcc => tcc.Categoria)
                    .Include(tp => tp.TemporadaPremiosPuesto)
                    ;
                return await premios.ToListAsync().ConfigureAwait(false);
            }
            return null;
        }
    }
}
