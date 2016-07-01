﻿using SampleAppXamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SampleAppXamarin.Pages
{
    public partial class ProductListPage : ContentPage
    {
        ProductViewModel _viewModel; 
        public ProductListPage()
        {
            InitializeComponent();
            _viewModel = new ProductViewModel();
            BindingContext = _viewModel;
        } 
    }
}