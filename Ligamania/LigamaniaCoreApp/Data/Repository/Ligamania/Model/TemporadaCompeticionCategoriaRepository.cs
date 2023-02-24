using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Base;
using LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces;

using Microsoft.EntityFrameworkCore;
namespace LigamaniaCoreApp.Data.Repository.Ligamania.Model
{
    public class TemporadaCompeticionCategoriaRepository : GenericAuditableRepository<TemporadaCompeticionCategoriaDTO>, ITemporadaCompeticionCategoriaRepository
    {
        public TemporadaCompeticionCategoriaRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        public async Task<ICollection<TemporadaCompeticionCategoriaDTO>> GetCategorias(TemporadaCompeticionDTO temporadaCompeticion)
        {
            ICollection<TemporadaCompeticionCategoriaDTO> categorias = await GetAllIncluding(tcc => tcc.Competicion, tcc => tcc.Categoria)
                .Where(tcc => tcc.TemporadaId.Equals(temporadaCompeticion.TemporadaId) && tcc.CompeticionId.Equals(temporadaCompeticion.CompeticionId))
                .ToListAsync().ConfigureAwait(false);
            return categorias;
        }
        public async Task<TemporadaCompeticionCategoriaDTO> GetCategoria(int idTemporada, int idCompeticion, int idCategoria)
        {
            TemporadaCompeticionCategoriaDTO temporadaCompeticionCategoria = await FindAsync(tcc => tcc.TemporadaId.Equals(idTemporada)
                && tcc.CompeticionId.Equals(idCompeticion) && tcc.CategoriaId.Equals(idCategoria)).ConfigureAwait(false);
            return temporadaCompeticionCategoria;
        }

    }
}
