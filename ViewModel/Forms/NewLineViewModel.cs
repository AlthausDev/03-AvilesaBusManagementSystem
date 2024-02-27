using System;
using System.ComponentModel;
using System.Windows.Input;
using Project._04_LineasAutobuses.Commands;
using Project._04_LineasAutobuses.Features.Linea;
using Project._04_LineasAutobuses.Model;
using Project._04_LineasAutobuses.Utils;

namespace Project._04_LineasAutobuses.ViewModel.Forms
{
    public class NewLineViewModel : INotifyPropertyChanged
    {
        private string _numeroLinea;
        public string NumeroLinea
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
            GuardarLineaCommand = new RelayCommand(GuardarLinea);
            
        }

        private void GuardarLinea()
        {
            try
            {
                var nuevaLinea = new Linea
                {
                    Origen = this.Origen,
                    Destino = this.Destino,
                    HoraSalida = DateTime.Now,
                    HoraLlegada = DateTime.Now.AddHours(1),
                    IntervaloSalida = TimeSpan.FromMinutes(30),
                    Itinerario = new Itinerario()
                };

                var csvDataService = new CsvDataService<Linea>("lineas.csv");
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
            var mainWindow = App.Current.MainWindow as MainWindow;
            mainWindow.MainFrame.Navigate(new LineasView());
        }


        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
