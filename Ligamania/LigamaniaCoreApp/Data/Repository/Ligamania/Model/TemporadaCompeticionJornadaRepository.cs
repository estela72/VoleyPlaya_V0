using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.DataModels.Base.Model;
using LigamaniaCoreApp.Data.Repository.Base;
using LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces;

using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace LigamaniaCoreApp.Data.Repository.Ligamania.Model
{
    public class TemporadaCompeticionJornadaRepository : GenericAuditableRepository<TemporadaCompeticionJornadaDTO>, ITemporadaCompeticionJornadaRepository
    {
        public TemporadaCompeticionJornadaRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        public async Task<TemporadaCompeticionJornadaDTO> GetJornadaActual(int competicionId, string nombreTemporada = "")
        {
            TemporadaCompeticionJornadaDTO jornada = null;
            if (nombreTemporada.Equals(string.Empty))
            {
                jornada = await FindAsync(tcj => tcj.Temporada.Actual && tcj.CompeticionId.Equals(competicionId) && tcj.Actual).ConfigureAwait(false);
            }
            else
            {
                jornada = await FindAsync(tcj => tcj.Temporada.Nombre.Equals(nombreTemporada) && tcj.CompeticionId.Equals(competicionId) && tcj.Actual).ConfigureAwait(false);
            }
            return jornada;
        }

        public async Task<TemporadaCompeticionJornadaDTO> GetJornadaCarrusel(int competicionId, string nombreTemporada="")
        {
            TemporadaCompeticionJornadaDTO jornada = null;
            if (nombreTemporada.Equals(string.Empty))
            {
                jornada = await FindAsync(tcj => tcj.Temporada.Actual && tcj.CompeticionId.Equals(competicionId) && tcj.Carrusel).ConfigureAwait(false);
            }
            else
            {
                jornada = await FindAsync(tcj => tcj.Temporada.Nombre.Equals(nombreTemporada) && tcj.CompeticionId.Equals(competicionId) && tcj.Carrusel).ConfigureAwait(false);
            }
            return jornada;
        }

        //public async Task<TemporadaCompeticionJornadaDTO> GetJornadaActualWithPartidos(int competicionId, string nombreTemporada = "")
        //{
        //    TemporadaCompeticionJornadaDTO jornada = null;
        //    if (nombreTemporada.Equals(string.Empty))
        //    {
        //        jornada = await FindIncludingAsync(tcj => tcj.Temporada.Actual && tcj.CompeticionId.Equals(competicionId) && tcj.Actual, tcj=>tcj.TemporadaPartido).ConfigureAwait(false);
        //    }
        //    else
        //    {
        //        jornada = await FindIncludingAsync(tcj => tcj.Temporada.Nombre.Equals(nombreTemporada) && tcj.CompeticionId.Equals(competicionId) && tcj.Actual, tcj => tcj.TemporadaPartido).ConfigureAwait(false);
        //    }
        //    return jornada;
        //}

        //public async Task<TemporadaCompeticionJornadaDTO> GetJornadaCarruselWithPartidos(int competicionId, string nombreTemporada = "")
        //{
        //    TemporadaCompeticionJornadaDTO jornada = null;
        //    if (nombreTemporada.Equals(string.Empty))
        //    {
        //        jornada = await FindIncludingAsync(tcj => tcj.Temporada.Actual && tcj.CompeticionId.Equals(competicionId) && tcj.Carrusel, tcj => tcj.TemporadaPartido).ConfigureAwait(false);
        //    }
        //    else
        //    {
        //        jornada = await FindIncludingAsync(tcj => tcj.Temporada.Nombre.Equals(nombreTemporada) && tcj.CompeticionId.Equals(competicionId) && tcj.Carrusel, tcj => tcj.TemporadaPartido).ConfigureAwait(false);
        //    }
        //    return jornada;
        //}

        public async Task<TemporadaCompeticionJornadaDTO> GetLastJornada(int competicionId, string nombreTemporada = "")
        {
            ICollection<TemporadaCompeticionJornadaDTO> jornadas = null;
            if (nombreTemporada.Equals(string.Empty))
            {
                jornadas = await FindAllAsync(tcj => tcj.Temporada.Actual && tcj.CompeticionId.Equals(competicionId)).ConfigureAwait(false);
            }
            else
            {
                jornadas = await FindAllAsync(tcj => tcj.Temporada.Nombre.Equals(nombreTemporada) && tcj.CompeticionId.Equals(competicionId)).ConfigureAwait(false);
            }
            if (jornadas == null || !jornadas.Any())
                return null;

            var maxJornada = jornadas.Max(tcj=>tcj.NumeroJornada);
            var jornada = jornadas.SingleOrDefault(tcj => tcj.NumeroJornada.Equals(maxJornada));
            return jornada;
        }
        public async Task<TemporadaCompeticionJornadaDTO> GetJornadaClasificacion(string nombreTemporada, int competicionId)
        {
            TemporadaCompeticionJornadaDTO jornada;
            jornada = await GetJornadaCarrusel(competicionId, nombreTemporada).ConfigureAwait(false);
            if (jornada == null) jornada = await GetJornadaActual(competicionId, nombreTemporada).ConfigureAwait(false);
            if (jornada == null) jornada = await GetLastJornada(competicionId, nombreTemporada).ConfigureAwait(false);
            return jornada;
        }
        public async Task<TemporadaCompeticionJornadaDTO> GetJornada(int temporadaId, int competicionId, int numJornada)
        {
            TemporadaCompeticionJornadaDTO jornada = await FindAsync(tcj => tcj.TemporadaId.Equals(temporadaId) && tcj.CompeticionId.Equals(competicionId) && tcj.NumeroJornada.Equals(numJornada)).ConfigureAwait(false);
            return jornada;
        }
        public async Task IncrementarJornadaActual(TemporadaCompeticionDTO temporadaCompeticion, TemporadaCompeticionJornadaDTO jornada)
        {
            var siguienteJornada = await FindAsync(tcj => tcj.TemporadaId.Equals(temporadaCompeticion.TemporadaId) 
                    && tcj.CompeticionId.Equals(temporadaCompeticion.CompeticionId) && tcj.NumeroJornada.Equals(jornada.NumeroJornada+1)).ConfigureAwait(false);
            if (siguienteJornada != null)
            {
                jornada.Actual = false;
                siguienteJornada.Actual = true;
                await UpdateAsyn(jornada,jornada.Id).ConfigureAwait(false);
                await UpdateAsyn(siguienteJornada, siguienteJornada.Id).ConfigureAwait(false);
            }
        }
    }
}
