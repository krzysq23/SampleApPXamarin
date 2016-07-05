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
    public class AddProductViewModel : ViewModelBase
    {
        public AddProductViewModel()
        {
            Title = AppResource.AddProduct;
        }

        #region Product
        private Product _product = new Product();
        public Product Product
        {
            get { return _product; }
            set
            {
                _product = value;
                OnPropertyChanged("Product");
            }
        }
        #endregion
    }
}
