using Sicat_Kayle_Bernard___Net_Developer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sicat_Kayle_Bernard___Net_Developer.Services.Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<int> PostProductAsync(Product products);
        Task<int> RemoveProductAsync(int[] productIds);
        Task<Product> PutProductAsync(Product product);
    }
}
