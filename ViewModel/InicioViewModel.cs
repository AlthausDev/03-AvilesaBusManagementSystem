using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Project._04_LineasAutobuses.Commands;
using Project._04_LineasAutobuses.Model;
using Project._04_LineasAutobuses.Services;
using Project._04_LineasAutobuses.ViewModel;
using Project._04_LineasAutobuses.Views;

namespace Project._04_LineasAutobuses.ViewModel
{
    public class InicioViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly DataService _dataService;
        public ObservableCollection<string> Municipios { get; set; }
        public String MunicipioOrigen { get; set; }
        public String MunicipioDestino { get; set; }
        public ObservableCollection<int> Horas { get; set; }
        public ObservableCollection<int> Minutos { get; set; }

        public TimePickerViewModel TimePicker { get; }


        private ObservableCollection<Itinerario> _itinerariosFiltrados;
        public ObservableCollection<Itinerario> ItinerariosFiltrados
        {
            get { return _itinerariosFiltrados; }
            set
            {
                _itinerariosFiltrados = value;
                OnPropertyChanged(nameof(ItinerariosFiltrados));
            }
        }



        public ICommand BuscarCommand { get; }        
        public ICommand FiltrarSugerenciasCommand { get; }


        public InicioViewModel()
        {
            _dataService = MainWindowViewModel.DataService;

            CargarMunicipiosDesdeParadas();

            MunicipioOrigen = string.Empty;
            MunicipioDestino = string.Empty;
            Horas = new ObservableCollection<int>();
            Minutos = new ObservableCollection<int>();

            TimePicker = new TimePickerViewModel();
            BuscarCommand = new RelayCommand(Buscar, CanBuscar);
            FiltrarSugerenciasCommand = new RelayCommandWithParameter<string>(FiltrarSugerencias);
            Sugerencias = new ObservableCollection<string>();

        }

        private void CargarMunicipiosDesdeParadas()
        {
            Municipios = new ObservableCollection<string>(_dataService.Paradas.Select(parada => parada.Municipio).Distinct());
        }

        private bool CanBuscar()
        {
            return !string.IsNullOrEmpty(MunicipioOrigen) &&
                   !string.IsNullOrEmpty(MunicipioDestino);
        }

        public void Buscar()
        {
            try
            {
                TimeSpan tiempoSeleccionado = new TimeSpan(TimePicker.SelectedHour, TimePicker.SelectedMinute, 0);
                ItinerariosFiltrados = new ObservableCollection<Itinerario>(_dataService.Itinerarios.Where(it =>
                    it.Paradas.Any(p => p.Municipio == MunicipioOrigen) &&
                    it.Paradas.Any(p => p.Municipio == MunicipioDestino) &&
                    TimeSpan.Compare(it.TiempoRecorrido, tiempoSeleccionado) >= 0));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar itinerarios: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        public void FiltrarSugerencias(string texto)
        {
            Sugerencias = new ObservableCollection<string>(Municipios.Where(s => s.StartsWith(texto)));
        }


        private ObservableCollection<string> _sugerencias;
        public ObservableCollection<string> Sugerencias
        {
            get { return _sugerencias; }
            set
            {
                _sugerencias = value;
                OnPropertyChanged(nameof(Sugerencias));
            }
        }       


        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
