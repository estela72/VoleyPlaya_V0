using LigamaniaCoreApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.ManagerViewModels
{
    public class CuadroViewModel
    {
        public int Id { get; set; }
        public int Ronda { get; set; }
        public int NumPartido { get; set; }
        public int Orden { get; set; }
        public string CompeticionEquipoA { get; set; }
        public string CategoriaEquipoA { get; set; }
        public string EquipoA 
        { 
            get 
            {
                if (CompeticionEquipoA.Equals(LigamaniaConst.Competicion_Copa))
                    return "Ganador partido " + EquipoAPuesto;
                else
                    return CompeticionEquipoA + " - " + CategoriaEquipoA + " - Puesto " + EquipoAPuesto; 
            } 
        }
        public int EquipoAPuesto { get; set; }
        public string CompeticionEquipoB { get; set; }
        public string CategoriaEquipoB { get; set; }
        public string EquipoB
        {
            get
            {
                if (CompeticionEquipoB.Equals(LigamaniaConst.Competicion_Copa))
                    return "Ganador partido " + EquipoBPuesto;
                else
                    return CompeticionEquipoB + " - " + CategoriaEquipoB + " - Puesto " + EquipoBPuesto;
            }
        }
        public int EquipoBPuesto { get; set; }
    }
}
