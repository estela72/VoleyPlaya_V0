using General.CrossCutting.Lib;

using Ligamania.Repository.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ligamania.Repository.Interfaces
{
    public interface ITemporadaCompeticionCategoriaRepository : IBaseRepository<TemporadaCompeticionCategoriaDTO>
    {
        Task<ICollection<TemporadaCompeticionCategoriaDTO>> GetCategorias(TemporadaCompeticionDTO temporadaCompeticion);

        Task<TemporadaCompeticionCategoriaDTO> GetCategoria(int idTemporada, int idCompeticion, int idCategoria);
    }
}