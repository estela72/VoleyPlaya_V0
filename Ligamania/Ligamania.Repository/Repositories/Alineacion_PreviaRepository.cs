using Ligamania.Repository.Interfaces;
using Ligamania.Repository.Models;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ligamania.Repository.Repositories
{
    public class AlineacionPreviaRepository : AlineacionRepository<AlineacionPreviaDTO>, IAlineacionPreviaRepository
    {
        public AlineacionPreviaRepository(LigamaniaDbContext context)
            : base(context)
        {
        }

        public async Task<ICollection<AlineacionPreviaDTO>> GetAllAlineacionesCompeticion(int competicionid)
        {
            IQueryable<AlineacionPreviaDTO> alineaciones = FindAllQueryable(a => a.Competicion_ID.Equals(competicionid));
            alineaciones = alineaciones
                .Include(h => h.Competicion)
                .Include(h => h.Categoria)
                .Include(h => h.Equipo).ThenInclude(te => te.Equipo)
                .Include(h => h.Jugador)
                .Include(h => h.Club)
                .Include(h => h.Puesto);
            return await alineaciones.ToListAsync().ConfigureAwait(false);
        }
    }
}