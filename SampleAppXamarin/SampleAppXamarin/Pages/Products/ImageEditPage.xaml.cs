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
    public partial class ImageEditPage : ContentPage
    {
        private ProductImage _item;
        public ImageEditPage(ProductImage item)
        {
            InitializeComponent();
            var viewModel = new ImageEditViewModel(item);
            _item = item;
            BindingContext = viewModel;
            DataResource();
        }

        async void DeleteClicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert(_item.Name, AppResource.DeleteImageQuest, AppResource.Yes, AppResource.No);
            if (answer)
            {
                try
                {
                    App.ProductImageManager.DeleteProductImage(_item.Id);
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
            delete.Text = AppResource.Delete;
        }
    }
}
