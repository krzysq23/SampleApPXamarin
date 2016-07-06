using SampleAppXamarin.Models;
using SampleAppXamarin.Resx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleAppXamarin.Pages
{
    public class ProductEditPage : TabbedPage
    {

        public ProductEditPage(Product item)
        {
            var imagePage = new ProductImagePage(item);
            imagePage.Title = AppResource.Info;

            var editPage = new ProductImageEditPage(item);
            editPage.Title = AppResource.Edit;

            this.Title = item.Name;

            this.Children.Add(imagePage);
            this.Children.Add(editPage);
        }
    }
}
