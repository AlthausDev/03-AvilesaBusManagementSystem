using Project._04_LineasAutobuses.Commands;
using Project._04_LineasAutobuses.Features.Itinerario;
using Project._04_LineasAutobuses.Features.Linea;
using Project._04_LineasAutobuses.ViewModel.Forms;
using Project._04_LineasAutobuses.Views;
using Project._04_LineasAutobuses.Views.Forms;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Project._04_LineasAutobuses.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly LineaViewModel _lineaViewModel = new LineaViewModel();
        private readonly ItinerarioViewModel _itinerarioViewModel = new ItinerarioViewModel();

        public event PropertyChangedEventHandler? PropertyChanged;



        public ICommand NavigateToLineasCommand =>
            new RelayCommand(() => NavigateTo(new LineasView(_lineaViewModel)));

        public ICommand NavigateToItinerarioCommand =>
            new RelayCommand(() => NavigateTo(new ItinerarioView(_itinerarioViewModel)));

        public ICommand NavigateToInicioCommand =>
            new RelayCommand(() => NavigateTo(new InicioView()));

        public ICommand NavigateToAboutCommand =>
            new RelayCommand(() => NavigateTo(new AboutView()));

        public ICommand NavigateToNewLineFormCommand =>
            new RelayCommand(() => NavigateTo(new NewLineForm()));



        private void NavigateTo(Page page)
        {
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {            
                mainWindow.MainFrame.Navigate(page);

            }
        }

    }
}
