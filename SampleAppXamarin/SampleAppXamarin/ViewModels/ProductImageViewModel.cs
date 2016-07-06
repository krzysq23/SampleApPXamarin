using SampleAppXamarin.Helpers;
using SampleAppXamarin.Models;
using SampleAppXamarin.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleAppXamarin.ViewModels
{
    public class ProductImageViewModel : ViewModelBase
    {
        Product _item;

        public ProductImageViewModel(Product item)
        {
            Title = item.Name;
            _item = item;
            Refresh();
        }

        #region SelectedProductImageItem
        private ProductImage _selectedProductImageItem;

        public ProductImage SelectedProductImageItem
        {
            get { return _selectedProductImageItem; }
            set
            {
                _selectedProductImageItem = value;
                OnPropertyChanged("SelectedProductImageItem");

                if (_selectedProductImageItem != null)
                {
                    var navigation = Application.Current.MainPage as NavigationPage;
                    navigation.PushAsync(new Pages.ImageEditPage(_selectedProductImageItem));
                    SelectedProductImageItem = null;
                }
            }
        }
        #endregion

        #region ProductImage
        private ObservableCollection<ProductImage> _productImages = new ObservableCollection<ProductImage>();
        public ObservableCollection<ProductImage> ProductImages
        {
            get { return _productImages; }
            set
            {
                _productImages = value;
                OnPropertyChanged("ProductImages");
            }
        }
        #endregion

        #region Refresh()
        void Refresh()
        {
            ExecuteRefreshCommand();
            MessagingCenter.Subscribe<ProductImage>(this, "ItemsChanged", (sender) =>
            {
                ExecuteRefreshCommand();
            });
        }

        Command refreshCommand;
        public Command RefreshCommand
        {
            get { return refreshCommand ?? (refreshCommand = new Command(async () => await ExecuteRefreshCommand())); }
        }

        async Task ExecuteRefreshCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var productImages = App.ProductImageManager.GetProductsImage(_item.Id);
                ProductImages.Clear();
                foreach (var pr in productImages)
                {
                    ProductImages.Add(pr);
                }
            }
            catch (Exception ex)
            {
                Acr.UserDialogs.UserDialogs.Instance.ShowError(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }
        #endregion
    }
}
