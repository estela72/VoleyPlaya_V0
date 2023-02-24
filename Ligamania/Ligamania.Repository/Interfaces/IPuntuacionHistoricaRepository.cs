using General.CrossCutting.Lib;

using Ligamania.Repository.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ligamania.Repository.Interfaces
{
    public interface IPuntuacionHistoricaRepository : IRepository<PuntuacionHistoricaDTO>
    {
        int GetPuntuacion(int competicionId, int categoriaId, int puesto, bool pichichi);

        Task<ICollection<PuntuacionHistoricaDTO>> GetAllPuntuaciones();
    }
}