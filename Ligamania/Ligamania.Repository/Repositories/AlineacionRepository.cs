using Ligamania.Repository.Interfaces;
using Ligamania.Repository.Models;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ligamania.Repository.Repositories
{
    public class AlineacionRepository : AlineacionRepository<AlineacionDTO>, IAlineacionRepository
    {
        public AlineacionRepository(LigamaniaDbContext context)
            : base(context)
        {
        }

        public async Task<ICollection<AlineacionDTO>> GetAlineaciones(TemporadaDTO temporada, TemporadaCompeticionDTO temporadaCompeticion, TemporadaCompeticionJornadaDTO jornadaCarrusel)
        {
            //ICollection<Alineacion_DTO> alineaciones = await FindAllIncludingAsync
            //    (a => a.Temporada_ID.Equals(temporada.Id) && a.Competicion_ID.Equals(temporadaCompeticion.Competicion.Id)
            //    && a.Jornada_ID.Equals(jornadaCarrusel.Id), a=>a.Competicion, a=>a.Categoria, a=>a.Equipo, a=>a.Jugador, a=>a.Club, a=>a.Puesto);
            // return alineaciones;

            IQueryable<AlineacionDTO> alineaciones = FindAllQueryable(a => a.Temporada_ID.Equals(temporada.Id) && a.Competicion_ID.Equals(temporadaCompeticion.Competicion.Id)
                && a.Jornada_ID.Equals(jornadaCarrusel.Id));
            alineaciones = alineaciones
                .Include(h => h.Competicion)
                .Include(h => h.Categoria)
                .Include(h => h.Jornada)
                .Include(h => h.Equipo).ThenInclude(te => te.Equipo)
                .Include(h => h.Jugador)
                .Include(h => h.Club)
                .Include(h => h.Puesto);
            return await alineaciones.ToListAsync().ConfigureAwait(false);
        }

        public async Task<ICollection<AlineacionDTO>> GetAlineacionesEquipo(TemporadaCompeticionJornadaDTO jornada, int temporadaEquipoId)
        {
            ICollection<AlineacionDTO> alineaciones = await FindAllIncludingAsync(a => a.Jornada_ID.Equals(jornada.Id) && a.Equipo_ID.Equals(temporadaEquipoId),
                a => a.Jugador).ConfigureAwait(false);
            return alineaciones;
        }

        public async Task<ICollection<AlineacionDTO>> GetAlineaciones(TemporadaDTO temporada,
            TemporadaCompeticionDTO temporadaCompeticion,
            TemporadaCompeticionJornadaDTO jornada,
            List<string> equipos)
        {
            List<AlineacionDTO> alineaciones = new List<AlineacionDTO>();
            if (equipos == null) return alineaciones;
            foreach (var equipo in equipos)
            {
                IQueryable<AlineacionDTO> aliEquipo = FindAllQueryable(a => a.Temporada_ID.Equals(temporada.Id)
                    && a.Competicion_ID.Equals(temporadaCompeticion.Competicion.Id)
                    && a.Jornada_ID.Equals(jornada.Id)
                    && a.Equipo.Equipo.Nombre.Equals(equipo));
                aliEquipo = aliEquipo
                    .Include(h => h.Competicion)
                    .Include(h => h.Categoria)
                    .Include(h => h.Jornada)
                    .Include(h => h.Equipo).ThenInclude(te => te.Equipo)
                    .Include(h => h.Jugador)
                    .Include(h => h.Club)
                    .Include(h => h.Puesto);
                alineaciones.AddRange(aliEquipo.ToList());
            }
            return await Task.FromResult(alineaciones).ConfigureAwait(false);
        }

        public async Task<List<AlineacionDTO>> GetAllAlineacionesEquipo(int competicionId, string nombreEquipo)
        {
            IQueryable<AlineacionDTO> alineaciones = FindAllQueryable(a => a.Temporada.Actual && a.Competicion_ID.Equals(competicionId)
                && a.Equipo.Equipo.Nombre.Equals(nombreEquipo));
            alineaciones = alineaciones
                .Include(h => h.Competicion)
                .Include(h => h.Categoria)
                .Include(h => h.Jornada)
                .Include(h => h.Equipo).ThenInclude(te => te.Equipo)
                .Include(h => h.Jugador)
                .Include(h => h.Club)
                .Include(h => h.Puesto);
            return await alineaciones.ToListAsync().ConfigureAwait(false);
        }
    }
}