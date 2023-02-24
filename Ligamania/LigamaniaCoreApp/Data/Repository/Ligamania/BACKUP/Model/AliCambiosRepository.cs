using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LigamaniaCoreApp.Data.Repository.Ligamania.Model
{

    public class AlineacionCambioRepository : GenericAuditableAlineacionRepository<AlineacionCambio_DTO>, IAliCambiosRepository
    {
        public AlineacionCambioRepository(DbContext context)
            : base(context)
        {

        }
    }
}
