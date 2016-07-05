using SampleAppXamarin.Models;
using SampleAppXamarin.Resx;
using SampleAppXamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SampleAppXamarin.Pages
{
    public partial class AddProductPage : ContentPage
    {
        public AddProductViewModel _viewModel;
        public AddProductPage()
        {
            InitializeComponent();
            DataResource();
            _viewModel = new AddProductViewModel();
            BindingContext = _viewModel;
        }

        async void SaveClicked(object sender, EventArgs e)
        {
            _viewModel.Product.Name = productNameEntry.Text;
            var product = App.Database.GetProduct(_viewModel.Product.Name); 
            if(product == null)
            {
                App.Database.SaveProduct(_viewModel.Product);
                var navigation = Application.Current.MainPage as NavigationPage;
                await navigation.PushAsync(new Pages.ProductListPageDB());
            }
            else
            {
                await DisplayAlert("Alert", AppResource.ProductExists, "OK");
            }
        }

        public void DataResource()
        {
            productName.Text = AppResource.ProductName;
            productNameEntry.Placeholder = AppResource.ProductName;
        }
    }
}
