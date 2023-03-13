using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace VoleyPlaya.ViewModels
{
    internal class CompeticionesViewModel : ObservableObject, IQueryAttributable
    {
        public ObservableCollection<ViewModels.CompeticionViewModel> AllCompeticiones { get; }
        public ICommand NewCommand { get; }
        public ICommand SelectCompeticionCommand { get; }
        public CompeticionesViewModel()
        {
            AllCompeticiones = new ObservableCollection<ViewModels.CompeticionViewModel>(Models.CompeticionWrapper.LoadAll().Select(n => new CompeticionViewModel(n)));
            NewCommand = new AsyncRelayCommand(NewCompeticionAsync);
            SelectCompeticionCommand = new AsyncRelayCommand<ViewModels.CompeticionViewModel>(SelectCompeticionAsync);
        }
        private async Task NewCompeticionAsync()
        {
            await Shell.Current.GoToAsync(nameof(Views.CompeticionPage));
        }

        private async Task SelectCompeticionAsync(ViewModels.CompeticionViewModel competicion)
        {
            if (competicion != null)
                await Shell.Current.GoToAsync($"{nameof(Views.CompeticionPage)}?load={competicion.Identifier}");
        }
        void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("deleted"))
            {
                string competicionId = query["deleted"].ToString();
                CompeticionViewModel matchedCompeticion = AllCompeticiones.Where((n) => n.Identifier == competicionId).FirstOrDefault();

                // If note exists, delete it
                if (matchedCompeticion != null)
                    AllCompeticiones.Remove(matchedCompeticion);
            }
            else if (query.ContainsKey("saved"))
            {
                string competicionId = query["saved"].ToString();
                CompeticionViewModel matchedCompeticion = AllCompeticiones.Where((n) => n.Identifier == competicionId).FirstOrDefault();

                // If note is found, update it
                if (matchedCompeticion != null)
                {
                    matchedCompeticion.Reload();
                    AllCompeticiones.Move(AllCompeticiones.IndexOf(matchedCompeticion), 0);
                }
                // If note isn't found, it's new; add it.
                else
                    AllCompeticiones.Insert(0, new CompeticionViewModel(Models.CompeticionWrapper.Load(competicionId)));
            }
        }
    }
}
