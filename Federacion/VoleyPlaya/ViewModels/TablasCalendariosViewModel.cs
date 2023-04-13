using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace VoleyPlaya.ViewModels
{
    public class TablasCalendariosViewModel : ObservableObject, IQueryAttributable
    {
        public ObservableCollection<ViewModels.TablaCalendarioViewModel> AllTablasCalendarios { get; }
        public ICommand NewCommand { get; }
        public ICommand SelectCommand { get; }
        public TablasCalendariosViewModel()
        {
            AllTablasCalendarios = new ObservableCollection<ViewModels.TablaCalendarioViewModel>(Models.TablaCalendarioWrapper.LoadAll().Select(n => new TablaCalendarioViewModel(n)));
            NewCommand = new AsyncRelayCommand(NewTablaCalendarioAsync);
            SelectCommand = new AsyncRelayCommand<ViewModels.TablaCalendarioViewModel>(SelectAsync);
        }
        private async Task NewTablaCalendarioAsync()
        {
            await Shell.Current.GoToAsync(nameof(Views.TablaCalendarioPage));
        }

        private async Task SelectAsync(ViewModels.TablaCalendarioViewModel tablaCalendario)
        {
            if (tablaCalendario != null)
                await Shell.Current.GoToAsync($"{nameof(Views.TablaCalendarioPage)}?load={tablaCalendario.Identifier}");
        }
        void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("deleted"))
            {
                string tablaCalendarioId = query["deleted"].ToString();
                TablaCalendarioViewModel matchedTablaCalendario = AllTablasCalendarios.Where((n) => n.Identifier == tablaCalendarioId).FirstOrDefault();

                // If note exists, delete it
                if (matchedTablaCalendario != null)
                    AllTablasCalendarios.Remove(matchedTablaCalendario);
            }
            else if (query.ContainsKey("saved"))
            {
                string tablaCalendarioId = query["saved"].ToString();
                TablaCalendarioViewModel matchedTablaCalendario = AllTablasCalendarios.Where((n) => n.Identifier == tablaCalendarioId).FirstOrDefault();

                // If note is found, update it
                if (matchedTablaCalendario != null)
                {
                    matchedTablaCalendario.Reload();
                    AllTablasCalendarios.Move(AllTablasCalendarios.IndexOf(matchedTablaCalendario), 0);
                }
                // If note isn't found, it's new; add it.
                else
                    AllTablasCalendarios.Insert(0, new TablaCalendarioViewModel(Models.TablaCalendarioWrapper.Load(tablaCalendarioId)));
            }
        }
    }
}
