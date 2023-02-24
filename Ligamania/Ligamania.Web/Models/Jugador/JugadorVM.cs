using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ligamania.Web.Models.Jugador
{
    public class JugadorVM : BaseVM
    {
        public int Id { get; set; }
        public string Jugador { get; set; }
        public string Baja { get; set; }
        public string Club { get; set; }
        public string Puesto { get; set; }
        public int OrdenPuesto { get; set; }
        public string Activo { get; set; }
        public string AliasClub { get; set; }
        
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public string Alias { get {
                string str = String.Format("{0: 3} - {1: -20} - {2: 20}", AliasClub, Puesto, Jugador);
                //return Jugador+" - "+AliasClub+" - "+Puesto; 
                return str;
            } 
        }
    }
}
