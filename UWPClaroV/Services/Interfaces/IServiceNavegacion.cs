using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace UWPClaroV.Services.Interfaces
{
    public interface IServiceNavegacion
    {
        void NavigateTo<TView>() where TView : Page;
        void GoBack();
    }
}
