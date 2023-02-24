using General.CrossCutting.Lib;

using System;

namespace Ligamania.Repository.Models
{
    public partial class ControlUsuarioDTO : Entity
    {
        public string Usuario { get; set; }
        public string Equipo { get; set; }
        public DateTime Fecha { get; set; }
        public string Accion { get; set; }
    }
}