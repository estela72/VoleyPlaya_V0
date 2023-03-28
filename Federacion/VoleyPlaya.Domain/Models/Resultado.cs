using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace VoleyPlaya.Models
{
    public class ResultadoParcial
    {
        int _local;
        int _visitante;
        public int Local { get => _local; set => _local = value; }
        public int Visitante { get => _visitante; set => _visitante = value; }

        internal static ResultadoParcial FromJson(JsonNode jsonNode)
        {
            ResultadoParcial resParcial = new ResultadoParcial()
            {
                Local = jsonNode["ResultadoLocal"]!.GetValue<int>(),
                Visitante = jsonNode["ResultadoVisitante"]!.GetValue<int>()
            };
            return resParcial;
        }
    }
    public class Resultado
    {
         int _local;
         int _visitante;
        ResultadoParcial _set1;
        ResultadoParcial _set2;
        ResultadoParcial _set3;

        public List<ResultadoParcial> Sets { get { return new List<ResultadoParcial> { _set1, _set2, _set3 }; } }

        public Resultado()
        {
            _local = 0;
            _visitante = 0;
            _set1 = new ResultadoParcial();
            _set2 = new ResultadoParcial();
            _set3 = new ResultadoParcial();
        }

        public int Local { get => _local; set => _local = value; }
        public int Visitante { get => _visitante; set => _visitante = value; }
        public ResultadoParcial Set1 { get => _set1; set { _set1 = value; UpdateResultado(); } }
        public ResultadoParcial Set2 { get => _set2; set { _set2 = value; UpdateResultado(); } }
        public ResultadoParcial Set3 { get => _set3; set { _set3 = value; UpdateResultado(); } }

        internal static Resultado FromJson(JsonArray jsonParciales)
        {
            Resultado resultado = new Resultado()
            {
                Set1 = ResultadoParcial.FromJson(jsonParciales[0]),
                Set2 = ResultadoParcial.FromJson(jsonParciales[1]),
                Set3 = ResultadoParcial.FromJson(jsonParciales[2])
            };
            //Resultado.UpdateResultado();
            return resultado;
        }

        public void UpdateResultado()
        {
            _local = 0;
            if (_set1.Local > _set1.Visitante) _local++;
            if (_set2.Local > _set2.Visitante) _local++;
            if (_set3.Local > _set3.Visitante) _local++;

            _visitante = 0;
            if (_set1.Local < _set1.Visitante) _visitante++;
            if (_set2.Local < _set2.Visitante) _visitante++;
            if (_set3.Local < _set3.Visitante) _visitante++;
        }
    }
}
