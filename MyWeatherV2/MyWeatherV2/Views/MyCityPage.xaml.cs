using MyWeatherV2.Services;
using MyWeatherV2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MyWeatherV2.Views
{
    public partial class MyCityPage : ContentPage
    {
        public MyCityPage(string city)
        {
            InitializeComponent();
            MyCityPageViewModel viewModel = App.Locator.MyCityPageViewModel;
            viewModel.City = city;
            
            BindingContext = viewModel;
            
        }
    }
}
