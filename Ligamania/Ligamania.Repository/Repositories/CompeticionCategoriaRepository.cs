using General.CrossCutting.Lib;

using Ligamania.Repository.Interfaces;
using Ligamania.Repository.Models;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ligamania.Repository.Repositories
{
    public class CompeticionCategoriaRepository : /*Repository<CompeticionCategoriaDTO>,*/ ICompeticionCategoriaRepository
    {
        LigamaniaDbContext _context;
        public CompeticionCategoriaRepository(LigamaniaDbContext context)
            //: base(context)
        {
            _context = context;
        }

        public async Task DeleteCategoriaFromCompeticion(int competicionId, int categoriaId)
        {
            var compCat = await _context.CompeticionCategoria.SingleOrDefaultAsync(cc => cc.Competicion_Id == competicionId && cc.Categoria_Id == categoriaId);
            var compCatBorrada = _context.CompeticionCategoria.Remove(compCat);
        }

        public async Task<ICollection<CategoriaDTO>> GetCategorias(int idCompeticion)
        {
            var categorias = _context.CompeticionCategoria.Where(cc => cc.Competicion_Id == idCompeticion).Select(cc => cc.Categoria);
            return await categorias.ToListAsync().ConfigureAwait(false);
        }

        public async Task UpdateCategoriaToCompeticion(int competicionId, int newCategoria)
        {
            await _context.AddAsync(new CompeticionCategoriaDTO
            {
                Categoria_Id = newCategoria,
                Competicion_Id = competicionId
            });
        }
    }
}