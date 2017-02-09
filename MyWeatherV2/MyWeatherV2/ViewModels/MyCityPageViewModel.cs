using GalaSoft.MvvmLight;
using MyWeatherV2.Models;
using MyWeatherV2.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyWeatherV2.ViewModels
{
    public class MyCityPageViewModel: ViewModelBase
    {
        private string city;
        private Weather weather;
        private NavigationService nav;
        private bool isBusy;



        public MyCityPageViewModel()
        {
            nav = App.Locator.NavigationService;
        }

        public async void GetdataAPI(string city)
        {
            RestService api = new RestService();

            IsBusy = true;
            weather = await api.GetWeatherAsync(city);

            if (weather.city_info == null)
            {
                await App.Current.MainPage.DisplayAlert("Error !", "No city found!", "OK");
            }

            IsBusy = false;
        }

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                if (isBusy != value)
                {
                    isBusy = value;
                    RaisePropertyChanged();
                }
            }
        }
        public string City
        {
            get { return city; }
            set {
                if (city != value)
                {
                    city = value;
                    GetdataAPI(city);
                    RaisePropertyChanged();
                }
            }
        }

        public Weather Weather
        {
            get { return weather; }
            set
            {
                if (weather != value)
                {
                    weather = value;
                    RaisePropertyChanged();
                }
            }
        }

    }
}
