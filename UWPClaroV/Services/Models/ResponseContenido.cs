using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UWPClaroV.Services.Models
{
    public class ResponseContenido
    {
        public GroupContenido group { get; set; }
    }

    public class GroupContenido
    {
        public Common common { get; set; }
        public External external { get; set; }
    }

    public class Common : Group
    {
        public string large_description { get; set; }
    }

    public class External
    {
        public Gracenote gracenote { get; set; }
    }

    public class Gracenote
    {
        public List<Cast> cast { get; set; }
        public List<string> genres { get; set; }
    }

    public class Cast
    {
        public string role_name { get; set; }
        public List<Talent> talents { get; set; }

    }

    public class Talent
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string image {  get; set; }
    }
}
