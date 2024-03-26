using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Windows.Input;
using CsvHelper;
using Project._04_LineasAutobuses.Commands;
using Project._04_LineasAutobuses.Model;
using Project._04_LineasAutobuses.Utils;

namespace Project._04_LineasAutobuses.ViewModel
{
    public class NewLineViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly CsvDataService<Linea> _lineaCsvDataService;
        private readonly TimePickerViewModel _timePickerViewModel;

        public ObservableCollection<string> Municipios { get; }

        private Linea _nuevaLinea;
        public Linea NuevaLinea
        {
            get { return _nuevaLinea; }
            set
            {
                _nuevaLinea = value;
                OnPropertyChanged(nameof(NuevaLinea));
            }
        }

        public ICommand GuardarLineaCommand { get; }
        public ICommand CancelarCommand { get; }

        public NewLineViewModel(CsvDataService<Linea> lineaCsvDataService)
        {
            _lineaCsvDataService = lineaCsvDataService;
            _timePickerViewModel = new TimePickerViewModel();
            GuardarLineaCommand = new RelayCommand(GuardarLinea, CanGuardarLinea);
            CancelarCommand = new RelayCommand(Cancelar);

            Municipios = new ObservableCollection<string>();
            LoadMunicipios();

            // Calcular automáticamente el número de línea
            var lineas = _lineaCsvDataService.ReadFromCsv();
            long ultimoNumeroLinea = 0;
            if (lineas.Any())
            {
                // Obtener el último registro y aumentar el número de línea en 1
                ultimoNumeroLinea = lineas.Max(l => l.NumeroLinea);
            }
            NuevaLinea = new Linea { NumeroLinea = ultimoNumeroLinea + 1 };
        }


        private void LoadMunicipios()
        {
            try
            {
                string csvFilePath = "Municipios.csv";

                using (var reader = new StreamReader(csvFilePath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<String>();
                    foreach (var NOMBRE in records)
                    {
                        Municipios.Add(NOMBRE);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al cargar los municipios desde el archivo CSV: {ex.Message}");
            }
        }


        private bool CanGuardarLinea()
        {
            return !string.IsNullOrWhiteSpace(NuevaLinea.Origen) &&
                   !string.IsNullOrWhiteSpace(NuevaLinea.Destino) &&
                   NuevaLinea.HoraSalida < NuevaLinea.HoraLlegada;
        }

        private void GuardarLinea()
        {
            try
            {
                long numeroLinea = NuevaLinea.NumeroLinea;
                string origen = NuevaLinea.Origen;
                string destino = NuevaLinea.Destino;

                int horaSeleccionada = _timePickerViewModel.SelectedHour;
                int minutoSeleccionado = _timePickerViewModel.SelectedMinute;

                DateTime horaSalida = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, horaSeleccionada, minutoSeleccionado, 0);
                DateTime horaLlegada = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, horaSeleccionada, minutoSeleccionado, 0);
                TimeSpan intervaloSalida = NuevaLinea.IntervaloSalida;

                Linea nuevaLinea = new Linea(numeroLinea, origen, destino, horaSalida, horaLlegada, intervaloSalida);

                var csvDataService = new CsvDataService<Linea>("Lineas.csv");
                var lineas = csvDataService.ReadFromCsv();

                lineas.Add(nuevaLinea);
                csvDataService.WriteToCsv(lineas);

                Debug.WriteLine("Nueva línea guardada exitosamente en Lineas.csv.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al guardar la línea en Lineas.csv: {ex.Message}");
            }
        }

        private void Cancelar()
        {
            NuevaLinea = new Linea();
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
