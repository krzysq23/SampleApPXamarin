using SampleAppXamarin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SampleAppXamarin.Pages
{
    public partial class ImagePage : ContentPage
    {
        public ImagePage(ProductImage item)
        {
            InitializeComponent();

            BindingContext = item;

            Content = new Image {
                Source = item.Url
            };
        }
    }
}
