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

        public string Temporada {get { return _temporada; } set { _temporada = value; } }
        public string Nombre { get { return _nombre; } set { _nombre = value; } } 
        public EnumCategorias Categoria { get { return _categoria; } set { _categoria = value; } } 
        public EnumGeneros Genero { get { return _genero; } set { _genero = value; } } 
        public string Grupo { get { return _grupo;  } set { _grupo = value; } }
        public int NumEquipos { get { return _numEquipos; } set { _numEquipos = value; } } 
        public int Jornadas { get { return _numJornadas; } set { _numJornadas = value; } }

        public List<Equipo> Equipos { get => _equipos; set => _equipos = value; }

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
        }
    }
}
