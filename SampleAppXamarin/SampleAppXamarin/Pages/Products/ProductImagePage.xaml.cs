using SampleAppXamarin.Models;
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
        public ProductImageViewModel _vievModel;

        public ProductImagePage(Product item)
        {
            InitializeComponent();
            _vievModel = new ViewModels.ProductImageViewModel(item);
            BindingContext = _vievModel;
        }
    }
}
