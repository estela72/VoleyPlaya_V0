using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.AdminViewModels
{
    public class ResultadoPartidoViewModel
    {
        public int newGF1 { get; set; }
        public int newGC1 { get; set; }
        public int dif1 { get; set; }
        public int puntos1 { get; set; }

        public int newGF2 { get; set; }
        public int newGC2 { get; set; }
        public int dif2 { get; set; }
        public int puntos2 { get; set; }

        public int GF1_GC2 { get; set; }
        public int GF2_GC1 { get; set; }
        public int p1 { get; set; }
        public int p2 { get; set; }

        public int newGEF1 { get; set; }
        public int newGEC1 { get; set; }

        public int newGEF2 { get; set; }
        public int newGEC2 { get; set; }
    }
}
