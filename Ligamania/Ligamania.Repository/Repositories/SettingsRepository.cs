using General.CrossCutting.Lib;

using Ligamania.Repository.Interfaces;
using Ligamania.Repository.Models;

using System.Linq;

namespace Ligamania.Repository.Repositories
{
    public class SettingsRepository : BaseRepository<SettingsDTO>, ISettingsRepository
    {
        public SettingsRepository(LigamaniaDbContext context)
            : base(context)
        {
        }

        public SettingsDTO GetSettings()
        {
            return DbSet.FirstOrDefault();
        }
    }
}