using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Project._04_LineasAutobuses.Model;
using System;
using Project._04_LineasAutobuses.Utils;
using Project._04_LineasAutobuses.Commands;
using System.Collections.Generic;

namespace Project._04_LineasAutobuses.ViewModel
{
    public class LineaViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Linea> Lineas { get; set; }
        public Linea LineaSeleccionada { get; set; }

        public ICommand AgregarLineaCommand { get; set; }
        public ICommand ModificarLineaCommand { get; set; }
        public ICommand EliminarLineaCommand { get; set; }
        public ICommand ConsultarLineasCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public LineaViewModel()
        {
            Lineas = LoadLineas();

            AgregarLineaCommand = new RelayCommand(AgregarLinea);
            ModificarLineaCommand = new RelayCommand(ModificarLinea);
            EliminarLineaCommand = new RelayCommand(EliminarLinea);
            ConsultarLineasCommand = new RelayCommand(ConsultarLineas);
        }

        private static ObservableCollection<Linea> LoadLineas()
        {
            new ObservableCollection<Linea>();

            var lineasCsv = new CsvDataService<Linea>("lineas.csv");
            var lineas = lineasCsv.ReadFromCsv();
            return lineas;
        }


        private void AgregarLinea()
        {

            Lineas.Add(new Linea());
        }


        private void ModificarLinea()
        {

            if (LineaSeleccionada != null)
            {

            }
        }

        private void EliminarLinea()
        {

            if (LineaSeleccionada != null)
            {
                Lineas.Remove(LineaSeleccionada);
            }
        }

        private void ConsultarLineas()
        {

        }
    }
}
