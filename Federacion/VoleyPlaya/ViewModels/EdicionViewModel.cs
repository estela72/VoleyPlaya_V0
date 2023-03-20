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

namespace VoleyPlaya.ViewModels
{
    public interface IEdicionVM
    {
        Task OnNumJornadasChanged();
        Task OnNumEquiposChanged();
        Task OnResultadoParcialChanged();
    }
    public class EdicionViewModel : ObservableObject, IQueryAttributable, IEdicionVM
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
        private Models.EdicionWrapper _edicionWrapper;
        public Edicion Edicion
        {
            get => _edicionWrapper?.Edicion;
            set
            {
                if (_edicionWrapper.Edicion != value)
                {
                    _edicionWrapper.Edicion = value;
                    _equipos = new ObservableCollection<Equipo>(_edicionWrapper.Edicion.Equipos);
                    _equiposOrdered = new ObservableCollection<Equipo>(_equipos.OrderByDescending(e => e.Puntos).ThenByDescending(e => e.Coeficiente));
                    _partidos = new ObservableCollection<Partido>(_edicionWrapper.Edicion.Partidos);
                    _fechasJornadas = new ObservableCollection<FechaJornada>(_edicionWrapper.Edicion.FechasJornadas);
                    OnPropertyChanged();
                }
            }
        }
        public DateTime Date => _edicionWrapper.Date;
        public string Identifier => _edicionWrapper.Filename;
        public ICommand SaveCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand VerPartidosCommand { get; private set; }
        public ICommand UpdatePartidosCommand { get; private set; }
        private static IVoleyPlayaService _voleyPlayaService;

        public EdicionViewModel(IVoleyPlayaService voleyPlayaService)
        {
            _voleyPlayaService = voleyPlayaService;
            Competiciones = new ObservableCollection<string>(EnumCompeticiones.Competiciones.Values);
            Categorias = new ObservableCollection<EnumCategorias>(Enum.GetValues(typeof(EnumCategorias)).OfType<EnumCategorias>().ToList());
            Generos = new ObservableCollection<EnumGeneros>(Enum.GetValues(typeof(EnumGeneros)).OfType<EnumGeneros>().ToList());

            _edicionWrapper = new Models.EdicionWrapper();
            _equipos = new ObservableCollection<Equipo>();
            _equiposOrdered = new ObservableCollection<Equipo>();
            _partidos = new ObservableCollection<Partido>();
            _fechasJornadas = new ObservableCollection<FechaJornada>();
            SaveCommand = new AsyncRelayCommand(Save);
            DeleteCommand = new AsyncRelayCommand(Delete);
            VerPartidosCommand = new AsyncRelayCommand(VerPartidos);
            UpdatePartidosCommand = new AsyncRelayCommand(UpdatePartidos);
        }

        public EdicionViewModel(IVoleyPlayaService voleyPlayaService, Models.EdicionWrapper edicionWrapper)
        {
            _voleyPlayaService = voleyPlayaService;
            _edicionWrapper = edicionWrapper;
            _equipos = new ObservableCollection<Equipo>(_edicionWrapper.Edicion.Equipos);
            _equiposOrdered = new ObservableCollection<Equipo>(_equipos.OrderByDescending(e => e.Puntos).ThenByDescending(e => e.Coeficiente));
            _partidos = new ObservableCollection<Partido>(_edicionWrapper.Edicion.Partidos);
            _fechasJornadas = new ObservableCollection<FechaJornada>(_edicionWrapper.Edicion.FechasJornadas);
            SaveCommand = new AsyncRelayCommand(Save);
            DeleteCommand = new AsyncRelayCommand(Delete);
            VerPartidosCommand = new AsyncRelayCommand(VerPartidos);
            UpdatePartidosCommand = new AsyncRelayCommand(UpdatePartidos);
        }
        private async Task Save()
        {
            _edicionWrapper.Date = DateTime.Now;
            _edicionWrapper.EdicionName = VoleyPlayaService.GetNombreEdicion(_edicionWrapper.Edicion.Temporada,
                _edicionWrapper.Edicion.Nombre, _edicionWrapper.Edicion.CategoriaStr, _edicionWrapper.Edicion.GeneroStr,
                _edicionWrapper.Edicion.Grupo);

            //Generar las jornadas
            for (int i = _edicionWrapper.Edicion.FechasJornadas.Count; i < _edicionWrapper.Edicion.Jornadas; i++)
                _edicionWrapper.Edicion.FechasJornadas.Add(new FechaJornada(i + 1));
            //Generar los equipos
            for (int i = _edicionWrapper.Edicion.Equipos.Count; i < _edicionWrapper.Edicion.NumEquipos; i++)
                _edicionWrapper.Edicion.Equipos.Add(new Equipo(i + 1, string.Empty));

            await _edicionWrapper.Save();

            string jsonString = JsonSerializer.Serialize(_edicionWrapper.Edicion);
            await _voleyPlayaService.SaveEdicionAsync(jsonString);

            await Shell.Current.GoToAsync($"..?saved={_edicionWrapper.Filename}");
        }

        private async Task Delete()
        {
            _edicionWrapper.Delete();

            await _voleyPlayaService.DeleteEdicionAsync(_edicionWrapper.EdicionName);

            await Shell.Current.GoToAsync($"..?deleted={_edicionWrapper.Filename}");
        }
        private async Task VerPartidos()
        {
            await Shell.Current.GoToAsync($"{nameof(Views.PartidosPage)}?load={Identifier}");
        }

        void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("load"))
            {
                //_competicionWrapper = Models.CompeticionWrapper.Load(query["load"].ToString());
                var jsonEdicion = _voleyPlayaService.GetEdicion(query["load"].ToString());
                JsonNode jsonNode = JsonNode.Parse(jsonEdicion)!;
                _edicionWrapper.Edicion = Edicion.FromJson(jsonNode);
                _equipos = new ObservableCollection<Equipo>(_edicionWrapper.Edicion.Equipos);
                _equiposOrdered = new ObservableCollection<Equipo>(_equipos.OrderByDescending(e => e.Puntos).ThenByDescending(e => e.Coeficiente));
                _partidos = new ObservableCollection<Partido>(_edicionWrapper.Edicion.Partidos);
                _fechasJornadas = new ObservableCollection<FechaJornada>(_edicionWrapper.Edicion.FechasJornadas);
                RefreshProperties();
            }
        }
        public async Task ReloadAsync()
        {
            //_competicionWrapper = Models.CompeticionWrapper.Load(_competicionWrapper.Filename);
            var jsonEdicion = await _voleyPlayaService.GetEdicionAsync(_edicionWrapper.Edicion.Nombre);
            JsonNode jsonNode = JsonNode.Parse(jsonEdicion)!;
            _edicionWrapper.Edicion = Edicion.FromJson(jsonNode);
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
        }
        public async Task UpdatePartidos()
        {
            await _edicionWrapper.Edicion.UpdateClasificacion();
            await Update();
        }

        public Task OnNumJornadasChanged()
        {
            //Generar las jornadas
            for (int i = _edicionWrapper.Edicion.Jornadas; i < _edicionWrapper.Edicion.Jornadas; i++)
                _edicionWrapper.Edicion.FechasJornadas.Add(new FechaJornada(i+1));
            Update();
            return Task.CompletedTask;
        }

        public Task OnNumEquiposChanged()
        {
            //Generar los equipos
            for (int i = _edicionWrapper.Edicion.Equipos.Count; i < _edicionWrapper.Edicion.NumEquipos; i++)
                _edicionWrapper.Edicion.Equipos.Add(new Equipo(i + 1, string.Empty));
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
            _edicionWrapper.Date = DateTime.Now;
            _edicionWrapper.Update();
            await Shell.Current.GoToAsync($"..?saved={_edicionWrapper.Filename}");
        }
    }
}
