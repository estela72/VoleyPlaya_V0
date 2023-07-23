using General.CrossCutting.Lib;

using Ligamania.Generic.Lib.Enums;
using Ligamania.Repository.Interfaces;
using Ligamania.Repository.Models;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ligamania.Repository.Repositories
{
    public class TemporadaClasificacionRepository : BaseRepository<TemporadaClasificacionDTO>, ITemporadaClasificacionRepository
    {
        public TemporadaClasificacionRepository(LigamaniaDbContext context)
            : base(context)
        {
        }

        public async Task<ICollection<TemporadaClasificacionDTO>> GetClasificaciones(int competicionId, int categoriaId, int jornadaId)
        {
            var lista = await FindAllIncludingAsync(tc => tc.CompeticionId.Equals(competicionId) && tc.CategoriaId.Equals(categoriaId) && tc.JornadaId.Equals(jornadaId),
                tc => tc.Temporada, tc => tc.Competicion, tc => tc.Categoria, tc => tc.Equipo, tc => tc.Jornada).ConfigureAwait(false);
            lista = lista.OrderByDescending(c => c.Puntos).ThenByDescending(c => c.GolesFavor).ThenByDescending(c => c.Diferencia).ToList();
            return lista;
        }

        public async Task<ICollection<TemporadaClasificacionDTO>> GetClasificacionesSinBot(int competicionId, int categoriaId, int jornadaId)
        {
            var lista = await FindAllIncludingAsync(tc => tc.CompeticionId.Equals(competicionId)
                    && tc.CategoriaId.Equals(categoriaId)
                    && tc.JornadaId.Equals(jornadaId)
                    && !tc.Equipo.EsBot,
                tc => tc.Temporada, tc => tc.Competicion, tc => tc.Categoria, tc => tc.Equipo, tc => tc.Jornada).ConfigureAwait(false);

            lista = lista.OrderByDescending(c => c.Puntos).ThenByDescending(c => c.GolesFavor).ThenByDescending(c => c.Diferencia).ToList();

            return lista;
        }

        public List<TemporadaClasificacionDTO> GetClasificacionesSinBotByTemporada(int temporadaId, int competicionId, int categoriaId)
        {
            var lista = FindAll(tc => tc.Temporada.Id.Equals(temporadaId) && tc.CompeticionId.Equals(competicionId) && tc.CategoriaId.Equals(categoriaId) && !tc.Equipo.EsBot);

            lista = lista.OrderByDescending(c => c.Puntos).ThenByDescending(c => c.GolesFavor).ThenByDescending(c => c.Diferencia).ToList();

            return lista.ToList();
        }

        public async Task<EquipoDTO> GetEquipoPuesto(int temporadaId, int competicionId, int categoriaId, PuestoCompeticion puesto, int jornada)
        {
            TemporadaClasificacionDTO registro = null;
            if (puesto.Equals(PuestoCompeticion.Pichichi))
            {
                var registros = await FindAllAsync(tc => tc.TemporadaId.Equals(temporadaId)
                    && tc.CompeticionId.Equals(competicionId)
                    && tc.CategoriaId.Equals(categoriaId)
                    && tc.Jornada.NumeroJornada.Equals(jornada)).ConfigureAwait(false);
                registro = registros
                    .Where(tc => !tc.Equipo.EsBot)
                    .OrderByDescending(tc => tc.Puntos)
                    .ThenByDescending(tc => tc.Diferencia)
                    .Skip(3)
                    .OrderByDescending(tc => tc.GolesFavor)
                    .FirstOrDefault();
            }
            else
            {
                int pu = (int)puesto + 1;
                var registros = await FindAllAsync(tc => tc.TemporadaId.Equals(temporadaId)
                        && tc.CompeticionId.Equals(competicionId)
                        && tc.CategoriaId.Equals(categoriaId)
                        && tc.Jornada.NumeroJornada.Equals(jornada)).ConfigureAwait(false);
                registro = registros
                        .Where(tc => !tc.Equipo.EsBot)
                        .OrderByDescending(tc => tc.Puntos)
                        .ThenByDescending(tc => tc.GolesFavor)
                        .Skip(pu - 1)
                        .Take(pu)
                        .FirstOrDefault();
            }
            if (registro != null)
                return registro.Equipo;
            return null;
        }
    }
}