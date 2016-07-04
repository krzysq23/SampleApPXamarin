package mono;

import java.io.*;
import java.lang.String;
import java.util.Locale;
import java.util.HashSet;
import java.util.zip.*;
import android.content.Context;
import android.content.Intent;
import android.content.pm.ApplicationInfo;
import android.content.res.AssetManager;
import android.util.Log;
import mono.android.Runtime;

public class MonoPackageManager {

	static Object lock = new Object ();
	static boolean initialized;

	static android.content.Context Context;

	public static void LoadApplication (Context context, ApplicationInfo runtimePackage, String[] apks)
	{
		synchronized (lock) {
			if (!initialized) {
				android.content.IntentFilter timezoneChangedFilter  = new android.content.IntentFilter (
						android.content.Intent.ACTION_TIMEZONE_CHANGED
				);
				context.registerReceiver (new mono.android.app.NotifyTimeZoneChanges (), timezoneChangedFilter);
				Context = context;
				
				System.loadLibrary("monodroid");
				Locale locale       = Locale.getDefault ();
				String language     = locale.getLanguage () + "-" + locale.getCountry ();
				String filesDir     = context.getFilesDir ().getAbsolutePath ();
				String cacheDir     = context.getCacheDir ().getAbsolutePath ();
				String dataDir      = getNativeLibraryPath (context);
				ClassLoader loader  = context.getClassLoader ();

				Runtime.init (
						language,
						apks,
						getNativeLibraryPath (runtimePackage),
						new String[]{
							filesDir,
							cacheDir,
							dataDir,
						},
						loader,
						new java.io.File (
							android.os.Environment.getExternalStorageDirectory (),
							"Android/data/" + context.getPackageName () + "/files/.__override__").getAbsolutePath (),
						MonoPackageManager_Resources.Assemblies,
						context.getPackageName ());
				
				mono.android.app.ApplicationRegistration.registerApplications ();
				
				initialized = true;
			}
		}
	}

	static String getNativeLibraryPath (Context context)
	{
	    return getNativeLibraryPath (context.getApplicationInfo ());
	}

	static String getNativeLibraryPath (ApplicationInfo ainfo)
	{
		if (android.os.Build.VERSION.SDK_INT >= 9)
			return ainfo.nativeLibraryDir;
		return ainfo.dataDir + "/lib";
	}

	public static String[] getAssemblies ()
	{
		return MonoPackageManager_Resources.Assemblies;
	}

	public static String[] getDependencies ()
	{
		return MonoPackageManager_Resources.Dependencies;
	}

	public static String getApiPackageName ()
	{
		return MonoPackageManager_Resources.ApiPackageName;
	}
}

class MonoPackageManager_Resources {
	public static final String[] Assemblies = new String[]{
		/* We need to ensure that "SampleAppXamarin.Droid.dll" comes first in this list. */
		"SampleAppXamarin.Droid.dll",
		"Acr.Support.Android.dll",
		"Acr.UserDialogs.dll",
		"Acr.UserDialogs.Interface.dll",
		"AndHUD.dll",
		"FormsViewGroup.dll",
		"Splat.dll",
		"SQLite-net.dll",
		"SQLitePCL.batteries.dll",
		"SQLitePCL.raw.dll",
		"SQLitePCLPlugin_esqlite3.dll",
		"Xamarin.Android.Support.Design.dll",
		"Xamarin.Android.Support.v4.dll",
		"Xamarin.Android.Support.v7.AppCompat.dll",
		"Xamarin.Android.Support.v7.CardView.dll",
		"Xamarin.Android.Support.v7.MediaRouter.dll",
		"Xamarin.Forms.Core.dll",
		"Xamarin.Forms.Platform.Android.dll",
		"Xamarin.Forms.Platform.dll",
		"Xamarin.Forms.Xaml.dll",
		"Zumero.DataGrid.Android.dll",
		"Zumero.DataGrid.dll",
		"Java.Interop.dll",
		"SampleAppXamarin.dll",
		"System.Runtime.dll",
		"System.Threading.Tasks.dll",
		"System.Collections.dll",
		"System.Runtime.Extensions.dll",
		"System.Reflection.dll",
		"System.Linq.Expressions.dll",
		"System.Diagnostics.Debug.dll",
		"System.Linq.dll",
		"System.Threading.dll",
		"System.Reflection.Extensions.dll",
		"System.Resources.ResourceManager.dll",
		"System.ObjectModel.dll",
		"System.Globalization.dll",
		"System.ComponentModel.dll",
		"System.Xml.ReaderWriter.dll",
		"System.Dynamic.Runtime.dll",
		"System.IO.dll",
		"System.ServiceModel.Internals.dll",
		"System.Text.RegularExpressions.dll",
		"System.Collections.Concurrent.dll",
		"System.Runtime.InteropServices.dll",
		"System.Diagnostics.Tools.dll",
		"Microsoft.Practices.ServiceLocation.dll",
		"GalaSoft.MvvmLight.Extras.dll",
		"System.Linq.Queryable.dll",
	};
	public static final String[] Dependencies = new String[]{
	};
	public static final String ApiPackageName = "Mono.Android.Platform.ApiLevel_23";
}
