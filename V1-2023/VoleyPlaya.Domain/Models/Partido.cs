﻿using Microsoft.Identity.Client;

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
        public string Competicion { get; set; }
        public string Categoria { get; set; }
        public string Genero { get; set; }
        public string Grupo { get; set; }
        public int Jornada { get; set; }
        public int NumPartido { get; set; }
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy HH:mm}")]
        public DateTime FechaHora { get; set; }
        public string Pista { get; set; }
        public string Local { get; set; }
        public string Visitante { get; set; }
        public Resultado Resultado { get; set; }
        public string Label { get; set; }
        public bool RetiradoLocal { get; set; }
        public bool RetiradoVisitante { get; set; }
        public string Prueba { get; set; }
        public bool Validado { get; set; }
        public string NombreLocal { get; set; }
        public string NombreVisitante { get; set; }
        public string Ronda { get; set; }
        public bool ConResultado { get; set; }
        public int EquipoLocalId { get; set; }
        public int EquipoVisitanteId { get; set; }
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
                Label = jsonPartido["Label"]!.GetValue<string>()!,
                RetiradoLocal = jsonPartido["RetiradoLocal"]!.GetValue<bool>()!,
                RetiradoVisitante = jsonPartido["RetiradoVisitante"]!.GetValue<bool>()!,
                Prueba = jsonPartido["Prueba"]!.GetValue<string>()!,
                Validado = jsonPartido["Validado"]!.GetValue<bool>()!,
                NombreLocal = jsonPartido["NombreLocal"]!.GetValue<string>()!,
                NombreVisitante = jsonPartido["NombreVisitante"]!.GetValue<string>()!,
                Ronda = jsonPartido["Ronda"]!.GetValue<string>()!,
                ConResultado = jsonPartido["ConResultado"]!.GetValue<bool>()!,
                EquipoLocalId = jsonPartido["EquipoLocalId"]!.GetValue<int>()!,
                EquipoVisitanteId = jsonPartido["EquipoVisitanteId"]!.GetValue<int>()!
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
                Resultado = Resultado.FromJson(jsonPartido["Parciales"]! as JsonArray)!,
                RetiradoLocal = jsonPartido["RetiradoLocal"]!.GetValue<bool>()!,
                RetiradoVisitante = jsonPartido["RetiradoVisitante"]!.GetValue<bool>()!,
                Prueba = jsonPartido["Prueba"]!.GetValue<string>()!,
                Validado = jsonPartido["Validado"]!.GetValue<bool>()!,
                NombreLocal = jsonPartido["NombreLocal"]!.GetValue<string>()!,
                NombreVisitante = jsonPartido["NombreVisitante"]!.GetValue<string>()!,
                Ronda = jsonPartido["Ronda"]!.GetValue<string>()!,
                ConResultado = jsonPartido["ConResultado"]!.GetValue<bool>()!,
                EquipoLocalId = jsonPartido["EquipoLocalId"]!.GetValue<int>()!,
                EquipoVisitanteId = jsonPartido["EquipoVisitanteId"]!.GetValue<int>()!
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
