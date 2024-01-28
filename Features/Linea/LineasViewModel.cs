using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Project._04_LineasAutobuses.Model;
using System;
using Project._04_LineasAutobuses.Utils;

namespace Project._04_LineasAutobuses.Features.Linea
{
    public class LineaViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Model.Linea> Lineas { get; set; }
        public Model.Linea LineaSeleccionada { get; set; }

        public ICommand AgregarLineaCommand { get; set; }
        public ICommand ModificarLineaCommand { get; set; }
        public ICommand EliminarLineaCommand { get; set; }
        public ICommand ConsultarLineasCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public LineaViewModel()
        {         
            Lineas = new ObservableCollection<Model.Linea>();

            AgregarLineaCommand = new RelayCommand(AgregarLinea);
            ModificarLineaCommand = new RelayCommand(ModificarLinea);
            EliminarLineaCommand = new RelayCommand(EliminarLinea);
            ConsultarLineasCommand = new RelayCommand(ConsultarLineas);
        }

        
        private void AgregarLinea()
        {
           
            Lineas.Add(new Model.Linea());
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
