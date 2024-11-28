using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWPClaroV.Views;
using UWPClaroV.ViewsModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPClaroV
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly MainPageViewModel _viewModel;

        public MainPage(MainPageViewModel viewModel)
        {
            this.InitializeComponent();
            _viewModel = viewModel;
            this.DataContext = _viewModel;
        }

        private void ButtonNextCarruselPremium_Click(object sender, RoutedEventArgs e)
        {
            ContenedorCarruselPremium.ChangeView(ContenedorCarruselPremium.HorizontalOffset - 550, null, null);
        }

        private void ButtonBackCarruselPremium_Click(object sender, RoutedEventArgs e)
        {
            ContenedorCarruselPremium.ChangeView(ContenedorCarruselPremium.HorizontalOffset + 550, null, null);
        }

        private void ButtonNextCarruselRecomendacion_Click(object sender, RoutedEventArgs e)
        {
            ContenedorCarruselRecomendacion.ChangeView(ContenedorCarruselRecomendacion.HorizontalOffset - 400, null, null);
        }

        private void ButtonBackCarruselRecomendacion_Click(object sender, RoutedEventArgs e)
        {
            ContenedorCarruselRecomendacion.ChangeView(ContenedorCarruselRecomendacion.HorizontalOffset + 400, null, null);
        }

        private void ButtonItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
