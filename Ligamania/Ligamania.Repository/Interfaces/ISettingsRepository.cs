using General.CrossCutting.Lib;

using Ligamania.Repository.Models;

namespace Ligamania.Repository.Interfaces
{
    public interface ISettingsRepository : IBaseRepository<SettingsDTO>
    {
        SettingsDTO GetSettings();
    }
}