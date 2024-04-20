using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace RocketLibrary
{
    public class RocketApiModel
    {
        public Result[] results { get; set; }
        
        public class Result
        {
            public string id { get; set; }
            public string url { get; set; }
            public string slug { get; set; }
            public string name { get; set; }
            public Status status { get; set; }
            public DateTime last_updated { get; set; }
            public DateTime net { get; set; }
            public DateTime window_end { get; set; }
            public DateTime window_start { get; set; }
            public Net_Precision net_precision { get; set; }
            public string weather_concerns { get; set; }
            public string holdreason { get; set; }
            public string failreason { get; set; }
            public string hashtag { get; set; }
            public Launch_Service_Provider launch_service_provider { get; set; }
            public Rocket rocket { get; set; }
            public bool webcast_live { get; set; }
            public string image { get; set; }
            public string infographic { get; set; }
            public int orbital_launch_attempt_count { get; set; }
            public int location_launch_attempt_count { get; set; }
            public int pad_launch_attempt_count { get; set; }
            public int agency_launch_attempt_count { get; set; }
            public int orbital_launch_attempt_count_year { get; set; }
            public int location_launch_attempt_count_year { get; set; }
            public int pad_launch_attempt_count_year { get; set; }
            public int agency_launch_attempt_count_year { get; set; }
            public string type { get; set; }
        }

        public class Status
        {
            public int id { get; set; }
            public string name { get; set; }
            public string abbrev { get; set; }
            public string description { get; set; }
        }

        public class Net_Precision
        {
            public int id { get; set; }
            public string name { get; set; }
            public string abbrev { get; set; }
            public string description { get; set; }
        }

        public class Launch_Service_Provider
        {
            public int id { get; set; }
            public string url { get; set; }
            public string name { get; set; }
            public string type { get; set; }
        }

        public class Rocket
        {
            public int id { get; set; }
            public Configuration configuration { get; set; }
        }

        public class Configuration
        {
            public int id { get; set; }
            public string url { get; set; }
            public string name { get; set; }
            public string family { get; set; }
            public string full_name { get; set; }
            public string variant { get; set; }
        }

    }
}
