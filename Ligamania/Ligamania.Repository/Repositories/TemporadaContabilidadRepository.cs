using General.CrossCutting.Lib;

using Ligamania.Repository.Interfaces;
using Ligamania.Repository.Models;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            try
            {
                var lista = await this.DbSet
                    .Include(t => t.Temporada)
                        .ThenInclude(tc => tc.TemporadaEquipo)
                            .ThenInclude(te => te.Equipo)
                        .ThenInclude(te => te.TemporadaEquipo)
                                .ThenInclude(te => te.Competicion)
                  .AsSplitQuery()
                  //.DistinctBy(l => l.Id)
                  .ToListAsync()
                  ;

                return lista;
            }
            catch (Exception x)
            {
                throw x;
            }
        }
    }
}