using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using AvilesaBusManagementSystem.Commands;
using AvilesaBusManagementSystem.Model;
using AvilesaBusManagementSystem.Services;
using AvilesaBusManagementSystem.Utils;

namespace AvilesaBusManagementSystem.ViewModel
{
    public class ItinerarioViewModel : INotifyPropertyChanged
    {
        private readonly DataService _dataService;
        

        private ObservableCollection<Itinerario> _itinerario;
        public ObservableCollection<Itinerario> Itinerario
        {
            get { return _itinerario; }
            set
            {
                _itinerario = value;
                OnPropertyChanged(nameof(Itinerario));
            }
        }


        private Itinerario _itinerarioSeleccionado;
        public Itinerario ItinerarioSeleccionado
        {
            get { return _itinerarioSeleccionado; }
            set
            {
                _itinerarioSeleccionado = value;
                OnPropertyChanged(nameof(ItinerarioSeleccionado));
            }
        }

        private ObservableCollection<Parada> _paradas;
        public ObservableCollection<Parada> Paradas
        {
            get { return _paradas; }
            set
            {
                _paradas = value;
                OnPropertyChanged(nameof(Paradas));
            }
        }


        public ICommand AgregarItinerarioCommand { get; private set; }
        public ICommand ModificarItinerarioCommand { get; private set; }
        public ICommand EliminarItinerarioCommand { get; private set; }
        public ICommand ConsultarItinerarioCommand { get; private set; }

        public ItinerarioViewModel()
        {
            _dataService = MainWindowViewModel.DataService;
            InitializeCommands();
            LoadItinerarios();
        }
      

        private void InitializeCommands()
        {
            AgregarItinerarioCommand = new RelayCommandWithParameter<Itinerario>(Add);
            ModificarItinerarioCommand = new RelayCommandWithParameter<Itinerario>(Update);
            EliminarItinerarioCommand = new RelayCommandWithParameter<Itinerario>(Delete);
            ConsultarItinerarioCommand = new RelayCommand(Consultar);
            Debug.WriteLine("ConsultarCommand inicializado correctamente.");

        }

        private void LoadItinerarios()
        {
            try
            {
                Itinerario = new ObservableCollection<Itinerario>(_dataService.Itinerarios);

                Debug.WriteLine($"Itinerarios cargados correctamente: {Itinerario.Count}");
                foreach (var itinerario in Itinerario)
                {
                    Debug.WriteLine($"Itinerario cargado: {itinerario}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al cargar los itinerarios: {ex.Message}");
                Itinerario = new ObservableCollection<Itinerario>();


            }

            OnPropertyChanged(nameof(Itinerario));
        }


        private void Add(object parameter)
        {
            _dataService.Add(ItinerarioSeleccionado);
            LoadItinerarios();
            Debug.WriteLine($"Itinerario agregado: {ItinerarioSeleccionado}");
        }

        private void Update(object parameter)
        {
            _dataService.Update(ItinerarioSeleccionado);
            LoadItinerarios();
            Debug.WriteLine($"Itinerario actualizado: {ItinerarioSeleccionado}");
        }

        private void Delete(object parameter)
        {
            _dataService.Delete(ItinerarioSeleccionado);
            LoadItinerarios();
            Debug.WriteLine($"Itinerario eliminado: {ItinerarioSeleccionado}");
        }

        private void Consultar()
        {
            if (IsLineSelected())
            {
                Debug.WriteLine($"Consultar - LineaSeleccionada: {ItinerarioSeleccionado}");
                MainWindowViewModel.NumeroLineaSeleccionada = ItinerarioSeleccionado.NumeroLinea;
                MainWindowViewModel.Instance.NavigateToParadasCommand.Execute(null);
            }
            else
            {
                Debug.WriteLine("No se ha seleccionado ninguna línea para consultar.");
            }
        }

       

        private bool IsLineSelected()
        {
            if (ItinerarioSeleccionado == null)
            {
                Debug.WriteLine("LineaSeleccionada es nula.");
                return false;
            }
            else
            {
                Debug.WriteLine($"LineaSeleccionada: {ItinerarioSeleccionado}");
                return true;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
