using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace LigamaniaCoreApp.Data.Repository.Ligamania.Model
{
    public class AlineacionPreviaRepository : GenericAuditableAlineacionRepository<Alineacion_Previa>, IAlineacionPreviaRepository
    {
        public AlineacionPreviaRepository(DbContext context)
            : base(context)
        {

        }
    }
}
