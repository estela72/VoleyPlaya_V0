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
        int _id;
        int _jornada;
        int _numPartido;
        DateTime _fechaHora;
        string _pista;
        string _local;
        string _visitante;
        Resultado _resultado;

        public Partido()
        {
            _resultado = new Resultado();
        }
        public int Id { get => _id; set => _id = value; }
        public int Jornada { get => _jornada; set => _jornada = value; }
        public int NumPartido { get => _numPartido; set => _numPartido = value; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)] 
        public DateTime FechaHora { get => _fechaHora; set => _fechaHora = value; }
        public string Pista { get => _pista; set => _pista = value; }
        public string Local { get => _local; set => _local = value; }
        public string Visitante { get => _visitante; set => _visitante = value; }
        public Resultado Resultado { get => _resultado; set => _resultado = value; }

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
