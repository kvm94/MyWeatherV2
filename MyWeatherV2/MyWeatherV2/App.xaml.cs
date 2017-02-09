using GalaSoft.MvvmLight.Ioc;
using MyWeatherV2.Enums;
using MyWeatherV2.Services;
using MyWeatherV2.ViewModels;
using MyWeatherV2.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MyWeatherV2
{
    public partial class App : Application
    {
        //ViewModelLocator object to handle ViewModels and bindings between them and Views (Pages):
        private static ViewModelLocator _locator;

        public App()
        {
            InitializeComponent();
            _locator = new ViewModelLocator();

            // Create new Navigation Page and set MainPage as its default page:
            var firstPage = new NavigationPage(new MainPage());

            // Set Navigation page as default page for Navigation Service:
            _locator.NavigationService.Initialize(firstPage);

            // You have to also set MainPage property for the app:
            MainPage = firstPage;
        }


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        //Properties
        public static ViewModelLocator Locator
        {
            get { return _locator ?? (_locator = new ViewModelLocator()); }
        }

    }
}
