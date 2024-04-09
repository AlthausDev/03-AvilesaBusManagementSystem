using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using AvilesaBusManagementSystem.Commands;
using AvilesaBusManagementSystem.Model;
using AvilesaBusManagementSystem.Utils;

namespace AvilesaBusManagementSystem.Services
{
    public class DataService : INotifyPropertyChanged
    {
        private readonly CsvDataService<Linea> _lineasCsvService;
        private readonly CsvDataService<Itinerario> _itinerariosCsvService;
        private readonly CsvDataService<Parada> _paradasCsvService;

        public ObservableCollection<Parada> Paradas { get; private set; }
        public ObservableCollection<Itinerario> Itinerarios { get; private set; }
        public ObservableCollection<Linea> Lineas { get; private set; }

        public ICommand AgregarCommand { get; private set; }
        public ICommand UpdateCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }

        public DataService()
        {
            _paradasCsvService = new CsvDataService<Parada>("Paradas.csv");
            _itinerariosCsvService = new CsvDataService<Itinerario>("Itinerarios.csv");
            _lineasCsvService = new CsvDataService<Linea>("Lineas.csv");

            LoadData();
            InitializeCommands();
        }

        private void LoadData()
        {
            Paradas = new ObservableCollection<Parada>(_paradasCsvService.ReadFromCsv());
            Itinerarios = new ObservableCollection<Itinerario>(_itinerariosCsvService.ReadFromCsv());
            Lineas = new ObservableCollection<Linea>(_lineasCsvService.ReadFromCsv());

            foreach (var itinerario in Itinerarios)
            {
                itinerario.Paradas = new ObservableCollection<Parada>(Paradas.Where(p => p.NumeroLinea == itinerario.NumeroLinea));
            }

            foreach (var linea in Lineas)
            {
                var paradasDeLinea = Paradas.Where(p => p.NumeroLinea == linea.NumeroLinea).ToList();

                if (paradasDeLinea.Any())
                {
                    paradasDeLinea = paradasDeLinea.OrderBy(p => p.OrdenParada).ToList();
                    linea.Origen = paradasDeLinea.First();
                    linea.Destino = paradasDeLinea.Last();
                }
            }

            OnPropertyChanged(nameof(Paradas));
            OnPropertyChanged(nameof(Itinerarios));
            OnPropertyChanged(nameof(Lineas));
        }

        private void InitializeCommands()
        {
            AgregarCommand = new RelayCommandWithParameter<object>(Add);
            UpdateCommand = new RelayCommandWithParameter<object>(Update);
            DeleteCommand = new RelayCommandWithParameter<object>(Delete);
        }

        public void Add(object parameter)
        {
            if (parameter is Parada parada)
            {
                Paradas.Add(parada);
                SaveToCsv(Paradas);
            }
            else if (parameter is Itinerario itinerario)
            {
                Itinerarios.Add(itinerario);
                SaveToCsv(Itinerarios);
            }
            else if (parameter is Linea linea)
            {
                Lineas.Add(linea);
                SaveToCsv(Lineas);
            }
        }


        public void Update(object parameter)
        {
            if (parameter is Parada parada)
            {
                var existingParada = Paradas.FirstOrDefault(p => p.NumeroLinea == parada.NumeroLinea);
                if (existingParada != null)
                {
                    existingParada = parada;
                    SaveToCsv(Paradas);
                }
            }
            else if (parameter is Itinerario itinerario)
            {
                var existingItinerario = Itinerarios.FirstOrDefault(i => i.NumeroLinea == itinerario.NumeroLinea);
                if (existingItinerario != null)
                {
                    existingItinerario = itinerario; 
                    SaveToCsv(Itinerarios);
                }
            }
            else if (parameter is Linea linea)
            {
                var existingLinea = Lineas.FirstOrDefault(l => l.NumeroLinea == linea.NumeroLinea);
                if (existingLinea != null)
                {
                    existingLinea = linea;
                    SaveToCsv(Lineas);
                }
            }
        }

        public void Delete(object parameter)
        {
            if (parameter is Parada parada)
            {
                Paradas.Remove(parada);
                SaveToCsv(Paradas);
            }
            else if (parameter is Itinerario itinerario)
            {
                Itinerarios.Remove(itinerario);
                SaveToCsv(Itinerarios);
            }
            else if (parameter is Linea linea)
            {
                Lineas.Remove(linea);
                SaveToCsv(Lineas);
            }
        }


        private void SaveToCsv<T>(ObservableCollection<T> collection)
        {
            if (typeof(T) == typeof(Parada))
            {
                var paradasCollection = collection as ObservableCollection<Parada>;
                if (paradasCollection != null)
                {
                    _paradasCsvService.WriteToCsv(paradasCollection);
                }
            }
            else if (typeof(T) == typeof(Itinerario))
            {
                var itinerariosCollection = collection as ObservableCollection<Itinerario>;
                if (itinerariosCollection != null)
                {
                    _itinerariosCsvService.WriteToCsv(itinerariosCollection);
                }
            }
            else if (typeof(T) == typeof(Linea))
            {
                var lineasCollection = collection as ObservableCollection<Linea>;
                if (lineasCollection != null)
                {
                    _lineasCsvService.WriteToCsv(lineasCollection);
                }
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
