using General.CrossCutting.Lib;

using Ligamania.Generic.Lib.Enums;
using Ligamania.Repository.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ligamania.Repository.Interfaces
{
    public interface ITemporadaClasificacionRepository : IRepository<TemporadaClasificacionDTO>
    {
        Task<ICollection<TemporadaClasificacionDTO>> GetClasificaciones(int competicionId, int categoriaId, int jornadaId);

        Task<ICollection<TemporadaClasificacionDTO>> GetClasificacionesSinBot(int competicionId, int categoriaId, int jornadaId);

        List<TemporadaClasificacionDTO> GetClasificacionesSinBotByTemporada(int temporadaId, int competicionId, int categoriaId);

        Task<EquipoDTO> GetEquipoPuesto(int temporadaId, int competicionId, int categoriaId, PuestoCompeticion puesto, int jornada);
    }
}