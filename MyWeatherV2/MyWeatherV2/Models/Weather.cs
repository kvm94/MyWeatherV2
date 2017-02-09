using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWeatherV2.Models
{

        public class Weather
        {
            public CityInfo city_info { get; set; }
            public ForecastInfo forecast_info { get; set; }
            public CurrentCondition current_condition { get; set; }


        }
        public class CityInfo
        {
            public string name { get; set; }
            public string country { get; set; }
            public string latitude { get; set; }
            public string longitude { get; set; }
            public string elevation { get; set; }
            public string sunrise { get; set; }
            public string sunset { get; set; }
        }

        public class ForecastInfo
        {
            public object latitude { get; set; }
            public object longitude { get; set; }
            public string elevation { get; set; }
        }

        public class CurrentCondition
        {
            public string date { get; set; }
            public string hour { get; set; }
            public int tmp { get; set; }
            public int wnd_spd { get; set; }
            public int wnd_gust { get; set; }
            public string wnd_dir { get; set; }
            public double pressure { get; set; }
            public int humidity { get; set; }
            public string condition { get; set; }
            public string icon { get; set; }
            public string icon_big { get; set; }
        }
    }
