using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using System.Collections.ObjectModel;
using VoleyPlaya.Repository.Services;
using System.Linq;
using VoleyPlaya.Models;
using System.Text.Json.Nodes;

namespace VoleyPlaya.ViewModels
{
    public class EdicionesViewModel : ObservableObject, IQueryAttributable
    {
        public ObservableCollection<ViewModels.EdicionViewModel> AllEdiciones { get; private set; }
        public ICommand NewCommand { get; }
        public ICommand SelectEdicionCommand { get; }
        IVoleyPlayaService _voleyPlayaService;

        public EdicionesViewModel(IVoleyPlayaService voleyPlayaService)
        {
            _voleyPlayaService = voleyPlayaService;
            NewCommand = new AsyncRelayCommand(NewEdicionAsync);
            SelectEdicionCommand = new AsyncRelayCommand<ViewModels.EdicionViewModel>(SelectEdicionAsync);
            InicializaEdiciones();
        }
        private async Task InicializaEdiciones()
        { 
            //AllEdiciones = new ObservableCollection<ViewModels.EdicionViewModel>(Models.EdicionWrapper.LoadAll().Select(n => new EdicionViewModel(n)));
            var jsonEdiciones = await _voleyPlayaService.GetAllEdicionesAsync();
            var ediciones = FromJson(jsonEdiciones);
            AllEdiciones = new ObservableCollection<ViewModels.EdicionViewModel>(ediciones.Select(n => new EdicionViewModel(_voleyPlayaService, n)));
        }

        private IEnumerable<EdicionWrapper> FromJson(string jsonEdiciones)
        {
            List<EdicionWrapper> list = new List<EdicionWrapper>();
            JsonNode node = JsonNode.Parse(jsonEdiciones)!;
            JsonArray ediciones = node!.AsArray();
            foreach(var edicion in ediciones)
                list.Add(EdicionWrapper.FromJson(edicion));
            return list;
        }

        private async Task NewEdicionAsync()
        {
            await Shell.Current.GoToAsync(nameof(Views.EdicionPage));
        }

        private async Task SelectEdicionAsync(ViewModels.EdicionViewModel edicion)
        {
            if (edicion != null)
                await Shell.Current.GoToAsync($"{nameof(Views.EdicionPage)}?load={edicion.Edicion.Nombre}");
        }
        void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("deleted"))
            {
                string edicionId = query["deleted"].ToString();
                EdicionViewModel matchedEdicion = AllEdiciones.Where((n) => n.Identifier == edicionId).FirstOrDefault();

                // If note exists, delete it
                if (matchedEdicion != null)
                    AllEdiciones.Remove(matchedEdicion);
            }
            else if (query.ContainsKey("saved"))
            {
                string edicionId = query["saved"].ToString();
                EdicionViewModel matchedEdicion = AllEdiciones.Where((n) => n.Identifier == edicionId).FirstOrDefault();

                // If note is found, update it
                if (matchedEdicion != null)
                {
                    matchedEdicion.ReloadAsync();
                    AllEdiciones.Move(AllEdiciones.IndexOf(matchedEdicion), 0);
                }
                // If note isn't found, it's new; add it.
                else
                    AllEdiciones.Insert(0, new EdicionViewModel(_voleyPlayaService, Models.EdicionWrapper.Load(edicionId)));
            }
        }
    }
}
