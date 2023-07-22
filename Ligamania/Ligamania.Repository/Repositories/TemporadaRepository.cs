using General.CrossCutting.Lib;

using Ligamania.Generic.Lib.Enums;
using Ligamania.Repository.Interfaces;
using Ligamania.Repository.Models;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ligamania.Repository.Repositories
{
    public class TemporadaRepository : Repository<TemporadaDTO>, ITemporadaRepository
    {
        public TemporadaRepository(LigamaniaDbContext context)
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
            TemporadaDTO temporada = await FindAsync(t => t.Estado.Equals(EstadoTemporada.EnPretemporada.ToString())).ConfigureAwait(false);
            if (temporada == null) return await GetActualAsync().ConfigureAwait(false);
            return temporada;
        }

        private IQueryable<byte[]> GetClasificacion(int id)
        {
            var img = from temp in DbSet where temp.Id == id select temp.Img_Clasificacion;
            return img;
        }
        public async Task<byte[]> GetImg_Clasificacion(int id)
        {
            //var img = GetClasificacion(id);
            var temp = await GetByIdAsync(id);
            byte[] imageData = temp.Img_Clasificacion.ToArray();
            return imageData;
        }

        public async Task<byte[]> GetImg_Clasificacion(string temporada)
        {
            var img = from temp in DbSet where temp.Nombre.Equals(temporada) select temp.Img_Clasificacion;
            return await Task.FromResult(img.First().ToArray());
        }

        public async Task<TemporadaDTO> GetUltimaTemporadaEnJuego()
        {
            var temporada = await FindAsync(t => t.Actual).ConfigureAwait(false);
            if (temporada == null)
            {
                var temps = await FindAllAsync(t => t.Estado.Equals(EstadoTemporada.Cerrada.ToString())).ConfigureAwait(false);
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
        
        public async Task<ICollection<TemporadaCompeticionDTO>> GetCompeticionesByTemporada(int idTemporada)
        {
            var t = this.DbSet.Where(t => t.Id.Equals(idTemporada))
                .Include(t => t.TemporadaCompeticion)
                .ThenInclude(tc => tc.Competicion);
            return await t.SelectMany(t=>t.TemporadaCompeticion).ToListAsync();
        }

        public async Task<ICollection<TemporadaCompeticionCategoriaDTO>> GetCategoriasByTemporadaAndCompeticion(int idTemporada, int idCompeticion)
        {
            var t = this.DbSet.Where(t => t.Id.Equals(idTemporada))
                .Include(t => t.TemporadaCompeticionCategoria)
                .ThenInclude(tc => tc.Categoria);
            return await t.SelectMany(t => t.TemporadaCompeticionCategoria.Where(tcc=>tcc.CompeticionId.Equals(idCompeticion))).ToListAsync();
        }

        public async Task<ICollection<TemporadaJugadorDTO>> GetJugadoresByTemporada(int idTemporada)
        {
            var t = this.DbSet.Where(t => t.Id.Equals(idTemporada))
                .Include(t => t.TemporadaJugador)
                    .ThenInclude(tj => tj.Club)
                .Include(t => t.TemporadaJugador)
                    .ThenInclude(tj => tj.Puesto)
                .Include(t => t.TemporadaJugador)
                    .ThenInclude(tj=>tj.Jugador)
                ;
            var t1 = t.First();
            var lista = await t.SelectMany(t => t.TemporadaJugador).ToListAsync();
            return lista;
        }

        public async Task<ICollection<ClubDTO>> GetAllClubs(int idTemporada)
        {

            var jugadores = await GetJugadoresByTemporada(idTemporada);
            var clubs = jugadores.Select(j=>j.Club).Distinct().ToList();
            return clubs;
        }
    }
}