using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoleyPlaya.Models
{
    public class ResultadoParcial
    {
        int _local;
        int _visitante;
        public int Local { get => _local; set => _local = value; }
        public int Visitante { get => _visitante; set => _visitante = value; }

    }
    public class Resultado
    {
         int _local;
         int _visitante;
         IList<ResultadoParcial> _parciales;

        ResultadoParcial _set1;
        ResultadoParcial _set2;
        ResultadoParcial _set3;

        public Resultado()
        {
            _local = 0;
            _visitante = 0;
            _parciales = new List<ResultadoParcial>();
            _parciales.Add(new() { Local = 0, Visitante = 0 });
            _parciales.Add(new() { Local = 0, Visitante = 0 });
            _parciales.Add(new() { Local = 0, Visitante = 0 });
            _set1 = new ResultadoParcial();
            _set2 = new ResultadoParcial();
            _set3 = new ResultadoParcial();
        }

        public int Local { get => _local; set => _local = value; }
        public int Visitante { get => _visitante; set => _visitante = value; }
        public IList<ResultadoParcial> Parciales
        {
            get => _parciales; set
            {
                _parciales = value;
                UpdateResultado();
            }
        }
        public ResultadoParcial Set1 { get => _set1; set { _set1 = value; UpdateResultado(); } }
        public ResultadoParcial Set2 { get => _set2; set { _set2 = value; UpdateResultado(); } }
        public ResultadoParcial Set3 { get => _set3; set { _set3 = value; UpdateResultado(); } }

        private void UpdateResultado()
        {
            _local = _parciales.Count(p => p.Local > p.Visitante);
            _visitante = _parciales.Count(p => p.Visitante > p.Local);
        }
    }
}
