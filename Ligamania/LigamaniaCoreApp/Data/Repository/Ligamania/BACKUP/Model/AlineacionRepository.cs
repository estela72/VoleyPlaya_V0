using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace LigamaniaCoreApp.Data.Repository.Ligamania.Model
{
    public class AlineacionRepository : GenericAuditableAlineacionRepository<Alineacion_DTO>, IAlineacionRepository
    {
        public AlineacionRepository(DbContext context)
            : base(context)
        {

        }
    }
}
