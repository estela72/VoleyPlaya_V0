using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoleyPlaya.Repository.Services
{
    public interface IVoleyPlayaService
    {
        Task<bool> SaveEdicionAsync(string json);
        Task<bool> DeleteEdicionAsync(string nombre);
        Task<bool> DeleteEdicionAsync(int id);
        Task<string> GetAllEdicionesAsync();
        Task<string> GetEdicionAsync(string name);
        string GetEdicion(string name);
        Task<string> GetEdicionAsync(int id);
        Task UpdatePartidosAsync(string jsonString);
        Task<string> GetGrupoAsync(int id);
        Task UpdateEquiposAsync(int idGrupo, string jsonEquipos);
        Task DeleteGrupoAsync(int id);
        Task DeleteEquipoAsync(int equipoId);
        Task DeletePartidoAsync(int partidoId);
        Task UpdateEquiposEdicionAsync(int idEdicion, string jsonEquiposToAddOrUpdate, string jsonEquiposToRemove);
        Task UpdateEquiposEdicionAsync(int edicionId, string json);
        Task UpdateGruposAsync(int id, string json);
        Task UpdateJornadasAsync(int id, string json);
        Task UpdateTipoCalendarioEdicionAsync(int id, string tipoCalendario);
        Task<string> GetTipoCalendarioEdicion(int id);
    }
}
