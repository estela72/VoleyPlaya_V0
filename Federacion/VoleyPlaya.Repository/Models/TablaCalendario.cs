using General.CrossCutting.Lib;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoleyPlaya.Repository.Models
{
    internal class TablaCalendario : Entity
    {
        public int NumEquipos { get; set; }
        public int NumPartido { get; set; }
        public string Ronda { get; set; }
        public string Equipo1 { get; set; }
        public string Equipo2 { get; set; }
    }
}
