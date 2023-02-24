using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Base;

using System.Collections.Generic;

namespace LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces
{
    public interface IJugadorRepository : IGenericAuditableNameRepository<JugadorDTO>
    {
        List<JugadorDTO> Search(string jugadorToSearch);
    }
}
