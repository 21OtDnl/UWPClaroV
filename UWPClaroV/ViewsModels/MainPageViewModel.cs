using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPClaroV.Services.Interfaces;
using UWPClaroV.Views;
using UWPClaroV.ViewsModels.Comandos;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Imaging;
using System.Windows.Input;

namespace UWPClaroV.ViewsModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private readonly IServiceNavegacion _serviceNavegacion;
        private readonly IServiceContenido _serviceContenido;
        private ObservableCollection<string> _menuItems;
        private ObservableCollection<ImagenComando> _imagenesCarrusel;
        private ObservableCollection<ImagenComando> _imagenesCarruselPremium;
        private ObservableCollection<ImagenComando> _imagenesCarruselRecomendacion;
        public ICommand NavigateToVCardViewCommand { get; }

        public ObservableCollection<string> MenuItems
        {
            get => _menuItems;
            set
            {
                _menuItems = value;
                OnPropertyChanged(nameof(MenuItems));
            }
        }

        public ObservableCollection<ImagenComando> ImagenesCarrusel
        {
            get => _imagenesCarrusel;
            set
            {
                _imagenesCarrusel = value;
                OnPropertyChanged(nameof(ImagenesCarrusel));
            }
        }

        public ObservableCollection<ImagenComando> ImagenesCarruselPremiun
        {
            get => _imagenesCarruselPremium;
            set
            {
                _imagenesCarruselPremium = value;
                OnPropertyChanged(nameof(ImagenesCarruselPremiun));
            }
        }

        public ObservableCollection<ImagenComando> ImagenesCarruselRecomendacion
        {
            get => _imagenesCarruselRecomendacion;
            set
            {
                _imagenesCarruselRecomendacion = value;
                OnPropertyChanged(nameof(ImagenesCarruselRecomendacion));
            }
        }

        public MainPageViewModel(IServiceNavegacion serviceNavegacion, IServiceContenido serviceContenido)
        {
            _serviceNavegacion = serviceNavegacion;
            NavigateToVCardViewCommand = new RelayCommand(NavigateToVCardPage);
            _serviceContenido = serviceContenido;
            MenuItems = new ObservableCollection<string>
            {
                "Inicio",
                "Claro Sports",
                "Películas",
                "Series",
                "Kids",
                "Compra y Renta"
            };
            CargarCarruselAsync();
            CargarCarruselPremiumAsync();
            CargarCarruselRecomendacionAsync();
        }

        private void NavigateToVCardPage(object imagen)
        {
            // Puedes usar el parámetro 'imagen' según sea necesario
            _serviceNavegacion.NavigateTo<VCard>();
        }

        private async void CargarCarruselAsync()
        {
            try
            {
                var imagenes = await _serviceContenido.GetContenidosCarruselAsync();
                ImagenesCarrusel = new ObservableCollection<ImagenComando>(
                imagenes.Select(imagen => new ImagenComando(imagen, new RelayCommand(ImagenClick))));
            }
            catch (Exception ex)
            {
                ImagenesCarrusel = new ObservableCollection<ImagenComando>
                {
                    new ImagenComando(new BitmapImage(new Uri("ms-appx:///imagenes/image-not-found.png")), null)
                };
            }
        }

        private async void CargarCarruselPremiumAsync()
        {
            try
            {
                var imagenes = await _serviceContenido.GetContenidosCarruselPremiumAsync();
                ImagenesCarruselPremiun = new ObservableCollection<ImagenComando>(
                imagenes.Select(imagen => new ImagenComando(imagen, new RelayCommand(ImagenClick))));
            }
            catch (Exception ex)
            {
                ImagenesCarruselPremiun = new ObservableCollection<ImagenComando>
                {
                    new ImagenComando(new BitmapImage(new Uri("ms-appx:///imagenes/image-not-found.png")), null)
                };
            }
        }

        private async void CargarCarruselRecomendacionAsync()
        {
            try
            {
                var imagenes = await _serviceContenido.GetContenidosCarruselRecomendacionAsync();
                ImagenesCarruselRecomendacion = new ObservableCollection<ImagenComando>(
                imagenes.Select(imagen => new ImagenComando(imagen, new RelayCommand(ImagenClick))));
            }
            catch (Exception ex)
            {
                ImagenesCarruselRecomendacion = new ObservableCollection<ImagenComando>
                {
                    new ImagenComando(new BitmapImage(new Uri("ms-appx:///imagenes/image-not-found.png")), null)
                };
            }
        }

        private void ImagenClick(object parameter)
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
