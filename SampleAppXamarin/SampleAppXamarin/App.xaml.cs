using SampleAppXamarin.Helpers;
using SampleAppXamarin.Services;
using SampleAppXamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SampleAppXamarin
{
    public partial class App : Application
    {
        public static bool IsUserLoggedIn { get; set; }

        public App()
        {
            InitializeComponent();

            bool useMock = true;

            if (useMock)
                ServiceLocator.Instance.Add<ISampleAppService, MockSampleAppService>();

            MainPage = new NavigationPage(new Pages.LoginPage())
            {
                BarBackgroundColor = (Color)Current.Resources["primaryBlue"],
                BarTextColor = Color.White
            };

            if (!IsUserLoggedIn)
            {
                MainPage = new NavigationPage(new Pages.LoginPage())
                {
                    BarBackgroundColor = (Color)Current.Resources["primaryBlue"],
                    BarTextColor = Color.White
                };
            }
            else
            {
                MainPage = new NavigationPage(new Pages.ProductListPage())
                {
                    BarBackgroundColor = (Color)Current.Resources["primaryBlue"],
                    BarTextColor = Color.White
                };
            }
        }

        private static readonly ViewModelLocator _locator = new ViewModelLocator();
        public static ViewModelLocator Locator
        {
            get { return _locator; }
        }

    }
}
