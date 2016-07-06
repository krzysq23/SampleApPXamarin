using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleAppXamarin.Models;
using SampleAppXamarin.Data;
using SQLite;

namespace SampleAppXamarin.Managers
{
    public sealed class ProductManager
    {
        static object locker = new object();

        private SQLiteConnection _connection;

        public ProductManager()
        {
            _connection = new ProductsDatabase().Connection();
        }

        public IEnumerable<Product> GetProducts()
        {
            lock (locker)
            {
                return (from i in _connection.Table<Product>() select i).ToList();
            }
        }

        public IEnumerable<Product> GetProductsNotDone()
        {
            lock (locker)
            {
                return _connection.Query<Product>("SELECT * FROM [Product] WHERE [Done] = 0");
            }
        }

        public Product GetProduct(string name)
        {
            lock (locker)
            {
                return _connection.Table<Product>().FirstOrDefault(x => x.Name == name);
            }
        }

        public int SaveProduct(Product item)
        {
            lock (locker)
            {
                if (item.Id != 0)
                {
                    _connection.Update(item);
                    return item.Id;
                }
                else
                {
                    return _connection.Insert(item);
                }
            }
        }

        public int DeleteProduct(int id)
        {
            lock (locker)
            {
                return _connection.Delete<Product>(id);
            }
        }
    }
}
