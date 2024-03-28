using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Project._04_LineasAutobuses.Commands;
using Project._04_LineasAutobuses.ViewModel;
using Project._04_LineasAutobuses.Views;

namespace Project._04_LineasAutobuses.ViewModels
{
    public class InicioViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private static InicioViewModel _instance;

        public static InicioViewModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new InicioViewModel();
                }
                return _instance;
            }
        }

        private ObservableCollection<string> _municipios;
        public ObservableCollection<string> Municipios
        {
            get { return _municipios; }
            set
            {
                _municipios = value;
                OnPropertyChanged(nameof(Municipios));
            }
        }

        private ObservableCollection<string> _origenSeleccionado;
        public ObservableCollection<string> OrigenSeleccionado
        {
            get { return _origenSeleccionado; }
            set
            {
                _origenSeleccionado = value;
                OnPropertyChanged(nameof(OrigenSeleccionado));
            }
        }

        private ObservableCollection<string> _destinoSeleccionado;
        public ObservableCollection<string> DestinoSeleccionado
        {
            get { return _destinoSeleccionado; }
            set
            {
                _destinoSeleccionado = value;
                OnPropertyChanged(nameof(DestinoSeleccionado));
            }
        }

        private ObservableCollection<int> _horas;
        public ObservableCollection<int> Horas
        {
            get { return _horas; }
            set
            {
                _horas = value;
                OnPropertyChanged(nameof(Horas));
            }
        }

        private ObservableCollection<int> _minutos;
        public ObservableCollection<int> Minutos
        {
            get { return _minutos; }
            set
            {
                _minutos = value;
                OnPropertyChanged(nameof(Minutos));
            }
        }

        public ICommand BuscarCommand { get; }

        public InicioViewModel()
        {
            BuscarCommand = new RelayCommand(Buscar, CanBuscar);
        }

        private bool CanBuscar()
        {
            return OrigenSeleccionado != null &&
                   DestinoSeleccionado != null &&
                   Horas != null &&
                   Minutos != null &&
                   OrigenSeleccionado.Count > 0 &&
                   DestinoSeleccionado.Count > 0 &&
                   Horas.Count >= 0 &&
                   Minutos.Count >= 0;
        }

        private void Buscar()
        {
            try
            {
                string origen = OrigenSeleccionado[0];
                string destino = DestinoSeleccionado[0];
                int hora = Horas[0];
                int minuto = Minutos[0];

                TimeSpan horaSalida = new TimeSpan(hora, minuto, 0);

                //MainWindowViewModel.Origen = origen;
                //MainWindowViewModel.Destino = destino;
                //MainWindowViewModel.HoraSalida = horaSalida;
                MainWindowViewModel.Instance.NavigateToItinerarioCommand.Execute(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar itinerarios: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
