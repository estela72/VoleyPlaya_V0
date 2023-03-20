using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoleyPlaya.Models
{
    public class Partido
    {
        int _jornada;
        int _numPartido;
        DateTime _fecha;
        TimeSpan _hora;
        string _pista;
        string _local;
        string _visitante;
        Resultado _resultado;

        public Partido()
        {
            _resultado = new Resultado();
        }

        public int Jornada { get => _jornada; set => _jornada = value; }
        public int NumPartido { get => _numPartido; set => _numPartido = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        public TimeSpan Hora { get => _hora; set => _hora = value; }
        public string Pista { get => _pista; set => _pista = value; }
        public string Local { get => _local; set => _local = value; }
        public string Visitante { get => _visitante; set => _visitante = value; }
        public Resultado Resultado { get => _resultado; set => _resultado = value; }

        internal static Partido FromJson(Partido partido)
        {
            throw new NotImplementedException();
        }
    }
}
