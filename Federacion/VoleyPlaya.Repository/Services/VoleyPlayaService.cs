using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using Org.BouncyCastle.Utilities.Collections;

using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Security.Claims;
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
            await _voleyPlayaUoW.SaveEntitiesAsync();
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
            await _voleyPlayaUoW.SaveEntitiesAsync();
            return res;
        }
        public async Task<List<Edicion>> GetAllEdicionesAsync()
        {
            var dto = await _voleyPlayaUoW.EdicionRepository.GetFullAsync();
            //var json = JsonSerializer.Serialize<List<Edicion>>(dto.ToList(),Options);
            return dto.OrderByDescending(c=>c.CreatedDate).ToList();
        }

        public async Task<Edicion> GetEdicionAsync(string edicionName)
        {
            var dto = await _voleyPlayaUoW.EdicionRepository.GetFullEdicionAsync(edicionName);
            //var json = JsonSerializer.Serialize<Edicion>(dto, Options);
            return dto;
        }
        public async Task<Edicion> GetEdicionAsync(int id)
        {
            var dto = await _voleyPlayaUoW.EdicionRepository.GetFullEdicionAsync(id);
            //var json = JsonSerializer.Serialize<Edicion>(dto, Options);
            return dto;
        }
        public async Task<Edicion> GetEdicionByIdAsync(int id)
        {
            var dto = await _voleyPlayaUoW.EdicionRepository.GetFullEdicionAsync(id);
            //var json = JsonSerializer.Serialize<Edicion>(dto, Options);
            return dto;
        }
        public async Task<Edicion> GetBasicEdicionAsync(int id)
        {
            var dto = await _voleyPlayaUoW.EdicionRepository.GetBasicAsync(id);
            return dto;// JsonSerializer.Serialize<Edicion>(dto, Options);
        }
        public Edicion GetEdicion(string edicionName)
        {
            var dto = _voleyPlayaUoW.EdicionRepository.GetByName(edicionName);
            //var json = JsonSerializer.Serialize<Edicion>(dto, Options);
            return dto;
        }
        public async Task<bool> SaveEdicionAsync(string json)
        {
            JsonNode edicionNode = JsonNode.Parse(json)!;
            Edicion edicionDto;
            // crear temporada, competicion y categoria si no existen
            var dtos = await BeforeSaveAsync(edicionNode);

            // crear o actualizar la edición
            edicionDto = await SaveEdicionAsync(edicionNode, dtos);
            await _voleyPlayaUoW.SaveEntitiesAsync();

            return true;
        }

        private async Task<bool> SaveGruposAsync(JsonArray grupos, Edicion edicionDto)
        {
            // almaceno grupos
            foreach (var grupo in grupos)
            {
                if (grupo["Name"] == null) continue;
                string nombre = grupo["Name"]!.GetValue<string>();
                string tipo = grupo["TipoGrupoStr"]!.GetValue<string>();
                var grupoDto = await _voleyPlayaUoW.EdicionGrupoRepository.CheckAddUpdate(edicionDto, nombre, tipo);
            }
            await _voleyPlayaUoW.SaveEntitiesAsync();

            foreach (var grupo in grupos)
            {
                if (grupo["Name"] == null) continue;
                string nombre = grupo["Name"]!.GetValue<string>();
                var grupoDto = await _voleyPlayaUoW.EdicionGrupoRepository.FindIncludingAsync(g => g.Edicion.Id.Equals(edicionDto.Id)
                    && g.Nombre.Equals(nombre), g => g.Equipos);
                JsonArray equipos = grupo["Equipos"]!.AsArray();
                await SaveEquiposAsync(grupoDto, equipos);
            }
            await _voleyPlayaUoW.SaveEntitiesAsync();
            return true;
        }
        // almacenar grupos y sus equipos
        public async Task<bool> UpdateGruposAsync(int id, string json)
        {
            JsonArray edicionNode = JsonNode.Parse(json)!.AsArray();
            Edicion edicionDto = await _voleyPlayaUoW.EdicionRepository.GetByIdAsync(id);
            await SaveGruposAsync(edicionNode, edicionDto);
            await _voleyPlayaUoW.SaveEntitiesAsync();
            return true;
        }
        private async Task<bool> SaveEquiposAsync(EdicionGrupo grupoDto, JsonArray equipos/*, int numEquipos*/)
        {
            foreach (var equipo in equipos)
            {
                int id = equipo!["Id"]!.GetValue<int>();
                int posicion = equipo!["Posicion"]!.GetValue<int>()!;
                int ordenEntrada = equipo!["OrdenEntrada"]!.GetValue<int>();
                string equiNombre = equipo["Nombre"]!.GetValue<string>()!;
                int jugados = equipo["Jugados"]!.GetValue<int>()!;
                int ganados = equipo["Ganados"]!.GetValue<int>()!;
                int perdidos = equipo["Perdidos"]!.GetValue<int>()!;
                int puntosFavor = equipo["PuntosFavor"]!.GetValue<int>()!;
                int puntosContra = equipo["PuntosContra"]!.GetValue<int>()!;
                double coeficiente = equipo["Coeficiente"]!.GetValue<double>()!;
                int puntos = equipo["Puntos"]!.GetValue<int>()!;
                var equipoDto = await _voleyPlayaUoW.EquipoRepository.CheckAddUpdate(grupoDto, id, posicion, equiNombre, jugados, ganados, perdidos, puntosFavor, puntosContra,
                    coeficiente, puntos, ordenEntrada);
                if (!grupoDto.Equipos.Contains(equipoDto))
                    grupoDto.Equipos.Add(equipoDto);
            }
            return true;
        }
        private async Task<bool> SaveEquiposAsync(Edicion edicionDto, JsonArray equipos)
        {
            foreach (var equipo in equipos)
            {
                int id = equipo!["Id"]!.GetValue<int>();
                int posicion = equipo!["Posicion"]!.GetValue<int>()!;
                int ordenEntrada = equipo!["OrdenEntrada"]!.GetValue<int>();
                string equiNombre = equipo["Nombre"]!.GetValue<string>()!;
                int jugados = equipo["Jugados"]!.GetValue<int>()!;
                int ganados = equipo["Ganados"]!.GetValue<int>()!;
                int perdidos = equipo["Perdidos"]!.GetValue<int>()!;
                int puntosFavor = equipo["PuntosFavor"]!.GetValue<int>()!;
                int puntosContra = equipo["PuntosContra"]!.GetValue<int>()!;
                double coeficiente = equipo["Coeficiente"]!.GetValue<double>()!;
                int puntos = equipo["Puntos"]!.GetValue<int>()!;
                await _voleyPlayaUoW.EquipoRepository.CheckAddUpdate(edicionDto, id, posicion, equiNombre, jugados, ganados, perdidos, puntosFavor, puntosContra,
                    coeficiente, puntos,ordenEntrada);
            }
            return true;
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
            string prueba = edicionNode["Prueba"]!.GetValue<string>();
            string tipoCalendario = "";
            if (edicionNode["tipoCalendario"]!=null) tipoCalendario = edicionNode["TipoCalendario"]!.GetValue<string>();
            string modeloCompeticion = edicionNode["ModeloCompeticionStr"]!.GetValue<string>();
            Edicion edicionDto = await _voleyPlayaUoW.EdicionRepository.CheckAddUpdate(
                dtos.temporadaDto,
                dtos.competicionDto,
                dtos.categoriaDto,
                genero,
                tipoCalendario,
                prueba,
                modeloCompeticion
                );
            return edicionDto;
        }
        public async Task<bool> UpdateJornadasAsync(int edicionId, string json)
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
            return await _voleyPlayaUoW.SaveEntitiesAsync();
        }

        public async Task<bool> UpdateGrupoPartidosAsync(string json)
        {
            JsonNode edicionNode = JsonNode.Parse(json)!;
            var id = edicionNode["Id"]!.GetValue<int>();
            EdicionGrupo edicionGrupoDto = await _voleyPlayaUoW.EdicionGrupoRepository.FindIncludingAsync(eg=>eg.Id.Equals(id), eg=>eg.Equipos);
            if (edicionGrupoDto != null)
            {
                //JsonObject equi = edicionNode["Equipos"].AsObject();
                JsonArray jsonEquipos = edicionNode["Equipos"]!.AsArray();
                await SaveEquiposAsync(edicionGrupoDto, jsonEquipos);
                JsonArray partidos = edicionNode["Partidos"]!.AsArray();
                await UpdatePartidos(edicionGrupoDto, partidos);
                return await _voleyPlayaUoW.SaveEntitiesAsync();
            }
            
            return false;
        }
        public async Task<bool> UpdateDatosPartidosAsync(string json)
        {
            JsonNode edicionNode = JsonNode.Parse(json)!;
            var id = edicionNode["Id"]!.GetValue<int>();
            EdicionGrupo edicionGrupoDto = await _voleyPlayaUoW.EdicionGrupoRepository.GetWithEquiposYPartidosAsync(id);
            if (edicionGrupoDto != null)
            {
                JsonArray partidos = edicionNode["Partidos"]!.AsArray();
                await UpdatePartidos(edicionGrupoDto, partidos);
                return await _voleyPlayaUoW.SaveEntitiesAsync();
            }
            return false;
        }

        public async Task<EdicionGrupo> UpdateResultadosPartidosAsync(string json)
        {
            JsonNode grupoNode = JsonNode.Parse(json)!;
            JsonArray partidos = grupoNode!.AsArray();
            int grupoId = await UpdateResultadoPartidos(partidos);
            await _voleyPlayaUoW.SaveEntitiesAsync();

            var grupoDto = await _voleyPlayaUoW.EdicionGrupoRepository.FindIncludingAsync(g=>g.Id.Equals(grupoId), g=>g.Equipos, g=>g.Partidos);
            return grupoDto;
        }
        public static string GetNombreEdicion(string temporada, string prueba, string competicion, string categoria, string genero)
        {
            return temporada + "_" + prueba + "_" + competicion + "_" + categoria + "_" + genero;
        }
        public static string GetGroupName(int groupNumber)
        {
            const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int alphabetLength = alphabet.Length;
            int index = groupNumber - 1;
            int firstLetterIndex = index / alphabetLength;
            int secondLetterIndex = index % alphabetLength;
            string groupName = "";

            if (firstLetterIndex > 0)
            {
                groupName += alphabet[firstLetterIndex - 1];
            }

            groupName += alphabet[secondLetterIndex];

            return groupName;
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
        private async Task AfterSaveAsync(JsonNode edicionNode, EdicionGrupo grupoDto, JsonArray partidos)
        {
            await UpdatePartidos(grupoDto, partidos);

            
        }
        private async Task UpdatePartidos(EdicionGrupo grupoDto, JsonArray partidos)
        {
            var user = _voleyPlayaUoW.GetCurrentUser();
            foreach (var partido in partidos)
            {
                var id = partido["Id"]!.GetValue<int>();
                int jornada = partido["Jornada"]!.GetValue<int>()!;
                int numPartido = partido["NumPartido"]!.GetValue<int>()!;
                DateTime fechaHora = partido["FechaHora"]!.GetValue<DateTime>()!;
                string pista = partido["Pista"]!=null?partido["Pista"]!.GetValue<string>():string.Empty;

                string local = string.Empty;
                if (partido["Local"] != null)
                    local = partido["Local"]!.GetValue<string>();
                else if (partido["NombreLocal"] != null)
                    local = partido["NombreLocal"]!.GetValue<string>();

                string visitante = string.Empty;
                if (partido["Visitante"] != null)
                    visitante = partido["Visitante"]!.GetValue<string>();
                else if (partido["NombreVisitante"] != null)
                    visitante = partido["NombreVisitante"]!.GetValue<string>();
                string label = partido["Label"]!=null?partido["Label"]!.GetValue<string>():string.Empty;

                string nombreLocal = local;
                if (partido["NombreLocal"]!=null)
                   nombreLocal = partido["NombreLocal"]!.GetValue<string>()!;
                string nombreVisitante = visitante;
                if (partido["NombreVisitante"]!=null)
                    nombreVisitante = partido["NombreVisitante"]!.GetValue<string>()!;
                bool validado = partido["Validado"]!.GetValue<bool>()!;

                var localDto = grupoDto.Equipos.SingleOrDefault(e=>e.Nombre.Equals(local));
                var visitanteDto = grupoDto.Equipos.SingleOrDefault(e => e.Nombre.Equals(visitante));

                string ronda = "I";
                if (partido["Ronda"] != null) ronda = partido["Ronda"]!.GetValue<string>();

                var partidoDto = await _voleyPlayaUoW.PartidoRepository.CheckAddUpdate(grupoDto, localDto, visitanteDto, id, jornada, numPartido, fechaHora, pista,label,validado, 
                    nombreLocal, nombreVisitante, ronda);

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

                partidoDto!.AddResultado(resLocal, resVisitante, set1Local, set1Visitante, set2Local, set2Visitante, set3Local, set3Visitante,user);

                grupoDto!.AddPartido(partidoDto);
            }
        }
        private async Task<int> UpdateResultadoPartidos(JsonArray partidos)
        {
            int grupoId = 0;
            var user = _voleyPlayaUoW.GetCurrentUser();
            foreach (var partido in partidos)
            {
                var id = partido["Id"]!.GetValue<int>();
                var partidoDto = await _voleyPlayaUoW.PartidoRepository.FindIncludingAsync(p=>p.Id.Equals(id), p=>p.Grupo);
                grupoId = partidoDto.Grupo.Id;
                JsonObject resultado = partido["Resultado"]!.AsObject()!;
                int resLocal = resultado["Local"]!.GetValue<int>()!;
                int resVisitante = resultado["Visitante"]!.GetValue<int>();
                if (partidoDto.ConResultado || partidoDto.Validado || (resLocal == 0 && resVisitante == 0))
                    continue;

                JsonObject set1 = resultado["Set1"]!.AsObject()!;
                int set1Local = set1["Local"]!.GetValue<int>();
                int set1Visitante = set1["Visitante"]!.GetValue<int>();
                JsonObject set2 = resultado["Set2"]!.AsObject()!;
                int set2Local = set2["Local"]!.GetValue<int>();
                int set2Visitante = set2["Visitante"]!.GetValue<int>();
                JsonObject set3 = resultado["Set3"]!.AsObject()!;
                int set3Local = set3["Local"]!.GetValue<int>();
                int set3Visitante = set3["Visitante"]!.GetValue<int>();

                partidoDto!.AddResultado(resLocal, resVisitante, set1Local, set1Visitante, set2Local, set2Visitante, set3Local, set3Visitante, user);
            }
            return grupoId;
        }
        public async Task<EdicionGrupo> GetGrupoAsync(int id)
        {
            var dto = await _voleyPlayaUoW.EdicionGrupoRepository.GetByIdAsync(id);
            //var json = JsonSerializer.Serialize<EdicionGrupo>(dto, Options);
            return dto;
        }
        public async Task<bool> UpdateEquiposAsync(int idGrupo, string jsonEquipos)
        {
            var grupoDto = await _voleyPlayaUoW.EdicionGrupoRepository.GetByIdAsync(idGrupo);
            JsonNode jsonGrupo = JsonNode.Parse(jsonEquipos)!;
            JsonArray equipos = jsonGrupo!.AsArray();
            await SaveEquiposAsync(grupoDto, equipos);
            return await _voleyPlayaUoW.SaveEntitiesAsync();
        }

        public async Task<bool> UpdateEquiposEdicionAsync(int idEdicion, string jsonEquiposToAddOrUpdate, string jsonEquiposToRemove)
        {
            var edicionDto = await _voleyPlayaUoW.EdicionRepository.GetByIdAsync(idEdicion);
            JsonNode json = JsonNode.Parse(jsonEquiposToAddOrUpdate)!;
            JsonArray equipos = json!.AsArray();
            await SaveEquiposAsync(edicionDto, equipos);

            json = JsonNode.Parse(jsonEquiposToRemove)!;
            equipos = json!.AsArray();
            await RemoveEquiposAsync(edicionDto, equipos);

            return await _voleyPlayaUoW.SaveEntitiesAsync();
        }

        public async Task<bool> UpdateEquiposEdicionAsync(int edicionId, string jsonEquipos)
        {
            var edicionDto = await _voleyPlayaUoW.EdicionRepository.GetByIdAsync(edicionId);
            JsonNode json = JsonNode.Parse(jsonEquipos)!;
            JsonArray equipos = json!.AsArray();
            await SaveEquiposAsync(edicionDto, equipos);
            return await _voleyPlayaUoW.SaveEntitiesAsync();
        }

        public async Task<bool> DeleteGrupoAsync(int id)
        {
            await DeleteGrupoWithPartidos(id);
            return await _voleyPlayaUoW.SaveEntitiesAsync();
        }
        public async Task<bool> DeleteGrupoWithPartidos(int id)
        {
            var grupo = await _voleyPlayaUoW.EdicionGrupoRepository.GetWithPartidosAsync(id);
            if (grupo == null) return false;
            foreach (var par in grupo.Partidos)
                await _voleyPlayaUoW.PartidoRepository.DeleteAsync(par.Id);

            await _voleyPlayaUoW.EdicionGrupoRepository.DeleteAsync(id);
            return await _voleyPlayaUoW.SaveEntitiesAsync();
        }
        public async Task<string> DeleteEquipoAsync(int id)
        {
            try
            {
                bool deleted = await _voleyPlayaUoW.EquipoRepository.DeleteAsync(id);
                var str = (await _voleyPlayaUoW.SaveEntitiesAsync()) ? "": "Se ha producido un error al borrar el equipo. Revise si el equipo está incluido en algún partido";
                return str;
            }
            catch(Exception x)
            {
                return "Se ha producido un error al borrar el equipo. Revise si el equipo está incluido en algún partido";
            }
        }
        public async Task<string> DeletePartidoAsync(int partidoId)
        {
            await _voleyPlayaUoW.PartidoRepository.DeleteAsync(partidoId);
            await _voleyPlayaUoW.SaveEntitiesAsync();
            return "El partido ha sido borrado";
        }
        public async Task<bool> UpdateTipoCalendarioEdicionAsync(int id, string tipoCalendario)
        {
            var edicionDto = await _voleyPlayaUoW.EdicionRepository.GetByIdAsync(id);
            edicionDto.TipoCalendario = tipoCalendario;
            await _voleyPlayaUoW.EdicionRepository.UpdateAsync(edicionDto);
            return await _voleyPlayaUoW.SaveEntitiesAsync();
        }
        public async Task<string> GetTipoCalendarioEdicion(int id)
        {
            var edicionDto = await _voleyPlayaUoW.EdicionRepository.GetByIdAsync(id);
            return edicionDto?.TipoCalendario;
        }

        public async Task<string> GetModeloCompeticionAsync(int id)
        {
            var edicionDto = await _voleyPlayaUoW.EdicionRepository.GetByIdAsync(id);
            return edicionDto?.ModeloCompeticion;
        }
        public async Task<List<EdicionGrupo>> GetAllGruposAsync(int? edicionId)
        {
            var grupos = await _voleyPlayaUoW.EdicionGrupoRepository.FindAllAsync(g => g.EdicionId.Equals(edicionId));
            return grupos.ToList();// JsonSerializer.Serialize<List<EdicionGrupo>>(grupos.ToList(), Options);
        }
        public async Task<List<PartidoVis>> GetPartidosFiltradosAsync(int edicionSelected, int grupoSelected)
        {
            if (grupoSelected != 0)
            {
                var partidosG = await _voleyPlayaUoW.PartidoRepository.FindAllIncludingAsync(p=>p.Grupo.Id.Equals(grupoSelected),
                    p=>p.Grupo, p=>p.Grupo.Edicion, p=>p.Grupo.Edicion.Competicion, p=>p.Grupo.Edicion.Categoria);
                var part = partidosG.Select(p => new PartidoVis(p)).ToList();
                return part;// json;
            }
            var partidos = await _voleyPlayaUoW.PartidoRepository.FindAllIncludingAsync(p=>p.Grupo.Edicion.Id.Equals(edicionSelected),
                                    p => p.Grupo, p => p.Grupo.Edicion, p => p.Grupo.Edicion.Competicion, p => p.Grupo.Edicion.Categoria);

            var partis = partidos.Select(p => new PartidoVis(p)).ToList();
            return partis;
        }
        public async Task<Edicion> GetBasicAsync(int id)
        {
            var edicion = await _voleyPlayaUoW.EdicionRepository.GetBasicAsync(id);
            return edicion;  
        }
        public async Task<EdicionGrupo> GetBasicGrupoAsync(int id)
        {
            var grupo = await _voleyPlayaUoW.EdicionGrupoRepository.GetBasicAsync(id);
            return grupo;
        }
        public async Task<EdicionGrupo> GetGrupoWithEquiposYPartidosAsync(int grupoId)
        {
            var grupo = await _voleyPlayaUoW.EdicionGrupoRepository.GetWithEquiposYPartidosAsync(grupoId);
            return grupo; 
        }
        public async Task<bool> AddEquipo(int edicionId, string equipo)
        {
            var edicion = await _voleyPlayaUoW.EdicionRepository.GetBasicAsync(edicionId);
            await _voleyPlayaUoW.EquipoRepository.CheckAddUpdate(edicion, 0, 0, equipo, 0, 0, 0, 0, 0, 0, 0,0);
            return await _voleyPlayaUoW.SaveEntitiesAsync();
        }
        public async Task<string> GetAllCompeticionesAsync(string idPrueba)
        {
            var dtos = await _voleyPlayaUoW.EdicionRepository.FindAllIncludingAsync(e=>e.Prueba.Equals(idPrueba), e=>e.Competicion);
            var competiciones = dtos.Select(e => new { Id = e.Competicion.Id, Nombre = e.Competicion.Nombre }).ToList();
            var comp = competiciones.Distinct();
            return JsonSerializer.Serialize(comp, Options);
        }
        public async Task<string> GetAllCategoriasByEdicionAsync(string idPrueba, int idCompeticion)
        {
            var ediciones = await _voleyPlayaUoW.EdicionRepository.FindAllIncludingAsync(e => e.Prueba.Equals(idPrueba) && e.Competicion.Id.Equals(idCompeticion), e=>e.Categoria);
            var categorias = ediciones.Select(e => new { Id = e.Categoria.Id, Nombre = e.Categoria.Nombre }).ToList();
            var cat = categorias.Distinct();
            return JsonSerializer.Serialize(cat, Options);
        }

        public async Task<string> GetAllGenerosAsync(string idPrueba, int idCompeticion, int idCategoria)
        {
            var ediciones = await _voleyPlayaUoW.EdicionRepository.FindAllAsync(e => e.Prueba.Equals(idPrueba) && e.Competicion.Id.Equals(idCompeticion)&&e.Categoria.Id.Equals(idCategoria));
            var generos = ediciones.Select(e => new { Id = e.Genero, Nombre = e.Genero}).ToList();
            return JsonSerializer.Serialize(generos, Options);
        }

        public async Task<string> GetAllGruposAsync(string idPrueba, int idCompeticion, int idCategoria, string genero)
        {
            var ediciones = await _voleyPlayaUoW.EdicionRepository.FindAllIncludingAsync(e => e.Prueba.Equals(idPrueba) && e.Competicion.Id.Equals(idCompeticion) && e.Categoria.Id.Equals(idCategoria) && e.Genero.Equals(genero), e=>e.Grupos);
            var grupos = ediciones.SelectMany(e=>e.Grupos).Select(g => new { Id = g.Id, Nombre = g.Nombre }).ToList();
            return JsonSerializer.Serialize(grupos, Options);
        }
        public async Task<List<EdicionGrupo>> GetClasificacionesAsync(string prueba, int competicionSelected, int categoriaSelected, string generoSelected, string grupoSelected)
        {
            var grupos = await _voleyPlayaUoW.EdicionGrupoRepository.GetWithEquiposAsync(prueba, competicionSelected, categoriaSelected, generoSelected, grupoSelected);
            return grupos;
        }

        public async Task<EdicionGrupo> RetirarEquipoAsync(int id)
        {
            var equipo = await _voleyPlayaUoW.EquipoRepository.GetByIdAsync(id);
            equipo.Retirado = true;
            await _voleyPlayaUoW.EquipoRepository.UpdateAsync(equipo);
            // buscar todos los partidos donde jugo este equipo y dejar el resultado como 0-0
            var partidos = await _voleyPlayaUoW.PartidoRepository.FindAllAsync(p => p.Local.Id.Equals(id) || p.Visitante.Id.Equals(id));
            foreach(var partido in partidos)
            {
                partido.ResultadoLocal = 0;
                partido.ResultadoVisitante = 0;
                foreach (var parcial in partido.Parciales)
                {
                    var resPar = await _voleyPlayaUoW.ParcialPartidoRepository.GetByIdAsync(parcial.Id);
                    resPar.ResultadoLocal = resPar.ResultadoVisitante = 0;
                    await _voleyPlayaUoW.ParcialPartidoRepository.UpdateAsync(resPar);
                }
                await _voleyPlayaUoW.PartidoRepository.UpdateAsync(partido);
            }
            // actualizar la clasificacion (desde dominio)
            await _voleyPlayaUoW.SaveEntitiesAsync();
            var grupo = await _voleyPlayaUoW.EdicionGrupoRepository.GetByIdAsync(equipo.EdicionGrupoId.Value);
            return grupo;// JsonSerializer.Serialize<EdicionGrupo>(grupo, Options);
        }

        public async Task<List<Partido>> GetPartidosAsync(string pruebaSelected, int competicionSelected, int categoriaSelected, string generoSelected, int grupoSelected)
        {
            var partidos = await _voleyPlayaUoW.PartidoRepository.GetListaPartidosAsync(pruebaSelected, competicionSelected, categoriaSelected, generoSelected, grupoSelected);
            return partidos;
        }
        public async Task<int> GetEdicionByIdAsync(string prueba, int competicion, int categoria, string genero)
        {
            var edicion = await _voleyPlayaUoW.EdicionRepository.FindAsync(e => e.Prueba.Equals(prueba) && e.Competicion.Id.Equals(competicion)
                                && e.Categoria.Id.Equals(categoria) && e.Genero.Equals(genero));
            return edicion.Id;
        }
        public async Task<string> UpdatePartidosFromExcelAsync(List<Partido> lista)
        {
            foreach(var partido in lista)
            {
                await _voleyPlayaUoW.PartidoRepository.UpdateHoraYPista(partido);
            }
            var msg = "Partidos actualizados";
            await _voleyPlayaUoW.SaveEntitiesAsync();
            return msg;
        }

        public async Task<List<EdicionGrupo>> GetAllGruposFiltradosAsync(string prueba, int idCompeticion, int idCategoria, string genero)
        {
            var edi = await _voleyPlayaUoW.EdicionRepository.FindAsync(e => e.Prueba.Equals(prueba) && e.Competicion.Id.Equals(idCompeticion) && e.Categoria.Id.Equals(idCategoria) && e.Genero.Equals(genero));
            var edicion = await _voleyPlayaUoW.EdicionRepository.GetFullEdicionAsync(edi.Id);
            var grupos = edicion.Grupos.ToList();
            return grupos;
        }

        public async Task<bool> SaveTablaCalendarios(List<TablaCalendario> partidos)
        {
            foreach (var partido in partidos)
            {
                try
                {
                    //partido.Nombre = "Calendario " + partido.NumEquipos.ToString() + " equipos - Partido " + partido.NumPartido;
                    var par = await _voleyPlayaUoW.TablaCalendarioRepository.FindAsync(p => p.Nombre.Equals(partido.Nombre));
                    if (par == null)
                        await _voleyPlayaUoW.TablaCalendarioRepository.CreateAsync(partido);
                    else
                    {
                        par.Equipo1 = partido.Equipo1;
                        par.Equipo2 = partido.Equipo2;
                        par.Jornada = partido.Jornada;
                        par.Ronda = partido.Ronda;
                        par.NumPartido = partido.NumPartido;
                        await _voleyPlayaUoW.TablaCalendarioRepository.UpdateAsync(partido);
                    }
                }
                catch (Exception x)
                { }
            }
            return await _voleyPlayaUoW.SaveEntitiesAsync();
        }
        public async Task<List<TablaCalendario>> GetCalendarioPartidosCircuito(int numEquipos)
        {
            var partidos = await _voleyPlayaUoW.TablaCalendarioRepository.FindAllAsync(t => t.NumEquipos == numEquipos);
            return partidos.ToList();
        }
        public async Task<List<TablaCalendario>> GetCalendarioPartidosCircuitoByNumGrupos(int numGrupos)
        {
            var partidos = await _voleyPlayaUoW.TablaCalendarioRepository.FindAllAsync(t => t.NumEquipos == -1 && t.NumGrupos==numGrupos);
            return partidos.ToList();
        }

        public async Task<bool> AddUpdateGrupoYPartidosFaseFinalAsync(int edicionId, string jsonGrupo)
        {
            var edicionDto = await _voleyPlayaUoW.EdicionRepository.GetByIdAsync(edicionId);
            if (edicionDto == null) return false;

            JsonNode json = JsonNode.Parse(jsonGrupo)!;
            var id = json["Id"]!.GetValue<int>();
            if (json["Name"] == null) return false;
            
            string nombre = json["Name"]!.GetValue<string>();
            string tipo = json["TipoGrupoStr"]!.GetValue<string>();
            var grupoDto = await _voleyPlayaUoW.EdicionGrupoRepository.CheckAddUpdate(edicionDto, nombre, tipo);
            await _voleyPlayaUoW.SaveEntitiesAsync();

            JsonArray jsonEquipos = json["Equipos"]!.AsArray();
            await SaveEquiposAsync(grupoDto, jsonEquipos);

            JsonArray partidos = json["Partidos"]!.AsArray();
            await UpdatePartidos(grupoDto, partidos);

            await _voleyPlayaUoW.SaveEntitiesAsync();
            return true;
        }
        public async Task<Edicion> GetEdicion(string pruebaId, int? competicionId, int? categoriaId, string generoId)
        {
            if (pruebaId ==null|| pruebaId.Equals("0") || competicionId == null || categoriaId == null || string.IsNullOrEmpty(generoId) || generoId.Equals("0"))
                return null;
            var edicion = await _voleyPlayaUoW.EdicionRepository.FindAsync(e => e.Prueba.Equals(pruebaId) && e.Competicion.Id.Equals(competicionId)
                            && e.Categoria.Id.Equals(categoriaId) && e.Genero.Equals(generoId));
            return edicion;
        }

        public async Task<string> ValidarPartidoAsync(int idPartido, bool activo)
        {
            var partido = await _voleyPlayaUoW.PartidoRepository.GetByIdAsync(idPartido);
            partido.Validado = activo;
            partido.UserValidador = _voleyPlayaUoW.GetCurrentUser();
            await _voleyPlayaUoW.SaveEntitiesAsync();
            return "Partido validado";
        }
        public async Task ArreglarGruposEquipos()
        {
            var ediciones = await _voleyPlayaUoW.EdicionRepository.GetAllIncludingAsync(e => e.Equipos);
            foreach (var edicion in ediciones)
            {
                foreach (var equipo in edicion.Equipos)
                {
                    var idGrupo = equipo.EdicionGrupoId ?? equipo.EdicionGrupoId.Value;
                    if (idGrupo != 0)
                    {
                        var ediGrupo = await _voleyPlayaUoW.EdicionGrupoRepository.GetByIdAsync(idGrupo);
                        equipo.Grupos.Add(ediGrupo);
                    }
                }
            }
            await _voleyPlayaUoW.SaveEntitiesAsync();
        }

        public async Task<string> ActualizarClasificacionFinal(int edicionId, List<Equipo> equipos)
        {
            string str = "";
            foreach(var equipo in equipos)
            {
                str += await _voleyPlayaUoW.EquipoRepository.UpdateClasificacionFinal(edicionId, equipo.Id, equipo.ClasificacionFinal);
            }
            await _voleyPlayaUoW.SaveEntitiesAsync();
            return str;
        }
        public async Task<string> GetListaPruebasAsync()
        {
            var dtos = await _voleyPlayaUoW.EdicionRepository.GetAllPruebasAsync();
            var pruebas = dtos.Select(e => new { Id = e.Id, Nombre = e.Prueba }).ToList();
            return JsonSerializer.Serialize(pruebas, Options);
        }
        public async Task<string> ActualizarPistaGrupo(int id, string pistaGrupo, bool sobreescribirPistasGrupo)
        {
            var grupo = await _voleyPlayaUoW.EdicionGrupoRepository.FindIncludingAsync(g => g.Id.Equals(id), g => g.Partidos);
            foreach (var partido in grupo.Partidos)
            {
                if (string.IsNullOrEmpty(partido.Pista) || (!string.IsNullOrEmpty(partido.Pista) && sobreescribirPistasGrupo))
                {
                    partido.Pista = pistaGrupo;
                    await _voleyPlayaUoW.PartidoRepository.UpdateAsync(partido);
                }
            }
            await _voleyPlayaUoW.SaveEntitiesAsync();
            return "Pistas actualizadas";
        }
    }
}
