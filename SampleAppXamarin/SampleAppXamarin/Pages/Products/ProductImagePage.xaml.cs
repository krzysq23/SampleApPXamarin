using SampleAppXamarin.Models;
using SampleAppXamarin.Resx;
using SampleAppXamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SampleAppXamarin.Pages
{
    public partial class ProductImagePage : ContentPage
    {
        private ProductImageViewModel _vievModel;
        private Product _item;

        public ProductImagePage(Product item)
        {
            InitializeComponent();
            _vievModel = new ViewModels.ProductImageViewModel(item);
            _item = item;
            BindingContext = _vievModel;
            DataResource();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        async void DeleteProductClicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert(_item.Name, AppResource.DeleteProductQuest, AppResource.Yes, AppResource.No);
            if(answer)
            {
                try
                {
                    App.ProductManager.DeleteProduct(_item.Id);
                    var navigation = Application.Current.MainPage as NavigationPage;
                    await navigation.PopAsync();
                }
                catch (Exception ex)
                {
                    Acr.UserDialogs.UserDialogs.Instance.ShowError(ex.Message);
                }   
            }
            
        }

        public void DataResource()
        {
            deleteProduct.Text = AppResource.DeleteProduct;
        }
    }
}
