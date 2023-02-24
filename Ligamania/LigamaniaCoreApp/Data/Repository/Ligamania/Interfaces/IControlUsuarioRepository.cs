using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Base;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces
{
    public interface IControlUsuarioRepository : IGenericAuditableIdRepository<ControlUsuarioDTO>
    {
        Task AddAccionUsuario(string userName, string accion, string equipo);
    }
}
