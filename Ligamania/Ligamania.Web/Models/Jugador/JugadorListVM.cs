using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ligamania.Web.Models.Jugador
{
    public class JugadorListVM : BaseVM
    {
        public List<JugadorVM> jugadores { get; set; }
        public JugadorVM nuevoJugador { get; set; }
        public List<JugadorVM> jugadoresPdtesBaja { get; set; }
        public JugadorVM jugadorSelected { get; set; }
        public JugadorListVM() : base()
        {
            Inicializar();
        }
        public JugadorListVM(string message) : base(message)
        {
            Inicializar();
        }

        private void Inicializar()
        {
            jugadores = new List<JugadorVM>();
            jugadores.Add(new JugadorVM());
            nuevoJugador = new JugadorVM();
        }
    }
}
