using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using System.Collections.ObjectModel;
using VoleyPlaya.Repository.Services;
using System.Linq;
using VoleyPlaya.Models;
using System.Text.Json.Nodes;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.WebUI;

namespace VoleyPlaya.ViewModels
{
    public class EdicionesViewModel : ObservableObject, IQueryAttributable
    {

        private ObservableCollection<Edicion> _allEdiciones;
        public IList<Edicion> AllEdiciones { get => _allEdiciones; set => _allEdiciones = (ObservableCollection<Edicion>)value; }
        public ICommand NewCommand { get; }
        public ICommand SelectEdicionCommand { get; }
        IVoleyPlayaService _voleyPlayaService;
        public EdicionesViewModel(IVoleyPlayaService voleyPlayaService)
        {
            _voleyPlayaService = voleyPlayaService;
            NewCommand = new AsyncRelayCommand(NewEdicionAsync);
            SelectEdicionCommand = new AsyncRelayCommand<Edicion>(SelectEdicionAsync);
            InicializaEdiciones();
        }
        private async Task InicializaEdiciones()
        { 
            //AllEdiciones = new ObservableCollection<ViewModels.EdicionViewModel>(Models.EdicionWrapper.LoadAll().Select(n => new EdicionViewModel(n)));
            var jsonEdiciones = await _voleyPlayaService.GetAllEdicionesAsync();
            var ediciones = FromJson(jsonEdiciones);
            _allEdiciones = new ObservableCollection<Edicion>(ediciones.ToList());
            OnPropertyChanged(nameof(AllEdiciones));
            OnPropertyChanged();
        }

        private IEnumerable<Edicion> FromJson(string jsonEdiciones)
        {
            List<Edicion> list = new List<Edicion>();
            JsonNode node = JsonNode.Parse(jsonEdiciones)!;
            JsonArray ediciones = node!.AsArray();
            foreach (var edicion in ediciones)
                list.Add(Edicion.FromJson(edicion));
            return list;
        }

        private async Task NewEdicionAsync()
        {
            await Shell.Current.GoToAsync(nameof(Views.EdicionPage));
        }

        private async Task SelectEdicionAsync(Edicion edicion)
        {
            if (edicion != null)
                await Shell.Current.GoToAsync($"{nameof(Views.EdicionPage)}?load={edicion.Nombre}");
        }
        void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("deleted"))
            {
                string edicionId = query["deleted"].ToString();
                edicionId = Uri.UnescapeDataString(edicionId);
                Edicion matchedEdicion = AllEdiciones.Where((n) => n.Nombre == edicionId).FirstOrDefault();

                // If edicion exists, delete it
                if (matchedEdicion != null)
                    AllEdiciones.Remove(matchedEdicion);
            }
            else if (query.ContainsKey("saved"))
            {
                string edicionId = query["saved"].ToString();
                edicionId = Uri.UnescapeDataString(edicionId);
                Edicion matchedEdicion = AllEdiciones.Where((n) => n.Nombre == edicionId).FirstOrDefault();

                // If edicion is found, update it
                if (matchedEdicion != null)
                {
                    //matchedEdicion.ReloadAsync();
                    //AllEdiciones.Move(AllEdiciones.IndexOf(matchedEdicion), 0);
                }
                // If edicion isn't found, it's new; add it.
                else
                {
                    Edicion edicion = GetEdicion(edicionId);
                    AllEdiciones.Insert(0, edicion);
                }
            }
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
