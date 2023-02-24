using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Base;
using LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Data.Repository.Ligamania.Model
{
    public class TemporadaContabilidadRepository : GenericAuditableRepository<TemporadaContabilidadDTO>, ITemporadaContabilidadRepository
    {
        public TemporadaContabilidadRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<ICollection<TemporadaContabilidadDTO>> GetContabilidadByTemporada(int id)
        {
            ICollection<TemporadaContabilidadDTO> lista = await FindAllAsync(tc => tc.TemporadaId.Equals(id)).ConfigureAwait(false);
            return lista;
        }

    }
}
