namespace Ligamania.Web.Models.Temporada
{
    public class TemporadaListVM : BaseVM
    {
        public List<TemporadaVM> temporadas { get; set; }
        public TemporadaVM nuevaTemporada { get; set; }

        public TemporadaListVM() : base()
        {
            Inicializar();
        }
        public TemporadaListVM(string message) : base(message)
        {
            Inicializar();
        }

        private void Inicializar()
        {
            temporadas = new List<TemporadaVM>();
            temporadas.Add(new TemporadaVM());
            nuevaTemporada = new TemporadaVM();
        }
    }
}
