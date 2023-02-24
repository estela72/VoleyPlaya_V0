using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.ConfigViewModels
{
    public class ValorDescViewModel
    {
        public string Valor { get; set; }
        public string Descripcion { get; set; }

        public ValorDescViewModel(string valor, string desc)
        {
            Valor = valor;
            Descripcion = desc;
        }
    }
}
