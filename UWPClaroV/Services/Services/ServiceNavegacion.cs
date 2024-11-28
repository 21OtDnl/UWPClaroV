using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using UWPClaroV.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace UWPClaroV.Services.Services
{
    public class ServiceNavegacion : IServiceNavegacion
    {
        private readonly IServiceProvider _serviceProvider;

        public ServiceNavegacion(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void NavigateTo<TView>() where TView : Page
        {
            var frame = Window.Current.Content as Frame;
            if (frame == null) throw new InvalidOperationException("No se encontró el Frame de navegación.");

            // Obtener la instancia de la página desde el contenedor de dependencias
            var page = _serviceProvider.GetRequiredService<TView>();

            // Navegar a la página resuelta
            frame.Navigate(typeof(TView), page);
        }

        public void GoBack()
        {
            var frame = Window.Current.Content as Frame;
            if (frame != null && frame.CanGoBack)
            {
                frame.GoBack();
            }
        }
    }
}
