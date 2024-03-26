using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
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
            NuevaLinea = new Linea();
            GuardarLineaCommand = new RelayCommand(GuardarLinea, CanGuardarLinea);
            CancelarCommand = new RelayCommand(Cancelar);
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
                // Obtener los valores del formulario
                long numeroLinea = NuevaLinea.NumeroLinea;
                string origen = NuevaLinea.Origen;
                string destino = NuevaLinea.Destino;

                int horaSeleccionada = _timePickerViewModel.SelectedHour;
                int minutoSeleccionado = _timePickerViewModel.SelectedMinute;

                DateTime horaSalida = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, horaSeleccionada, minutoSeleccionado, 0);
                DateTime horaLlegada = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, horaSeleccionada, minutoSeleccionado, 0);

                //Linea nuevaLinea = new Linea(numeroLinea, origen, destino, horaSalida, horaLlegada);

                var csvDataService = new CsvDataService<Linea>("Lineas.csv");
                var lineas = csvDataService.ReadFromCsv();

                //lineas.Add(nuevaLinea);
                csvDataService.WriteToCsv(lineas);

                NuevaLinea = new Linea();
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
