using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Base;

namespace LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces
{
    public interface ICompeticionCategoriaRepository : IGenericRepository<CompeticionCategoriaDTO>
    {
        Task<ICollection<CompeticionCategoriaDTO>> GetByCompeticion(string competicion);
        Task<ICollection<CompeticionDTO>> GetAllCompeticiones();
    }
}
