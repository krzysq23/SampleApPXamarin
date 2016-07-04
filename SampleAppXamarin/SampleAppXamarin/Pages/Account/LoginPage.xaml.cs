using SampleAppXamarin.Helpers;
using SampleAppXamarin.Resx;
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

            DataResource();
        }

        async void OnSubmitButtonClicked(object sender, EventArgs e)
        {
            var isValid = await _service.LogIn(usernameEntry.Text, passwordEntry.Text);
            if (isValid)
            {
                App.IsUserLoggedIn = true;
                Navigation.InsertPageBefore(new MainPage(), this);
                await Navigation.PopAsync();
            }
            else
            {
                messageLabel.Text = AppResource.IncorrectData;
                passwordEntry.Text = string.Empty;
            }
        }

        void xxx(object sender, EventArgs e)
        {
        }

        public void DataResource()
        {
            userLbl.Text = AppResource.Username;
            usernameEntry.Placeholder = AppResource.Username;
            passwordLbl.Text = AppResource.Password;
            passwordEntry.Placeholder = AppResource.Password;
            submitBtn.Text = AppResource.Submit;


        }
    }
}
