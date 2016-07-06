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
    public class ImageEditViewModel : ViewModelBase
    {
        public ImageEditViewModel(ProductImage item)
        {
            Title = item.Name;
            _productImage = item;
        }

        #region ProductImage
        private ProductImage _productImage = new ProductImage();
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
