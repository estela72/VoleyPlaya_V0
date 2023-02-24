using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Base.Interfaces;


namespace LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces
{

    public interface ITemporadaJugadorRepository : IGenericAuditableIdRepository<TemporadaJugador>
    {
        List<TemporadaJugador> Search(string jugadorToSearch);
        Task<IEnumerable<TemporadaJugador>> SearchAsync(string jugadorToSearch);
    }
}
