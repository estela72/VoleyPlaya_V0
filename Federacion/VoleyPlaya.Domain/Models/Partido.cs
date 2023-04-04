﻿using System;
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
        public DateTime FechaHora { get; set; }
        public string Pista { get; set; }
        public string Local { get; set; }
        public string Visitante { get; set; }
        public Resultado Resultado { get; set; }


        internal static Partido FromJson(JsonNode jsonPartido)
        {
            //string horaDT = jsonPartido["Hora"]!.GetValue<string>();
            //string[] h = horaDT.Split(":");
            //TimeSpan hora = new TimeSpan(Convert.ToInt32(h[0]), Convert.ToInt32(h[1]), Convert.ToInt32(h[2]));
            Partido partido = new()
            {
                Id = jsonPartido["Id"]!.GetValue<int>(),
                FechaHora = jsonPartido["FechaHora"]!.GetValue<DateTime>(),
                Jornada = jsonPartido["Jornada"]!.GetValue<int>(),
                Local = EquipoFromJson(jsonPartido["Local"]),
                NumPartido = jsonPartido["NumPartido"]!.GetValue<int>(),
                Pista = jsonPartido["Pista"]!.GetValue<string>(),
                Resultado = Resultado.FromJson(jsonPartido["Parciales"] as JsonArray),
                Visitante = EquipoFromJson(jsonPartido["Visitante"])
            };
            partido.Resultado.Local = jsonPartido["ResultadoLocal"]!.GetValue<int>();
            partido.Resultado.Visitante = jsonPartido["ResultadoVisitante"]!.GetValue<int>();

            return partido;
        }
        private static string EquipoFromJson(JsonNode jsonNode)
        {
            return jsonNode["Nombre"].GetValue<string>();
        }
    }
}
