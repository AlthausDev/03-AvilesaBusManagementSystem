using Project._04_LineasAutobuses.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project._04_LineasAutobuses.Views
{
    /// <summary>
    /// Lógica de interacción para ParadasView.xaml
    /// </summary>
    public partial class ParadasView : Page
    {
        public ParadasView(ParadasViewModel viewModel, long NumeroLinea)
        {
            InitializeComponent();
            DataContext = viewModel;
            viewModel.NumeroLineaSeleccionada = NumeroLinea;
        }
    }
}
