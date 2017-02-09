using MyWeatherV2.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyWeatherV2.Services
{
    public class NavigationService : INavigationService
    {
        private readonly Dictionary<AppPages, Type> _pagesByKey = new Dictionary<AppPages, Type>();
        private NavigationPage _navigation;

        //Get the current page key
        public string CurrentPageKey
        {
            get
            {
                lock (_pagesByKey)
                {
                    if (_navigation.CurrentPage == null)
                    {
                        return null;
                    }

                    var pageType = _navigation.CurrentPage.GetType();

                    return _pagesByKey.ContainsValue(pageType)
                                      ? _pagesByKey.First(p => p.Value == pageType).Key.ToString() : null;
                }
            }
        }

        //Go to the last page
        public void GoBack()
        {
            _navigation.PopAsync();
        }

        //Navigate to the page
        public void NavigateTo(AppPages pageKey)
        {
            NavigateTo(pageKey, null);
        }
        //Navigate to the page with parameter
        public void NavigateTo(AppPages pageKey, object parameter)
        {
            lock (_pagesByKey)
            {

                if (_pagesByKey.ContainsKey(pageKey))
                {
                    var type = _pagesByKey[pageKey];
                    ConstructorInfo constructor;
                    object[] parameters;

                    if (parameter == null)
                    {
                        constructor = type.GetTypeInfo()
                            .DeclaredConstructors
                            .FirstOrDefault(c => !c.GetParameters().Any());

                        parameters = new object[]
                        {
                        };
                    }
                    else
                    {
                        constructor = type.GetTypeInfo()
                            .DeclaredConstructors
                            .FirstOrDefault(
                                c =>
                                {
                                    var p = c.GetParameters();
                                    return p.Count() == 1
                                           && p[0].ParameterType == parameter.GetType();
                                });

                        parameters = new[]
                        {
                            parameter
                        };
                    }

                    if (constructor == null)
                    {
                        throw new InvalidOperationException(
                            "No suitable constructor found for page " + pageKey);
                    }

                    var page = constructor.Invoke(parameters) as Page;
                    _navigation.PushAsync(page);
                }
                else
                {
                    throw new ArgumentException(
                        string.Format(
                            "No such page: {0}. Did you forget to call NavigationService.Configure?",
                            pageKey), nameof(pageKey));
                }
            }
        }
        //Add a page key into the dictionary.
        public void Configure(AppPages pageKey, Type pageType)
        {
            lock (_pagesByKey)
            {
                if (_pagesByKey.ContainsKey(pageKey))
                {
                    _pagesByKey[pageKey] = pageType;
                }
                else
                {
                    _pagesByKey.Add(pageKey, pageType);
                }
            }
        }
        //Initialise the first NavigationPage
        public void Initialize(NavigationPage navigation)
        {
            _navigation = navigation;
        }
    }
}
