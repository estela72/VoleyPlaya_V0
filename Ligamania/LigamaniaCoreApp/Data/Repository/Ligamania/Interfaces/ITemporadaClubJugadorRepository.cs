using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Base;
using System.Collections.Generic;

namespace LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces
{
    public interface ITemporadaClubJugadorRepository : IGenericAuditableIdRepository<TemporadaClubJugador_DTO>
    {
        List<TemporadaClubJugador_DTO> Search(string jugador);
    }
}
