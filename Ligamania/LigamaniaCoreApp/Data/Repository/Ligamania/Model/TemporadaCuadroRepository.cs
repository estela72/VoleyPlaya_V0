using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Base;
using LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Data.Repository.Ligamania.Model
{
    public class TemporadaCuadroRepository : GenericAuditableRepository<TemporadaCuadroDTO>, ITemporadaCuadroRepository
    {
        public TemporadaCuadroRepository(ApplicationDbContext context)
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
            var cuadro = await FindAllAsync(c => c.TemporadaId.Equals(temporadaId)&&c.CompeticionId.Equals(competicionId)).ConfigureAwait(false);
            return cuadro.ToList();
        }
    }
}
