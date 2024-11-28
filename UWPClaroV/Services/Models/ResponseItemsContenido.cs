using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPClaroV.Services.Models
{
    public class RootResponse
    {
        public RecordItemsContenido record {  get; set; }
    }

    public class RecordItemsContenido
    {
        public ResponseItemsContenido response { get; set; }
    }

    public class ResponseItemsContenido
    {
        public List<Group> groups { get; set; }
    }

    public class Group
    {
        public string id { get; set; }
        public string title { get; set; }
        public string title_episode { get; set; }
        public string title_uri { get; set; }
        public string title_original { get; set; }
        public string description { get; set; }
        public string description_large { get; set; }
        public string short_description { get; set; }
        public string image_large { get; set; }
        public string image_background { get; set; }
        public string image_clean_horizontal { get; set; }
        public string image_clean_vertical { get; set; }
        public string duration { get; set; }
        public string date { get; set; }
        public string year { get; set; }
        public string proveedor_name { get; set; }
        public string proveedor_code { get; set; }
    }
}
