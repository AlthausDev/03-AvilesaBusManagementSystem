using Project._04_LineasAutobuses.Commands;
using Project._04_LineasAutobuses.Model;
using Project._04_LineasAutobuses.Utils;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;

namespace Project._04_LineasAutobuses.ViewModel
{
    public class ItinerarioViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Itinerario> _itinerarios;
        public ObservableCollection<Itinerario> Itinerarios
        {
            get { return _itinerarios; }
            set
            {
                _itinerarios = value;
                OnPropertyChanged(nameof(Itinerarios));
            }
        }

        private ObservableCollection<Parada> _paradas;
        public ObservableCollection<Parada> Paradas
        {
            get { return _paradas; }
            set
            {
                _paradas = value;
                OnPropertyChanged(nameof(Paradas));
            }
        }

        public ICommand ConsultarParadasCommand { get; set; }

        private long? _numeroLineaSeleccionada;

        public long? NumeroLineaSeleccionada
        {
            get { return _numeroLineaSeleccionada; }
            set
            {
                _numeroLineaSeleccionada = value;
                OnPropertyChanged(nameof(NumeroLineaSeleccionada));
                CargarParadas();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ItinerarioViewModel()
        {
            Paradas = LoadParadas();

            //AgregarItinerarioCommand = new RelayCommand(AgregarItinerario);
            //ModificarItinerarioCommand = new RelayCommand(ModificarItinerario);
            //EliminarItinerarioCommand = new RelayCommand(EliminarItinerario);
            //ConsultarItinerariosCommand = new RelayCommand(ConsultarItinerarios);

        }

        private ObservableCollection<Parada> LoadParadas()
        {
            try
            {
                var paradasCsv = new CsvDataService<Parada>("Paradas.csv");
                return new ObservableCollection<Parada>(paradasCsv.ReadFromCsv());
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al cargar las paradas: {ex.Message}");
                return new ObservableCollection<Parada>();
            }
        }


        private ObservableCollection<Itinerario> LoadItinerarios()
        {
            try
            {
                var paradasCsv = new CsvDataService<Parada>("Paradas.csv");
                var paradas = paradasCsv.ReadFromCsv();
                var paradasPorLinea = paradas.GroupBy(p => p.NumeroLinea);

                var itinerarios = new List<Itinerario>();
                foreach (var grupoParadas in paradasPorLinea)
                {
                    var numeroLinea = grupoParadas.Key;
                    var paradasDeLinea = grupoParadas.ToList();
                    var intervaloDesdeSalida = paradasDeLinea.First().HoraLlegada.TimeOfDay;

                    var itinerario = new Itinerario
                    {
                        NumeroLinea = numeroLinea,
                        Paradas = paradasDeLinea,
                        IntervaloDesdeSalida = intervaloDesdeSalida
                    };

                    itinerarios.Add(itinerario);
                }

                return new ObservableCollection<Itinerario>(itinerarios);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al cargar los itinerarios: {ex.Message}");
                return new ObservableCollection<Itinerario>();
            }
        }


        private void CargarParadas()
        {
            try
            {
                var paradasCsv = new CsvDataService<Parada>("Paradas.csv");
                var todasLasParadas = paradasCsv.ReadFromCsv();

                Paradas = NumeroLineaSeleccionada.HasValue ?
                    new ObservableCollection<Parada>(todasLasParadas.Where(p => p.NumeroLinea == NumeroLineaSeleccionada.Value)) :
                    todasLasParadas;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al cargar las paradas: {ex.Message}");
                Paradas = new ObservableCollection<Parada>();
            }
        }

        private void ConsultarParadas()
        {
            CargarParadas();
        }

        private void AgregarItinerario()
        {
            // Implementar lógica para agregar un itinerario
        }

        private void ModificarItinerario()
        {
            // Implementar lógica para modificar un itinerario
        }

        private void EliminarItinerario()
        {
            // Implementar lógica para eliminar un itinerario
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }   

}
