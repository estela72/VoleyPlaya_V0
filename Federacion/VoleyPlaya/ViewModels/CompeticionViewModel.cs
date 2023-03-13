using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using VoleyPlaya.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using VoleyPlaya.Views;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace VoleyPlaya.ViewModels
{
    public interface ICompeticionVM
    {
        Task OnNumJornadasChanged();
        Task OnNumEquiposChanged();
        Task OnResultadoParcialChanged();
    }
    internal class CompeticionViewModel : ObservableObject, IQueryAttributable, ICompeticionVM
    {

        public ObservableCollection<string> Competiciones { get; set; } 
        public ObservableCollection<EnumCategorias> Categorias { get; set; } 
        public ObservableCollection<EnumGeneros> Generos { get; set; }

        private ObservableCollection<Partido> _partidos;
        private ObservableCollection<FechaJornada> _fechasJornadas;
        private ObservableCollection<Equipo> _equipos;
        private ObservableCollection<Equipo> _equiposOrdered;

        public IList<Partido> Partidos { get => _partidos; set => _partidos = (ObservableCollection<Partido>)value; }
        public IList<FechaJornada> FechasJornadas { get => _fechasJornadas; set => _fechasJornadas = (ObservableCollection<FechaJornada>)value; }
        public IList<Equipo> Equipos { get => _equipos; set => _equipos = (ObservableCollection<Equipo>)value; }

        public IList<Equipo> EquiposOrdered { get => _equiposOrdered; set => _equiposOrdered = (ObservableCollection<Equipo>)value; }

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
                    _equiposOrdered = new ObservableCollection<Equipo>(_equipos.OrderByDescending(e => e.Puntos).ThenByDescending(e => e.Coeficiente));
                    _partidos = new ObservableCollection<Partido>(_competicionWrapper.Competicion.Partidos);
                    _fechasJornadas = new ObservableCollection<FechaJornada>(_competicionWrapper.Competicion.FechasJornadas);
                    OnPropertyChanged();
                }
            }
        }

        public DateTime Date => _competicionWrapper.Date;
        public string Identifier => _competicionWrapper.Filename;
        public ICommand SaveCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand VerPartidosCommand { get; private set; }
        public ICommand UpdatePartidosCommand { get; private set; }

        public CompeticionViewModel()
        {
            Competiciones = new ObservableCollection<string>(EnumCompeticiones.Competiciones.Values);
            Categorias = new ObservableCollection<EnumCategorias>(Enum.GetValues(typeof(EnumCategorias)).OfType<EnumCategorias>().ToList());
            Generos = new ObservableCollection<EnumGeneros>(Enum.GetValues(typeof(EnumGeneros)).OfType<EnumGeneros>().ToList());

            _competicionWrapper = new Models.CompeticionWrapper();
            _equipos = new ObservableCollection<Equipo>();
            _equiposOrdered = new ObservableCollection<Equipo>();
            _partidos = new ObservableCollection<Partido>();
            _fechasJornadas = new ObservableCollection<FechaJornada>();
            SaveCommand = new AsyncRelayCommand(Save);
            DeleteCommand = new AsyncRelayCommand(Delete);
            VerPartidosCommand = new AsyncRelayCommand(VerPartidos);
            UpdatePartidosCommand = new AsyncRelayCommand(UpdatePartidos);
        }

        public CompeticionViewModel(Models.CompeticionWrapper competicionWrapper)
        {
            _competicionWrapper = competicionWrapper;
            _equipos = new ObservableCollection<Equipo>(_competicionWrapper.Competicion.Equipos);
            _equiposOrdered = new ObservableCollection<Equipo>(_equipos.OrderByDescending(e => e.Puntos).ThenByDescending(e => e.Coeficiente));
            _partidos = new ObservableCollection<Partido>(_competicionWrapper.Competicion.Partidos);
            _fechasJornadas = new ObservableCollection<FechaJornada>(_competicionWrapper.Competicion.FechasJornadas);
            SaveCommand = new AsyncRelayCommand(Save);
            DeleteCommand = new AsyncRelayCommand(Delete);
            VerPartidosCommand = new AsyncRelayCommand(VerPartidos);
            UpdatePartidosCommand = new AsyncRelayCommand(UpdatePartidos);
        }
        private async Task Save()
        {
            _competicionWrapper.Date = DateTime.Now;
            //Generar las jornadas
            for (int i = _competicionWrapper.Competicion.FechasJornadas.Count; i < _competicionWrapper.Competicion.Jornadas; i++)
                _competicionWrapper.Competicion.FechasJornadas.Add(new FechaJornada(i + 1));
            //Generar los equipos
            for (int i = _competicionWrapper.Competicion.Equipos.Count; i < _competicionWrapper.Competicion.NumEquipos; i++)
                _competicionWrapper.Competicion.Equipos.Add(new Equipo(i + 1, string.Empty));

            await _competicionWrapper.Save();
            await Shell.Current.GoToAsync($"..?saved={_competicionWrapper.Filename}");
        }

        private async Task Delete()
        {
            _competicionWrapper.Delete();
            await Shell.Current.GoToAsync($"..?deleted={_competicionWrapper.Filename}");
        }
        private async Task VerPartidos()
        {
            await Shell.Current.GoToAsync($"{nameof(Views.PartidosPage)}?load={Identifier}");
        }

        void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("load"))
            {
                _competicionWrapper = Models.CompeticionWrapper.Load(query["load"].ToString());
                _equipos = new ObservableCollection<Equipo>(_competicionWrapper.Competicion.Equipos);
                _equiposOrdered = new ObservableCollection<Equipo>(_equipos.OrderByDescending(e => e.Puntos).ThenByDescending(e => e.Coeficiente));
                _partidos = new ObservableCollection<Partido>(_competicionWrapper.Competicion.Partidos);
                _fechasJornadas = new ObservableCollection<FechaJornada>(_competicionWrapper.Competicion.FechasJornadas);
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
            OnPropertyChanged(nameof(Partidos));
            OnPropertyChanged(nameof(FechasJornadas));
            OnPropertyChanged(nameof(EquiposOrdered));
        }
        public async Task UpdatePartidos()
        {
            await _competicionWrapper.Competicion.UpdateClasificacion();
            await Update();
        }

        public Task OnNumJornadasChanged()
        {
            //Generar las jornadas
            for (int i = _competicionWrapper.Competicion.Jornadas; i < _competicionWrapper.Competicion.Jornadas; i++)
                _competicionWrapper.Competicion.FechasJornadas.Add(new FechaJornada(i+1));
            Update();
            return Task.CompletedTask;
        }

        public Task OnNumEquiposChanged()
        {
            //Generar los equipos
            for (int i = _competicionWrapper.Competicion.Equipos.Count; i < _competicionWrapper.Competicion.NumEquipos; i++)
                _competicionWrapper.Competicion.Equipos.Add(new Equipo(i + 1, string.Empty));
            Update();
            return Task.CompletedTask;
        }
        public Task OnResultadoParcialChanged()
        {
            //Actualizar resultado
            Update();
            return Task.CompletedTask;
        }
        public async Task Update()
        {
            _competicionWrapper.Date = DateTime.Now;
            _competicionWrapper.Update();
            await Shell.Current.GoToAsync($"..?saved={_competicionWrapper.Filename}");
        }
    }
}
