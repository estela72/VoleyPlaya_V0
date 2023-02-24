using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Base;
using LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces;

using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LigamaniaCoreApp.Data.Repository.Ligamania.Model
{
    public class SettingsRepository : GenericAuditableRepository<SettingsDTO>, ISettingsRepository
    {
        public SettingsRepository(ApplicationDbContext context)
            : base(context)
        {

        }
        public SettingsDTO GetSettings()
        {
            return _entities.Set<SettingsDTO>().FirstOrDefault();
        }
        
    }
}
