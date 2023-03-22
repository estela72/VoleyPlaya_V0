using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Markup;

using VoleyPlaya.Repository.Models;

namespace VoleyPlaya.Repository.Services
{
    public class VoleyPlayaService : IVoleyPlayaService
    {
        private IVoleyPlayaUnitOfWork _voleyPlayaUoW;
        public VoleyPlayaService(IVoleyPlayaUnitOfWork unitOfWork) => _voleyPlayaUoW= unitOfWork;
        JsonSerializerOptions Options = new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.IgnoreCycles };

        public async Task<bool> DeleteEdicionAsync(string edicionName)
        {
            return await _voleyPlayaUoW.EdicionRepository.Remove(edicionName);
        }

        public async Task<string> GetAllEdicionesAsync()
        {
            var dto = await _voleyPlayaUoW.EdicionRepository.GetFullAsync();
            //JsonSerializerOptions opt = new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.Preserve };
            var json = JsonSerializer.Serialize<List<Edicion>>(dto.ToList(),Options);
            return json;
        }

        public async Task<string> GetEdicionAsync(string edicionName)
        {
            var dto = await _voleyPlayaUoW.EdicionRepository.GetByNameAsync(edicionName);
            var json = JsonSerializer.Serialize<Edicion>(dto, Options);
            return json;
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
            // crear temporada, competicion y categoria si no existen
             var dtos = await BeforeSaveAsync(edicionNode);
            await _voleyPlayaUoW.SaveMauiChangesAsync();

            // crear o actualizar la edición
            string genero = edicionNode["GeneroStr"]!.GetValue<string>();
            string grupo = edicionNode["Grupo"]!.GetValue<string>();
            int numEquipos = edicionNode["NumEquipos"]!.GetValue<int>();
            int numJornadas = edicionNode["NumJornadas"]!.GetValue<int>();

            var edicionDto = await _voleyPlayaUoW.EdicionRepository.CheckAddUpdate(
                dtos.temporadaDto,
                dtos.competicionDto,
                dtos.categoriaDto,
                genero,
                grupo,
                numEquipos,
                numJornadas
                );
            await _voleyPlayaUoW.SaveMauiChangesAsync();

            // crear o actualizar los equipos
            JsonArray equipos = edicionNode["Equipos"]!.AsArray();
            foreach (var equipo in equipos)
            {
                int posicion = equipo["Posicion"]!.GetValue<int>()!;
                string nombre = equipo["Nombre"]!.GetValue<string>()!;
                int jugados = equipo["Jugados"]!.GetValue<int>()!;
                int ganados = equipo["Ganados"]!.GetValue<int>()!;
                int perdidos = equipo["Perdidos"]!.GetValue<int>()!;
                int puntosFavor = equipo["PuntosFavor"]!.GetValue<int>()!;
                int puntosContra = equipo["PuntosContra"]!.GetValue<int>()!;
                double coeficiente = equipo["Coeficiente"]!.GetValue<double>()!;
                int puntos = equipo["Puntos"]!.GetValue<int>()!;
                var equipoDto = await _voleyPlayaUoW.EquipoRepository.CheckAddUpdate(edicionDto, posicion, nombre, jugados, ganados, perdidos, puntosFavor, puntosContra,
                    coeficiente, puntos);
            }
            await _voleyPlayaUoW.SaveMauiChangesAsync();

            // crear o actualizar los partidos con sus resultados
            await AfterSaveAsync(edicionNode, edicionDto);

            await _voleyPlayaUoW.SaveMauiChangesAsync();
            return true;
        }

        public static string GetNombreEdicion(string temporada, string competicion, string categoria, string genero, string grupo)
        {
            return temporada + "_" + competicion + "_" + categoria + "_" + genero + "_" + grupo;
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

        private async Task AfterSaveAsync(JsonNode edicionNode, Edicion edicionDto)
        {
            JsonArray partidos = edicionNode["Partidos"]!.AsArray();
            foreach (var partido in partidos)
            {
                int jornada = partido["Jornada"]!.GetValue<int>()!;
                int numPartido = partido["NumPartido"]!.GetValue<int>()!;
                DateTime fecha = partido["Fecha"]!.GetValue<DateTime>()!;
                string horaDT = partido["Hora"]!.GetValue<string>();
                string[] val = horaDT.Split(':');
                TimeSpan hora = new TimeSpan(int.Parse(val[0]), int.Parse(val[1]), int.Parse(val[2]));
                string pista = partido["Pista"]!.GetValue<string>();
                string local = partido["Local"]!.GetValue<string>();
                string visitante = partido["Visitante"]!.GetValue<string>();
                var localDto = await _voleyPlayaUoW!.EquipoRepository.GetByNameAsync(local);
                var visitanteDto = await _voleyPlayaUoW.EquipoRepository.GetByNameAsync(visitante);

                var partidoDto = await _voleyPlayaUoW.PartidoRepository.CheckAddUpdate(edicionDto, localDto, visitanteDto, jornada, numPartido, fecha, hora, pista);

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

                edicionDto!.AddPartido(partidoDto);
            }

            JsonArray jornadas = edicionNode["FechasJornadas"]!.AsArray()!;
            foreach(var jornada in jornadas)
            {
                Jornada jornadaDto = new Jornada()
                {
                    Numero = jornada["Jornada"]!.GetValue<int>(),
                    Fecha = jornada["Fecha"]!.GetValue<DateTime>()
                };
                edicionDto.AddJornada(jornadaDto);
            }
        }
    }
}
