using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using VoleyPlaya.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace VoleyPlaya.ViewModels
{
    internal class CompeticionViewModel : ObservableObject, IQueryAttributable
    {

        public ObservableCollection<string> Competiciones { get; set; } 
        public ObservableCollection<EnumCategorias> Categorias { get; set; } 
        public ObservableCollection<EnumGeneros> Generos { get; set; }
        private ObservableCollection<Equipo> _equipos;
        public IList<Equipo> Equipos => _equipos;


        private Models.CompeticionWrapper _competicionWrapper;
        public Competicion Competicion
        {
            get => _competicionWrapper.Competicion;
            set
            {
                if (_competicionWrapper.Competicion != value)
                {
                    _competicionWrapper.Competicion = value;
                    _equipos = new ObservableCollection<Equipo>(_competicionWrapper.Competicion.Equipos);
                    OnPropertyChanged();
                }
            }
        }

        public DateTime Date => _competicionWrapper.Date;

        public string Identifier => _competicionWrapper.Filename;

        public ICommand SaveCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand GenerarPartidosCommand { get; private set; }
        
        public CompeticionViewModel()
        {
            Competiciones = new ObservableCollection<string>(EnumCompeticiones.Competiciones.Values);
            Categorias = new ObservableCollection<EnumCategorias>(Enum.GetValues(typeof(EnumCategorias)).OfType<EnumCategorias>().ToList());
            Generos = new ObservableCollection<EnumGeneros>(Enum.GetValues(typeof(EnumGeneros)).OfType<EnumGeneros>().ToList());

            _competicionWrapper = new Models.CompeticionWrapper();
            _equipos = new ObservableCollection<Equipo>();
            SaveCommand = new AsyncRelayCommand(Save);
            DeleteCommand = new AsyncRelayCommand(Delete);
            GenerarPartidosCommand = new AsyncRelayCommand(GenerarPartidos);
        }

        public CompeticionViewModel(Models.CompeticionWrapper competicionWrapper)
        {
            _competicionWrapper = competicionWrapper;
            _equipos = new ObservableCollection<Equipo>(competicionWrapper.Competicion.Equipos);
            SaveCommand = new AsyncRelayCommand(Save);
            DeleteCommand = new AsyncRelayCommand(Delete);
            GenerarPartidosCommand = new AsyncRelayCommand(GenerarPartidos);
        }
        private async Task Save()
        {
            _competicionWrapper.Date = DateTime.Now;
            _competicionWrapper.Save();
            await Shell.Current.GoToAsync($"..?saved={_competicionWrapper.Filename}");
        }

        private async Task Delete()
        {
            _competicionWrapper.Delete();
            await Shell.Current.GoToAsync($"..?deleted={_competicionWrapper.Filename}");
        }
        private async Task GenerarPartidos()
        {

        }
        void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("load"))
            {
                _competicionWrapper = Models.CompeticionWrapper.Load(query["load"].ToString());
                _equipos = new ObservableCollection<Equipo>(_competicionWrapper.Competicion.Equipos);
                RefreshProperties();
            }
        }
        public void Reload()
        {
            _competicionWrapper = Models.CompeticionWrapper.Load(_competicionWrapper.Filename);
            RefreshProperties();
        }

        private void RefreshProperties()
        {
            OnPropertyChanged(nameof(Competicion));
            OnPropertyChanged(nameof(Date));
            OnPropertyChanged(nameof(Equipos));
        }
    }
}
