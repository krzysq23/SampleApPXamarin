using SampleAppXamarin.Data;
using SampleAppXamarin.Helpers;
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
        static ProductsDatabase database;

        public App()
        {
            InitializeComponent();

            bool useMock = true;

            var assembly = typeof(App).GetTypeInfo().Assembly;
            foreach (var res in assembly.GetManifestResourceNames())
                System.Diagnostics.Debug.WriteLine(" ### found resource: " + res);

            if (useMock)
            {
                ServiceLocator.Instance.Add<ISampleAppService, MockSampleAppService>();
                DependencyService.Get<ILocalize>().SetLocale(); 
            }

            //if (Device.OS != TargetPlatform.WinPhone)
            //{
            //    DependencyService.Get<ILocalize>().SetLocale();
            //    Resx.AppResources.Culture = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            //}

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

        public static ProductsDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ProductsDatabase();
                }
                return database;
            }
        }

        private static readonly ViewModelLocator _locator = new ViewModelLocator();
        public static ViewModelLocator Locator
        {
            get { return _locator; }
        }

    }
}
