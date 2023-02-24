using General.CrossCutting.Lib;

using Ligamania.Repository.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ligamania.Repository.Interfaces
{
    public interface ITemporadaCompeticionCategoriaReferenciaRepository : IRepository<TemporadaCompeticionCategoriaReferenciaDTO>
    {
        Task<ICollection<TemporadaCompeticionCategoriaReferenciaDTO>> GetReferencias(int competicion_Id, int categoria_Id, bool usarMarca = true, string descripcionContains = "");
    }
}