using LigamaniaCoreApp.Models.GlobalViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.InvitadoViewModels
{
    public class HistorialViewModel
    {
        public string Temporada { get; set; }
        public byte[] ImgClasificacion { get; set; }
        public ICollection<CategoriaHistoricaViewModel> CategoriasHistoricas { get; set; }
    }
}
