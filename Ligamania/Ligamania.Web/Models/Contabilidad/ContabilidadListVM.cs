using Ligamania.Web.Models.Jugador;

namespace Ligamania.Web.Models.Contabilidad
{
    public class ContabilidadListVM : BaseVM
    {
        public List<ContabilidadVM> Contabilidad { get; set; }

        public ContabilidadListVM() : base()
        {
            Inicializar();
        }
        public ContabilidadListVM(string message) : base(message)
        {
            Inicializar();
        }

        private void Inicializar()
        {
            Contabilidad = new List<ContabilidadVM>();
            Contabilidad.Add(new ContabilidadVM());
        }
    }
}