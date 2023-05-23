using Microsoft.AspNetCore.Mvc.ModelBinding;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

using VoleyPlaya.Domain.Services;
using VoleyPlaya.Repository.Models;

namespace VoleyPlaya.Domain.Models
{
    public class EdicionGrupo : IDomainDto
    {
        IConfiguracionService _configService;

        public EdicionGrupo()
        {
            Name = "";
            TipoGrupo = EnumTipoGrupo.None;
            Equipos = new List<Equipo>();
            Partidos = new List<Partido>();
        }
        public EdicionGrupo(IConfiguracionService service):this()
        {
            _configService = service;
        }
        public int Id { get; set; }
        [Display(Name = "Grupo")]
        public string Name { get; set; }
        [Display(Name = "Nº Equipos")]
        public int NumEquipos { get; set; }
        public List<Equipo> Equipos { get; set; }

        [BindNever] 
        public List<Equipo> EquiposOrdered { get { return Equipos.OrderByDescending(e => e.Puntos).ThenByDescending(e => e.Coeficiente).ToList(); } }
        public List<Partido> Partidos { get; set; }
        public Edicion Edicion { get; set; }

        [Display(Name = "Tipo")]
        public EnumTipoGrupo TipoGrupo { get; set; }
        [Obsolete]
        public string TipoGrupoStr { get { return Enum.GetName(typeof(EnumTipoGrupo), TipoGrupo); } }

        public async Task GenerarPartidosAsync(EnumModeloCompeticion modeloCompeticion, string tipoCalendario, List<FechaJornada> jornadas, List<Equipo> equipos)
        {
            if (modeloCompeticion.Equals(EnumModeloCompeticion.JuegosDeportivos))
                await GeneraPartidosJuegosDeportivos(tipoCalendario, jornadas, equipos);
            else if (modeloCompeticion.Equals(EnumModeloCompeticion.Circuito))
                await GeneraPartidosJuegosDeportivos(tipoCalendario, jornadas, equipos); 
            else if (modeloCompeticion.Equals(EnumModeloCompeticion.Cuadro))
                await GeneraPartidosCircuito(jornadas, equipos);
        }

        private async Task GeneraPartidosJuegosDeportivos(string tipoCalendario, List<FechaJornada> jornadas, List<Equipo> equipos)
        { 
            var tablaOriginal = (await TablaCalendario.LoadCalendarios()).Where(t => t.Tipo.Equals(tipoCalendario)).FirstOrDefault();
            var numequi = Equipos.Count;
            if (tablaOriginal == null)
                tablaOriginal = await TablaCalendario.LoadCalendario(numequi, 1);
            var tabla = await TablaCalendario.LoadCalendario(numequi, tablaOriginal.NumVueltas);

            if (tabla == null) return;
            var numPartido = 1;
            foreach (var vuelta in tabla.Vueltas)
            {
                foreach (var partido in vuelta.Partidos)
                {
                    var fecha = jornadas.Where(j => j.Jornada == partido.Jornada).First().Fecha;
                    fecha = new DateTime(fecha.Year, fecha.Month, fecha.Day, 10, 0, 0);
                    Partido nuevoPartido = new()
                    {
                        Jornada = partido.Jornada,
                        Label = Name + numPartido.ToString(),
                        NumPartido = numPartido++,
                        FechaHora = fecha,
                        Pista = string.Empty,
                        Local = equipos.Where(e => e.Posicion == partido.Local).First().Nombre,
                        Visitante = equipos.Where(e => e.Posicion == partido.Visitante).First().Nombre,
                        Resultado = new Resultado()
                    };
                    if (!Partidos.Exists(p => p.NumPartido == nuevoPartido.NumPartido))
                        Partidos.Add(nuevoPartido);
                }
            }
        }

        private async Task GeneraPartidosCircuito(List<FechaJornada> jornadas, List<Equipo> equipos)
        {
            List<PartidoCalendarioCircuito> partidosCalendario = await _configService.GetTablaCalendario(equipos.Count);
            foreach(var partido in partidosCalendario)
            {
                var fecha = jornadas.Where(j => j.Jornada == partido.Jornada).First().Fecha;
                fecha = new DateTime(fecha.Year, fecha.Month, fecha.Day, 10, 0, 0);
                Partido nuevoPartido = new()
                {
                    Jornada = partido.Jornada,
                    Label = Name + partido.NumPartido.ToString(),
                    NumPartido = partido.NumPartido,
                    FechaHora = fecha,
                    Pista = string.Empty,
                    Local = GetEquipo(partido.Equipo1), 
                    Visitante = GetEquipo(partido.Equipo2),
                    Resultado = new Resultado()
                };
                if (!Partidos.Exists(p => p.NumPartido == nuevoPartido.NumPartido))
                    Partidos.Add(nuevoPartido);
            }
        }

        private string GetEquipo(string idEquipo)
        {
            if (idEquipo.StartsWith("GP")||idEquipo.StartsWith("PP"))
            {
                //Hay que obtener el ganador o perdedor del partido indicado en el número
                var idPartido = idEquipo.Substring(2);
                var numPartido = Convert.ToInt32(idPartido);
                var partido = Partidos.Where(p => p.NumPartido.Equals(numPartido)).FirstOrDefault();
                if (partido.Resultado.Local > 0 || partido.Resultado.Visitante>0) // el partido tiene resultado
                {
                    if (idEquipo.StartsWith("GP"))
                        if (partido.Resultado.Local > partido.Resultado.Visitante)
                            return partido.Local;
                        else
                            return partido.Visitante;
                    else if (idEquipo.StartsWith("PP"))
                        if (partido.Resultado.Local > partido.Resultado.Visitante)
                            return partido.Visitante;
                        else
                            return partido.Local;
                }
                else
                {
                    if (idEquipo.StartsWith("GP"))
                        return "Ganador partido " + numPartido;
                    else if (idEquipo.StartsWith("PP"))
                        return "Perdedor partido " + numPartido;
                }
            }
            else
            {
                // hay que obtener el equipo con Seed idEquipo
                int seed = Convert.ToInt32(idEquipo);
                return Equipos.Where(e => e.OrdenEntrada.Equals(seed)).First().Nombre;
            }
            return "ND";
        }

        public static EdicionGrupo FromJson(JsonNode jsonEdicion)
        {
            EdicionGrupo grupo = new EdicionGrupo();
            if (jsonEdicion == null) return grupo;
            grupo.Id = jsonEdicion["Id"]!.GetValue<int>();
            grupo.Name = jsonEdicion["Nombre"]!.GetValue<string>();
            grupo.Equipos = EquiposFromJson(jsonEdicion["Equipos"]!.AsArray());
            grupo.Partidos = PartidosFromJson(jsonEdicion["Partidos"]!.AsArray());

            if (jsonEdicion["Edicion"] !=null) grupo.Edicion = Edicion.FromJson(jsonEdicion["Edicion"]!, mapGrupos:false)!;
            //grupo.NumEquipos = jsonEdicion["NumEquipos"]!.GetValue<int>();
            grupo.NumEquipos = grupo.Equipos.Count;
            Enum.TryParse(jsonEdicion["Tipo"]!.GetValue<string>(), out EnumTipoGrupo tipo);
            grupo.TipoGrupo = tipo;
            return grupo;
        }

        private static List<Equipo> EquiposFromJson(JsonArray jsonEquipos)
        {
            List<Equipo> equipos = new List<Equipo>();
            foreach (var equipo in jsonEquipos)
                equipos.Add(Equipo.FromJson(equipo));
            return equipos;
        }
        private static List<Partido> PartidosFromJson(JsonArray jsonPartidos)
        {
            List<Partido> partidos = new List<Partido>();
            foreach (var partido in jsonPartidos)
                partidos.Add(Partido.FromJson(partido));
            return partidos;
        }
        public void UpdateEquipos(int numEquipos)
        {
            for (int i = Equipos.Count; i < numEquipos; i++)
                Equipos.Add(new Equipo(i + 1, "Equipo "+(i+1)+" a completar"));
            if (Equipos.Count > numEquipos)
                Equipos.RemoveRange(numEquipos, Equipos.Count - numEquipos);
            NumEquipos = numEquipos;
        }

        internal bool TodosPartidosJugados()
        {
            var noJugados = Partidos.Select(p => p.Resultado).Count(r => r.Local == 0 && r.Visitante == 0);
            return (noJugados == 0);
        }
    }
}
