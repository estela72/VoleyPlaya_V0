using Ligamania.Repository.Interfaces;
using Ligamania.Repository.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ligamania.Repository.Repositories
{
    public class AlineacionHistoricoRepository : AlineacionRepository<AlineacionHistoricoDTO>, IAlineacionHistoricoRepository
    {
        public AlineacionHistoricoRepository(LigamaniaDbContext context)
            : base(context)
        {
        }

        public async Task InsertHistorico(List<AlineacionHistoricoDTO> aliHists)
        {
            //TODO: ARREGLAR USANDO UoW
            ////using (var transaction = _entities.Database.BeginTransaction())
            ////{
            ////    await _entities.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT dbo.HistoricoAlineacion ON");
            ////    await _entities.HistoricoAlineacion.AddRangeAsync(aliHists).ConfigureAwait(false);
            ////    await _entities.SaveChangesAsync().ConfigureAwait(false);
            ////    await _entities.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT dbo.HistoricoAlineacion OFF");

            ////    transaction.Commit();
            ////}
        }
    }
}