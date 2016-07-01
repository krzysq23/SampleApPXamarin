using SampleAppXamarin.Helpers;
using SampleAppXamarin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SampleAppXamarin.Pages
{
    public partial class LoginPage : ContentPage
    {
        ISampleAppService _service;

        public LoginPage()
        {
            InitializeComponent();
            _service = ServiceLocator.Instance.Resolve<ISampleAppService>();
        }

        async void OnSubmitButtonClicked(object sender, EventArgs e)
        {
            var isValid = await _service.LogIn(username.Text, password.Text);
            if (isValid)
            {
                App.IsUserLoggedIn = true;
                var navigation = Application.Current.MainPage as NavigationPage;
                await navigation.PushAsync(new Pages.ProductListPage());
                //Navigation.InsertPageBefore(new ProductListPage(), this);
                //await Navigation.PopAsync();
            }
            else
            {
                messageLabel.Text = "Dane niepoprawne";
                password.Text = string.Empty;
            }
        }
    }
}
