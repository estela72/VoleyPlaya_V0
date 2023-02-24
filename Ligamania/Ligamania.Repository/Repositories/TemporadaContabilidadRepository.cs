using General.CrossCutting.Lib;

using Ligamania.Repository.Interfaces;
using Ligamania.Repository.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ligamania.Repository.Repositories
{
    public class TemporadaContabilidadRepository : Repository<TemporadaContabilidadDTO>, ITemporadaContabilidadRepository
    {
        public TemporadaContabilidadRepository(LigamaniaDbContext context) : base(context)
        {
        }

        public async Task<ICollection<TemporadaContabilidadDTO>> GetContabilidadByTemporada(int id)
        {
            ICollection<TemporadaContabilidadDTO> lista = await FindAllAsync(tc => tc.TemporadaId.Equals(id)).ConfigureAwait(false);
            return lista;
        }
    }
}