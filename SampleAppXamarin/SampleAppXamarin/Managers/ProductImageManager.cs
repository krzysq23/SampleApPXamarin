using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleAppXamarin.Models;
using SQLite;
using SampleAppXamarin.Data;

namespace SampleAppXamarin.Managers
{
    public sealed class ProductImageManager
    {
        static object locker = new object();
        private SQLiteConnection _connection;

        public ProductImageManager()
        {
            _connection = new ProductsDatabase().Connection();
        }

        public IEnumerable<ProductImage> GetProductsImage(int id)
        {
            lock (locker)
            {
                return _connection.Table<ProductImage>().Where(w => w.ProductId == id).ToList();
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
