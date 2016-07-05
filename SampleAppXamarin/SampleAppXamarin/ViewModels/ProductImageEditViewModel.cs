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
    public class ProductImageEditViewModel : ViewModelBase
    {

        public ProductImageEditViewModel(Product item)
        {
            Title = AppResource.ProductImageEdit;
            ProductImage = item;
        }

        #region ProductImage
        private Product _productImage = new Product();
        public Product ProductImage
        {
            get { return _productImage; }
            set
            {
                _productImage = value;
                OnPropertyChanged("ProductImage");
            }
        }
        #endregion
    }
}
