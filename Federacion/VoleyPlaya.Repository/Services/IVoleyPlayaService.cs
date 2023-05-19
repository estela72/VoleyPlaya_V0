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
        Task<List<Edicion>> GetAllEdicionesAsync();
        Task<Edicion> GetEdicionAsync(string name);
        Edicion GetEdicion(string name);
        Task<Edicion> GetEdicionByIdAsync(int id);
        Task<Edicion> GetBasicEdicionAsync(int id);
        Task<bool> UpdateGrupoPartidosAsync(string jsonString);
        Task<bool> UpdateDatosPartidosAsync(string json);
        Task<EdicionGrupo> GetGrupoAsync(int id);
        Task<bool> UpdateEquiposAsync(int idGrupo, string jsonEquipos);
        Task<bool> DeleteGrupoAsync(int id);
        Task<string> DeleteEquipoAsync(int equipoId);
        Task<bool> DeletePartidoAsync(int partidoId);
        Task<bool> UpdateEquiposEdicionAsync(int idEdicion, string jsonEquiposToAddOrUpdate, string jsonEquiposToRemove);
        Task<bool> UpdateEquiposEdicionAsync(int edicionId, string json);
        Task<bool> UpdateGruposAsync(int id, string json);
        Task<bool> UpdateJornadasAsync(int id, string json);
        Task<bool> UpdateTipoCalendarioEdicionAsync(int id, string tipoCalendario);
        Task<string> GetTipoCalendarioEdicion(int id);
        Task<List<EdicionGrupo>> GetAllGruposAsync(int? edicionId);
        Task<List<PartidoVis>> GetPartidosFiltradosAsync(int edicionSelected, int grupoSelected);
        Task<Edicion> GetBasicAsync(int id);
        Task<EdicionGrupo> GetBasicGrupoAsync(int grupoId);
        Task<EdicionGrupo> GetGrupoWithEquiposYPartidosAsync(int grupoId);
        Task<EdicionGrupo> UpdateResultadosPartidosAsync(string jsonString);
        Task<bool> AddEquipo(int edicionId, string nuevoEquipo);
        Task<string> GetAllCompeticionesAsync();
        Task<string> GetAllCategoriasByEdicionAsync(int idCompeticion);
        Task<string> GetAllGenerosAsync(int idCompeticion, int idCategoria);
        Task<string> GetAllGruposAsync(int idCompeticion, int idCategoria, string genero);
        Task<List<EdicionGrupo>> GetAllGruposFiltradosAsync(int idCompeticion, int idCategoria, string genero);

        Task<List<EdicionGrupo>> GetClasificacionesAsync(int competicionSelected, int categoriaSelected, string generoSelected, string grupoSelected);
        Task<EdicionGrupo> RetirarEquipoAsync(int id);
        Task<List<Partido>> GetPartidosAsync(int competicionSelected, int categoriaSelected, string generoSelected, int grupoSelected);
        Task<int> GetEdicionByIdAsync(int competicion, int categoria, string genero);
        Task<string> UpdatePartidosFromExcelAsync(List<Partido> lista);
        Task<bool> SaveTablaCalendarios(List<TablaCalendario> partidos);
        Task<string> GetModeloCompeticionAsync(int id);
        Task<List<TablaCalendario>> GetCalendarioPartidosCircuito(int numEquipos);
    }
}
