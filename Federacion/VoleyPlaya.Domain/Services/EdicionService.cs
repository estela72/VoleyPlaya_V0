using AutoMapper;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;

using NPOI.POIFS.Crypt.Dsig;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using VoleyPlaya.Domain.Models;
using VoleyPlaya.Repository.Services;

using static System.Runtime.InteropServices.JavaScript.JSType;

using EdicionGrupo = VoleyPlaya.Domain.Models.EdicionGrupo;

namespace VoleyPlaya.Domain.Services
{
    public interface IEdicionService
    {
        Task<List<Edicion>> GetAllAsync();
        IEnumerable<Edicion> EdicionesFromJson(string jsonEdiciones);
        EdicionGrupo GetGrupoFromJson(string jsonEdicion);
        Task<Edicion> GetEdicionByName(string id);
        Task UpdateEdicionAsync(Edicion edicion);
        Task<Edicion> GetEdicionById(int id);
        Task<Edicion> GetEdicionByIdAsync(int id);
        Task DeleteEdicion(string nombre);
        Task DeleteEdicion(int id);
        Task UpdatePartidosAsync(EdicionGrupo edicion);
        Task UpdateDatosPartidosAsync(EdicionGrupo grupo);
        Task<EdicionGrupo> GetGrupoAsync(int value);
        Task<EdicionGrupo> UpdateGrupoAsync(EdicionGrupo grupo);
        Task UpdateEquipsGrupoAsync(int idGrupo, IList<Equipo> equipos);
        Task UpdateClasificacion(EdicionGrupo grupo);
        Task DeleteGrupoAsync(int id);
        Task<string> DeleteEquipoAsync(int equipoId);
        Task<string> DeletePartidoAsync(int partidoId);
        Task UpdateEquiposEdicionAsync(int edicionId, Edicion edicion);
        Task UpdateEquiposEdicionAsync(int edicionId, List<Equipo> equipos);
        Task UpdateGruposAsync(Edicion edicion);
        Task UpdateJornadasAsync(Edicion edicion);
        Task<string> GetTipoCalendarioEdicion(int id);
        Task<List<EdicionGrupo>> GetAllGruposAsync(int? edicionId);
        Task<List<Partido>> GetPartidosFiltradosAsync(int edicionSelected, int grupoSelected);
        Task<List<SelectionItem>> GetListaGrupos(int edicionId);
        Task<dynamic> ExportarCalendarioAsync(string prueba, int competicion, int categoria, string genero, int grupo);
        Task UpdatePartidosClasificacionAsync(List<Partido> partidos);
        Task AddEquipo(int edicionId,string nuevoEquipo);
        Task<List<SelectionItem>> GetListaPruebas();
        Task<List<SelectionItem>> GetListaCompeticiones(string idPrueba);
        Task<List<SelectionItem>> GetListaCategorias(string idPrueba, int idCompeticion);
        Task<List<SelectionItem>> GetListaGeneros(string idPrueba, int idCompeticion, int idCategoria);
        Task<List<SelectionItem>> GetListaGrupos(string idPrueba, int idCompeticion, int idCategoria, string idGenero);
        Task<List<SelectionItem>> GetListaEdiciones();
        Task<List<EdicionGrupo>> GetClasificacionEquiposAsync(string prueba, int competicionSelected, int categoriaSelected, string generoSelected, string grupoSelected);
        Task<string> RetirarEquipoASync(int id);
        Task<List<Partido>> GetPartidosFiltradosAsync(string pruebaSelected, int competicionSelected, int categoriaSelected, string generoSelected, int grupoSelected);
        Task<string> UpdatePartidosFromExcelAsync(List<Partido> partidos);
        Task<List<EdicionGrupo>> GetAllGruposAsync(string prueba, int competicion, int categoria, string generoSelected);
        Task<EnumModeloCompeticion> GetModeloCompeticionAsyn(int id);
        Task<bool> GenerarFaseFinal(int id, DateTime fechaFaseFinal, int intervaloMin);
        Task<Edicion> GetEdicionAsync(string pruebaId, int? competicionId, int? categoriaId, string generoId);
        Task<string> ValidarPartidoAsync(int idPartido, bool activo);
        Task<string> ActualizarClasificacionFinal(int edicionId, List<Equipo> equipos);
        Task<string> ActualizarPistaGrupo(int id, string pistaGrupo, bool sobreescribirPistasGrupo);
        Task<string> UpdateClasificacionGrupos(int edicionId);
    }
    public class EdicionService : IEdicionService
    {
        IVoleyPlayaService _service;
        IMapper _mapper;

        public EdicionService(IVoleyPlayaService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<List<Edicion>> GetAllAsync()
        {
            var ediciones = await _service.GetAllEdicionesAsync();
            return _mapper.Map<List<Edicion>>(ediciones);
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

        public async Task<Edicion> GetEdicionByName(string id)
        {
            var edicion = await _service.GetEdicionAsync(id);
            return _mapper.Map<Edicion>(edicion);
        }

        public async Task UpdateEdicionAsync(Edicion edicion)
        {
            string jsonString = JsonSerializer.Serialize(edicion);
            await _service.SaveEdicionAsync(jsonString);
        }

        public async Task<Edicion> GetEdicionById(int id)
        {
            var edicion = await _service.GetEdicionByIdAsync(id);
            return _mapper.Map<Edicion>(edicion);
        }
        public async Task<Edicion> GetEdicionByIdAsync(int id)
        {
            var dtoRepo = await _service.GetEdicionByIdAsync(id);
            return _mapper.Map<Edicion>(dtoRepo);
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
            JsonSerializerOptions options = new() { ReferenceHandler = ReferenceHandler.IgnoreCycles };
            string jsonString = JsonSerializer.Serialize(grupo, options);
            await _service.UpdateGrupoPartidosAsync(jsonString);
        }
        public async Task UpdateDatosPartidosAsync(EdicionGrupo grupo)
        {
            JsonSerializerOptions options = new() { ReferenceHandler = ReferenceHandler.IgnoreCycles };
            string jsonString = JsonSerializer.Serialize(grupo, options);
            await _service.UpdateDatosPartidosAsync(jsonString);
        }

        public async Task<Domain.Models.EdicionGrupo> GetGrupoAsync(int id)
        {
            var grupo = await _service.GetGrupoAsync(id);
            return _mapper.Map<Domain.Models.EdicionGrupo>(grupo);

        }
        public async Task UpdateClasificacion(EdicionGrupo grupo)
        {
            foreach (var equipo in grupo.Equipos)
                await equipo.Reset();
            foreach (var partido in grupo.Partidos)
            {
                var local = grupo.Equipos.First(e => e.Nombre.Equals(partido.Local));
                var visitante = grupo.Equipos.First(e => e.Nombre.Equals(partido.Visitante));
                ActualizarResultadoPartido(partido, local, visitante);
            }
        }
        private void ActualizarResultadoPartido(Partido partido, Equipo local, Equipo visitante)
        {
            partido.Resultado.Local = partido.Resultado.Sets.Count(s => s.Local > s.Visitante);
            partido.Resultado.Visitante = partido.Resultado.Sets.Count(s => s.Visitante > s.Local);
            if (partido.Resultado.Local > partido.Resultado.Visitante)
            {
                local.Ganados++;
                local.Puntos += 2;
                visitante.Perdidos++;
                visitante.Puntos += visitante.Retirado ? 0 : 1;
            }
            else if (partido.Resultado.Local < partido.Resultado.Visitante)
            {
                visitante.Ganados++;
                visitante.Puntos += 2;
                local.Perdidos++;
                local.Puntos += local.Retirado ? 0 : 1;
            }
            local.Jugados = local.Ganados + local.Perdidos;

            visitante.Jugados = visitante.Ganados + visitante.Perdidos;
            local.PuntosFavor += partido.Resultado.Set1.Local;
            local.PuntosFavor += partido.Resultado.Set2.Local;
            local.PuntosFavor += partido.Resultado.Set3.Local;

            local.PuntosContra += partido.Resultado.Set1.Visitante;
            local.PuntosContra += partido.Resultado.Set2.Visitante;
            local.PuntosContra += partido.Resultado.Set3.Visitante;

            if (local.PuntosContra != 0)
                local.Coeficiente = local.PuntosFavor * 1.0 / local.PuntosContra * 1.0;

            visitante.PuntosFavor += partido.Resultado.Set1.Visitante;
            visitante.PuntosFavor += partido.Resultado.Set2.Visitante;
            visitante.PuntosFavor += partido.Resultado.Set3.Visitante;

            visitante.PuntosContra += partido.Resultado.Set1.Local;
            visitante.PuntosContra += partido.Resultado.Set2.Local;
            visitante.PuntosContra += partido.Resultado.Set3.Local;

            if (visitante.PuntosContra != 0)
                visitante.Coeficiente = visitante.PuntosFavor * 1.0 / visitante.PuntosContra * 1.0;
        }

        public async Task<EdicionGrupo> UpdateGrupoAsync(EdicionGrupo grupo)
        {
            var gr = _mapper.Map<EdicionGrupo>(grupo);
            await grupo.GenerarPartidosAsync(gr.Edicion.ModeloCompeticion, gr.Edicion.TipoCalendario, gr.Edicion.FechasJornadas, gr.Equipos);
            string json = JsonSerializer.Serialize(grupo);
            await _service.UpdateGrupoPartidosAsync(json);

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

        public async Task<string> DeleteEquipoAsync(int equipoId)
        {
            return await _service.DeleteEquipoAsync(equipoId);
        }

        public async Task<string> DeletePartidoAsync(int partidoId)
        {
            return await _service.DeletePartidoAsync(partidoId);
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

        public static string GetNombreEdicion(string temporada, string prueba, string competicion, string categoria, string genero)
        {
            return temporada + "_" + prueba+"_"+ competicion + "_" + categoria + "_" + genero;
        }

        public Task<string> GetTipoCalendarioEdicion(int id)
        {
            return _service.GetTipoCalendarioEdicion(id);
        }

        public async Task<List<EdicionGrupo>> GetAllGruposAsync(int? edicionId)
        {
            List<EdicionGrupo> list = new List<EdicionGrupo>();
            var gruposDto = await _service.GetAllGruposAsync(edicionId);
            list = _mapper.Map<List<EdicionGrupo>>(gruposDto);
            return list;
        }

        public async Task<List<Partido>> GetPartidosFiltradosAsync(int edicionSelected, int grupoSelected)
        {
            //List<Partido> partidos = new List<Partido>();
            if (edicionSelected == 0) return new List<Partido>();
            var partidosDto = await _service.GetPartidosFiltradosAsync(edicionSelected, grupoSelected);
            var partidos = _mapper.Map<List<Partido>>(partidosDto);
            //JsonArray jsonArray = JsonNode.Parse(json!)!.AsArray();
            //foreach (var p in jsonArray)
            //    partidos.Add(Partido.FromJsonVis(p));
            return partidos.OrderBy(p => p.Jornada).ThenBy(p => p.Label).ThenBy(p => p.FechaHora).ToList();
        }

        
        public async Task<List<SelectionItem>> GetListaGrupos(int edicionId)
        {
            var grupos = await GetAllGruposAsync(edicionId);
            return grupos.Select(g => new SelectionItem { Id = g.Id, Item = g.Name }).ToList();
        }

        public async Task<dynamic> ExportarCalendarioAsync(string prueba, int competicion, int categoria, string genero, int grupoId)
        {
            var partidos = await GetPartidosFiltradosAsync(prueba,competicion, categoria, genero, grupoId);

            // Descargar el archivo de Excel en el navegador del usuario
            dynamic miObjetoDynamic = new System.Dynamic.ExpandoObject();
            miObjetoDynamic.edicion = partidos.First().Competicion+ " "+ partidos.First().Categoria+" "+partidos.First().Genero;
            miObjetoDynamic.grupo = partidos.First().Grupo;
            miObjetoDynamic.partidos = partidos;
            return miObjetoDynamic;
        }

        public async Task UpdatePartidosClasificacionAsync(List<Partido> partidos)
        {
            string jsonString = System.Text.Json.JsonSerializer.Serialize(partidos);
            var grupoDto = await _service.UpdateResultadosPartidosAsync(jsonString);
            var grupo = _mapper.Map<EdicionGrupo>(grupoDto);//EdicionGrupo.FromJson(JsonNode.Parse(json)!);
            if (grupo.TipoGrupo.Equals(EnumTipoGrupo.Liga))
            {
                await UpdateClasificacion(grupo);
                await UpdateEquipsGrupoAsync(grupo.Id, grupo.Equipos);
            }
        }

        public async Task AddEquipo(int edicionId, string nuevoEquipo)
        {
            await _service.AddEquipo(edicionId, nuevoEquipo);
        }
        public async Task<List<SelectionItem>> GetCompeticiones()
        {
            var edicionesDto = await _service.GetAllEdicionesAsync();
            var ediciones = _mapper.Map<List<Edicion>>(edicionesDto);  //EdicionesFromJson(json);
            return ediciones.Select(e => new SelectionItem { Id = e.Id, Item = e.Alias }).ToList();
        }
        public async Task<List<SelectionItem>> GetListaEdiciones()
        {
            var edicionesDto = await _service.GetAllEdicionesAsync();
            var ediciones = _mapper.Map<List<Edicion>>(edicionesDto);  //EdicionesFromJson(json);
            return ediciones.Select(e => new SelectionItem { Id = e.Id, Item = e.Alias }).ToList();
        }
        public async Task<List<SelectionItem>> GetListaPruebas()
        {
            var json = await _service.GetListaPruebasAsync();
            JsonNode node = JsonNode.Parse(json)!;
            JsonArray pruebas = node!.AsArray();
            List<SelectionItem> lista = new List<SelectionItem>();
            foreach (var prueba in pruebas)
                lista.Add(new SelectionItem { Id = prueba["Id"]!.GetValue<int>(), Item = prueba["Nombre"]!.GetValue<string>() });
            return lista;
        }
        public async Task<List<SelectionItem>> GetListaCompeticiones(string idPrueba)
        {
            var json = await _service.GetAllCompeticionesAsync(idPrueba);
            JsonNode node = JsonNode.Parse(json)!;
            JsonArray competiciones = node!.AsArray();
            List<SelectionItem> lista = new List<SelectionItem>();
            foreach (var cat in competiciones)
                lista.Add(new SelectionItem { Id = cat["Id"]!.GetValue<int>(), Item = cat["Nombre"]!.GetValue<string>() });
            return lista;
        }
        public async Task<List<SelectionItem>> GetListaCategorias(string idPrueba, int idCompeticion)
        {
            var json = await _service.GetAllCategoriasByEdicionAsync(idPrueba,idCompeticion);
            JsonNode node = JsonNode.Parse(json)!;
            JsonArray categorias = node!.AsArray();
            List<SelectionItem> lista = new List<SelectionItem>();
            foreach (var cat in categorias)
                lista.Add(new SelectionItem { Id = cat["Id"]!.GetValue<int>(), Item = cat["Nombre"]!.GetValue<string>() });
            return lista;
        }
        public async Task<List<SelectionItem>> GetListaGeneros(string idPrueba, int idCompeticion, int idCategoria)
        {
            var json = await _service.GetAllGenerosAsync(idPrueba,idCompeticion, idCategoria);
            JsonNode node = JsonNode.Parse(json)!;
            JsonArray generos = node!.AsArray();
            List<SelectionItem> lista = new List<SelectionItem>();
            int id = 0;
            foreach (var cat in generos)
                lista.Add(new SelectionItem { Id = id++, Item = cat["Nombre"]!.GetValue<string>() });
            return lista;
        }

        public async Task<List<SelectionItem>> GetListaGrupos(string idPrueba, int idCompeticion, int idCategoria, string genero)
        {
            var json = await _service.GetAllGruposAsync(idPrueba,idCompeticion, idCategoria, genero);
            JsonNode node = JsonNode.Parse(json)!;
            JsonArray grupos = node!.AsArray();
            List<SelectionItem> lista = new List<SelectionItem>();
            foreach (var cat in grupos)
                lista.Add(new SelectionItem { Id = cat["Id"]!.GetValue<int>(), Item = cat["Nombre"]!.GetValue<string>() });
            return lista;
        }

        public async Task<List<EdicionGrupo>> GetClasificacionEquiposAsync(string prueba, int competicionSelected, int categoriaSelected, string generoSelected, string grupoSelected)
        {
            List<EdicionGrupo> list = new List<EdicionGrupo>();
            var clasificaciones = await _service.GetClasificacionesAsync(prueba, competicionSelected, categoriaSelected, generoSelected, grupoSelected);
            list = _mapper.Map<List<EdicionGrupo>>(clasificaciones);
            return list;
        }

        public async Task<string> RetirarEquipoASync(int id)
        {
            var grupoDto = await _service.RetirarEquipoAsync(id);
            var grupo = _mapper.Map<EdicionGrupo>(grupoDto);
            // me devuelve el grupo para poder actualizar la clasificación
            //var grupo = GetGrupoFromJson(jsonGrupo);
            await UpdateClasificacion(grupo);
            await UpdatePartidosAsync(grupo);
            return "Equipo retirado";
        }

        public async Task<List<Partido>> GetPartidosFiltradosAsync(string pruebaSelected, int competicionSelected, int categoriaSelected, string generoSelected, int grupoSelected)
        {
            List<Partido> list = new List<Partido>();
            var partidos = await _service.GetPartidosAsync(pruebaSelected, competicionSelected, categoriaSelected, generoSelected, grupoSelected);
            list = _mapper.Map<List<Partido>>(partidos);
           
            return list;
        }

        public async Task<string> UpdatePartidosFromExcelAsync(List<Partido> partidos)
        {
            var lista = _mapper.Map<List<VoleyPlaya.Repository.Models.Partido>>(partidos);
            string msg = await _service.UpdatePartidosFromExcelAsync(lista);
            return msg;
        }

        public async Task<List<EdicionGrupo>> GetAllGruposAsync(string pruebaId, int competicion, int categoria, string genero)
        {
            List<EdicionGrupo> list = new List<EdicionGrupo>();
            var gruposDto = await _service.GetAllGruposFiltradosAsync(pruebaId, competicion,categoria,genero);
            list = _mapper.Map<List<EdicionGrupo>>(gruposDto);
            return list;
        }

        public async Task<EnumModeloCompeticion> GetModeloCompeticionAsyn(int id)
        {
            string modelo = await _service.GetModeloCompeticionAsync(id);
            return (EnumModeloCompeticion)Enum.Parse(typeof(EnumModeloCompeticion), modelo);
        }

        public async Task<bool> GenerarFaseFinal(int id, DateTime fechaFaseFinal, int intervaloMin)
        {
            //Generar la fase final para la edición con id=id
            var edi = await _service.GetEdicionByIdAsync(id);
            var edicion = _mapper.Map<Edicion>(edi);

            var tablaCalendario = new TablaCalendarioCircuito(_service, _mapper);

            if (await edicion.GenerarFaseFinal(tablaCalendario, fechaFaseFinal, intervaloMin))
            {
                var grupo = edicion.Grupos.Where(g => g.TipoGrupo.Equals(EnumTipoGrupo.Final)).FirstOrDefault();
                if (grupo == null) return false;
                JsonSerializerOptions options = new() { ReferenceHandler = ReferenceHandler.IgnoreCycles };
                string jsonString = JsonSerializer.Serialize(grupo, options);
                await _service.AddUpdateGrupoYPartidosFaseFinalAsync(id, jsonString);
                return true;
            }
            return false;
        }

        public async Task<Edicion> GetEdicionAsync(string pruebaId, int? competicionId, int? categoriaId, string generoId)
        {
            var edicion = await _service.GetEdicion(pruebaId, competicionId, categoriaId, generoId);
            return _mapper.Map<Edicion>(edicion);
        }

        public async Task<string> ValidarPartidoAsync(int idPartido, bool activo)
        {
            return await _service.ValidarPartidoAsync(idPartido, activo);
        }

        public async Task<string> ActualizarClasificacionFinal(int edicionId, List<Equipo> equipos)
        {
            var equi = _mapper.Map<List<VoleyPlaya.Repository.Models.Equipo>>(equipos);
            return await _service.ActualizarClasificacionFinal(edicionId, equi);
        }

        public async Task<string> ActualizarPistaGrupo(int id, string pistaGrupo, bool sobreescribirPistasGrupo)
        {
            return await _service.ActualizarPistaGrupo(id, pistaGrupo, sobreescribirPistasGrupo);
        }
        public async Task<string> UpdateClasificacionGrupos(int edicionId)
        {
            var edicion = await _service.GetEdicionByIdAsync(edicionId);
            var edi = _mapper.Map<Edicion>(edicion);
            foreach (var grupo in edi.Grupos.Where(g=>g.TipoGrupo.Equals(EnumTipoGrupo.Liga)))
            {
                await UpdateClasificacion(grupo);
                await UpdateEquipsGrupoAsync(grupo.Id, grupo.Equipos);
            }
            return "Clasificación grupos actualizada";
        }
    }
}
