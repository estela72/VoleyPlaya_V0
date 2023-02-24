using General.CrossCutting.Lib;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ligamania.API.Lib.Models
{
    public class Calendario : Response
    {
        public Calendario()
        {
        }

        public Calendario(string errorMessage) : base(errorMessage)
        {
        }

        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public int NumEquipos { get; private set; }
        public List<CalendarioDetalle> Partidos { get; private set; }
    }
    public class CalendarioDetalle
    {
        public int Id { get; private set; }
        public int Jornada { get; private set; }
        public string Local { get; private set; }
        public string Visitante { get; private set; }
    }
}
