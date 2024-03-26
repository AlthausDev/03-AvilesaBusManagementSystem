using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Project._04_LineasAutobuses.Model;
using Project._04_LineasAutobuses.Utils;
using System;
using Project._04_LineasAutobuses.Commands;
using Project._04_LineasAutobuses.Views;
using Project._04_LineasAutobuses.Views.Forms;
using System.Windows;
using System.Windows.Shapes;
using System.Diagnostics;

namespace Project._04_LineasAutobuses.ViewModel
{
    public class LineaViewModel : INotifyPropertyChanged
    {
        private static LineaViewModel _instance;

        public static LineaViewModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LineaViewModel();
                }
                return _instance;
            }
        }

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
                
        public ICommand ModificarLineaCommand { get; }
        public ICommand EliminarLineaCommand { get; }
        public ICommand ConsultarLineasCommand { get; }
        public ICommand NavigateToNewLineFormCommand => MainWindowViewModel.Instance.NavigateToNewLineFormCommand;


        public event PropertyChangedEventHandler PropertyChanged;

        public LineaViewModel()
        {
            Lineas = LoadLineas();
          
            ModificarLineaCommand = new RelayCommand(ModificarLinea, CanModifyLinea);
            EliminarLineaCommand = new RelayCommand(EliminarLinea, CanDeleteLinea);
            ConsultarLineasCommand = new RelayCommand(ConsultarLineas);

        }

        internal ObservableCollection<Linea> LoadLineas()
        {
            try
            {
                var lineasCsv = new CsvDataService<Linea>("Lineas.csv");
                return lineasCsv.ReadFromCsv();               
            }

            catch (Exception ex)
            {
                Debug.WriteLine($"Error al cargar las líneas: {ex.Message}");
                return new ObservableCollection<Linea>();
            }
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

                try
                {
                    var csvDataService = new CsvDataService<Linea>("Lineas.csv");
                    csvDataService.WriteToCsv(Lineas);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error al escribir en el archivo CSV: {ex.Message}");
                }
            }
        }



        private bool CanDeleteLinea()
        {
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
