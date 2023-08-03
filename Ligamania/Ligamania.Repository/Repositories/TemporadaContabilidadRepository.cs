using General.CrossCutting.Lib;

using Ligamania.Repository.Interfaces;
using Ligamania.Repository.Models;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ligamania.Repository.Repositories
{
    public class TemporadaContabilidadRepository : BaseRepository<TemporadaContabilidadDTO>, ITemporadaContabilidadRepository
    {
        public TemporadaContabilidadRepository(LigamaniaDbContext context) : base(context)
        {
        }

        public async Task<ICollection<TemporadaContabilidadDTO>> GetContabilidadByTemporada(int id)
        {
            ICollection<TemporadaContabilidadDTO> lista = await FindAllAsync(tc => tc.TemporadaId.Equals(id)).ConfigureAwait(false);
            return lista;
        }

        public async Task<ICollection<TemporadaContabilidadDTO>> GetContabilidades()
        {
            //ICollection<TemporadaContabilidadDTO> lista = await GetAllIncludingAsync(tc=>tc.Temporada)
            var lista = await this.DbSet
                .Include(t => t.Temporada)
                    .ThenInclude(tc => tc.TemporadaEquipo)
                        .ThenInclude(te => te.Equipo)
                    .ThenInclude(te => te.TemporadaEquipo)
                            .ThenInclude(te=>te.Competicion)
              .AsSplitQuery()
              .ToListAsync();

            return lista;
        }
    }
}