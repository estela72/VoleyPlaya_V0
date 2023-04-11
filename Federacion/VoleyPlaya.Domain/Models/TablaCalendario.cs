using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoleyPlaya.Domain.Models
{
    public class RootTablaCalendario
    {
        public List<TablaCalendario> calendarios { get; set; }
    }
    public class TablaCalendario 
    {
        private string _nombre;
        private int _numVueltas;
        private int _numEquipos;
        private List<VueltaCalendario> _vueltas;
        //[NonSerialized]
        public string Tipo { get { return NumVueltas.ToString() + " vueltas - " + NumEquipos.ToString() + " equipos"; } }

        public TablaCalendario() 
        {
            _vueltas = new List<VueltaCalendario>();
        }
        public TablaCalendario(string name, int jornadas, int equipos, int vueltas)
        {
            _numVueltas = jornadas;
            _numEquipos = equipos;
            _vueltas = new List<VueltaCalendario>();
        }
        
        public int NumVueltas { get => _numVueltas; set => _numVueltas = value; }
        public int NumEquipos { get => _numEquipos; set => _numEquipos = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public List<VueltaCalendario> Vueltas { get => _vueltas; set => _vueltas = value; }


        public static async Task<TablaCalendario> LoadCalendario(int numEquipos, int numVueltas)
        {
            try
            {
                using var stream = File.Open("calendarios.json", FileMode.Open);
                using var reader = new StreamReader(stream);

                var json = reader.ReadToEnd();
                RootTablaCalendario calendarios = JsonConvert.DeserializeObject<RootTablaCalendario>(json);
                var calendario = calendarios!.calendarios.Where(c => c.NumEquipos == numEquipos && c.NumVueltas == numVueltas).First();
                return calendario;
            }
            catch
            {
                return null;
            }
        }
        public static async Task<List<TablaCalendario>> LoadCalendarios(int numEquipos)
        {
            try
            {
                using var stream = File.Open("calendarios.json", FileMode.Open);
                using var reader = new StreamReader(stream);

                var json = reader.ReadToEnd();
                RootTablaCalendario calendarios = JsonConvert.DeserializeObject<RootTablaCalendario>(json);
                var tabla = calendarios!.calendarios.Where(c => c.NumEquipos == numEquipos ).ToList();
                return tabla;
            }
            catch
            {
                return null;
            }
        }
        public static async Task<List<TablaCalendario>> LoadCalendarios()
        {
            try
            {
                using var stream = File.Open("calendarios.json", FileMode.Open);
                using var reader = new StreamReader(stream);

                var json = reader.ReadToEnd();
                RootTablaCalendario calendarios = JsonConvert.DeserializeObject<RootTablaCalendario>(json);
                return calendarios.calendarios;
            }
            catch
            {
                return null;
            }
        }
        public static async Task<List<string>> LoadTipos()
        {
            var cal = await LoadCalendarios();
            return cal.Select(c => c.Tipo).ToList();
        }
        public static async Task<int> NumVueltasPosibles(int numEquipos)
        {
            var calendarios = await LoadCalendarios(numEquipos);
            return calendarios.Count;
        }

        public static async Task<int> NumJornadas(int numEquipos,int numVueltas)
        {
            var calendarios = await LoadCalendario(numEquipos, numVueltas);
            if (calendarios == null) return 0;
            return calendarios.Vueltas.SelectMany(v => v.Partidos).Max(p => p.Jornada);
        }

        public static async Task<dynamic> GetInfoTipo(string tipoCalendarioSeleccionado)
        {
            var cal = await LoadCalendarios();
            var calendario = cal.First(c => c.Tipo.Equals(tipoCalendarioSeleccionado));
            dynamic miObjetoDynamic = new System.Dynamic.ExpandoObject();
            miObjetoDynamic.Vueltas = calendario.NumVueltas;
            miObjetoDynamic.Equipos = calendario.NumEquipos;
            return miObjetoDynamic;
        }
    }
}
