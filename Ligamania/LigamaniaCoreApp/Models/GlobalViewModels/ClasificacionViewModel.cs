using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.GlobalViewModels
{
    public class EquipoClasificacionViewModel
    {
        public int Puesto { get; set; }
        public int PuestoSinBot { get; set; }
        public string Equipo { get; set; }
        public ReferenciaPremioViewModel Premio { get; set; }
        public int Jugados { get; set; }
        public int Ganados { get; set; }
        public int Perdidos { get; set; }
        public int Empatados { get; set; }
        public int GolesFavor { get; set; }
        public int GolesContra { get; set; }
        public int GolesExtraFavor { get; set; }
        public int GolesExtraContra { get; set; }
        public int Diferencia { get; set; }
        public int Puntos { get; set; }

        public EquipoClasificacionViewModel()
        {
            Puesto = 0;
            PuestoSinBot = 0;
            Equipo = string.Empty;
            Premio = new ReferenciaPremioViewModel();
            Jugados = 0;
            Ganados = 0;
            Perdidos = 0;
            Empatados = 0;
            GolesContra = 0;
            GolesFavor = 0;
            GolesExtraContra = 0;
            GolesExtraFavor = 0;
            Diferencia = 0;
            Puntos = 0;
        }
        public EquipoClasificacionViewModel(string equipo) : this()
        {
            Equipo = equipo;
        }
    }
    public class ReferenciaPremioViewModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Simbolo{ get; set; }
        public bool UsarColor { get; set; }
        public Color Color { get; set; }
        public string ColorName { get { return ColorTranslator.FromHtml("#" + Color.Name).Name; } }
        public string HtmlColor { get { return ColorTranslator.ToHtml(Color); } }
    }
    public class ClasificacionViewModel
    {
        public string Categoria { get; set; }
        public List<ReferenciaPremioViewModel> Premios { get; set; }
        public List<EquipoClasificacionViewModel> Equipos { get; set; }

        public ClasificacionViewModel() { }
        public ClasificacionViewModel(string categoria)
        {
            Categoria = categoria;
            Premios = new List<ReferenciaPremioViewModel>();
            Equipos = new List<EquipoClasificacionViewModel>();
        }
    }
}
