using General.CrossCutting.Lib;

using Ligamania.Repository.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ligamania.Repository.Interfaces
{
    public interface IEquipoRepository : IRepository<EquipoDTO>
    {
        Task<ICollection<EquipoDTO>> GetEquiposActivos();
        Task<EquipoDTO> AddNewEquipo(byte[] imagen, string nombre, bool esBot, LigamaniaApplicationUser user);
    }
}