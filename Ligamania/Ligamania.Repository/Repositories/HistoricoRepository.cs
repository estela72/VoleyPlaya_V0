using General.CrossCutting.Lib;

using Ligamania.Generic.Lib.Enums;
using Ligamania.Repository.Interfaces;
using Ligamania.Repository.Models;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ligamania.Repository.Repositories
{
    public class HistoricoRepository : Repository<HistoricoDTO>, IHistoricoRepository
    {
        public HistoricoRepository(LigamaniaDbContext context)
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
            IQueryable<HistoricoDTO> historial = FindAllQueryable(h => h.Temporada.Estado.Equals(EstadoTemporada.Cerrada.ToString()) || h.Temporada.Estado.Equals(EstadoTemporada.Finalizada.ToString()));
            historial = historial
                .Include(h => h.Temporada)
                .Include(h => h.TemporadaEquipo).ThenInclude(te => te.Equipo)
                .Include(h => h.TemporadaCompeticionCategoria).ThenInclude(tcc => tcc.Competicion)
                .Include(h => h.TemporadaCompeticionCategoria).ThenInclude(tcc => tcc.Categoria);
            return await historial.ToListAsync().ConfigureAwait(false);
        }
    }
}