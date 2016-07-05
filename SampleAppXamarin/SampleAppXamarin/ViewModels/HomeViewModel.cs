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
    public class HomeViewModel : ViewModelBase
    {
        public HomeViewModel()
        {
            Title = AppResource.Home;
        }
    }  
}
