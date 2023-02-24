using General.CrossCutting.Lib;

using Ligamania.Repository.Interfaces;
using Ligamania.Repository.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ligamania.Repository.Repositories
{
    public class TemporadaPartidoRepository : Repository<TemporadaPartidoDTO>, ITemporadaPartidoRepository
    {
        public TemporadaPartidoRepository(LigamaniaDbContext context)
            : base(context)
        {
        }

        public async Task<ICollection<TemporadaPartidoDTO>> GetPartidos(TemporadaDTO temporada, TemporadaCompeticionDTO competicion, TemporadaCompeticionJornadaDTO jornada = null)
        {
            if (jornada != null)
            {
                var partidos = await FindAllIncludingAsync(tp => tp.TemporadaId.Equals(temporada.Id)
                    && tp.CompeticionId.Equals(competicion.Competicion.Id) && tp.JornadaId.Equals(jornada.Id),
                    tp => tp.Categoria, tp => tp.EquipoA, tp => tp.EquipoB, tp => tp.EquipoGanador).ConfigureAwait(false);
                return partidos;
            }
            else
            {
                var partidos = await FindAllIncludingAsync(tp => tp.TemporadaId.Equals(temporada.Id)
                    && tp.CompeticionId.Equals(competicion.Competicion.Id),
                    tp => tp.Categoria, tp => tp.EquipoA, tp => tp.EquipoB, tp => tp.EquipoGanador).ConfigureAwait(false);
                return partidos;
            }
        }
    }
}