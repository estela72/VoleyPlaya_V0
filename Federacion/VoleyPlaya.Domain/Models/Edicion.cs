using Newtonsoft.Json;

using System.Text.Json.Nodes;

using VoleyPlaya.Repository.Models;
using VoleyPlaya.Repository.Services;

namespace VoleyPlaya.Models
{
    public class Edicion
    {
        string _temporada;
        string _nombre;
        string _competicion;
        EnumCategorias _categoria;
        EnumGeneros _genero;
        string _grupo;
        int _numEquipos;
        int _numJornadas;
        private List<Equipo> _equipos;
        private List<Partido> _partidos;
        private List<FechaJornada> _fechasJornadas;
        DateTime _fecha;
        string _lugar;
        public string Temporada { get { return _temporada; } set { _temporada = value; } }
        public string Nombre { get { return _nombre; } set { _nombre = value; } }
        public string Competicion { get { return _competicion; } set { _competicion = value; } }
        public EnumCategorias Categoria { get { return _categoria; } set { _categoria = value; } }
        public EnumGeneros Genero { get { return _genero; } set { _genero = value; } }
        public string Grupo { get { return _grupo; } set { _grupo = value; } }
        public int NumEquipos { get { return _numEquipos; } set { _numEquipos = value; } }
        public int NumJornadas { get { return _numJornadas; } set { _numJornadas = value; } }
        public string Lugar { get { return _lugar; } set { _lugar = value; } }
        public List<Equipo> Equipos { get => _equipos; set => _equipos = value; }
        public List<Partido> Partidos { get => _partidos; set => _partidos = value; }
        public List<FechaJornada> FechasJornadas { get=>_fechasJornadas; set=> _fechasJornadas=value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }

        public string CategoriaStr { get => Enum.GetName(typeof(EnumCategorias), Categoria); }
        public string GeneroStr { get => Enum.GetName(typeof(EnumGeneros), Genero); }

        public Edicion()
        {
            _temporada = DateTime.Now.Year.ToString();
            _competicion = EnumCompeticiones.Competiciones[0];
            _categoria = EnumCategorias.None;
            _genero = EnumGeneros.None;
            _grupo = "";
            _nombre = "";
            _numEquipos = 0;
            _numJornadas = 0;
            _equipos = new List<Equipo>();
            _partidos = new List<Partido>();
            _fechasJornadas = new List<FechaJornada>();
            _fecha = DateTime.Now;
            _lugar = string.Empty;
        }
        internal async Task GenerarPartidosAsync()
        {
            var tabla = await LoadCalendario(_numEquipos, _numJornadas);
            if (tabla == null) return;
            var numPartido = 1;
            foreach (var jornada in tabla.Jornadas)
            {
                var fecha = _fechasJornadas.Where(j => j.Jornada == jornada.Jornada).First().Fecha;
                foreach (var partido in jornada.Partidos)
                {
                    Partido nuevoPartido = new()
                    {
                        Jornada = jornada.Jornada,
                        NumPartido = numPartido++,
                        Fecha = fecha,
                        Hora = new TimeSpan(10, 0, 0),
                        Pista = string.Empty,
                        Local = _equipos.Where(e => e.Posicion == partido.Local).First().Nombre,
                        Visitante = _equipos.Where(e => e.Posicion == partido.Visitante).First().Nombre,
                        Resultado = new Resultado()
                    };
                    if (!Partidos.Exists(p => p.NumPartido == nuevoPartido.NumPartido))
                        Partidos.Add(nuevoPartido);
                }
            }
        }
        public async Task<TablaCalendario> LoadCalendario(int numEquipos, int numJornadas)
        {
            try
            {
                using var stream = await FileSystem.OpenAppPackageFileAsync("calendarios.json");
                using var reader = new StreamReader(stream);

                var json = reader.ReadToEnd();
                RootTablaCalendario calendarios = JsonConvert.DeserializeObject<RootTablaCalendario>(json);
                var calendario = calendarios.calendarios.Where(c => c.NumEquipos == NumEquipos && c.NumJornadas == numJornadas).First();
                return calendario;
            }
            catch 
            {
                return null;
            }

        }
        public async Task UpdateClasificacion()
        {
            foreach (var equipo in Equipos)
                await equipo.Reset();
            foreach(var partido in Partidos)
            {
                var local = _equipos.First(e => e.Nombre.Equals(partido.Local));
                var visitante = _equipos.First(e => e.Nombre.Equals(partido.Visitante));
                await local.SetLocal(partido);
                await visitante.SetVisitante(partido);
                partido.Resultado.Local = partido.Resultado.Sets.Count(s => s.Local > s.Visitante);
                partido.Resultado.Visitante = partido.Resultado.Sets.Count(s => s.Visitante > s.Local);
            }
        }

        internal static Edicion FromJson(JsonNode jsonEdicion)
        {
            Edicion edicion = new Edicion();
            edicion.Temporada = NombreFromJson(jsonEdicion["Temporada"]);
            edicion.Competicion = NombreFromJson(jsonEdicion["Competicion"]);
            Enum.TryParse(NombreFromJson(jsonEdicion["Categoria"]), out EnumCategorias categoria);
            edicion.Categoria = categoria;
            Enum.TryParse(jsonEdicion["Genero"].GetValue<string>(), out EnumGeneros genero);
            edicion.Genero = genero;
            edicion.Grupo = jsonEdicion["Grupo"].GetValue<string>();
            edicion.Equipos = EquiposFromJson(jsonEdicion["Equipos"]!.AsArray());
            edicion.Partidos = PartidosFromJson(jsonEdicion["Partidos"]!.AsArray());
            edicion.Fecha = jsonEdicion["UpdatedDate"]!.GetValue<DateTime>();
            edicion.Nombre = jsonEdicion["Nombre"]!.GetValue<string>();
            edicion.NumEquipos = jsonEdicion["NumEquipos"]!.GetValue<int>();
            edicion.NumJornadas = jsonEdicion["NumJornadas"]!.GetValue<int>();
            edicion.FechasJornadas = JornadasFromJson(jsonEdicion["Jornadas"]!.AsArray());
            edicion.Lugar = jsonEdicion["Lugar"]!.GetValue<string>();
            return edicion;
        }
        private static string NombreFromJson(JsonNode jsonNode)
        {
            return jsonNode["Nombre"].GetValue<string>();
        }
        private static List<Equipo> EquiposFromJson(JsonArray jsonEquipos)
        {
            List<Equipo> equipos = new List<Equipo>();
            foreach (var equipo in jsonEquipos)
                equipos.Add(Equipo.FromJson(equipo));
            return equipos;
        }
        private static List<Partido> PartidosFromJson(JsonArray jsonPartidos)
        {
            List<Partido> partidos = new List<Partido>();
            foreach (var partido in jsonPartidos)
                partidos.Add(Partido.FromJson(partido));
            return partidos;
        }
        private static List<FechaJornada> JornadasFromJson(JsonArray jsonJornadas)
        {
            List<FechaJornada> jornadas = new List<FechaJornada>();
            foreach (var jornada in jsonJornadas)
                jornadas.Add(FechaJornada.FromJson(jornada));
            return jornadas;
        }
    }
}
