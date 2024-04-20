using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketLibrary
{
    public class RocketDbModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public DateTime launch_date_time { get; set; }
        public string provider_name { get; set; }
        public DateTime last_updated  { get; set; }
        public string img_url { get; set; }
        public string status { get; set; }  
        public int is_updated { get; set; }

    }
}
