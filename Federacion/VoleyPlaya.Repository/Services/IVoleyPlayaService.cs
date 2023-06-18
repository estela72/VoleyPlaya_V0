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
        Task<bool> DeleteEdicionAsync(string nombre);
        Task<bool> DeleteEdicionAsync(int id);
        Task<List<Edicion>> GetAllEdicionesAsync();
        Task<Edicion> GetEdicionAsync(string name);
        Edicion GetEdicion(string name);
        Task<Edicion> GetEdicionByIdAsync(int id);
        Task<Edicion> GetBasicEdicionAsync(int id);
        Task<bool> UpdateGrupoPartidosAsync(EdicionGrupo grupo);
        Task<bool> UpdateDatosPartidosAsync(EdicionGrupo grupo);
        Task<EdicionGrupo> GetGrupoAsync(int id);
        Task<bool> UpdateEquiposAsync(int idGrupo, IEnumerable<Equipo> equipos);
        Task<bool> DeleteGrupoAsync(int id);
        Task<string> DeleteEquipoAsync(int equipoId);
        Task<string> DeletePartidoAsync(int partidoId);
        Task<bool> UpdateEquiposEdicionAsync(int edicionId, List<Equipo> equipos);
        Task<bool> UpdateTipoCalendarioEdicionAsync(int id, string tipoCalendario);
        Task<string> GetTipoCalendarioEdicion(int id);
        Task<List<EdicionGrupo>> GetAllGruposAsync(int? edicionId);
        Task<List<PartidoVis>> GetPartidosFiltradosAsync(int edicionSelected, int grupoSelected);
        Task<Edicion> GetBasicAsync(int id);
        Task<EdicionGrupo> GetBasicGrupoAsync(int grupoId);
        Task<EdicionGrupo> GetGrupoWithEquiposYPartidosAsync(int grupoId);
        Task<EdicionGrupo> UpdateResultadosPartidosAsync(IEnumerable<Partido> partidos);
        Task<bool> AddEquipo(int edicionId, string nuevoEquipo);
        Task<IList<(int id, string nombre)>> GetAllCompeticionesAsync(string idPrueba);
        Task<IList<(int id, string nombre)>> GetAllCategoriasByEdicionAsync(string idPrueba, int idCompeticion);
        Task<IList<(string id, string nombre)>> GetAllGenerosAsync(string idPrueba, int idCompeticion, int idCategoria);
        Task<IList<(int id, string nombre)>> GetAllGruposAsync(string idPrueba, int idCompeticion, int idCategoria, string genero);
        Task<List<EdicionGrupo>> GetAllGruposFiltradosAsync(string prueba,int idCompeticion, int idCategoria, string genero);
        Task<List<EdicionGrupo>> GetClasificacionesAsync(string prueba, int competicionSelected, int categoriaSelected, string generoSelected, string grupoSelected);
        Task<EdicionGrupo> RetirarEquipoAsync(int id);
        Task<List<Partido>> GetPartidosAsync(string pruebaSelected, int competicionSelected, int categoriaSelected, string generoSelected, int grupoSelected);
        Task<int> GetEdicionByIdAsync(string prueba, int competicion, int categoria, string genero);
        Task<string> UpdatePartidosFromExcelAsync(List<Partido> lista);
        Task<bool> SaveTablaCalendarios(List<TablaCalendario> partidos);
        Task<string> GetModeloCompeticionAsync(int id);
        Task<List<TablaCalendario>> GetCalendarioPartidosCircuito(int numEquipos);
        Task<List<TablaCalendario>> GetCalendarioPartidosCircuitoByNumGrupos(int numGrupos);
        Task<Edicion> GetEdicion(string pruebaId, int? competicionId, int? categoriaId, string generoId);
        Task<string> ValidarPartidoAsync(int idPartido, bool activo, int set1L, int set1V, int set2L, int set2V, int set3L, int set3V);
        Task ArreglarGruposEquipos();
        Task<string> ActualizarClasificacionFinal(int edicionId, List<VoleyPlaya.Repository.Models.Equipo> equipos);
        Task<IList<(int id, string nombre)>> GetListaPruebasAsync();
        Task<string> ActualizarPistaGrupo(int id, string pistaGrupo, bool sobreescribirPistasGrupo);
        Task CambiarEstadoEdicion(int idEdicion, string nuevoEstado);
        Task<bool> UpdateEdicionGenericoAsync(Edicion edi, string temporada, string competicion, string categoria);
        Task<bool> UpdateEquiposEdicionAsync(int edicionId, List<Equipo> equiposToAdd, List<Equipo> equiposToRemove);
        Task<bool> UpdateGruposAsync(int id, HashSet<EdicionGrupo> grupos);
        Task<bool> UpdateJornadasAsync(int id, HashSet<Jornada> jornadas);
        Task<bool> UpdatePosicionEquiposAsync(List<Equipo> equipos, int grupoId);
        Task<bool> AddUpdateGrupoYPartidosFaseFinalAsync(int id, EdicionGrupo edicionGrupo);
        Task<(EdicionGrupo? grupo, string res)> ConfirmarResultadoAsync(int idPartido, bool activo, int set1L, int set1V, int set2L, int set2V, int set3L, int set3V);
    }
}
