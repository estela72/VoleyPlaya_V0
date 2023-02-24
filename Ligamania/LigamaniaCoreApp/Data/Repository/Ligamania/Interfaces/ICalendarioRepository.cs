using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Base;

namespace LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces
{
    public interface ICalendarioRepository : IGenericAuditableNameRepository<CalendarioDTO>, IGenericIdRepository<CalendarioDTO>
    {
    }
}
