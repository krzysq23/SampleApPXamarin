using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using SampleAppXamarin.Data;
using SampleAppXamarin.Droid;
using System.IO;
using SQLite;

[assembly: Dependency(typeof(SQLite_Android))]

namespace SampleAppXamarin.Droid
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android()
        {
        }

        public SQLite.SQLiteConnection GetConnection()
        {
            var sqliteFilename = "ProductSQLite.db3";

            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);

            var conn = new SQLiteConnection(path);

            return conn;
        }


    }
}