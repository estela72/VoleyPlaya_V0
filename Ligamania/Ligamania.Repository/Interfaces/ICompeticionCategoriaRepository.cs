using General.CrossCutting.Lib;

using Ligamania.Repository.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ligamania.Repository.Interfaces
{
    public interface ICompeticionCategoriaRepository //: IRepository<CompeticionCategoriaDTO>
    {
        Task<ICollection<CategoriaDTO>> GetCategorias(int idCompeticion);
        Task UpdateCategoriaToCompeticion(int competicionId, int newCategoria);
        Task DeleteCategoriaFromCompeticion(int competicionId, int categoriaId);
        //Task<ICollection<CompeticionCategoriaDTO>> GetByCompeticion(string competicion);

        //Task<ICollection<CompeticionDTO>> GetAllCompeticiones();
    }
}