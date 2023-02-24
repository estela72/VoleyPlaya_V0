using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Base;
using LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Data.Repository.Ligamania.Model
{
    public class CuadroCopaRepository : GenericAuditableRepository<CuadroCopaDTO>, ICuadroCopaRepository
    {
        public CuadroCopaRepository(ApplicationDbContext context)
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
