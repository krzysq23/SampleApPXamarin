using SampleAppXamarin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAppXamarin.Services
{
    public interface ISampleAppService
    {
        Task Initialize();

        #region Products
        Task<bool> LogIn(string userName, string password);
        Task<User> GetByuserName(string userName);
        #endregion

        #region Products
        Task<IEnumerable<Product>> GetProducts();

        Task<IEnumerable<ProductImage>> GetProductImageByProductId(string productId);
        #endregion
    }
}
