using SampleAppXamarin.Helpers;
using SampleAppXamarin.Pages.Navigation;
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
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            masterPage.ListView.ItemSelected += OnItemSelected;
            //DataResource();
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                //Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                //masterPage.ListView.SelectedItem = null;
                //IsPresented = false;
            }
        }

        //async void ProductListButtonClicked(object sender, EventArgs e)
        //{
        //    var navigation = Application.Current.MainPage as NavigationPage;
        //    await navigation.PushAsync(new Pages.ProductListPage());
        //}

        //async void AddProductButtonClicked(object sender, EventArgs e)
        //{
        //    var navigation = Application.Current.MainPage as NavigationPage;
        //    await navigation.PushAsync(new Pages.AddProductPage());
        //}

        //async void ProductListSqlButtonClicked(object sender, EventArgs e)
        //{
        //    var navigation = Application.Current.MainPage as NavigationPage;
        //    await navigation.PushAsync(new Pages.ProductListPage());
        //}

        //public void DataResource()
        //{
        //    title.Text = AppResource.Title;
        //    addpProduct.Text = AppResource.AddProduct;
        //    productList.Text = AppResource.ProductList;
        //    productListSql.Text = AppResource.ProductListSQL;
        //}
    }
}
