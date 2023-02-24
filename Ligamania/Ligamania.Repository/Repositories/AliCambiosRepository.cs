using Ligamania.Repository.Interfaces;
using Ligamania.Repository.Models;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ligamania.Repository.Repositories
{
    public class AlineacionCambioRepository : AlineacionRepository<AlineacionCambioDTO>, IAlineacionCambiosRepository
    {
        public AlineacionCambioRepository(LigamaniaDbContext context)
            : base(context)
        {
        }

        public async Task<AlineacionCambioDTO> GetByJugador(int competicionId, int categoriaId, int equipoId, string jugador)
        {
            var ali = await FindAsync(a => a.Competicion_ID.Equals(competicionId) && a.Equipo_ID.Equals(equipoId) && a.Jugador != null && a.Jugador.Nombre.Equals(jugador)).ConfigureAwait(false);
            return ali;
        }

        public async Task<ICollection<AlineacionCambioDTO>> GetAllAlineacionesCompeticion(int competicionid)
        {
            IQueryable<AlineacionCambioDTO> alineaciones = FindAllQueryable(a => a.Competicion_ID.Equals(competicionid));
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