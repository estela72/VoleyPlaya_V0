using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace VoleyPlaya.Domain.Models
{
    public class FechaJornada
    {
        public FechaJornada()
        {
            Jornada = 0;
            Fecha = DateTime.MinValue;
        }

        public FechaJornada(int jornada)
            :this()
        {
            Jornada = jornada;
            Fecha = DateTime.Now.AddDays(7);
        }
        public int Id { get; set; }
        public int Jornada { get; set; }
        public DateTime Fecha { get; set; }

        public static FechaJornada FromJson(JsonNode jornada)
        {
            FechaJornada fechaJornada = new FechaJornada()
            {
                Id = jornada["Id"]!.GetValue<int>(),
                Jornada = jornada["Numero"]!.GetValue<int>(),
                Fecha = jornada["Fecha"]!.GetValue<DateTime>()
            };
            return fechaJornada;
        }
    }
}
