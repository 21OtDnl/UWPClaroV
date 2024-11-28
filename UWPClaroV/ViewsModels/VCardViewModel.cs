using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UWPClaroV.Services.Interfaces;
using UWPClaroV.ViewsModels.Comandos;

namespace UWPClaroV.ViewsModels
{
    public class VCardViewModel : INotifyPropertyChanged
    {
        private readonly IServiceNavegacion _serviceNavegacion;
        private readonly IServiceContenido _serviceContenido;
        public ICommand GoBackCommand { get; }

        public VCardViewModel(IServiceNavegacion serviceNavegacion, IServiceContenido serviceContenido)
        {
            _serviceNavegacion = serviceNavegacion;
            GoBackCommand = new RelayCommand(_ => serviceNavegacion.GoBack());
            _serviceContenido = serviceContenido;
        }

        private async void CargarVCard()
        {
            try
            {
                var contenido = await _serviceContenido.GetvCardContenido();
            }
            catch (Exception ex)
            {

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
