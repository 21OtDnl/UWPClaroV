using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Media.Imaging;

namespace UWPClaroV.ViewsModels.Comandos
{
    public class ImagenComando : INotifyPropertyChanged
    {
        private BitmapImage _imagen;
        private ICommand _clickCommand;

        public BitmapImage Imagen
        {
            get => _imagen;
            set
            {
                _imagen = value;
                OnPropertyChanged(nameof(Imagen));
            }
        }

        public ICommand ClickCommand
        {
            get => _clickCommand;
            set
            {
                _clickCommand = value;
                OnPropertyChanged(nameof(ClickCommand));
            }
        }

        public ImagenComando(BitmapImage imagen, ICommand clickCommand)
        {
            _imagen = imagen;
            _clickCommand = clickCommand;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
