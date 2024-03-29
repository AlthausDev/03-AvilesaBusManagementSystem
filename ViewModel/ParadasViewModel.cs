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
    public class ParadasViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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

        public ICommand ModificarParadaCommand { get; }
        public ICommand EliminarParadaCommand { get; }
        public ICommand AgregarParadaCommand { get; }
        public ICommand VolverCommand { get; }


        public ParadasViewModel()
        {
            Paradas = LoadParadas();

            ModificarParadaCommand = new RelayCommand(ModificarParada);
            EliminarParadaCommand = new RelayCommand(EliminarParada);
            AgregarParadaCommand = new RelayCommand(AgregarParada);
            VolverCommand = new RelayCommand(Volver);
        }

        private void AgregarParada()
        {
            throw new NotImplementedException();
        }

        private void EliminarParada()
        {
            throw new NotImplementedException();
        }

        private void ModificarParada()
        {
            throw new NotImplementedException();
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

        private void CargarParadas()
        {
            try
            {
                var paradasCsv = new CsvDataService<Parada>("Paradas.csv");
                var todasLasParadas = paradasCsv.ReadFromCsv();

                Paradas = NumeroLineaSeleccionada.HasValue ?
                    new ObservableCollection<Parada>(todasLasParadas.Where(p => p.NumeroLinea == NumeroLineaSeleccionada.Value)) :
                    new ObservableCollection<Parada>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al cargar las paradas: {ex.Message}");
                Paradas = new ObservableCollection<Parada>();
            }
        }

        private void Volver()
        {
            MainWindowViewModel.Instance.NavigateToLineasCommand.Execute(null);
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
