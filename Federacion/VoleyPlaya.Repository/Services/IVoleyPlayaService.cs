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
        Task<string> DeletePartidoAsync(int partidoId);
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
        Task<string> GetAllCompeticionesAsync(string idPrueba);
        Task<string> GetAllCategoriasByEdicionAsync(string idPrueba, int idCompeticion);
        Task<string> GetAllGenerosAsync(string idPrueba, int idCompeticion, int idCategoria);
        Task<string> GetAllGruposAsync(string idPrueba, int idCompeticion, int idCategoria, string genero);
        Task<List<EdicionGrupo>> GetAllGruposFiltradosAsync(string prueba,int idCompeticion, int idCategoria, string genero);

        Task<List<EdicionGrupo>> GetClasificacionesAsync(string prueba, int competicionSelected, int categoriaSelected, string generoSelected, string grupoSelected);
        Task<EdicionGrupo> RetirarEquipoAsync(int id);
        Task<List<Partido>> GetPartidosAsync(string pruebaSelected, int competicionSelected, int categoriaSelected, string generoSelected, int grupoSelected);
        Task<int> GetEdicionByIdAsync(string prueba, int competicion, int categoria, string genero);
        Task<string> UpdatePartidosFromExcelAsync(List<Partido> lista);
        Task<bool> SaveTablaCalendarios(List<TablaCalendario> partidos);
        Task<string> GetModeloCompeticionAsync(int id);
        Task<List<TablaCalendario>> GetCalendarioPartidosCircuito(int numEquipos);
        Task<bool> AddUpdateGrupoYPartidosFaseFinalAsync(int edicionId, string jsonGrupo);
        Task<List<TablaCalendario>> GetCalendarioPartidosCircuitoByNumGrupos(int numGrupos);
        Task<Edicion> GetEdicion(string pruebaId, int? competicionId, int? categoriaId, string generoId);
        Task<string> ValidarPartidoAsync(int idPartido, bool activo);
        Task ArreglarGruposEquipos();
        Task<string> ActualizarClasificacionFinal(int edicionId, List<VoleyPlaya.Repository.Models.Equipo> equipos);
        Task<string> GetListaPruebasAsync();
        Task<string> ActualizarPistaGrupo(int id, string pistaGrupo, bool sobreescribirPistasGrupo);
    }
}
