using LigamaniaCoreApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.InvitadoViewModels
{
    public class HistoriaEquipoCategoriaViewModel
    {
        public string Categoria { get; set; }
        public List<string> TempCampeon { get; set; }
        public List<string> TempSubcampeon { get; set; }
        public List<string> TempTercero { get; set; }
        public List<string> TempPichichi { get; set; }
        public string Path_Img_Campeon { get; set; }
        public string Path_Img_Subcampeon { get; set; }
        public string Path_Img_Tercero { get; set; }
        public string Path_Img_Pichichi { get; set; }

        public HistoriaEquipoCategoriaViewModel()
        {
            TempCampeon = new List<string>();
            TempSubcampeon = new List<string>();
            TempTercero = new List<string>();
            TempPichichi = new List<string>();
        }
    }
}
