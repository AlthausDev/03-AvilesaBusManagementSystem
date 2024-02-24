using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Project._04_LineasAutobuses.Model;
using Project._04_LineasAutobuses.Utils;
using System;
using Project._04_LineasAutobuses.Commands;

namespace Project._04_LineasAutobuses.ViewModel
{
    public class LineaViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Linea> _lineas;
        public ObservableCollection<Linea> Lineas
        {
            get { return _lineas; }
            set
            {
                _lineas = value;
                OnPropertyChanged(nameof(Lineas));
            }
        }

        private Linea _lineaSeleccionada;
        public Linea LineaSeleccionada
        {
            get { return _lineaSeleccionada; }
            set
            {
                _lineaSeleccionada = value;
                OnPropertyChanged(nameof(LineaSeleccionada));
            }
        }

        public ICommand AgregarLineaCommand { get; }
        public ICommand ModificarLineaCommand { get; }
        public ICommand EliminarLineaCommand { get; }
        public ICommand ConsultarLineasCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public LineaViewModel()
        {
            Lineas = LoadLineas();

            AgregarLineaCommand = new RelayCommand(AgregarLinea);
            ModificarLineaCommand = new RelayCommand(ModificarLinea, CanModifyLinea);
            EliminarLineaCommand = new RelayCommand(EliminarLinea, CanDeleteLinea);
            ConsultarLineasCommand = new RelayCommand(ConsultarLineas);
        }

        private ObservableCollection<Linea> LoadLineas()
        {
            var lineasCsv = new CsvDataService<Linea>("lineas.csv");
            return lineasCsv.ReadFromCsv();
        }

        private void AgregarLinea()
        {
            Lineas.Add(new Linea());
        }

        private void ModificarLinea()
        {
            // Pendiente
        }

        private bool CanModifyLinea()
        {
            //Pendiente
            return LineaSeleccionada != null;
        }

        private void EliminarLinea()
        {
            if (LineaSeleccionada != null)
            {
                Lineas.Remove(LineaSeleccionada);
            }
        }

        private bool CanDeleteLinea()
        {
            // Pendiente
            return LineaSeleccionada != null;
        }

        private void ConsultarLineas()
        {
            // Pendiente
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
