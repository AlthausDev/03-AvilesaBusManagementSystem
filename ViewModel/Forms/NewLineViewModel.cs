using System;
using System.ComponentModel;
using System.Windows.Input;
using AvilesaBusManagementSystem.Commands;
using AvilesaBusManagementSystem.Features.Linea;
using AvilesaBusManagementSystem.Model;
using AvilesaBusManagementSystem.Utils;

namespace AvilesaBusManagementSystem.ViewModel.Forms
{
    public class NewLineViewModel : MainWindowViewModel
    {
        private long _numeroLinea;
        public long NumeroLinea
        {
            get { return _numeroLinea; }
            set
            {
                _numeroLinea = value;
                OnPropertyChanged(nameof(NumeroLinea));
            }
        }


        private string _origen;
        public string Origen
        {
            get { return _origen; }
            set
            {
                _origen = value;
                OnPropertyChanged(nameof(Origen));
            }
        }

        private string _destino;
        public string Destino
        {
            get { return _destino; }
            set
            {
                _destino = value;
                OnPropertyChanged(nameof(Destino));
            }
        }

        private DateTime _horaSalida;
        public DateTime HoraSalida
        {
            get { return _horaSalida; }
            set
            {
                _horaSalida = value;
                OnPropertyChanged(nameof(HoraSalida));
            }
        }

        private DateTime _horaLlegada;

        public event PropertyChangedEventHandler? PropertyChanged;

        public DateTime HoraLlegada
        {
            get { return _horaLlegada; }
            set
            {
                _horaLlegada = value;
                OnPropertyChanged(nameof(HoraLlegada));
            }
        }

        public ICommand GuardarLineaCommand { get; }
        public ICommand CancelarCommand { get; }

        public NewLineViewModel()
        {
            var csvDataService = new CsvDataService<Linea>("Lineas.csv");
            _numeroLinea = csvDataService.GetLastLineaNumber() + 1;

            //GuardarLineaCommand = new RelayCommand(GuardarLinea);
            //CancelarCommand = new RelayCommand(Cancelar);
        }

        private void GuardarLinea()
        {
            try
            {
                var nuevaLinea = new Linea
                {
                    //NumeroLinea = this.NumeroLinea,
                    //Origen = this.Origen,
                    //Destino = this.Destino,
                    //HoraSalida = DateTime.Now,
                    //HoraLlegada = DateTime.Now.AddHours(1),
                    //IntervaloSalida = TimeSpan.FromMinutes(30),
                    //Itinerario = new Itinerario()
                };

                var csvDataService = new CsvDataService<Linea>("Lineas.csv");
                var lineas = csvDataService.ReadFromCsv();
                lineas.Add(nuevaLinea);
                csvDataService.WriteToCsv(lineas);
                Cancelar();
            }
            catch (Exception ex)
            {

            }
        }
        private void Cancelar()
        {
            if (NavigateToLineasCommand != null && NavigateToLineasCommand.CanExecute(null))
            {
                Origen = string.Empty;
                Destino = string.Empty;
                NavigateToLineasCommand.Execute(null);
            }
        }


        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
