using LigamaniaCoreApp.Models.EntrenadorViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.ManagerViewModels
{
    public class AlineacionesJornadaEquipo
    {
        public bool AlineacionInicalActivo { get; set; }
        public bool CambiosActivo { get; set; }
        public ICollection<AlineacionViewModel> Previa { get; set; }
        public ICollection<AlineacionViewModel> Cambios { get; set; }
        public ICollection<AlineacionViewModel> Actual { get; set; }

        public InfoAlineacion Portero { get; set; }
        public InfoAlineacion Defensa1 { get; set; }
        public InfoAlineacion Defensa2 { get; set; }
        public InfoAlineacion Defensa3 { get; set; }
        public InfoAlineacion Medio1 { get; set; }
        public InfoAlineacion Medio2 { get; set; }
        public InfoAlineacion Medio3 { get; set; }
        public InfoAlineacion Medio4 { get; set; }
        public InfoAlineacion Delantero1 { get; set; }
        public InfoAlineacion Delantero2 { get; set; }
        public InfoAlineacion Delantero3 { get; set; }

        public int NumCambiosFijosRealizados { get; set; }
        public int NumCambiosExtrasRealizados { get; set; }
        //public int NumCambiosRealizados { get; set; }

    }
}
