using Microsoft.AspNetCore.Mvc.ModelBinding;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace VoleyPlaya.Domain.Models
{
    public class EdicionGrupo : IDomainDto
    {
        public EdicionGrupo()
        {
            Name = "";
            TipoGrupo = EnumTipoGrupo.None;
            Equipos = new List<Equipo>();
            Partidos = new List<Partido>();
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

        public async Task GenerarPartidosAsync(string tipoCalendario, List<FechaJornada> jornadas, List<Equipo> equipos)
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
    }
}
