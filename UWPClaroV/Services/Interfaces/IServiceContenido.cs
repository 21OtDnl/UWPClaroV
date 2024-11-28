using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPClaroV.Services.Models;
using Windows.UI.Xaml.Media.Imaging;

namespace UWPClaroV.Services.Interfaces
{
    public interface IServiceContenido
    {
        Task<List<BitmapImage>> GetContenidosCarruselAsync();

        Task<List<BitmapImage>> GetContenidosCarruselPremiumAsync();

        Task<List<BitmapImage>> GetContenidosCarruselRecomendacionAsync();

        Task<ContenidoDTO> GetvCardContenido();
    }
}
