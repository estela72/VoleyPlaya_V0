using General.CrossCutting.Lib;

using Ligamania.Repository.Interfaces;
using Ligamania.Repository.Models;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ligamania.Repository.Repositories
{
    public class TemporadaRondaRepository : Repository<TemporadaRondaDTO>, ITemporadaRondaRepository
    {
        public TemporadaRondaRepository(LigamaniaDbContext context) : base(context)
        {
        }

        public async Task<List<TemporadaRondaDTO>> GetRondas(TemporadaDTO temporada, TemporadaCompeticionDTO temporadaCompeticion)
        {
            var rondas = await FindAllIncludingAsync(tr => tr.Temporada.Id.Equals(temporada.Id) && tr.Competicion.Equals(temporadaCompeticion.CompeticionId)
                , tr => tr.JornadaIda, tr => tr.JornadaVuelta).ConfigureAwait(false);
            return rondas.ToList();
        }

        public async Task<int> ActivarSiguienteRonda(TemporadaCompeticionDTO temporadaCompeticion)
        {
            TemporadaRondaDTO infoRonda = await FindIncludingAsync(tr => tr.Temporada.Actual && tr.CompeticionID.Equals(temporadaCompeticion.CompeticionId) && tr.Activa,
                tr => tr.JornadaIda, tr => tr.JornadaVuelta).ConfigureAwait(false);
            TemporadaRondaDTO rondaAActivar = null;
            if (infoRonda == null)
            {
                rondaAActivar = await FindIncludingAsync(tr => tr.Temporada.Actual && tr.CompeticionID.Equals(temporadaCompeticion.CompeticionId) && tr.NumRonda == 1,
                    tr => tr.JornadaIda, tr => tr.JornadaVuelta).ConfigureAwait(false);
            }
            else
            {
                rondaAActivar = await FindIncludingAsync(tr => tr.Temporada.Actual && tr.CompeticionID.Equals(temporadaCompeticion.CompeticionId) && tr.NumRonda == infoRonda.NumRonda + 1,
                    tr => tr.JornadaIda, tr => tr.JornadaVuelta).ConfigureAwait(false);
            }
            if (infoRonda != null) infoRonda.Activa = false;
            rondaAActivar.Activa = true;
            rondaAActivar.JornadaIdaActiva = true;
            rondaAActivar.JornadaIda.Actual = true;

            return rondaAActivar.NumRonda;
        }

        public Task<List<string>> GetEquiposRondaActiva(TemporadaCompeticionDTO temporadaCompeticion)
        {
            IQueryable<TemporadaRondaDTO> rondaActiva = FindAllQueryable(tr => tr.Temporada.Actual && tr.CompeticionID.Equals(temporadaCompeticion.CompeticionId) && tr.Activa);
            rondaActiva = rondaActiva
                .Include(h => h.JornadaIda).ThenInclude(j => j.TemporadaPartido).ThenInclude(tp => tp.EquipoA)
                .Include(h => h.JornadaIda).ThenInclude(j => j.TemporadaPartido).ThenInclude(tp => tp.EquipoB);

            IEnumerable<string> equiposA = rondaActiva.First().JornadaIda.TemporadaPartido.Select(tp => tp.EquipoA.Nombre);
            IEnumerable<string> equiposB = rondaActiva.First().JornadaIda.TemporadaPartido.Select(tp => tp.EquipoB.Nombre);
            List<string> equipos = equiposA.Union(equiposB).ToList();
            return Task.FromResult(equipos);
        }
    }
}