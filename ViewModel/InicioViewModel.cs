using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Project._04_LineasAutobuses.Commands;
using Project._04_LineasAutobuses.Model;
using Project._04_LineasAutobuses.ViewModel;
using Project._04_LineasAutobuses.Views;

namespace Project._04_LineasAutobuses.ViewModel
{
    public class InicioViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<string> Municipios { get; set; }
        public ObservableCollection<string> MunicipioOrigen { get; set; }
        public ObservableCollection<string> MunicipioDestino { get; set; }
        public ObservableCollection<int> Horas { get; set; }
        public ObservableCollection<int> Minutos { get; set; }

        public TimePickerViewModel TimePicker { get; }

        public ICommand BuscarCommand { get; }

        public InicioViewModel()
        {
            // Inicializar colecciones
            Municipios = new ObservableCollection<string>();
            MunicipioOrigen = new ObservableCollection<string>();
            MunicipioDestino = new ObservableCollection<string>();
            Horas = new ObservableCollection<int>();
            Minutos = new ObservableCollection<int>();

            TimePicker = new TimePickerViewModel();
            BuscarCommand = new RelayCommand(Buscar, CanBuscar);
        }

        private bool CanBuscar()
        {   
                return !string.IsNullOrEmpty(MunicipioOrigen?[0]) &&
                       !string.IsNullOrEmpty(MunicipioDestino?[0]);
       
        }

        private void Buscar()
        {
            //try
            //{
            //    var itinerariosFiltrados = Itinerarios.Where(it =>
            //        it.Paradas.Any(p => p.Municipio == MunicipioOrigen) &&
            //        it.Paradas.Any(p => p.Municipio == MunicipioDestino) &&
            //        it.Hora >= TimePicker.SelectedHour &&
            //        it.Minuto >= TimePicker.SelectedMinute).ToList();

            //    MainWindowViewModel.Instance.NavigateToItinerariosCommand.Execute(itinerariosFiltrados);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Error al buscar itinerarios: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
