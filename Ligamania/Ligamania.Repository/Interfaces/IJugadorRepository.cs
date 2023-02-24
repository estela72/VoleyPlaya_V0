using General.CrossCutting.Lib;

using Ligamania.Repository.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ligamania.Repository.Interfaces
{
    public interface IJugadorRepository : IRepository<JugadorDTO>
    {
        List<JugadorDTO> Search(string jugadorToSearch);
        Task<JugadorDTO> Alta(JugadorDTO jugadorDto);
        Task<JugadorDTO> Baja(JugadorDTO jugadorDto);
    }
}