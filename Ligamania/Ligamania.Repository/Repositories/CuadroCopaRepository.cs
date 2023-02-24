using General.CrossCutting.Lib;

using Ligamania.Repository.Interfaces;
using Ligamania.Repository.Models;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ligamania.Repository.Repositories
{
    public class CuadroCopaRepository : Repository<CuadroCopaDTO>, ICuadroCopaRepository
    {
        public CuadroCopaRepository(LigamaniaDbContext context)
            : base(context)
        {
        }

        public async Task<List<CuadroCopaDTO>> GetCuadro()
        {
            IQueryable<CuadroCopaDTO> cuadro = GetAll();
            cuadro = cuadro
                .Include(h => h.CompeticionCategoriaEquipoA)
                .ThenInclude(cc => cc.Competicion)
                .Include(h => h.CompeticionCategoriaEquipoA)
                .ThenInclude(cc => cc.Categoria)
                .Include(h => h.CompeticionCategoriaEquipoB)
                .ThenInclude(cc => cc.Competicion)
                .Include(h => h.CompeticionCategoriaEquipoB)
                .ThenInclude(cc => cc.Categoria);
            return await cuadro.ToListAsync().ConfigureAwait(false);
        }
    }
}