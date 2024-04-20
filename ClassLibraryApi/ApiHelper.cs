using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RocketLibrary
{
    public class ApiHelper{
        public static HttpClient ApiClient;

        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            ApiClient.BaseAddress = new Uri("https://lldev.thespacedevs.com/2.2.0/launch/upcoming");
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<RocketApiModel> GetUpcomingRocketsFromApi()
        {
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(ApiClient.BaseAddress))
            {
                if (response.IsSuccessStatusCode)
                {
                    RocketApiModel rocket = await response.Content.ReadAsAsync<RocketApiModel>();
                    return rocket;
                } else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }


    }
}
