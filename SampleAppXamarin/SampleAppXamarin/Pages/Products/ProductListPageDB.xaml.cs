using SampleAppXamarin.Models;
using SampleAppXamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SampleAppXamarin.Pages
{
    public partial class ProductListPageDB : ContentPage
    {
        public ProductListPageDB()
        {
            InitializeComponent();

            var _viewModel = new ProductListDBViewModel();
            BindingContext = _viewModel;
        }

    }
}
