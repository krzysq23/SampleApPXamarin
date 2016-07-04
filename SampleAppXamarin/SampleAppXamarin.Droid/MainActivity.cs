using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Acr.UserDialogs;

namespace SampleAppXamarin.Droid
{
    [Activity(Label = "@string/app_name", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            Zumero.DataGridComponent.Init();
            LoadApplication(new App());
        }
    }
}

//namespace SampleAppXamarin.Droid
//{
//    [Activity(Label = "@string/app_name", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
//    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
//    {
//        protected override void OnCreate(Bundle bundle)
//        {
//            TabLayoutResource = Resource.Layout.Tabs;
//            ToolbarResource = Resource.Layout.Toolbar;

//            base.OnCreate(bundle);

//            //UserDialogs.Init(this);

//            global::Xamarin.Forms.Forms.Init(this, bundle);
//            //Zumero.DataGridComponent.Init();
//            LoadApplication(new App());
//        }
//    }
//}
