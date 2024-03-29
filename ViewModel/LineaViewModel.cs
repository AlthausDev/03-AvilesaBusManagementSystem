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
using Project._04_LineasAutobuses.Services;

namespace Project._04_LineasAutobuses.ViewModel
{
    public class LineaViewModel : INotifyPropertyChanged
    {

        private readonly DataService _dataService;


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
            _dataService = MainWindowViewModel.DataService;
            Lineas = _dataService.Lineas;

            ModificarLineaCommand = new RelayCommand(ModificarLinea, CanModifyLinea);
            EliminarLineaCommand = new RelayCommand(EliminarLinea, IsLineSelected);
            ConsultarLineasCommand = new RelayCommand(ConsultarLineas, IsLineSelected);
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
            if (IsLineSelected())
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


        private void ConsultarLineas()
        {
            if (IsLineSelected())
            {
                Debug.WriteLine($"ConsultarLineas - LineaSeleccionada: {LineaSeleccionada}");
                MainWindowViewModel.NumeroLineaSeleccionada = LineaSeleccionada.NumeroLinea;
                MainWindowViewModel.Instance.NavigateToParadasCommand.Execute(null);
            }
        }


        private bool IsLineSelected()
        {
            return LineaSeleccionada != null;
        }



        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
