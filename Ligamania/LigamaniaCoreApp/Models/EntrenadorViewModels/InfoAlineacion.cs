using LigamaniaCoreApp.Models.ManagerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.EntrenadorViewModels
{
    public class InfoAlineacion
    {
        public AlineacionViewModel JugadorPrevia { get; set; }
        public AlineacionViewModel JugadorCambio { get; set; }

    }
}
