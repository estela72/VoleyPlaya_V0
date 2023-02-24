using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Base;
using LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Data.Repository.Ligamania.Model
{
    public class TemporadaPartidoRepository : GenericAuditableRepository<TemporadaPartidoDTO>, ITemporadaPartidoRepository
    {
        public TemporadaPartidoRepository(ApplicationDbContext context)
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
