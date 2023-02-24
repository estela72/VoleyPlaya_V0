using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Base.Model;
using LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace LigamaniaCoreApp.Data.Repository.Ligamania.Model
{
    public class SettingsRepository : GenericAuditableRepository<Settings>, ISettingsRepository
    {
        public SettingsRepository(DbContext context)
            : base(context)
        {

        }
        public Settings GetSettings()
        {
            return GetAll().SingleOrDefault();
        }
        public async Task<Settings> GetSettingsAsync()
        {
            ICollection<Settings> lista = await GetAllAsync();
            return lista.SingleOrDefault();
        }
    }
}
