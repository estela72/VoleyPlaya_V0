using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Base;
using LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces;

using Microsoft.EntityFrameworkCore;
using static LigamaniaCoreApp.Data.LigamaniaEnum;

namespace LigamaniaCoreApp.Data.Repository.Ligamania.Model
{
    public class HistoricoRepository : GenericAuditableRepository<HistoricoDTO>, IHistoricoRepository
    {
        public HistoricoRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        public async Task<ICollection<HistoricoDTO>> GetHistoriaEquipo(string equipo)
        {
            IQueryable<HistoricoDTO> historial = FindAllQueryable(h => h.TemporadaEquipo.Equipo.Nombre.Equals(equipo));
            historial = historial
                .Include(h => h.Temporada)
                .Include(h => h.TemporadaEquipo).ThenInclude(te => te.Equipo)
                .Include(h => h.TemporadaCompeticionCategoria).ThenInclude(tcc => tcc.Competicion)
                .Include(h => h.TemporadaCompeticionCategoria).ThenInclude(tcc => tcc.Categoria);
            return await historial.ToListAsync().ConfigureAwait(false);
        }

        public async Task<ICollection<HistoricoDTO>> GetHistorial()
        {
            IQueryable<HistoricoDTO> historial = FindAllQueryable(h => h.Temporada.Estado.Equals(EEstadoTemporada.Cerrada.ToString()) || h.Temporada.Estado.Equals(EEstadoTemporada.Finalizada.ToString()));
            historial = historial
                .Include(h => h.Temporada)
                .Include(h => h.TemporadaEquipo).ThenInclude(te=>te.Equipo)
                .Include(h => h.TemporadaCompeticionCategoria).ThenInclude(tcc=>tcc.Competicion)
                .Include(h => h.TemporadaCompeticionCategoria).ThenInclude(tcc => tcc.Categoria);
            return await historial.ToListAsync().ConfigureAwait(false);
        }
    }
}
