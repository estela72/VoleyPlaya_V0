using General.CrossCutting.Lib;

using Ligamania.Repository.Interfaces;
using Ligamania.Repository.Models;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ligamania.Repository.Repositories
{
    public class TemporadaEquipoRepository : Repository<TemporadaEquipoDTO>, ITemporadaEquipoRepository
    {
        public TemporadaEquipoRepository(LigamaniaDbContext context)
            : base(context)
        {
        }

        public async Task<ICollection<TemporadaEquipoDTO>> GetEquiposCompeticion(TemporadaCompeticionDTO temporadaCompeticion)
        {
            ICollection<TemporadaEquipoDTO> equipos = await GetAllIncluding(te => te.Competicion, te => te.Categoria, te => te.Equipo)
                .Where(tcc => tcc.TemporadaId.Equals(temporadaCompeticion.TemporadaId) && tcc.CompeticionId.Equals(temporadaCompeticion.CompeticionId)
                        && !tcc.Baja && !tcc.Equipo.EsBot)
                .ToListAsync().ConfigureAwait(false);
            return equipos;
        }

        public async Task<ICollection<TemporadaEquipoDTO>> GetEquiposTemporada(int temporadaId)
        {
            ICollection<TemporadaEquipoDTO> equipos = await GetAllIncluding(te => te.Competicion, te => te.Categoria, te => te.Equipo)
                .Where(tcc => tcc.TemporadaId.Equals(temporadaId))
                .ToListAsync().ConfigureAwait(false);
            return equipos;
        }

        public async Task<ICollection<TemporadaEquipoDTO>> GetEquiposTemporadaNoEnCompeticion(int temporadaId, string competicion)
        {
            ICollection<TemporadaEquipoDTO> equipos = await GetAllIncluding(te => te.Competicion, te => te.Categoria, te => te.Equipo)
                .Where(tcc => tcc.TemporadaId.Equals(temporadaId) && !tcc.Competicion.Nombre.Equals(competicion))
                .ToListAsync().ConfigureAwait(false);
            return equipos;
        }

        public async Task<ICollection<TemporadaEquipoDTO>> GetEquiposActivosUser(int temporadaId, string user)
        {
            ICollection<TemporadaEquipoDTO> equipos = await FindAllIncludingAsync(te => te.TemporadaId.Equals(temporadaId)
                && te.Equipo.ApplicationUser.UserName.Equals(user) && !te.Baja, te => te.Competicion, te => te.Categoria, te => te.Equipo).ConfigureAwait(false);
            return equipos;
        }

        public async Task<TemporadaEquipoDTO> GetEquipoTemporada(int temporadaId, int competicionId, int categoriaId, int? equipoId)
        {
            TemporadaEquipoDTO temporadaEquipo = await FindAsync(te => te.TemporadaId.Equals(temporadaId)
                && te.CompeticionId.Equals(competicionId) && te.CategoriaId.Equals(categoriaId) && te.EquipoId.Equals((int)equipoId)).ConfigureAwait(false);
            return temporadaEquipo;
        }
    }
}