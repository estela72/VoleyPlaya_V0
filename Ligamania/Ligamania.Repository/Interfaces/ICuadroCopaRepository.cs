using General.CrossCutting.Lib;

using Ligamania.Repository.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ligamania.Repository.Interfaces
{
    public interface ICuadroCopaRepository : IRepository<CuadroCopaDTO>
    {
        Task<List<CuadroCopaDTO>> GetCuadro();
    }
}