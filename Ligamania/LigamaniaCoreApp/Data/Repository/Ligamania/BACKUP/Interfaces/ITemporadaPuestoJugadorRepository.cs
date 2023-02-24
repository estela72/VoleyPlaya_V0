using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Base.Interfaces;

namespace LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces
{
    public interface ITemporadaPuestoJugadorRepository : IGenericAuditableIdRepository<TemporadaPuestoJugador>
    {
        List<TemporadaPuestoJugador> Search(string jugadorToSearch);
        Task<IEnumerable<TemporadaPuestoJugador>> SearchAsync(string jugadorToSearch);
    }
}
