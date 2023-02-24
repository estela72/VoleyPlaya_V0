using System.Collections.Generic;
using System.Threading.Tasks;
using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using LigamaniaCoreApp.Data.Repository.Base;

namespace LigamaniaCoreApp.Data.Repository.Ligamania.Interfaces
{
    public interface ITemporadaClasificacionRepository : IGenericAuditableIdRepository<TemporadaClasificacionDTO>
    {
        Task<ICollection<TemporadaClasificacionDTO>> GetClasificaciones(int competicionId, int categoriaId, int jornadaId);
        Task<ICollection<TemporadaClasificacionDTO>> GetClasificacionesSinBot(int competicionId, int categoriaId, int jornadaId);
        List<TemporadaClasificacionDTO> GetClasificacionesSinBotByTemporada(int temporadaId, int competicionId, int categoriaId);
        Task<EquipoDTO> GetEquipoPuesto(int temporadaId, int competicionId, int categoriaId, LigamaniaEnum.ePuestoCompeticion puesto, int jornada);
    }
}
