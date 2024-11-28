using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using UWPClaroV.Services.Interfaces;
using UWPClaroV.Services.Services;
using UWPClaroV.ViewsModels;
using UWPClaroV.Views;

namespace UWPClaroV
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            var serviceCollection = new ServiceCollection();

            // Registrar los servicios en el contenedor de dependencias
            ConfigureServices(serviceCollection);

            // Crear el proveedor de servicios
            ServiceProvider = serviceCollection.BuildServiceProvider();

            // Obtener la instancia de MainPage desde el contenedor de dependencias
            var mainPage = ServiceProvider.GetRequiredService<MainPage>();

            Frame rootFrame = Window.Current.Content as Frame;

            if (rootFrame == null)
            {
                rootFrame = new Frame();
                rootFrame.NavigationFailed += OnNavigationFailed;
                Window.Current.Content = rootFrame;
            }

            // Asignar la instancia de MainPage al Frame, asegurando que se inyecten las dependencias correctas
            rootFrame.Content = mainPage;
            Window.Current.Activate();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Registrar servicios (puedes agregar más servicios aquí según lo necesites)
            services.AddSingleton<IServiceContenido, ServiceContenido>();
            services.AddSingleton<IServiceNavegacion, ServiceNavegacion>();

            // Registrar las páginas y sus respectivos ViewModels
            services.AddSingleton<MainPage>();
            services.AddSingleton<MainPageViewModel>();

            services.AddSingleton<VCard>();
            services.AddSingleton<VCardViewModel>();
        }

        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
}
