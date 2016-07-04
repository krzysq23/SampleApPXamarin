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
        static object locker = new object();

        SQLiteConnection database;


        public ProductsDatabase()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            // create the tables
            database.CreateTable<Product>();
        }

        public IEnumerable<Product> GetItems()
        {
            lock (locker)
            {
                return (from i in database.Table<Product>() select i).ToList();
            }
        }

        public IEnumerable<Product> GetItemsNotDone()
        {
            lock (locker)
            {
                return database.Query<Product>("SELECT * FROM [Product] WHERE [Done] = 0");
            }
        }

        public Product GetItem(int id)
        {
            lock (locker)
            {
                return database.Table<Product>().FirstOrDefault(x => x.Id == id);
            }
        }

        public int SaveItem(Product item)
        {
            lock (locker)
            {
                if (item.Id != 0)
                {
                    database.Update(item);
                    return item.Id;
                }
                else
                {
                    return database.Insert(item);
                }
            }
        }

        public int DeleteItem(int id)
        {
            lock (locker)
            {
                return database.Delete<Product>(id);
            }
        }
    }
}
