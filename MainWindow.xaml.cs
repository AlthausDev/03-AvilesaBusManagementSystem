using Project._04_LineasAutobuses.Features.Linea;
using Project._04_LineasAutobuses.Model;
using Project._04_LineasAutobuses.Utils;
using Project._04_LineasAutobuses.ViewModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project._04_LineasAutobuses
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeMainWindow();
        }

        private void InitializeMainWindow()
        {
            try
            {
                // Establecer el DataContext de la ventana
                DataContext = new MainWindowViewModel();

                // Navegar a la página predeterminada
                MainFrame.Navigate(new LineasView());
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que ocurra durante la inicialización
                MessageBox.Show($"Error al inicializar la ventana principal: {ex.Message}",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Close(); // Cerrar la ventana en caso de error grave
            }
        }
    }
}