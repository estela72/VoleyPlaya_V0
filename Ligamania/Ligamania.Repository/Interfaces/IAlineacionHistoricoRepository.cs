using Ligamania.Repository.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ligamania.Repository.Interfaces
{
    public interface IAlineacionHistoricoRepository : IAlineacionRepository<AlineacionHistoricoDTO>
    {
        Task InsertHistorico(List<AlineacionHistoricoDTO> aliHists);
    }
}