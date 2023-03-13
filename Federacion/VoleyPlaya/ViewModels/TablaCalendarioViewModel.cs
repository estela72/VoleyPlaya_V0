using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoleyPlaya.Models;
using System.Collections.ObjectModel;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Windows.Input;

namespace VoleyPlaya.ViewModels
{
    public class TablaCalendarioViewModel : ObservableObject, IQueryAttributable
    {
        //public ObservableCollection<string> Competiciones { get; set; }
        //public ObservableCollection<EnumCategorias> Categorias { get; set; }
        //public ObservableCollection<EnumGeneros> Generos { get; set; }

        private Models.TablaCalendarioWrapper _tablaCalendarioWrapper;
        public TablaCalendario TablaCalendario
        {
            get => _tablaCalendarioWrapper.TablaCalendario;
            set
            {
                if (_tablaCalendarioWrapper.TablaCalendario != value)
                {
                    _tablaCalendarioWrapper.TablaCalendario = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime Date => _tablaCalendarioWrapper.Date;

        public string Identifier => _tablaCalendarioWrapper.Filename;

        public ICommand SaveCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public TablaCalendarioViewModel()
        {
            //Competiciones = new ObservableCollection<string>(EnumCompeticiones.Competiciones.Values);
            //Categorias = new ObservableCollection<EnumCategorias>(Enum.GetValues(typeof(EnumCategorias)).OfType<EnumCategorias>().ToList());
            //Generos = new ObservableCollection<EnumGeneros>(Enum.GetValues(typeof(EnumGeneros)).OfType<EnumGeneros>().ToList());

            _tablaCalendarioWrapper = new Models.TablaCalendarioWrapper();
            SaveCommand = new AsyncRelayCommand(Save);
            DeleteCommand = new AsyncRelayCommand(Delete);
        }

        public TablaCalendarioViewModel(Models.TablaCalendarioWrapper wrapper)
        {
            _tablaCalendarioWrapper = wrapper;
            SaveCommand = new AsyncRelayCommand(Save);
            DeleteCommand = new AsyncRelayCommand(Delete);
        }
        private async Task Save()
        {
            _tablaCalendarioWrapper.Date = DateTime.Now;
            _tablaCalendarioWrapper.Save();
            await Shell.Current.GoToAsync($"..?saved={_tablaCalendarioWrapper.Filename}");
        }

        private async Task Delete()
        {
            _tablaCalendarioWrapper.Delete();
            await Shell.Current.GoToAsync($"..?deleted={_tablaCalendarioWrapper.Filename}");
        }
        void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("load"))
            {
                _tablaCalendarioWrapper = Models.TablaCalendarioWrapper.Load(query["load"].ToString());
                RefreshProperties();
            }
        }
        public void Reload()
        {
            _tablaCalendarioWrapper = Models.TablaCalendarioWrapper.Load(_tablaCalendarioWrapper.Filename);
            RefreshProperties();
        }

        private void RefreshProperties()
        {
            OnPropertyChanged(nameof(Competicion));
            OnPropertyChanged(nameof(Date));
        }
    }
}
