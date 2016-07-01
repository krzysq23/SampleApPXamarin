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
    public class ProductInfoViewModel : ViewModelBase
    {
        ISampleAppService _service;
        Product _item;

        public ProductInfoViewModel(Product item)
        {
            Title = item.Name;
            _item = item;
            _service = ServiceLocator.Instance.Resolve<ISampleAppService>();
            Refresh();
        }

        #region ViewDataGrid
        public List<View> ViewDataGrid()
        {
            List<View> views = new List<View>();
            
            foreach (var item in ProductImages)
            {
                Image img = new Image
                {
                    Source = item.Url
                };
                views.Add(img);
            }

            return views;
        }
        #endregion

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
                    navigation.PushAsync(new Pages.ImagePage(_selectedProductImageItem));
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
                var productImages = await _service.GetProductImageByProductId(_item.ProductId);
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
