using NUnit.Framework;
using Project._04_LineasAutobuses.Model;
using Project._04_LineasAutobuses.ViewModel;
using System.Collections.ObjectModel;

namespace Project._04_LineasAutobuses.Tests
{
    [TestFixture]
    public class ViewModelTests
    {
        private InicioViewModel inicioViewModel;
        private LineaViewModel lineaViewModel;
        private ParadasViewModel paradasViewModel;
        private ItinerarioViewModel itinerarioViewModel;
        private MainWindowViewModel mainWindowViewModel;


        [SetUp]
        public void Setup()
        {
            inicioViewModel = new InicioViewModel();
            lineaViewModel = new LineaViewModel();
            paradasViewModel = new ParadasViewModel();
            itinerarioViewModel = new ItinerarioViewModel();
            mainWindowViewModel = new MainWindowViewModel();
        }

        [Test]
        public void CanBuscar_WhenMunicipioOrigenAndDestinoAreNotEmpty_ReturnsTrue()
        {
            // Arrange
            inicioViewModel.MunicipioOrigen = "Origen";
            inicioViewModel.MunicipioDestino = "Destino";

            // Act
            bool canBuscar = inicioViewModel.BuscarCommand.CanExecute(null);

            // Assert
            Assert.That(canBuscar, Is.True);
        }

        [Test]
        public void CanModifyLinea_WhenLineaSeleccionadaIsNotNull_ReturnsTrue()
        {
            // Arrange
            lineaViewModel.LineaSeleccionada = new Linea();

            // Act
            bool canModifyLinea = lineaViewModel.ModificarLineaCommand.CanExecute(null);

            // Assert
            Assert.That(canModifyLinea, Is.True);
        }

        [Test]
        public void CanActualizarParadas_WhenParadasAreNotEmpty_ReturnsTrue()
        {
            // Arrange
            // Simular paradas no vacías en el ViewModel
            paradasViewModel.Paradas = new System.Collections.ObjectModel.ObservableCollection<Parada>();

            // Act
            bool canActualizarParadas = paradasViewModel.ModificarParadaCommand.CanExecute(null);

            // Assert
            Assert.That(canActualizarParadas, Is.True);
        }

        [Test]
        public void CanExecuteCommand_WhenItinerarioIsNotEmpty_ReturnsTrue()
        {
            // Arrange
            var itinerario = new Itinerario
            {
                NumeroLinea = 123, 
                Paradas = new List<Parada>
                {
                    new Parada { NumeroLinea = 123, OrdenParada = 1, Municipio = "Municipio 1", TiempoDesdeOrigen = TimeSpan.FromMinutes(5) },
                    new Parada { NumeroLinea = 123, OrdenParada = 2, Municipio = "Municipio 2", TiempoDesdeOrigen = TimeSpan.FromMinutes(10) }
                },
                TiempoRecorrido = TimeSpan.FromMinutes(30) 
            };

            itinerarioViewModel.Itinerario = new ObservableCollection<Itinerario> { itinerario };

            // Act
            bool canExecuteCommand = itinerarioViewModel.AgregarItinerarioCommand.CanExecute(null);

            // Assert
            Assert.That(canExecuteCommand, Is.True);
        }

        [Test]
        public void Sugerencias_IsNotNull_AfterFiltrarSugerenciasCommand()
        {
            // Arrange
            inicioViewModel.FiltrarSugerencias("O");

            // Act
            var sugerencias = inicioViewModel.Sugerencias;

            // Assert
            Assert.That(sugerencias, Is.Not.Null);
        }

        [Test]
        public void ItinerariosFiltrados_IsNotNull_AfterBuscarCommand()
        {
            // Arrange
            inicioViewModel.MunicipioOrigen = "Origen";
            inicioViewModel.MunicipioDestino = "Destino";

            // Act
            inicioViewModel.Buscar();

            // Assert
            Assert.That(inicioViewModel.ItinerariosFiltrados, Is.Not.Null);
        }

        [Test]
        public void NumeroLineaSeleccionada_IsInitialized_AfterMainWindowViewModelInitialization()
        {
            // Arrange & Act
            long numeroLineaSeleccionada = MainWindowViewModel.NumeroLineaSeleccionada;

            // Assert
            Assert.That(numeroLineaSeleccionada, Is.EqualTo(0));
        }
    }

}

