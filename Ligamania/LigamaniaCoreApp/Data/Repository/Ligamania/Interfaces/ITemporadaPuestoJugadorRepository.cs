using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.DataModels.Base.Model;
using LigamaniaCoreApp.Data.Repository.Base;
using System.Collections.Generic;

namespace LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces
{
    public interface ITemporadaPuestoJugadorRepository : IGenericAuditableIdRepository<TemporadaPuestoJugador_DTO>
    {
        List<TemporadaPuestoJugador_DTO> Search(string jugadorToSearch);
    }
}
