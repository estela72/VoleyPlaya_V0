﻿using Org.BouncyCastle.Utilities.Collections;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Markup;
using VoleyPlaya.Repository.Models;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VoleyPlaya.Repository.Services
{
    public class VoleyPlayaService : IVoleyPlayaService
    {
        private IVoleyPlayaUnitOfWork _voleyPlayaUoW;
        public VoleyPlayaService(IVoleyPlayaUnitOfWork unitOfWork) => _voleyPlayaUoW= unitOfWork;
        JsonSerializerOptions Options = new() { ReferenceHandler = ReferenceHandler.IgnoreCycles };

        public async Task<bool> DeleteEdicionAsync(string edicionName)
        {
            bool val = await _voleyPlayaUoW.EdicionRepository.Remove(edicionName);
            await _voleyPlayaUoW.SaveMauiChangesAsync();
            return val;
        }
        public async Task<bool> DeleteEdicionAsync(int id)
        {
            // obtener la edición
            var edi = await _voleyPlayaUoW.EdicionRepository.GetFullEdicionAsync(id);
            if (edi == null) return true;
            foreach (var jor in edi.Jornadas)
                await _voleyPlayaUoW.JornadaRepository.DeleteAsync(jor.Id);
            foreach (var equi in edi.Equipos)
                await _voleyPlayaUoW.EquipoRepository.DeleteAsync(equi.Id);
            foreach (var grupo in edi.Grupos)
                await DeleteGrupoWithPartidos(grupo.Id);

            bool res = await _voleyPlayaUoW.EdicionRepository.Remove(id);
            await _voleyPlayaUoW.SaveMauiChangesAsync();
            return res;
        }
        public async Task<string> GetAllEdicionesAsync()
        {
            var dto = await _voleyPlayaUoW.EdicionRepository.GetFullAsync();
            var json = JsonSerializer.Serialize<List<Edicion>>(dto.ToList(),Options);
            return json;
        }

        public async Task<string> GetEdicionAsync(string edicionName)
        {
            var dto = await _voleyPlayaUoW.EdicionRepository.GetFullEdicionAsync(edicionName);
            var json = JsonSerializer.Serialize<Edicion>(dto, Options);
            return json;
        }
        public async Task<string> GetEdicionAsync(int id)
        {
            var dto = await _voleyPlayaUoW.EdicionRepository.GetFullEdicionAsync(id);
            var json = JsonSerializer.Serialize<Edicion>(dto, Options);
            return json;
        }
        public async Task<string> GetBasicEdicionAsync(int id)
        {
            var dto = await _voleyPlayaUoW.EdicionRepository.GetBasicAsync(id);
            return JsonSerializer.Serialize<Edicion>(dto, Options);
        }
        public string GetEdicion(string edicionName)
        {
            var dto = _voleyPlayaUoW.EdicionRepository.GetByName(edicionName);
            var json = JsonSerializer.Serialize<Edicion>(dto, Options);
            return json;
        }
        public async Task<bool> SaveEdicionAsync(string json)
        {
            JsonNode edicionNode = JsonNode.Parse(json)!;
            Edicion edicionDto;
            // crear temporada, competicion y categoria si no existen
            var dtos = await BeforeSaveAsync(edicionNode);

            // crear o actualizar la edición
            edicionDto = await SaveEdicionAsync(edicionNode, dtos);
            await _voleyPlayaUoW.SaveMauiChangesAsync();

            return true;
        }

        private async Task SaveGruposAsync(JsonArray grupos, Edicion edicionDto)
        {
            // almaceno grupos
            foreach (var grupo in grupos)
            {
                if (grupo["Name"] == null) continue;
                string nombre = grupo["Name"]!.GetValue<string>();
                string tipo = grupo["TipoGrupoStr"]!.GetValue<string>();
                var grupoDto = await _voleyPlayaUoW.EdicionGrupoRepository.CheckAddUpdate(edicionDto, nombre, tipo);
            }
            await _voleyPlayaUoW.SaveMauiChangesAsync();

            foreach (var grupo in grupos)
            {
                if (grupo["Name"] == null) continue;
                string nombre = grupo["Name"]!.GetValue<string>();
                var grupoDto = await _voleyPlayaUoW.EdicionGrupoRepository.FindIncludingAsync(g => g.Edicion.Id.Equals(edicionDto.Id)
                    && g.Nombre.Equals(nombre), g => g.Equipos);
                JsonArray equipos = grupo["Equipos"]!.AsArray();
                await SaveEquiposAsync(grupoDto, equipos);
            }
            await _voleyPlayaUoW.SaveMauiChangesAsync();

        }
        // almacenar grupos y sus equipos
        public async Task UpdateGruposAsync(int id, string json)
        {
            JsonArray edicionNode = JsonNode.Parse(json)!.AsArray();
            Edicion edicionDto = await _voleyPlayaUoW.EdicionRepository.GetByIdAsync(id);
            await SaveGruposAsync(edicionNode, edicionDto);
            await _voleyPlayaUoW.SaveMauiChangesAsync();
        }
        private async Task SaveEquiposAsync(EdicionGrupo grupoDto, JsonArray equipos/*, int numEquipos*/)
        {
            foreach (var equipo in equipos)
            {
                int posicion = equipo!["Posicion"]!.GetValue<int>()!;
                string equiNombre = equipo["Nombre"]!.GetValue<string>()!;
                int jugados = equipo["Jugados"]!.GetValue<int>()!;
                int ganados = equipo["Ganados"]!.GetValue<int>()!;
                int perdidos = equipo["Perdidos"]!.GetValue<int>()!;
                int puntosFavor = equipo["PuntosFavor"]!.GetValue<int>()!;
                int puntosContra = equipo["PuntosContra"]!.GetValue<int>()!;
                double coeficiente = equipo["Coeficiente"]!.GetValue<double>()!;
                int puntos = equipo["Puntos"]!.GetValue<int>()!;
                var equipoDto = await _voleyPlayaUoW.EquipoRepository.CheckAddUpdate(grupoDto, posicion, equiNombre, jugados, ganados, perdidos, puntosFavor, puntosContra,
                    coeficiente, puntos);
            }
            //// borrar equipos si es necesario
            //if (equipos.Count < grupoDto.Equipos.Count)
            //{
            //    await _voleyPlayaUoW.EquipoRepository.RemoveEquipos(equipos.Count, grupoDto);
            //}
        }
        private async Task SaveEquiposAsync(Edicion edicionDto, JsonArray equipos)
        {
            foreach (var equipo in equipos)
            {
                int posicion = equipo!["Posicion"]!.GetValue<int>()!;
                string equiNombre = equipo["Nombre"]!.GetValue<string>()!;
                int jugados = equipo["Jugados"]!.GetValue<int>()!;
                int ganados = equipo["Ganados"]!.GetValue<int>()!;
                int perdidos = equipo["Perdidos"]!.GetValue<int>()!;
                int puntosFavor = equipo["PuntosFavor"]!.GetValue<int>()!;
                int puntosContra = equipo["PuntosContra"]!.GetValue<int>()!;
                double coeficiente = equipo["Coeficiente"]!.GetValue<double>()!;
                int puntos = equipo["Puntos"]!.GetValue<int>()!;
                await _voleyPlayaUoW.EquipoRepository.CheckAddUpdate(edicionDto, posicion, equiNombre, jugados, ganados, perdidos, puntosFavor, puntosContra,
                    coeficiente, puntos);
            }
        }
        private async Task RemoveEquiposAsync(Edicion edicionDto, JsonArray equipos)
        {
            foreach(var equipo in equipos)
            {
                int id = equipo["Id"]!.GetValue<int>()!;
                await _voleyPlayaUoW.EquipoRepository.DeleteAsync(id);
            }
        }
        private async Task<Edicion> SaveEdicionAsync(JsonNode edicionNode, dynamic dtos)
        {
            string genero = edicionNode["GeneroStr"]!.GetValue<string>();
            string lugar = edicionNode["Lugar"]!.GetValue<string>();
            string tipoCalendario = "";
            if (edicionNode["tipoCalendario"]!=null) tipoCalendario = edicionNode["TipoCalendario"]!.GetValue<string>();
            Edicion edicionDto = await _voleyPlayaUoW.EdicionRepository.CheckAddUpdate(
                dtos.temporadaDto,
                dtos.competicionDto,
                dtos.categoriaDto,
                genero,
                tipoCalendario,
                lugar
                );
            return edicionDto;
        }
        public async Task UpdateJornadasAsync(int edicionId, string json)
        {
            var edicionDto = await _voleyPlayaUoW.EdicionRepository.GetByIdAsync(edicionId);
            JsonNode jsonNode = JsonNode.Parse(json)!;
            JsonArray jornadas = jsonNode!.AsArray()!;
            foreach (var jornada in jornadas)
            {
                var numero = jornada["Jornada"]!.GetValue<int>();
                var fecha = jornada["Fecha"]!.GetValue<DateTime>();
                var nombre = "Jornada " + jornada["Jornada"]!.GetValue<int>().ToString();
                var jornadaDto = await _voleyPlayaUoW.JornadaRepository.CheckAddUpdate(edicionDto, numero, fecha, nombre);
            }
            await _voleyPlayaUoW.SaveMauiChangesAsync();
        }

        public async Task UpdatePartidosAsync(string json)
        {
            JsonNode edicionNode = JsonNode.Parse(json)!;
            var id = edicionNode["Id"]!.GetValue<int>();
            EdicionGrupo edicionGrupoDto = await _voleyPlayaUoW.EdicionGrupoRepository.GetByIdAsync(id);
            if (edicionGrupoDto != null)
            {
                JsonArray jsonEquipos = edicionNode["Equipos"]!.AsArray();
                await SaveEquiposAsync(edicionGrupoDto, jsonEquipos/*, edicionGrupoDto.NumEquipos*/);
                await UpdatePartidos(edicionNode, edicionGrupoDto);
                await _voleyPlayaUoW.SaveMauiChangesAsync();
            }
        }
        public static string GetNombreEdicion(string temporada, string competicion, string categoria, string genero)
        {
            return temporada + "_" + competicion + "_" + categoria + "_" + genero;
        }
        private async Task<dynamic> BeforeSaveAsync(JsonNode competicionNode)
        {
            string temporada = competicionNode["Temporada"]!.GetValue<string>();
            var temporadaDto = await _voleyPlayaUoW.TemporadaRepository.CheckAddUpdate(temporada);

            string competicion = competicionNode["Competicion"]!.GetValue<string>();
            var competicionDto = await _voleyPlayaUoW.CompeticionRepository.CheckAddUpdate(competicion);

            string categoria = competicionNode["CategoriaStr"]!.GetValue<string>();
            var categoriaDto = await _voleyPlayaUoW.CategoriaRepository.CheckAddUpdate(categoria);

            return new { temporadaDto, competicionDto, categoriaDto };
        }
        private async Task AfterSaveAsync(JsonNode edicionNode, EdicionGrupo grupoDto)
        {
            await UpdatePartidos(edicionNode, grupoDto);

            
        }
        private async Task UpdatePartidos(JsonNode edicionNode, EdicionGrupo grupoDto)
        {
            JsonArray partidos = edicionNode["Partidos"]!.AsArray();
            foreach (var partido in partidos)
            {
                var id = partido["Id"]!.GetValue<int>();
                int jornada = partido["Jornada"]!.GetValue<int>()!;
                int numPartido = partido["NumPartido"]!.GetValue<int>()!;
                DateTime fechaHora = partido["FechaHora"]!.GetValue<DateTime>()!;
                string pista = partido["Pista"]!=null?partido["Pista"]!.GetValue<string>():string.Empty;
                string local = partido["Local"]!.GetValue<string>();
                string visitante = partido["Visitante"]!.GetValue<string>();
                string label = partido["Label"]!=null?partido["Label"]!.GetValue<string>():string.Empty;
                var localDto = grupoDto.Equipos.SingleOrDefault(e=>e.Nombre.Equals(local));
                var visitanteDto = grupoDto.Equipos.SingleOrDefault(e => e.Nombre.Equals(visitante));

                var partidoDto = await _voleyPlayaUoW.PartidoRepository.CheckAddUpdate(grupoDto, localDto, visitanteDto, id, jornada, numPartido, fechaHora, pista,label);

                JsonObject resultado = partido["Resultado"]!.AsObject()!;
                int resLocal = resultado["Local"]!.GetValue<int>()!;
                int resVisitante = resultado["Visitante"]!.GetValue<int>();

                JsonObject set1 = resultado["Set1"]!.AsObject()!;
                int set1Local = set1["Local"]!.GetValue<int>();
                int set1Visitante = set1["Visitante"]!.GetValue<int>();
                JsonObject set2 = resultado["Set2"]!.AsObject()!;
                int set2Local = set2["Local"]!.GetValue<int>();
                int set2Visitante = set2["Visitante"]!.GetValue<int>();
                JsonObject set3 = resultado["Set3"]!.AsObject()!;
                int set3Local = set3["Local"]!.GetValue<int>();
                int set3Visitante = set3["Visitante"]!.GetValue<int>();

                partidoDto!.AddResultado(resLocal, resVisitante, set1Local, set1Visitante, set2Local, set2Visitante, set3Local, set3Visitante);

                grupoDto!.AddPartido(partidoDto);
            }
        }
        public async Task<string> GetGrupoAsync(int id)
        {
            var dto = await _voleyPlayaUoW.EdicionGrupoRepository.GetByIdAsync(id);
            var json = JsonSerializer.Serialize<EdicionGrupo>(dto, Options);
            return json;
        }
        public async Task UpdateEquiposAsync(int idGrupo, string jsonEquipos)
        {
            var grupoDto = await _voleyPlayaUoW.EdicionGrupoRepository.GetByIdAsync(idGrupo);
            JsonNode jsonGrupo = JsonNode.Parse(jsonEquipos)!;
            JsonArray equipos = jsonGrupo!.AsArray();
            await SaveEquiposAsync(grupoDto, equipos/*, grupoDto.NumEquipos*/);
            await _voleyPlayaUoW.SaveMauiChangesAsync();
        }

        public async Task UpdateEquiposEdicionAsync(int idEdicion, string jsonEquiposToAddOrUpdate, string jsonEquiposToRemove)
        {
            var edicionDto = await _voleyPlayaUoW.EdicionRepository.GetByIdAsync(idEdicion);
            JsonNode json = JsonNode.Parse(jsonEquiposToAddOrUpdate)!;
            JsonArray equipos = json!.AsArray();
            await SaveEquiposAsync(edicionDto, equipos);

            json = JsonNode.Parse(jsonEquiposToRemove)!;
            equipos = json!.AsArray();
            await RemoveEquiposAsync(edicionDto, equipos);

            await _voleyPlayaUoW.SaveMauiChangesAsync();
        }

        public async Task UpdateEquiposEdicionAsync(int edicionId, string jsonEquipos)
        {
            var edicionDto = await _voleyPlayaUoW.EdicionRepository.GetByIdAsync(edicionId);
            JsonNode json = JsonNode.Parse(jsonEquipos)!;
            JsonArray equipos = json!.AsArray();
            await SaveEquiposAsync(edicionDto, equipos);
            await _voleyPlayaUoW.SaveMauiChangesAsync();
        }

        public async Task DeleteGrupoAsync(int id)
        {
            await DeleteGrupoWithPartidos(id);
            await _voleyPlayaUoW.SaveMauiChangesAsync();
        }
        public async Task DeleteGrupoWithPartidos(int id)
        {
            var grupo = await _voleyPlayaUoW.EdicionGrupoRepository.GetWithPartidosAsync(id);
            if (grupo == null) return;
            foreach (var par in grupo.Partidos)
                await _voleyPlayaUoW.PartidoRepository.DeleteAsync(par.Id);

            await _voleyPlayaUoW.EdicionGrupoRepository.DeleteAsync(id);
        }
        public async Task DeleteEquipoAsync(int id)
        {
            await _voleyPlayaUoW.EquipoRepository.DeleteAsync(id);
            await _voleyPlayaUoW.SaveMauiChangesAsync();
        }
        public async Task DeletePartidoAsync(int partidoId)
        {
            await _voleyPlayaUoW.PartidoRepository.DeleteAsync(partidoId);
            await _voleyPlayaUoW.SaveMauiChangesAsync();
        }
        public async Task UpdateTipoCalendarioEdicionAsync(int id, string tipoCalendario)
        {
            var edicionDto = await _voleyPlayaUoW.EdicionRepository.GetByIdAsync(id);
            edicionDto.TipoCalendario = tipoCalendario;
            await _voleyPlayaUoW.EdicionRepository.UpdateAsync(edicionDto);
            await _voleyPlayaUoW.SaveMauiChangesAsync();
        }
        public async Task<string> GetTipoCalendarioEdicion(int id)
        {
            var edicionDto = await _voleyPlayaUoW.EdicionRepository.GetByIdAsync(id);
            return edicionDto?.TipoCalendario;
        }
        public async Task<string> GetAllGruposAsync(int? edicionId)
        {
            var grupos = await _voleyPlayaUoW.EdicionGrupoRepository.FindAllAsync(g => g.EdicionId.Equals(edicionId));
            return JsonSerializer.Serialize<List<EdicionGrupo>>(grupos.ToList(), Options);
        }

        public async Task<string> GetPartidosFiltradosAsync(int edicionSelected, int grupoSelected)
        {
            if (grupoSelected != 0)
            {
                var partidosG = await _voleyPlayaUoW.PartidoRepository.FindAllAsync(p=>p.Grupo.Id.Equals(grupoSelected));
                var part = partidosG.Select(p => new PartidoVis(p)).ToList();
                var json = JsonSerializer.Serialize<List<PartidoVis>>(part);
                return json;
            }
            var partidos = await _voleyPlayaUoW.PartidoRepository.FindAllAsync(p=>p.Grupo.Edicion.Id.Equals(edicionSelected));
            var partis = partidos.Select(p => new PartidoVis(p)).ToList();
            var json2 = JsonSerializer.Serialize<List<PartidoVis>>(partis);
            return json2;
        }
        public async Task<string> GetBasicAsync(int id)
        {
            var edicion = await _voleyPlayaUoW.EdicionRepository.GetBasicAsync(id);
            return JsonSerializer.Serialize<Edicion>(edicion, Options);
        }
        public async Task<string> GetBasicGrupoAsync(int id)
        {
            var grupo = await _voleyPlayaUoW.EdicionGrupoRepository.GetBasicAsync(id);
            return JsonSerializer.Serialize<EdicionGrupo>(grupo, Options);
        }
    }
}
