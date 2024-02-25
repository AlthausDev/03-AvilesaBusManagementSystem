using Project._04_LineasAutobuses.Commands;
using Project._04_LineasAutobuses.Features.Itinerario;
using Project._04_LineasAutobuses.Features.Linea;
using Project._04_LineasAutobuses.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Project._04_LineasAutobuses.ViewModel
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public ICommand NavigateToLineasCommand { get; }
        public ICommand NavigateToItinerarioCommand { get; }
        public ICommand NavigateToInicioCommand { get; }
        public ICommand NavigateToAboutCommand { get; }

        public MainWindowViewModel()
        {
            NavigateToInicioCommand = new RelayCommand(NavigateToInicio);
            NavigateToLineasCommand = new RelayCommand(NavigateToLineas);
            NavigateToItinerarioCommand = new RelayCommand(NavigateToItinerario);
            NavigateToAboutCommand = new RelayCommand(NavigateToAbout);
        }

        private void NavigateToLineas()
        {
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.MainFrame.Navigate(new LineasView());
            }
        }

        private void NavigateToItinerario()
        {
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.MainFrame.Navigate(new ItinerarioView());
            }
        }


        private void NavigateToInicio()
        {
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.MainFrame.Navigate(new InicioView());
            }
        }


        private void NavigateToAbout()
        {
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.MainFrame.Navigate(new AboutView());
            }
        }


    }
}
