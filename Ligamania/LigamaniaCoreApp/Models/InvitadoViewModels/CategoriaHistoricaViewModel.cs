using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.InvitadoViewModels
{
    public class CategoriaHistoricaViewModel
    {
        public string Competicion { get; set; }
        public string Categoria { get; set; }
        public string PathImagenClasificacion { get; set; }
        public int Orden { get; set; }
        public ICollection<PremioHistoricoViewModel> Premios { get; set; }
    }
}
