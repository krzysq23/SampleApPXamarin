using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleAppXamarin.Models;

namespace SampleAppXamarin.Services
{
    class MockSampleAppService : ISampleAppService
    {
        List<User> _users { get; set; } = new List<User>();
        List<Product> _products { get; set; } = new List<Product>();
        List<ProductImage> _productImage { get; set; } = new List<ProductImage>();

        public MockSampleAppService()
        {
            if (_products.Count == 0)
                _products = MockProducts();

            if (_productImage.Count == 0)
                _productImage = MockProductImage();

            if (_users.Count == 0)
                _users = MockUser();
        }

        public Task<User> GetByuserName(string userName)
        {
            return Task.FromResult(_users.FirstOrDefault(x => x.UserName == userName));
        }

        public Task Initialize()
        {
            return null;
        }

        public Task<IEnumerable<ProductImage>> GetProductImageByProductId(string productId)
        {
            IEnumerable<ProductImage> productImage = _productImage.Where(w => w.ProductId == productId).AsQueryable();
            return Task.FromResult(productImage);
        }

        public Task<IEnumerable<Product>> GetProducts()
        {
            IEnumerable<Product> products = _products.AsQueryable();
            return Task.FromResult(products);
        }

        public Task<bool> LogIn(string userName, string password)
        {
            var user = GetByuserName(userName).Result;
            return Task.FromResult(user != null && user.Password == password);
        }

        #region MockUser()
        private List<User> MockUser()
        {
            var items = new List<User>();

            var u1 = new User
            {
                UserName = "demo",
                Password = "demo"
            };
            items.Add(u1);

            return items;
        }
        #endregion

        #region MockProducts()
        private List<Product> MockProducts()
        {
            var items = new List<Product>();

            var p1 = new Product
            {
                ProductId = "1",
                Name = "audi A4"
            };
            items.Add(p1);

            var p2 = new Product
            {
                ProductId = "2",
                Name = "bmw m3"
            };
            items.Add(p2);

            var p3 = new Product
            {
                ProductId = "3",
                Name = "bmw m5"
            };
            items.Add(p3);

            var p4 = new Product
            {
                ProductId = "4",
                Name = "ferrari 458 italia"
            };
            items.Add(p4);

            return items;
        }
        #endregion

        #region MockProductImage()
        private List<ProductImage> MockProductImage()
        {
            var items = new List<ProductImage>();

            var p1 = new ProductImage
            {
                ProductId = "1",
                Url = @"http://s3.caradvice.com.au/thumb/1000/562/wp-content/uploads/2015/11/2015-audi-a4-runout-CA.jpg",
                UrlThubnail = @"https://upload.wikimedia.org/wikipedia/commons/3/32/Audi_A4_allroad_quattro_Phantomschwarz.JPG",
                Name = "audi A4",
                Description = "audi A4"
            };
            items.Add(p1);

            var p2 = new ProductImage
            {
                ProductId = "1",
                Url = @"http://s3.caradvice.com.au/thumb/1000/562/wp-content/uploads/2015/11/2015-audi-a4-runout-CA.jpg",
                UrlThubnail = @"https://upload.wikimedia.org/wikipedia/commons/3/32/Audi_A4_allroad_quattro_Phantomschwarz.JPG",
                Name = "audi A4",
                Description = "audi A4"
            };
            items.Add(p2);

            var p3 = new ProductImage
            {
                ProductId = "1",
                Url = @"http://s3.caradvice.com.au/thumb/1000/562/wp-content/uploads/2015/11/2015-audi-a4-runout-CA.jpg",
                UrlThubnail = @"https://upload.wikimedia.org/wikipedia/commons/3/32/Audi_A4_allroad_quattro_Phantomschwarz.JPG",
                Name = "audi A4",
                Description = "audi A4"
            };
            items.Add(p3);

            var p4 = new ProductImage
            {
                ProductId = "2",
                Url = @"http://pictures.topspeed.com/IMG/crop/201601/bmw-m3-rs-e9x-by-g-p-11_600x0w.jpg",
                UrlThubnail = @"http://cdn10.se.smcloud.net/t/photos/t/312774/bmw-m3-e92_19578852.jpg",
                Name = "bmw m3",
                Description = "bmw m3"
            };
            items.Add(p4);

            var p5 = new ProductImage
            {
                ProductId = "2",
                Url = @"http://s3.caradvice.com.au/thumb/1000/562/wp-content/uploads/2015/11/2015-audi-a4-runout-CA.jpg",
                UrlThubnail = @"http://cdn10.se.smcloud.net/t/photos/t/312774/bmw-m3-e92_19578852.jpg",
                Name = "bmw m3",
                Description = "bmw m3"
            };
            items.Add(p5);

            var p6 = new ProductImage
            {
                ProductId = "2",
                Url = @"http://pictures.topspeed.com/IMG/crop/201601/bmw-m3-rs-e9x-by-g-p-11_600x0w.jpg",
                UrlThubnail = @"http://cdn10.se.smcloud.net/t/photos/t/312774/bmw-m3-e92_19578852.jpg",
                Name = "bmw m3",
                Description = "bmw m3"
            };
            items.Add(p6);

            var p7 = new ProductImage
            {
                ProductId = "3",
                Url = @"http://s3.caradvice.com.au/thumb/1000/562/wp-content/uploads/2015/08/2015-bmw-m5-pure-3.jpg",
                UrlThubnail = @"http://cdn10.se.smcloud.net/t/photos/t/312774/bmw-m3-e92_19578852.jpg",
                Name = "bmw m5",
                Description = "bmw m5"
            };
            items.Add(p7);

            var p8 = new ProductImage
            {
                ProductId = "3",
                Url = @"http://s3.caradvice.com.au/thumb/1000/562/wp-content/uploads/2015/08/2015-bmw-m5-pure-3.jpg",
                UrlThubnail = @"http://cdn10.se.smcloud.net/t/photos/t/312774/bmw-m3-e92_19578852.jpg",
                Name = "bmw m5",
                Description = "bmw m5"
            };
            items.Add(p8);

            var p9 = new ProductImage
            {
                ProductId = "3",
                Url = @"http://pictures.topspeed.com/IMG/crop/201601/bmw-m3-rs-e9x-by-g-p-11_600x0w.jpg",
                UrlThubnail = @"http://cdn10.se.smcloud.net/t/photos/t/312774/bmw-m3-e92_19578852.jpg",
                Name = "bmw m3",
                Description = "bmw m3"
            };
            items.Add(p9);

            var p10 = new ProductImage
            {
                ProductId = "4",
                Url = @"http://s1.blomedia.pl/autokult.pl/images/2010/08/2010-ferrari-458-italia.jpg",
                UrlThubnail = @"http://cdn10.se.smcloud.net/t/photos/t/312774/bmw-m3-e92_19578852.jpg",
                Name = "ferrari 458 italia",
                Description = "ferrari 458 italia"
            };
            items.Add(p10);

            return items;
        }
        #endregion
    }
}
