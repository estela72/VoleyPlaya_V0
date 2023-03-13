using Newtonsoft.Json;

namespace VoleyPlaya.Models
{
    internal class Competicion
    {
        string _temporada;
        string _nombre;
        EnumCategorias _categoria;
        EnumGeneros _genero;
        string _grupo;
        int _numEquipos;
        int _numJornadas;
        private List<Equipo> _equipos;
        private List<Partido> _partidos;
        private List<FechaJornada> _fechasJornadas;


        public string Temporada {get { return _temporada; } set { _temporada = value; } }
        public string Nombre { get { return _nombre; } set { _nombre = value; } } 
        public EnumCategorias Categoria { get { return _categoria; } set { _categoria = value; } } 
        public EnumGeneros Genero { get { return _genero; } set { _genero = value; } } 
        public string Grupo { get { return _grupo;  } set { _grupo = value; } }
        public int NumEquipos { get { return _numEquipos; } set { _numEquipos = value; } } 
        public int Jornadas { get { return _numJornadas; } set { _numJornadas = value; } }

        public List<Equipo> Equipos { get => _equipos; set => _equipos = value; }
        public List<Partido> Partidos { get => _partidos; set => _partidos = value; }
        public List<FechaJornada> FechasJornadas { get=>_fechasJornadas; set=> _fechasJornadas=value; }
        public Competicion()
        {
            _temporada = "2023";
            _nombre = EnumCompeticiones.Competiciones[0];
            _categoria = EnumCategorias.None;
            _genero = EnumGeneros.None;
            _grupo = "";
            _numEquipos = 0;
            _numJornadas = 0;
            _equipos = new List<Equipo>();
            _partidos = new List<Partido>();
            _fechasJornadas = new List<FechaJornada>();
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
                    else
                    {
                        var par = Partidos.First(p => p.NumPartido == nuevoPartido.NumPartido);
                        par.Fecha = par.Fecha == DateTime.MinValue ? fecha : par.Fecha;
                        par.Local = _equipos.Where(e => e.Posicion == partido.Local).First().Nombre;
                        par.Visitante = _equipos.Where(e => e.Posicion == partido.Visitante).First().Nombre;
                    }
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

        //internal async Task UpdateFechasJornadas()
        //{
        //    for (int i=0; i < Partidos.Count; i++)
        //    {
        //        var par = FechasJornadas.Where(fj => fj.Jornada == Partidos[i].Jornada).FirstOrDefault();
        //        if (par != null)
        //            Partidos[i].DateTime = par.Fecha;
        //    }
        //}
    }
}
