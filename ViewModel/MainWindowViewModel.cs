using AvilesaBusManagementSystem.Commands;
using AvilesaBusManagementSystem.Features.Itinerario;
using AvilesaBusManagementSystem.Features.Linea;
using AvilesaBusManagementSystem.Services;
using AvilesaBusManagementSystem.ViewModel.Forms;
using AvilesaBusManagementSystem.Views;
using AvilesaBusManagementSystem.Views.Forms;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AvilesaBusManagementSystem.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private static readonly Lazy<MainWindowViewModel> instance = new Lazy<MainWindowViewModel>(() => new MainWindowViewModel());

        private static readonly DataService _dataService = new();
        public static DataService DataService = _dataService;

        private readonly ItinerarioViewModel _itinerarioViewModel = new ItinerarioViewModel();
        private readonly ParadasViewModel _paradasViewModel = new ParadasViewModel();
        private readonly LineaViewModel _lineaViewModel;
        private readonly InicioViewModel _inicioViewModel = new InicioViewModel();

        public static long NumeroLineaSeleccionada { get; set; }      
        public static MainWindowViewModel Instance => instance.Value;

        public ICommand NavigateToLineasCommand =>
             new RelayCommand(() => NavigateToLineas());

        public ICommand NavigateToItinerarioCommand =>
            new RelayCommand(() => NavigateTo(new ItinerarioView(_itinerarioViewModel)));

        public ICommand NavigateToParadasCommand =>
            new RelayCommand(() => NavigateTo(new ParadasView(_paradasViewModel, NumeroLineaSeleccionada)));

        public ICommand NavigateToInicioCommand =>
            new RelayCommand(() => NavigateTo(new InicioView()));

        public ICommand NavigateToAboutCommand =>
            new RelayCommand(() => NavigateTo(new AboutView()));

        public ICommand NavigateToNewLineFormCommand =>
            new RelayCommand(() => NavigateTo(new NewLineForm()));
     
        private void NavigateToLineas()
        {
            var lineaViewModel = new LineaViewModel();
            NavigateTo(new LineasView(lineaViewModel));
        }

        private void NavigateTo(Page page)
        {
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.MainFrame.Navigate(page);
            }
        }
    }
}
