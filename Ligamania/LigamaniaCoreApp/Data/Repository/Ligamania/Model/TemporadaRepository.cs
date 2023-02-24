using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Base;
using LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static LigamaniaCoreApp.Data.LigamaniaEnum;

namespace LigamaniaCoreApp.Data.Repository.Ligamania.Model
{
    public class TemporadaRepository : GenericAuditableNameRepository<TemporadaDTO>, ITemporadaRepository
    {
        public TemporadaRepository(ApplicationDbContext context)
            : base(context)
        {

        }
        public TemporadaDTO GetActual()
        {
            return FindBy(t => t.Actual).FirstOrDefault();
        }
        public async Task<TemporadaDTO> GetActualAsync()
        {
            return await FindBy(t => t.Actual).SingleOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task<TemporadaDTO> GetPreTemporada()
        {
            // lo primero mirar si tenemos una temporada en estado 'PRETEMPORADA'
            // sino, devolvemos temporada actual
            TemporadaDTO temporada = await FindAsync(t => t.Estado.Equals(EEstadoTemporada.EnPretemporada.ToString())).ConfigureAwait(false);
            if (temporada == null) return await GetActualAsync().ConfigureAwait(false);
            return temporada;
            // si tenemos ya temporada actual, la retornamos
            // sino, miramos si hay una temporada cuyo estado sea 'EnPretemporada'
            //Temporada_DTO temporada = await FindAsync(t => t.Actual);
            //if (temporada == null)
            //    temporada = await FindAsync(t => t.Estado.Equals(eEstadoTemporada.EnPretemporada.ToString()));

            //return temporada;

            //IQueryable<Temporada_DTO> temporadas = FindAllQueryable(t => t.Estado.Equals(eEstadoTemporada.EnPretemporada.ToString()));
            //temporadas = temporadas.Include(t => t.TemporadaCompeticion).ThenInclude(tc => tc.Competicion);
            //if (temporadas.Any())
            //{
            //    return await temporadas.FirstOrDefaultAsync();
            //}
            //return null;
        }

        //public List<TemporadaCompeticion_DTO> GetCompeticionesActivas(int id)
        //{
        //    return _dbset
        //        .Include(t => t.TemporadaCompeticion)
        //        .Where(t => t.Id.Equals(id))
        //        .FirstOrDefault()
        //        .TemporadaCompeticion
        //        .Where(c=>c.Activa)
        //        .ToList();
        //}

        public IQueryable<byte[]> GetImg_Clasificacion(int id)
        {
            var img = from temp in _dbset where temp.Id == id select temp.ImgClasificacion;
            return img;
        }
        public IQueryable<byte[]> GetImg_Clasificacion(string temporada)
        {
            var img = from temp in _dbset where temp.Nombre.Equals(temporada) select temp.ImgClasificacion;
            return img;
        }

        public async Task<TemporadaDTO> GetUltimaTemporadaEnJuego()
        {
            var temporada = await FindAsync(t => t.Actual).ConfigureAwait(false);
            if (temporada == null)
            {
                var temps = await FindAllAsync(t => t.Estado.Equals(EEstadoTemporada.Cerrada.ToString())).ConfigureAwait(false);
                temps = temps.OrderBy(t => t.Nombre).ToList();
                temporada = temps.LastOrDefault();
            }
            return temporada;
        }
        public async Task<TemporadaDTO> GetTemporadaAnteriorAsync(TemporadaDTO temporada)
        {
            var temps = temporada.Nombre.Split('-');
            int.TryParse(temps[0], out int tact);

            string tprevStr = Convert.ToString(tact);

            var tempAnterior = await FindAsync(t => t.Nombre.EndsWith(tprevStr)).ConfigureAwait(false);
            return tempAnterior;
        }
    }
}
