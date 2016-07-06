using SampleAppXamarin.Helpers;
using SampleAppXamarin.Models;
using SampleAppXamarin.Resx;
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
    public class ProductListDBViewModel : ViewModelBase
    {
        public ProductListDBViewModel()
        {
            Title = AppResource.ProductList;
            Refresh();
        }

        #region ProductItems
        private ObservableCollection<Product> _productItems = new ObservableCollection<Product>();
        public ObservableCollection<Product> ProductItems
        {
            get { return _productItems; }
            set
            {
                _productItems = value;
                OnPropertyChanged("ProductItems");
            }
        }
        #endregion

        #region SelectedProductItem
        private Product _selectedProductItem;

        public Product SelectedProductItem
        {
            get { return _selectedProductItem; }
            set
            {
                _selectedProductItem = value;
                OnPropertyChanged("SelectedProductItem");

                if (_selectedProductItem != null)
                {
                    var navigation = Application.Current.MainPage as NavigationPage;
                    navigation.PushAsync(new Pages.ProductEditPage(_selectedProductItem));
                    SelectedProductItem = null;
                }
            }
        }
        #endregion

        #region Refresh()
        void Refresh()
        {
            ExecuteRefreshCommand();
            MessagingCenter.Subscribe<ProductViewModel>(this, "ItemsChanged", (sender) =>
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
                var products = App.ProductManager.GetProducts();
                ProductItems.Clear();
                foreach (var todo in products)
                {
                    ProductItems.Add(todo);
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
