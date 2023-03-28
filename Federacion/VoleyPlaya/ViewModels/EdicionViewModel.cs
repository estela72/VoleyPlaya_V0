using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using VoleyPlaya.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using VoleyPlaya.Views;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using VoleyPlaya.Repository.Services;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Channels;

namespace VoleyPlaya.ViewModels
{
    public interface IEdicionVM
    {
        Task OnNumJornadasChanged();
        Task OnNumEquiposChanged();
        Task OnResultadoParcialChanged();
    }
    public class EdicionViewModel : ObservableObject, IQueryAttributable
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
        private Models.Edicion _edicion;
        public Edicion Edicion
        {
            get => _edicion; 
            set
            {
                if (_edicion!=value)
                {
                    _edicion = value;
                    _equipos = new ObservableCollection<Equipo>(Edicion.Equipos);
                    _equiposOrdered = new ObservableCollection<Equipo>(_equipos.OrderByDescending(e => e.Puntos).ThenByDescending(e => e.Coeficiente));
                    _partidos = new ObservableCollection<Partido>(Edicion.Partidos);
                    _fechasJornadas = new ObservableCollection<FechaJornada>(Edicion.FechasJornadas);
                    OnPropertyChanged();
                }
            }
        }
        const int RefreshDuration = 2;
        bool isRefreshing;

        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set
            {
                isRefreshing = value;
                OnPropertyChanged();
            }
        }
        public ICommand RefreshCommand => new Command(async () => await RefreshItemsAsync());

        public DateTime Date => Edicion.Fecha;
        public string Identifier => Edicion.Nombre;
        public ICommand SaveCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand VerPartidosCommand { get; private set; }
        public ICommand UpdatePartidosCommand { get; private set; }
        public ICommand AddEquiposCommand { get; private set; }
        public ICommand AddJornadasCommand { get; private set; }
        private static IVoleyPlayaService _voleyPlayaService;

        public EdicionViewModel(IVoleyPlayaService voleyPlayaService)
        {
            _voleyPlayaService = voleyPlayaService;
            Competiciones = new ObservableCollection<string>(EnumCompeticiones.Competiciones.Values);
            Categorias = new ObservableCollection<EnumCategorias>(Enum.GetValues(typeof(EnumCategorias)).OfType<EnumCategorias>().ToList());
            Generos = new ObservableCollection<EnumGeneros>(Enum.GetValues(typeof(EnumGeneros)).OfType<EnumGeneros>().ToList());

            _edicion = new Models.Edicion();
            _equipos = new ObservableCollection<Equipo>();
            _equiposOrdered = new ObservableCollection<Equipo>();
            _partidos = new ObservableCollection<Partido>();
            _fechasJornadas = new ObservableCollection<FechaJornada>();
            SaveCommand = new AsyncRelayCommand(Save);
            DeleteCommand = new AsyncRelayCommand(Delete);
            VerPartidosCommand = new AsyncRelayCommand(VerPartidos);
            UpdatePartidosCommand = new AsyncRelayCommand(UpdatePartidos);
            AddEquiposCommand = new AsyncRelayCommand(AddEquipos);
            AddJornadasCommand = new AsyncRelayCommand(AddJornadas);
        }

        public EdicionViewModel(IVoleyPlayaService voleyPlayaService, Models.Edicion edicion)
        {
            _voleyPlayaService = voleyPlayaService;
            Edicion = edicion;
            _equipos = new ObservableCollection<Equipo>(Edicion.Equipos);
            _equiposOrdered = new ObservableCollection<Equipo>(_equipos.OrderByDescending(e => e.Puntos).ThenByDescending(e => e.Coeficiente));
            _partidos = new ObservableCollection<Partido>(Edicion.Partidos);
            _fechasJornadas = new ObservableCollection<FechaJornada>(Edicion.FechasJornadas);
            SaveCommand = new AsyncRelayCommand(Save);
            DeleteCommand = new AsyncRelayCommand(Delete);
            VerPartidosCommand = new AsyncRelayCommand(VerPartidos);
            UpdatePartidosCommand = new AsyncRelayCommand(UpdatePartidos);
        }
        private async Task Save()
        {
            IsRefreshing = true;
            await Task.Delay(TimeSpan.FromSeconds(RefreshDuration));

            await Edicion.GenerarPartidosAsync();

            string jsonString = JsonSerializer.Serialize(Edicion);
            try
            {
                await _voleyPlayaService.SaveEdicionAsync(jsonString);
            }
            catch(Exception x)
            {
                //TODO: Mostrar un error en pantalla
                await Application.Current.MainPage.DisplayAlert("Voley Playa", "Error al guardar la edición", "Ok");
            }
            _equipos = new ObservableCollection<Equipo>(Edicion.Equipos);
            _equiposOrdered = new ObservableCollection<Equipo>(_equipos.OrderByDescending(e => e.Puntos).ThenByDescending(e => e.Coeficiente));
            _partidos = new ObservableCollection<Partido>(Edicion.Partidos);
            _fechasJornadas = new ObservableCollection<FechaJornada>(Edicion.FechasJornadas);

            RefreshProperties();
            IsRefreshing = false;
        }
        internal async Task AddEquipos()
        {
            //Generar los equipos
            for (int i = Edicion.Equipos.Count; i < Edicion.NumEquipos; i++)
                Edicion.Equipos.Add(new Equipo(i + 1, string.Empty));
            if (Edicion.Equipos.Count > Edicion.NumEquipos)
                Edicion.Equipos.RemoveRange(Edicion.NumEquipos, Edicion.Equipos.Count - Edicion.NumEquipos);

            _equipos = new ObservableCollection<Equipo>(Edicion.Equipos);
            _equiposOrdered = new ObservableCollection<Equipo>(_equipos.OrderByDescending(e => e.Puntos).ThenByDescending(e => e.Coeficiente));
            RefreshProperties();
        }
        internal async Task AddJornadas()
        {
            //Generar las jornadas
            for (int i = Edicion.FechasJornadas.Count; i < Edicion.NumJornadas; i++)
                Edicion.FechasJornadas.Add(new FechaJornada(i + 1));
            if (Edicion.FechasJornadas.Count > Edicion.NumJornadas)
                Edicion.FechasJornadas.RemoveRange(Edicion.NumJornadas, Edicion.FechasJornadas.Count - Edicion.NumJornadas);
            _fechasJornadas = new ObservableCollection<FechaJornada>(Edicion.FechasJornadas);
            RefreshProperties();
        }
        private async Task Delete()
        {
            await _voleyPlayaService.DeleteEdicionAsync(Edicion.Nombre);

            await Shell.Current.GoToAsync($"..?deleted={Edicion.Nombre}");
        }
        private async Task VerPartidos()
        {
            await Shell.Current.GoToAsync($"{nameof(Views.PartidosPage)}?load={Edicion.Nombre}");
        }

        void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("load"))
            {
                string name = Uri.UnescapeDataString(query["load"].ToString());
                if (!string.IsNullOrEmpty(name))
                {
                    Edicion = GetEdicion(name);
                    _equipos = new ObservableCollection<Equipo>(Edicion.Equipos);
                    _equiposOrdered = new ObservableCollection<Equipo>(_equipos.OrderByDescending(e => e.Puntos).ThenByDescending(e => e.Coeficiente));
                    _partidos = new ObservableCollection<Partido>(Edicion.Partidos);
                    _fechasJornadas = new ObservableCollection<FechaJornada>(Edicion.FechasJornadas);
                    RefreshProperties();
                }
            }
        }
        public async Task ReloadAsync()
        {
            var jsonEdicion = await _voleyPlayaService.GetEdicionAsync(Edicion.Nombre);
            JsonNode jsonNode = JsonNode.Parse(jsonEdicion)!;
            Edicion = Edicion.FromJson(jsonNode);
            _equipos = new ObservableCollection<Equipo>(Edicion.Equipos);
            _equiposOrdered = new ObservableCollection<Equipo>(_equipos.OrderByDescending(e => e.Puntos).ThenByDescending(e => e.Coeficiente));
            _partidos = new ObservableCollection<Partido>(Edicion.Partidos);
            _fechasJornadas = new ObservableCollection<FechaJornada>(Edicion.FechasJornadas);
            RefreshProperties();
        }

        private void RefreshProperties()
        {
            OnPropertyChanged(nameof(Edicion));
            OnPropertyChanged(nameof(Date));
            OnPropertyChanged(nameof(Equipos));
            OnPropertyChanged(nameof(Partidos));
            OnPropertyChanged(nameof(FechasJornadas));
            OnPropertyChanged(nameof(EquiposOrdered));
            OnPropertyChanged();
        }
        public async Task UpdatePartidos()
        {
            await Edicion.UpdateClasificacion();
            _equipos = new ObservableCollection<Equipo>(Edicion.Equipos);
            _equiposOrdered = new ObservableCollection<Equipo>(_equipos.OrderByDescending(e => e.Puntos).ThenByDescending(e => e.Coeficiente));
            _partidos = new ObservableCollection<Partido>(Edicion.Partidos);
            _fechasJornadas = new ObservableCollection<FechaJornada>(Edicion.FechasJornadas);
            RefreshProperties();
        }
        async Task RefreshItemsAsync()
        {
            IsRefreshing = true;
            await Task.Delay(TimeSpan.FromSeconds(RefreshDuration));
            RefreshProperties();
            IsRefreshing = false;
        }
        private Edicion GetEdicion(string edicionId)
        {
            var jsonEdicion = _voleyPlayaService.GetEdicion(edicionId);
            JsonNode jsonNode = JsonNode.Parse(jsonEdicion)!;
            var edicion = Edicion.FromJson(jsonNode);
            return edicion;
        }
    }
}
