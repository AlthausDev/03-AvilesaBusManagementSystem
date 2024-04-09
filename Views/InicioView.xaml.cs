using AvilesaBusManagementSystem.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace AvilesaBusManagementSystem.Views
{
    public partial class InicioView : Page
    {
        private readonly InicioViewModel viewModel;

        public InicioView()
        {
            InitializeComponent();
            viewModel = new InicioViewModel();
            DataContext = viewModel;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.SelectedItem == null)
            {
                string texto = comboBox.Text;             
            }
        }
    }
}
