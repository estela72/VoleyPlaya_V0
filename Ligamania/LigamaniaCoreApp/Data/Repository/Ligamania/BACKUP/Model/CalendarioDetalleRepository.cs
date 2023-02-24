using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Base.Model;
using LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace LigamaniaCoreApp.Data.Repository.Ligamania.Model
{
    public class CalendarioDetalleRepository : GenericAuditableRepository<CalendarioDetalle>, ICalendarioDetalleRepository
    {
        public CalendarioDetalleRepository(DbContext context) : base(context)
        {
        }
    }
}
