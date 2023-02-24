using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LigamaniaCoreApp.Data.Repository.Ligamania.Model
{
    public class AlineacionPreviaRepository : AlineacionGenericAuditableRepository<AlineacionPreviaDTO>, IAlineacionPreviaRepository
    {
        public AlineacionPreviaRepository(ApplicationDbContext context)
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
