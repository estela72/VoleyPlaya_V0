using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VoleyPlaya.Repository.Models;

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
        Task<string> GetBasicEdicionAsync(int id);
        Task UpdateGrupoPartidosAsync(string jsonString);
        Task UpdateDatosPartidosAsync(string json);
        Task<string> GetGrupoAsync(int id);
        Task UpdateEquiposAsync(int idGrupo, string jsonEquipos);
        Task DeleteGrupoAsync(int id);
        Task<string> DeleteEquipoAsync(int equipoId);
        Task DeletePartidoAsync(int partidoId);
        Task UpdateEquiposEdicionAsync(int idEdicion, string jsonEquiposToAddOrUpdate, string jsonEquiposToRemove);
        Task UpdateEquiposEdicionAsync(int edicionId, string json);
        Task UpdateGruposAsync(int id, string json);
        Task UpdateJornadasAsync(int id, string json);
        Task UpdateTipoCalendarioEdicionAsync(int id, string tipoCalendario);
        Task<string> GetTipoCalendarioEdicion(int id);
        Task<string> GetAllGruposAsync(int? edicionId);
        Task<string> GetPartidosFiltradosAsync(int edicionSelected, int grupoSelected);
        Task<string> GetBasicAsync(int id);
        Task<string> GetBasicGrupoAsync(int grupoId);
        Task<string> GetGrupoWithEquiposYPartidosAsync(int grupoId);
        Task<string> UpdateResultadosPartidosAsync(int idGrupo, string jsonString);
        Task AddEquipo(int edicionId, string nuevoEquipo);
    }
}
