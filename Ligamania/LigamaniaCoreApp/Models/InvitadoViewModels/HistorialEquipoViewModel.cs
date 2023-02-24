using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.InvitadoViewModels
{ 
    public class HistorialEquipoViewModel
    {
        public string Equipo { get; set; }
        public int Puntos { get; set; }
        public double Coeficiente { get; set; }
        public Dictionary<string, HistoriaEquipoCategoriaViewModel> InfoCategoria { get; set; }
        public Dictionary<string, HistoriaEquipoTemporadaViewModel> InfoTemporada { get; set; }
        public List<HistoriaEquipoCambiosEquipoViewModel> CambiosEquipo { get; set; }

        public string TextoHistoriaEquipo
        {
            get
            {
                StringBuilder strb = new StringBuilder();
                strb.AppendLine(Equipo);
                foreach (var cambio in CambiosEquipo)
                {
                    strb.AppendLine("// " + cambio.Equipo + " hasta " + cambio.Temporada);
                    //strb.Append(cambio.Equipo);
                }
                return strb.ToString();
            }
        }

        public HistorialEquipoViewModel(string equipo)
        {
            Equipo = equipo;
            InfoCategoria = new Dictionary<string, HistoriaEquipoCategoriaViewModel>();
            InfoTemporada = new Dictionary<string, HistoriaEquipoTemporadaViewModel>();
            CambiosEquipo = new List<HistoriaEquipoCambiosEquipoViewModel>();
        }
    }
}
