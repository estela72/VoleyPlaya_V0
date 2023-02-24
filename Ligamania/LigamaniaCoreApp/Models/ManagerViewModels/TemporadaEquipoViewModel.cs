using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.ManagerViewModels
{
    public class TemporadaEquipoViewModel
    {
        public int Id { get; set; }
        public string Equipo { get; set; }
        public int EquipoId { get; set; }
        public string Competicion { get; set; }
        public int CompeticionId { get; set; }
        public string Categoria { get; set; }
        public bool Confirmada { get; set; }
        public bool Pagada { get; set; }
        public int OrdenCompeticion { get; set; }
        public int OrdenCategoria { get; set; }
        public bool Baja { get; set; }

        public AlineacionesJornadaEquipo Alineaciones { get; set; }
        public int NumCambiosFijosRealizados { get; set; }
        public int NumCambiosExtrasRealizados { get; set; }
        //public int NumCambiosRealizados { get; set; }
        public int MaxCambiosFijosPosibles { get; set; }

        public bool AlineacionLibre { get; set; }

        public bool RepetirClub { get; set; }
    }
}
