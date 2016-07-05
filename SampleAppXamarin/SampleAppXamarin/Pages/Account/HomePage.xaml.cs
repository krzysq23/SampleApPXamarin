using SampleAppXamarin.Helpers;
using SampleAppXamarin.Resx;
using SampleAppXamarin.Services;
using SampleAppXamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SampleAppXamarin.Pages
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            DataResource();
            BindingContext = new HomeViewModel();
        }

        async void ProductListButtonClicked(object sender, EventArgs e)
        {
            var navigation = Application.Current.MainPage as NavigationPage;
            await navigation.PushAsync(new Pages.ProductListPage());
        }

        async void AddProductButtonClicked(object sender, EventArgs e)
        {
            var navigation = Application.Current.MainPage as NavigationPage;
            await navigation.PushAsync(new Pages.AddProductPage());
        }

        async void ProductListSqlButtonClicked(object sender, EventArgs e)
        {
            var navigation = Application.Current.MainPage as NavigationPage;
            await navigation.PushAsync(new Pages.ProductListPageDB());
        }

        public void DataResource()
        {
            title.Text = AppResource.Title;
            addpProduct.Text = AppResource.AddProduct;
            productList.Text = AppResource.ProductList;
            productListSql.Text = AppResource.ProductListSQL;
        }
    }
}
