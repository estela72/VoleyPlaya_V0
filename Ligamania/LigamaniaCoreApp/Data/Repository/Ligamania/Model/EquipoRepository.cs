using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Base;
using LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Data.Repository.Ligamania.Model
{
    public class EquipoRepository : GenericAuditableNameRepository<EquipoDTO>, IEquipoRepository
    {
        public EquipoRepository(ApplicationDbContext context)
            : base(context)
        {

        }
        public async Task<ICollection<EquipoDTO>> GetEquiposActivos()
        {
            var equipos = await FindAllAsync(e => !e.Baja).ConfigureAwait(false);
            return equipos;
        }
    }
}
