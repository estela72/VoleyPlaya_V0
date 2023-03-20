using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using VoleyPlaya.Models;

namespace VoleyPlaya.ViewModels
{
    public class ConfiguracionViewModel : ObservableObject
    {
        public ICommand TablasCalendariosCommand { get; private set; }

        public ConfiguracionViewModel()
        {
            TablasCalendariosCommand = new AsyncRelayCommand(TablasCalendarios);
        }
        private async Task TablasCalendarios()
        {
            await Shell.Current.GoToAsync("TablasCalendariosPage");
        }
        
    }
}
