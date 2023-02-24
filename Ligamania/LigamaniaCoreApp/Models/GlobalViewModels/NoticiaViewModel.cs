using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.GlobalViewModels
{
    public class NoticiaViewModel
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Noticia { get; set; }
    }
}
