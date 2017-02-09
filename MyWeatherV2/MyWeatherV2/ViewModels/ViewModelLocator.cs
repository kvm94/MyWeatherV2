using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using MyWeatherV2.Enums;
using MyWeatherV2.Services;
using MyWeatherV2.ViewModels;
using MyWeatherV2.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWeatherV2.ViewModels
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        // Setup navigation service:
        private NavigationService _navigationService;

        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {

            _navigationService = new NavigationService();

            // Configure pages:
            _navigationService.Configure(AppPages.MainPage, typeof(MainPage));
            _navigationService.Configure(AppPages.MyCityPage, typeof(MyCityPage));

            // Register NavigationService in IoC container:
            SimpleIoc.Default.Register<INavigationService>(() => _navigationService);

            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            //Register all the ViewModel
            SimpleIoc.Default.Register<MainPageViewModel>();
            SimpleIoc.Default.Register<MyCityPageViewModel>();
        }

        //ViewModel Properties
        public MainPageViewModel MainPageViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainPageViewModel>();
            }
        }
        public MyCityPageViewModel MyCityPageViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MyCityPageViewModel>();
            }
        }

        public NavigationService NavigationService
        {
            get { return _navigationService; }
        }

        //Clean all ViewModel
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
            
        }
    }
}
