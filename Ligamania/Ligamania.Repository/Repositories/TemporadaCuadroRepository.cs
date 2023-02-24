using General.CrossCutting.Lib;

using Ligamania.Repository.Interfaces;
using Ligamania.Repository.Models;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ligamania.Repository.Repositories
{
    public class TemporadaCuadroRepository : Repository<TemporadaCuadroDTO>, ITemporadaCuadroRepository
    {
        public TemporadaCuadroRepository(LigamaniaDbContext context)
            : base(context)
        {
        }

        public async Task<TemporadaCuadroDTO> GetLastPartidoCuadro(int temporadaId, int competicionId)
        {
            var cuadro = await FindAllAsync(c => c.TemporadaId.Equals(temporadaId)).ConfigureAwait(false);
            return cuadro.OrderBy(c => c.NumeroPartido).Last();
        }

        public async Task<List<TemporadaCuadroDTO>> GetCuadro(int temporadaId, int competicionId)
        {
            var cuadro = await FindAllAsync(c => c.TemporadaId.Equals(temporadaId) && c.CompeticionId.Equals(competicionId)).ConfigureAwait(false);
            return cuadro.ToList();
        }
    }
}