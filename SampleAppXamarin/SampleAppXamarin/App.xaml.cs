using SampleAppXamarin.Data;
using SampleAppXamarin.Helpers;
using SampleAppXamarin.Managers;
using SampleAppXamarin.Resx;
using SampleAppXamarin.Services;
using SampleAppXamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SampleAppXamarin
{
    public partial class App : Application
    {
        public static bool IsUserLoggedIn { get; set; }
        private static ProductManager productManager;
        private static ProductImageManager productImageManager;

        public App()
        {
            InitializeComponent();

            bool useMock = true;

            var assembly = typeof(App).GetTypeInfo().Assembly;

            if (useMock)
            {
                ServiceLocator.Instance.Add<ISampleAppService, MockSampleAppService>();
            }

            if (Device.OS != TargetPlatform.WinPhone)
            {
                DependencyService.Get<ILocalize>().SetLocale();
            }

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
                MainPage = new NavigationPage(new Pages.HomePage())
                {
                    BarBackgroundColor = (Color)Current.Resources["primaryBlue"],
                    BarTextColor = Color.White
                };
            }
        }

        public static ProductManager ProductManager
        {
            get
            {
                if (productManager == null)
                {
                    productManager = new ProductManager();
                }
                return productManager;
            }
        }

        public static ProductImageManager ProductImageManager
        {
            get
            {
                if (productImageManager == null)
                {
                    productImageManager = new ProductImageManager();
                }
                return productImageManager;
            }
        }

        private static readonly ViewModelLocator _locator = new ViewModelLocator();
        public static ViewModelLocator Locator
        {
            get { return _locator; }
        }

    }
}
