using General.CrossCutting.Lib;

using Ligamania.Repository.Models;

using System.Collections.Generic;

namespace Ligamania.Repository.Interfaces
{
    public interface ITemporadaClubJugadorRepository : IRepository<TemporadaClubJugadorDTO>
    {
        List<TemporadaClubJugadorDTO> Search(string jugador);
    }
}