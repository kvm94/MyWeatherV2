using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MyWeatherV2.Enums;
using MyWeatherV2.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyWeatherV2.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        //Instance of NavigationService
        private readonly INavigationService _navigationService;

        public RelayCommand SelectCommand { get; set; }

        private string entryCity;        

        public MainPageViewModel()
        {
            _navigationService = App.Locator.NavigationService;
            //Match the command with the method
            SelectCommand = new RelayCommand(() => SelectOnClick());
        }

        private void SelectOnClick()
        {
            try
            {
               _navigationService.NavigateTo(AppPages.MyCityPage, entryCity);

            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Error !", "Invalide entry! \n" + ex.Message, "OK");
            }           
        }

        public string EntryCity
        {
            get { return entryCity; }
            set
            {
                if (entryCity != value)
                {
                    entryCity = value;
                    RaisePropertyChanged();
                }
            }
        }

        

    }
}
