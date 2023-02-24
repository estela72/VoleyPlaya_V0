using General.CrossCutting.Lib;

using Ligamania.Generic.Lib.Enums;

namespace Ligamania.API.Lib.Models
{
    public class Equipo : Response
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public EstadoEquipo Estado { get; private set; }
        public TipoEquipo Tipo { get; private set; }
        public string EntrenadorId { get; private set; }
        public byte[] Escudo { get; set; }
        public Equipo()
        {
        }

        public Equipo(string errorMessage) : base(errorMessage)
        { }
    }
}