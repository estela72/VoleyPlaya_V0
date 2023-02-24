using General.CrossCutting.Lib;

using Ligamania.Repository.Interfaces;
using Ligamania.Repository.Models;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ligamania.Repository.Repositories
{
    public class TemporadaCompeticionRepository : BaseRepository<TemporadaCompeticionDTO>, ITemporadaCompeticionRepository
    {
        public TemporadaCompeticionRepository(LigamaniaDbContext context)
            : base(context)
        {
        }

        public async Task<TemporadaCompeticionDTO> GetLiga(int temporadaId)
        {
            var tempComp = await FindAsync(tc => tc.Temporada.Id.Equals(temporadaId) && tc.Competicion.Nombre.Equals(LigamaniaConst.Competicion_Liga) && tc.Activa).ConfigureAwait(false);
            if (tempComp == null)
                tempComp = await FindAsync(tc => tc.Temporada.Id.Equals(temporadaId) && tc.Competicion.Nombre.Equals(LigamaniaConst.Competicion_Pretemporada) && tc.Activa).ConfigureAwait(false);
            return tempComp;
        }

        //public async Task<TemporadaCompeticionDTO> GetCompeticion(int temporadaId, LigamaniaEnum.eTipoCompeticion tipoCompeticion)
        //{
        //    var tempComp = await FindAsync(
        //        tc => tc.TemporadaId.Equals(temporadaId) && tc.Competicion.Tipo.HasValue && tc.Competicion.Tipo.Value.Equals((int)tipoCompeticion) && tc.Activa
        //        ); //tc => tc.Temporada, tc => tc.Competicion);
        //    //var tempComp = await FindIncludingAsync(
        //    //    tc => tc.TemporadaId.Equals(temporadaId) && tc.Competicion.Tipo != null && tc.Competicion.Tipo.Equals((int)tipoCompeticion) && tc.Competicion.Nombre != "Pretemporada",
        //    //    tc => tc.Temporada, tc => tc.Competicion, tc => tc.EstadoActual, tc => tc.OperacionActual).ConfigureAwait(false);
        //    return tempComp;

        //    //var tempComp = lista.FirstOrDefault(tc => tc.TemporadaId.Equals(temporadaId) && tc.Competicion.Nombre.Equals(tipoCompeticion.ToString()));
        //    //return tempComp;

        //}
        public async Task<TemporadaCompeticionDTO> GetCompeticion(int temporadaId, int idCompeticion)
        {
            //var lista = await GetAllIncluding(tc => tc.Temporada, tc => tc.Competicion).ToListAsync();
            //var tempComp = lista.FirstOrDefault(tc => tc.TemporadaId.Equals(temporadaId) && tc.CompeticionId.Equals(idCompeticion));
            var tempComp = await FindIncludingAsync(
                tc => tc.TemporadaId.Equals(temporadaId) && tc.CompeticionId.Equals(idCompeticion),
                tc => tc.Temporada, tc => tc.Competicion, tc => tc.EstadoActual, tc => tc.OperacionActual).ConfigureAwait(false);
            return tempComp;
        }

        public async Task<TemporadaCompeticionDTO> GetCompeticion(int temporadaId, string competicion)
        {
            var tempComp = await FindIncludingAsync(
                tc => tc.TemporadaId.Equals(temporadaId) && tc.Competicion.Nombre.Equals(competicion),
                tc => tc.Temporada, tc => tc.Competicion, tc => tc.EstadoActual, tc => tc.OperacionActual).ConfigureAwait(false);
            return tempComp;
        }

        public async Task<ICollection<TemporadaCompeticionDTO>> GetCompeticiones()
        {
            var temporadaCompeticion = await GetAllIncluding(tc => tc.Temporada, tc => tc.Competicion, tc => tc.EstadoActual, tc => tc.OperacionActual)
                .Where(tc => tc.Temporada.Actual)
                .GroupBy(tc => tc.Competicion.Nombre).Select(grp => grp.FirstOrDefault())
                .ToListAsync().ConfigureAwait(false);
            return temporadaCompeticion;
        }

        public async Task<ICollection<TemporadaCompeticionDTO>> GetCompeticionesActivas()
        {
            //var temporadaCompeticion = await GetAllIncluding(tc => tc.Temporada, tc => tc.Competicion, tc => tc.EstadoActual, tc => tc.OperacionActual)
            //    .Where(tc => tc.Temporada.Actual && tc.Activa)
            //    .GroupBy(tc => tc.Competicion.Nombre).Select(grp => grp.FirstOrDefault())
            //    .ToListAsync().ConfigureAwait(false);

            var temporadaCompeticion = await FindAllIncludingAsync(tc => tc.Temporada.Actual && tc.Activa,
                    tc => tc.Temporada, tc => tc.Competicion, tc => tc.EstadoActual, tc => tc.OperacionActual).ConfigureAwait(false);
            temporadaCompeticion = temporadaCompeticion.GroupBy(tc => tc.Competicion.Nombre).Select(grp => grp.FirstOrDefault()).ToList();

            return temporadaCompeticion;
        }

        public async Task<ICollection<TemporadaCompeticionDTO>> GetCompeticionesActivas(TemporadaDTO temporada)
        {
            var temporadaCompeticion = await GetAllIncluding(tc => tc.Temporada, tc => tc.Competicion, tc => tc.EstadoActual, tc => tc.OperacionActual)
                .Where(tc => tc.TemporadaId.Equals(temporada.Id) && tc.Activa)
                .GroupBy(tc => tc.Competicion.Nombre).Select(grp => grp.FirstOrDefault())
                .ToListAsync().ConfigureAwait(false);
            return temporadaCompeticion;
        }

        public async Task SetEstadoActualAsync(TemporadaCompeticionDTO temporadaCompeticion, EstadoCompeticionDTO regEstado, OperacionCompeticionDTO regOperacion, string descripcion)
        {
            var tempcomp = GetById(temporadaCompeticion.Id);
            tempcomp.EstadoActual = regEstado;
            tempcomp.OperacionActual = regOperacion;
            tempcomp.DescripcionEstado = descripcion;
            await UpdateAsyn(tempcomp, tempcomp.Id).ConfigureAwait(false);
            // TODO: REVISAR!
            //await SaveAsync().ConfigureAwait(false);
        }

        public async Task<ICollection<TemporadaCompeticionDTO>> GetCompeticionesByTemporada(int idTemporada)
        {
            var temporadaCompeticionList = await GetAllIncluding(tc => tc.Competicion, tc => tc.EstadoActual, tc => tc.OperacionActual)
                            .Where(tc => tc.TemporadaId.Equals(idTemporada))
                            .ToListAsync().ConfigureAwait(false);
            return temporadaCompeticionList;
        }
    }
}