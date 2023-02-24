using General.CrossCutting.Lib;

using Ligamania.Repository.Interfaces;
using Ligamania.Repository.Models;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ligamania.Repository.Repositories
{
    public class TemporadaPremiosRepository : Repository<TemporadaPremiosDTO>, ITemporadaPremiosRepository
    {
        public TemporadaPremiosRepository(LigamaniaDbContext context) : base(context)
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