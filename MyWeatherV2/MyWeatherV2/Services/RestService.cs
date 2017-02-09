using MyWeatherV2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyWeatherV2.Services
{
    
    class RestService
    {
        private HttpClient client;

        public RestService()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<Weather> GetWeatherAsync(string city)
        {
            Weather weather = new Weather();
            HttpResponseMessage reponse = client.GetAsync("http://www.prevision-meteo.ch/services/json/"+ city).Result;
            if (reponse.IsSuccessStatusCode)
            {
                weather = JsonConvert.DeserializeObject<Weather>(await reponse.Content.ReadAsStringAsync());
            }
            return weather;
        }


    }
}
