using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ligamania.Web.Models
{
    public class CalendarioListVM : BaseVM
    {
        public List<CalendarioVM> calendarios { get; set; }
        public CalendarioVM nuevoCalendario { get; set; }

        public CalendarioListVM() : base()
        {
            Inicializar();
        }
        public CalendarioListVM(string message) : base(message)
        {
            Inicializar();
        }

        private void Inicializar()
        {
            calendarios = new List<CalendarioVM>();
            calendarios.Add(new CalendarioVM());
            nuevoCalendario = new CalendarioVM();
        }

    }
}
