using SampleAppXamarin.Managers;
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
    public partial class ProductImageEditPage : ContentPage
    {
        private ProductImageEditViewModel _vievModel;
        private ProductImage _productImage = new ProductImage();
        private Product _item;

        public ProductImageEditPage(Product item)
        {
            InitializeComponent();
            _vievModel = new ProductImageEditViewModel(item);
            _productImage.ProductId = item.Id;
            _item = item;
            BindingContext = _vievModel;

            DataResource();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        async void SaveClicked(object sender, EventArgs e)
        {
            _productImage.Name = imageNameEntry.Text;
            _productImage.Url = urlEntry.Text;
            _productImage.UrlThubnail = urlThubnailEntry.Text;
            _productImage.Description = descriptionEntry.Text;
            try
            {
                App.ProductImageManager.SaveProductImage(_productImage);
                //Navigation.InsertPageBefore(new ProductEditPage(_item), this);
            }
            catch (Exception ex)
            {
                Acr.UserDialogs.UserDialogs.Instance.ShowError(ex.Message);
            }
        }

        public void DataResource()
        {
            imageName.Text = AppResource.ImageName;
            imageNameEntry.Placeholder = AppResource.ImageName;
            url.Text = AppResource.Url;
            urlEntry.Placeholder = AppResource.Url;
            urlThubnail.Text = AppResource.UrlThubnail;
            urlThubnailEntry.Placeholder = AppResource.UrlThubnail;
            description.Text = AppResource.Description;
            descriptionEntry.Placeholder = AppResource.Description;
            save.Text = AppResource.Submit;
        }
    }
}
