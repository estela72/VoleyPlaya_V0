using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoleyPlaya.Models
{
    public class RootTablaCalendario
    {
        public List<TablaCalendario> calendarios { get; set; }
    }
    public class TablaCalendario 
    {
        private string _nombre;
        private int _numJornadas;
        private int _numEquipos;
        private List<JornadaCalendario> _jornadas;

        public TablaCalendario() 
        {
            _jornadas = new List<JornadaCalendario>();
        }
        public TablaCalendario(string name, int jornadas, int equipos, int vueltas)
        {
            _numJornadas = jornadas;
            _numEquipos = equipos;
            _jornadas = new List<JornadaCalendario>();
        }
        
        public int NumJornadas { get => _numJornadas; set => _numJornadas = value; }
        public int NumEquipos { get => _numEquipos; set => _numEquipos = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public List<JornadaCalendario> Jornadas { get => _jornadas; set => _jornadas = value; }

    }
}
