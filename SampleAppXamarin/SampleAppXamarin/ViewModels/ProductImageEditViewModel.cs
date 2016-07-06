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
        private ProductImage _productImage = new ProductImage();

        public ProductImageEditViewModel(Product item)
        {
            Title = AppResource.ProductImageEdit;
            _productImage.ProductId = item.Id;
        }

        #region ProductImage
        public ProductImage ProductImage
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
