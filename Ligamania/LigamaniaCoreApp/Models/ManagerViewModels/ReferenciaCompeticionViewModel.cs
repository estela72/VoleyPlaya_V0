using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.ManagerViewModels
{
    public class ReferenciaCompeticionViewModel
    {
        public int Id { get; set; }
        public int PosicionInicial { get; set; }
        public int PosicionFinal { get; set; }
        public string Descripcion { get; set; }
        public bool UsarMarca { get; set; }
        public bool UsarColor { get; set; }
        public bool EsPremio { get; set; }
        public int Argb { get; set; }
        public string Marca { get; set; }

        public string Competicion { get; set; }
        public string Categoria { get; set; }

        public int OrdenCompeticion { get; set; }
        public int OrdenCategoria { get; set; }
        public System.Drawing.Color Color
        {
            get { return System.Drawing.Color.FromArgb(this.Argb); }
            set
            {
                if (value != null)
                    this.Argb = value.ToArgb();
                else
                    this.Argb = 0;
            }
        }
        public string HtmlColor { get { return ColorTranslator.ToHtml(Color); } }
    }

    public class AccionCambiarReferencia
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool EsPremio { get; set; }

        public int PosicionInicial { get; set; }
        public int PosicionFinal { get; set; }
        public bool UsarMarca { get; set; }
        public string Marca { get; set; }
        public bool UsarColor { get; set; }
        public int Argb { get; set; }
        public string HexColor { get; set; }
        public System.Drawing.Color Color { get; set; }
        public string Competicion { get; set; }
        public string Categoria { get; set; }
    }
}
