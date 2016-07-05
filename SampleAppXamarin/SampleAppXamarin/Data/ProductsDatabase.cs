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

        SQLiteConnection _connection;


        public ProductsDatabase()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
            _connection.CreateTable<Product>();
            _connection.CreateTable<ProductImage>();
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

        public IEnumerable<ProductImage> GetProductsImage(int id)
        {
            lock (locker)
            {
                return _connection.Table<ProductImage>().Where(w=> w.Id == id).ToList();
            }
        }

        public IEnumerable<ProductImage> GetProductsImageNotDone()
        {
            lock (locker)
            {
                return _connection.Query<ProductImage>("SELECT * FROM [Product] WHERE [Done] = 0");
            }
        }

        public ProductImage GetProductImage(int id)
        {
            lock (locker)
            {
                return _connection.Table<ProductImage>().FirstOrDefault(x => x.Id == id);
            }
        }

        public int SaveProductImage(ProductImage item)
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

        public int DeleteProductImage(int id)
        {
            lock (locker)
            {
                return _connection.Delete<ProductImage>(id);
            }
        }
    }
}
