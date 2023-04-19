using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using NPOI.POIFS.Crypt.Dsig;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

using VoleyPlaya.Domain.Models;
using VoleyPlaya.Repository.Services;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VoleyPlaya.Domain.Services
{
    public interface IEdicionService
    {
        Task<string> GetAllAsync();
        IEnumerable<Edicion> EdicionesFromJson(string jsonEdiciones);
        EdicionGrupo GetGrupoFromJson(string jsonEdicion);
        Task<string> GetEdicionByName(string id);
        Task UpdateEdicionAsync(Edicion edicion);
        Task<string> GetEdicionById(int id);
        Task DeleteEdicion(string nombre);
        Task DeleteEdicion(int id);
        Task UpdatePartidosAsync(EdicionGrupo edicion);
        Task<string> GetGrupoAsync(int value);
        Task<EdicionGrupo> UpdateGrupoAsync(EdicionGrupo grupo);
        Task UpdateEquipsGrupoAsync(int idGrupo, IList<Equipo> equipos);
        Task UpdateClasificacion(EdicionGrupo grupo);
        Task DeleteGrupoAsync(int id);
        Task DeleteEquipoAsync(int equipoId);
        Task DeletePartidoAsync(int partidoId);
        Task UpdateEquiposEdicionAsync(int edicionId, Edicion edicion);
        Task UpdateEquiposEdicionAsync(int edicionId, List<Equipo> equipos);
        Task UpdateGruposAsync(Edicion edicion);
        Task UpdateJornadasAsync(Edicion edicion);
        Task<string> GetTipoCalendarioEdicion(int id);
        Task<List<EdicionGrupo>> GetAllGruposAsync(int? edicionId);
        Task<List<Partido>> GetPartidosFiltradosAsync(int edicionSelected, int grupoSelected);
        Task<List<SelectionItem>> GetListaEdiciones();
        Task<List<SelectionItem>> GetListaGrupos(int edicionId);
        Task<dynamic> ExportarCalendarioAsync(int competicionId, int grupoId);
    }
    public class EdicionService : IEdicionService
    {
        IVoleyPlayaService _service;
        public EdicionService(IVoleyPlayaService service)
        {
            _service = service;
        }

        public async Task<string> GetAllAsync()
        {
            return await _service.GetAllEdicionesAsync();
        }

        public IEnumerable<Edicion> EdicionesFromJson(string jsonEdiciones)
        {
            List<VoleyPlaya.Domain.Models.Edicion> list = new List<VoleyPlaya.Domain.Models.Edicion>();
            JsonNode node = JsonNode.Parse(jsonEdiciones)!;
            JsonArray ediciones = node!.AsArray();
            foreach (var edicion in ediciones)
                list.Add(VoleyPlaya.Domain.Models.Edicion.FromJson(edicion));
            return list;
        }
        public EdicionGrupo GetGrupoFromJson(string jsonEdicion)
        {
            EdicionGrupo edicion = new EdicionGrupo();
            JsonNode node = JsonNode.Parse(jsonEdicion)!;
            edicion = EdicionGrupo.FromJson(node);
            return edicion;
        }

        public async Task<string> GetEdicionByName(string id)
        {
            return await _service.GetEdicionAsync(id);
        }

        public async Task UpdateEdicionAsync(Edicion edicion)
        {
            string jsonString = JsonSerializer.Serialize(edicion);
            await _service.SaveEdicionAsync(jsonString);
        }

        public async Task<string> GetEdicionById(int id)
        {
            return await _service.GetEdicionAsync(id);
        }

        public async Task DeleteEdicion(string nombre)
        {
            await _service.DeleteEdicionAsync(nombre);
        }

        public async Task DeleteEdicion(int id)
        {
            await _service.DeleteEdicionAsync(id);
        }

        public async Task UpdatePartidosAsync(EdicionGrupo grupo)
        {
            string jsonString = JsonSerializer.Serialize(grupo);
            await _service.UpdatePartidosAsync(jsonString);
        }

        public async Task<string> GetGrupoAsync(int id)
        {
            return await _service.GetGrupoAsync(id);

        }
        public async Task UpdateClasificacion(EdicionGrupo grupo)
        {
            foreach (var equipo in grupo.Equipos)
                await equipo.Reset();
            foreach (var partido in grupo.Partidos)
            {
                var local = grupo.Equipos.First(e => e.Nombre.Equals(partido.Local));
                var visitante = grupo.Equipos.First(e => e.Nombre.Equals(partido.Visitante));
                await local.SetLocal(partido);
                await visitante.SetVisitante(partido);
                partido.Resultado.Local = partido.Resultado.Sets.Count(s => s.Local > s.Visitante);
                partido.Resultado.Visitante = partido.Resultado.Sets.Count(s => s.Visitante > s.Local);
            }
        }
        public async Task<EdicionGrupo> UpdateGrupoAsync(EdicionGrupo grupo)
        {
            var jsonGrupo = await GetGrupoAsync(grupo.Id);
            var gr = EdicionGrupo.FromJson(JsonNode.Parse(jsonGrupo!)!);
            int numEquipos = grupo.Equipos.Count;

            await grupo.GenerarPartidosAsync(gr.Edicion.TipoCalendario, gr.Edicion.FechasJornadas, gr.Equipos);
            string json = JsonSerializer.Serialize(grupo);
            await _service.UpdatePartidosAsync(json);

            return grupo;
        }

        public async Task UpdateEquipsGrupoAsync(int idGrupo, IList<Equipo> equipos)
        {
            await _service.UpdateEquiposAsync(idGrupo, JsonSerializer.Serialize(equipos));
        }

        public async Task DeleteGrupoAsync(int id)
        {
            await _service.DeleteGrupoAsync(id);
        }

        public async Task DeleteEquipoAsync(int equipoId)
        {
            await _service.DeleteEquipoAsync(equipoId);
        }

        public async Task DeletePartidoAsync(int partidoId)
        {
            await _service.DeletePartidoAsync(partidoId);
        }

        public async Task UpdateEquiposEdicionAsync(int edicionId, Edicion edicion)
        {
            await _service.UpdateEquiposEdicionAsync(edicionId, JsonSerializer.Serialize(edicion.EquiposToAdd), JsonSerializer.Serialize(edicion.EquiposToRemove));
        }
        public async Task UpdateEquiposEdicionAsync(int edicionId, List<Equipo> equipos)
        {
            var json = JsonSerializer.Serialize(equipos);
            await _service.UpdateEquiposEdicionAsync(edicionId, json);
        }

        public async Task UpdateGruposAsync(Edicion edicion)
        {
            // actualizar el tipo de calendario en la edición
            await _service.UpdateTipoCalendarioEdicionAsync(edicion.Id, edicion.TipoCalendario);

            // grupos y sus equipos
            var json = JsonSerializer.Serialize(edicion.Grupos);
            await _service.UpdateGruposAsync(edicion.Id, json);

            // jornadas
            json = JsonSerializer.Serialize(edicion.FechasJornadas);
            await _service.UpdateJornadasAsync(edicion.Id, json);
        }
        public async Task UpdateJornadasAsync(Edicion edicion)
        {
            var json = JsonSerializer.Serialize(edicion.FechasJornadas);
            await _service.UpdateJornadasAsync(edicion.Id, json);
        }

        public static string GetNombreEdicion(string temporada, string competicion, string categoria, string genero)
        {
            return temporada + "_" + competicion + "_" + categoria + "_" + genero;
        }

        public Task<string> GetTipoCalendarioEdicion(int id)
        {
            return _service.GetTipoCalendarioEdicion(id);
        }

        public async Task<List<EdicionGrupo>> GetAllGruposAsync(int? edicionId)
        {
            List<EdicionGrupo> list = new List<EdicionGrupo>();
            var json = await _service.GetAllGruposAsync(edicionId);
            JsonNode jsonNode = JsonNode.Parse(json);
            JsonArray jsonArray = jsonNode.AsArray();
            foreach (var jsGrupo in jsonArray)
                list.Add(EdicionGrupo.FromJson(jsGrupo));
            return list;
        }

        public async Task<List<Partido>> GetPartidosFiltradosAsync(int edicionSelected, int grupoSelected)
        {
            List<Partido> partidos = new List<Partido>();
            if (edicionSelected == 0) return partidos;
            var json = await _service.GetPartidosFiltradosAsync(edicionSelected, grupoSelected);
            JsonArray jsonArray = JsonNode.Parse(json!)!.AsArray();
            foreach (var p in jsonArray)
                partidos.Add(Partido.FromJsonVis(p));
            return partidos.OrderBy(p => p.Jornada).ThenBy(p => p.Label).ThenBy(p => p.FechaHora).ToList();
        }

        public async Task<List<SelectionItem>> GetListaEdiciones()
        {
            var json = await _service.GetAllEdicionesAsync();
            var ediciones = EdicionesFromJson(json);
            return ediciones.Select(e => new SelectionItem { Id = e.Id, Item = e.Alias }).ToList();
        }

        public async Task<List<SelectionItem>> GetListaGrupos(int edicionId)
        {
            var grupos = await GetAllGruposAsync(edicionId);
            return grupos.Select(g => new SelectionItem { Id = g.Id, Item = g.Name }).ToList();
        }

        public async Task<dynamic> ExportarCalendarioAsync(int competicionId, int grupoId)
        {
            var jsonEd = await _service.GetBasicEdicionAsync(competicionId);
            var edicion = Edicion.FromJson(JsonNode.Parse(jsonEd)!, false);

            var json = await _service.GetBasicGrupoAsync(grupoId);
            var grupo = EdicionGrupo.FromJson(JsonNode.Parse(json)!);

            var partidos = await GetPartidosFiltradosAsync(competicionId, grupoId);

            // Descargar el archivo de Excel en el navegador del usuario
            dynamic miObjetoDynamic = new System.Dynamic.ExpandoObject();
            miObjetoDynamic.edicion = edicion;
            miObjetoDynamic.grupo = grupo;
            miObjetoDynamic.partidos = partidos;
            return miObjetoDynamic;
        }
    }
}
