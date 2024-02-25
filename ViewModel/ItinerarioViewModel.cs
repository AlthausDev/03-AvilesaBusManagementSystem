using Project._04_LineasAutobuses.Commands;
using Project._04_LineasAutobuses.Model;
using Project._04_LineasAutobuses.Utils;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Project._04_LineasAutobuses.ViewModel
{
    public class ItinerarioViewModel
    {
        public ObservableCollection<Itinerario> Itinerarios { get; set; }

        public ICommand AgregarItinerarioCommand { get; set; }
        public ICommand ModificarItinerarioCommand { get; set; }
        public ICommand EliminarItinerarioCommand { get; set; }
        public ICommand ConsultarItinerariosCommand { get; set; }


        public ItinerarioViewModel()
        {          
            Itinerarios = new ObservableCollection<Itinerario>();      
            LoadItinerarios();

            AgregarItinerarioCommand = new RelayCommand(AgregarItinerario);
            ModificarItinerarioCommand = new RelayCommand(ModificarItinerario);
            EliminarItinerarioCommand = new RelayCommand(EliminarItinerario);
            ConsultarItinerariosCommand = new RelayCommand(ConsultarItinerarios);
        }


        private void LoadItinerarios()
        {
            // Crear una instancia del servicio CSV para los itinerarios
            var itinerariosCsv = new CsvDataService<Itinerario>("itinerarios.csv");

            // Leer itinerarios desde el archivo CSV y agregarlos a la colección
            var itinerarios = itinerariosCsv.ReadFromCsv();
            foreach (var itinerario in itinerarios)
            {
                Itinerarios.Add(itinerario);
            }
        }

        private void AgregarItinerario()
        {
            // Pendiente
        }

        private void ModificarItinerario()
        {
            // Pendiente
        }

        private void EliminarItinerario()
        {
            // Pendiente
        }

            private void ConsultarItinerarios()
        {
            // Pendiente
        }
    }
}