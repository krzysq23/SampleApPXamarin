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
    public partial class ProductInfoPage : ContentPage
    {
        public ProductInfoViewModel _vievModel;

        public ProductInfoPage(Product item)
        {
            InitializeComponent();
            _vievModel = new ViewModels.ProductInfoViewModel(item);
            BindingContext = _vievModel;
        }

    }
}
