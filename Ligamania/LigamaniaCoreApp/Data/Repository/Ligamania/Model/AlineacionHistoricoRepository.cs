using System.Collections.Generic;
using System.Threading.Tasks;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Base;
using LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces;

using Microsoft.EntityFrameworkCore;
namespace LigamaniaCoreApp.Data.Repository.Ligamania.Model
{
    public class AlineacionHistoricoRepository : AlineacionGenericAuditableRepository<AlineacionHistoricoDTO>, IAlineacionHistoricoRepository
    {
        public AlineacionHistoricoRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        public async Task InsertHistorico(List<AlineacionHistoricoDTO> aliHists)
        {
            using (var transaction = _entities.Database.BeginTransaction())
            {
                _entities.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.HistoricoAlineacion ON");
                await _entities.HistoricoAlineacion.AddRangeAsync(aliHists).ConfigureAwait(false);
                await _entities.SaveChangesAsync().ConfigureAwait(false);
                _entities.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.HistoricoAlineacion OFF");

                transaction.Commit();
            }
            
        }
    }
}
