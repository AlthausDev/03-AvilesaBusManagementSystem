using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Project._04_LineasAutobuses.Model;
using Project._04_LineasAutobuses.Utils;

namespace Project._04_LineasAutobuses.Services
{
    public class DataService : INotifyPropertyChanged
    {
        private readonly CsvDataService<Linea> _lineasCsvService;
        private readonly CsvDataService<Itinerario> _itinerariosCsvService;
        private readonly CsvDataService<Parada> _paradasCsvService;

        private ObservableCollection<Parada> _paradas;
        private ObservableCollection<Itinerario> _itinerarios;
        private ObservableCollection<Linea> _lineas;

        public ObservableCollection<Parada> Paradas
        {
            get { return _paradas; }
            set
            {
                _paradas = value;
                OnPropertyChanged(nameof(Paradas));
            }
        }

        public ObservableCollection<Itinerario> Itinerarios
        {
            get { return _itinerarios; }
            set
            {
                _itinerarios = value;
                OnPropertyChanged(nameof(Itinerarios));
            }
        }

        public ObservableCollection<Linea> Lineas
        {
            get { return _lineas; }
            set
            {
                _lineas = value;
                OnPropertyChanged(nameof(Lineas));
            }
        }

        public DataService()
        {
            _paradasCsvService = new CsvDataService<Parada>("Paradas.csv");
            _itinerariosCsvService = new CsvDataService<Itinerario>("Itinerarios.csv");
            _lineasCsvService = new CsvDataService<Linea>("Lineas.csv");

            LoadData();
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

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
