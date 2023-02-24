using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Base.Interfaces;

namespace LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces
{
    public interface ITemporadaRepository : IGenericAuditableNameRepository<Temporada>
    {
        Temporada GetActual();
        //List<TemporadaCompeticion> GetCompeticionesActivas(int id);
        IQueryable<byte[]> GetImgClasificacion(int id);

        Task<Temporada> GetActualAsync();
        //Task<IEnumerable<TemporadaCompeticion>> GetCompeticionesActivasAsync(int id);
        Task<IQueryable<byte[]>> GetImgClasificacionAsync(int id);

    }
}
