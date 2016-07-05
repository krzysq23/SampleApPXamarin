using SampleAppXamarin.Helpers;
using SampleAppXamarin.Models;
using SampleAppXamarin.Resx;
using SampleAppXamarin.Services;
using SampleAppXamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SampleAppXamarin.Pages
{
    public partial class MasterPage : ContentPage
    {
        public ListView ListView { get { return listView; } }

        public MasterPage()
        {
            InitializeComponent();

            var masterPageItems = new List<MasterPageItem>();
            masterPageItems.Add(new MasterPageItem
            {
                Title = AppResource.Home,
                IconSource = "icon.png",
                TargetType = typeof(HomePage)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = AppResource.ProductList,
                IconSource = "icon.png",
                TargetType = typeof(ProductListPage)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = AppResource.ProductListSQL,
                IconSource = "icon.png",
                TargetType = typeof(ProductListPageDB)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = AppResource.Home,
                IconSource = "icon.png",
                TargetType = typeof(ProductListPageDB)
            });

            listView.ItemsSource = masterPageItems;
        }
    }
}
