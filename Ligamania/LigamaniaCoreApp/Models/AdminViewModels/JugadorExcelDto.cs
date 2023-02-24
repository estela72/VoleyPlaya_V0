using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LigamaniaCoreApp.Models.AdminViewModels
{
    public class JugadorActivoExcelDto
    {
        public string Jugador { get; set; }
        //public string Club { get; set; }
        public string Puesto { get; set; }
        //public string Temporada { get; set; }
        //public string Baja { get; set; }
        //public string Activo{ get; set;}
    }
    public class JugadorBajaExcelDto
    {
        public string Jugador { get; set; }
        //public string Club { get; set; }
        //public string Puesto { get; set; }
        //public string Temporada { get; set; }
        //public string Baja { get; set; }
        //public string Activo{ get; set;}
    }
    public class ClubExcelDto
    {
        public string Club { get; set; }
    }
}
