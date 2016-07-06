using SampleAppXamarin.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleAppXamarin.Data
{
    public class ProductsDatabase
    {

        SQLiteConnection _connection;

        public ProductsDatabase()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
            _connection.CreateTable<Product>();
            _connection.CreateTable<ProductImage>();
        }

        public SQLiteConnection Connection()
        {
            return _connection;
        }
    }
}
