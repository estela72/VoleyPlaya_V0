using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace VoleyPlaya.Domain.Models
{ 
    public class Partido
    {
        public Partido()
        {
            Resultado = new Resultado();
        }
        public int Id { get; set; }
        public int Jornada { get; set; }
        public int NumPartido { get; set; }
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy HH:mm}")]
        public DateTime FechaHora { get; set; }
        public string Pista { get; set; }
        public string Local { get; set; }
        public string Visitante { get; set; }
        public Resultado Resultado { get; set; }
        public string Label { get; set; }
        public bool NoPresentadoLocal { get; set; }
        public bool NoPresentadoVisitante { get; set; }

        internal static Partido FromJson(JsonNode jsonPartido)
        {
            Partido partido = new()
            {
                Id = jsonPartido["Id"]!.GetValue<int>()!,
                FechaHora = jsonPartido["FechaHora"]!.GetValue<DateTime>()!,
                Jornada = jsonPartido["Jornada"]!.GetValue<int>()!,
                Local = EquipoFromJson(jsonPartido["Local"])!,
                NumPartido = jsonPartido["NumPartido"]!.GetValue<int>()!,
                Pista = jsonPartido["Pista"]!.GetValue<string>()!,
                Resultado = Resultado.FromJson(jsonPartido["Parciales"]! as JsonArray)!,
                Visitante = EquipoFromJson(jsonPartido["Visitante"]!)!,
                Label = jsonPartido["Label"]!.GetValue<string>()!
            };
            partido.Resultado.Local = jsonPartido["ResultadoLocal"]!.GetValue<int>();
            partido.Resultado.Visitante = jsonPartido["ResultadoVisitante"]!.GetValue<int>();

            return partido;
        }
        internal static Partido FromJsonVis(JsonNode jsonPartido)
        {
            Partido partido = new()
            {
                Id = jsonPartido["Id"]!.GetValue<int>()!,
                FechaHora = jsonPartido["FechaHora"]!.GetValue<DateTime>()!,
                Jornada = jsonPartido["Jornada"]!.GetValue<int>()!,
                Local = jsonPartido["Local"]!.GetValue<string>()!,
                NumPartido = jsonPartido["NumPartido"]!.GetValue<int>()!,
                Pista = jsonPartido["Pista"]!.GetValue<string>()!,
                Visitante = jsonPartido["Visitante"]!.GetValue<string>()!,
                Label = jsonPartido["Label"]!.GetValue<string>()!,
                Resultado = Resultado.FromJson(jsonPartido["Parciales"]! as JsonArray)!
            };
            partido.Resultado.Local = jsonPartido["ResultadoLocal"]!.GetValue<int>();
            partido.Resultado.Visitante = jsonPartido["ResultadoVisitante"]!.GetValue<int>();

            return partido;
        }
        private static string EquipoFromJson(JsonNode jsonNode)
        {
            return jsonNode["Nombre"].GetValue<string>()!;
        }
    }
}
