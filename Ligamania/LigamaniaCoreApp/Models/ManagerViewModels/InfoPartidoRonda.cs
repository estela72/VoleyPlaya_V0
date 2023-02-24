using LigamaniaCoreApp.Data.DataModels.Base.Ligamania.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.ManagerViewModels
{
    public class InfoPartidoRonda
    {
        public List<AlineacionViewModel> AlineacionEquipoA { get; set; }
        public List<AlineacionViewModel> AlineacionEquipoB { get; set; }
        //public ICollection<TemporadaJornadaJugadorDTO> Goleadores { get; set; }
        //public ICollection<TemporadaJornadaJugadorDTO> InfoJugadoresEquipoA { get; set; }
        //public ICollection<TemporadaJornadaJugadorDTO> InfoJugadoresEquipoB { get; set; }
    }
}
