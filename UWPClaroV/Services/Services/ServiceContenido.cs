using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using UWPClaroV.Services.Interfaces;
using UWPClaroV.Services.Models;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace UWPClaroV.Services.Services
{
    public class ServiceContenido : IServiceContenido
    {
        private readonly HttpClient _httpClient;

        public ServiceContenido()
        {
            _httpClient = new HttpClient();
        }

        private async Task<List<ContenidoDTO>> GetCarruselContenidoItemsAsync(string urlApi)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(urlApi);
            response.EnsureSuccessStatusCode();
            string jsonResponse = await response.Content.ReadAsStringAsync();
            RootResponse apiResponse = JsonConvert.DeserializeObject<RootResponse>(jsonResponse);
            List<ContenidoDTO> list = apiResponse.record.response.groups.Select(g => new ContenidoDTO()
            { 
                urlImageLarge = g.image_large,
                urlCleanHorizontal = g.image_clean_horizontal,
                urlCleanVertical = g.image_clean_vertical
            }).ToList();
            return list;
        }

        private async Task<BitmapImage> DescargarImagenAsync(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var imagenBytes = await httpClient.GetByteArrayAsync(url);

                var bitmapImage = new BitmapImage();
                using (var stream = new InMemoryRandomAccessStream())
                {
                    await stream.WriteAsync(imagenBytes.AsBuffer());
                    stream.Seek(0);

                    bitmapImage.SetSource(stream);
                }

                return bitmapImage;
            }
        }

        public async Task<List<BitmapImage>> GetContenidosCarruselAsync()
        {
            string urlApi = "https://api.jsonbin.io/v3/b/6670b6abe41b4d34e404c0bd";
            try
            {
                List<ContenidoDTO> list = await GetCarruselContenidoItemsAsync(urlApi);
                var listImagenes = new List<BitmapImage>();
                foreach(var oContenido in list)
                {
                    var imagen = await DescargarImagenAsync(oContenido.urlImageLarge);
                    listImagenes.Add(imagen);
                }
                return listImagenes;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<BitmapImage>> GetContenidosCarruselPremiumAsync()
        {
            string urlApi = "https://api.jsonbin.io/v3/b/6670b55be41b4d34e404c04d";
            try
            {
                List<ContenidoDTO> list = await GetCarruselContenidoItemsAsync(urlApi);
                var listImagenes = new List<BitmapImage>();
                foreach (var oContenido in list)
                {
                    var imagen = await DescargarImagenAsync(oContenido.urlCleanHorizontal);
                    listImagenes.Add(imagen);
                }
                return listImagenes;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<BitmapImage>> GetContenidosCarruselRecomendacionAsync()
        {
            string urlApi = "https://api.jsonbin.io/v3/b/6670b67cad19ca34f87a78ed";
            try
            {
                List<ContenidoDTO> list = await GetCarruselContenidoItemsAsync(urlApi);
                var listImagenes = new List<BitmapImage>();
                foreach (var oContenido in list)
                {
                    var imagen = await DescargarImagenAsync(oContenido.urlCleanVertical);
                    listImagenes.Add(imagen);
                }
                return listImagenes;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<ContenidoDTO> GetvCardContenido()
        {
            string urlApi = "https://api.jsonbin.io/v3/b/6670b786e41b4d34e404c0f0";
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(urlApi);
                response.EnsureSuccessStatusCode();
                string jsonResponse = await response.Content.ReadAsStringAsync();
                ResponseContenido apiResponse = JsonConvert.DeserializeObject<ResponseContenido>(jsonResponse);
                ContenidoDTO contenido = new ContenidoDTO()
                {
                    title = apiResponse.group.common.title,
                    titleOriginal = apiResponse.group.common.title_original,
                    duration = apiResponse.group.common.duration,
                    year = apiResponse.group.common.year,
                    genres = string.Join(",", apiResponse.group.external.gracenote.genres),
                    urlImageBackground = apiResponse.group.common.image_background,
                    listTalents = apiResponse.group.external.gracenote.cast.SelectMany(c => c.talents.Select(t => new TalentoDTO
                    {
                        firstName = t.first_name,
                        lastName = t.last_name,
                        urlImage = t.image,
                        rol = c.role_name
                    })).ToList()
                };
                return contenido;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
