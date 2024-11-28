using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPClaroV.Services.Models
{
    public class ContenidoDTO
    {
        public string title {  get; set; }
        public string titleOriginal { get; set; }
        public string descriptionLarge { get; set; }
        public string duration {  get; set; }
        public string year { get; set; }
        public string urlImageLarge {  get; set; }
        public string urlImageBackground { get; set; }
        public string urlCleanHorizontal { get; set; }
        public string urlCleanVertical { get; set; }
        public string genres { get; set; }
        public List<TalentoDTO> listTalents { get;set; }

    }
}
