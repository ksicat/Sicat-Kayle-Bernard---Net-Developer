using Microsoft.EntityFrameworkCore;
using Sicat_Kayle_Bernard___Net_Developer.Models;
using Sicat_Kayle_Bernard___Net_Developer.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sicat_Kayle_Bernard___Net_Developer.Services.Concretes
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApiDbContext _apiDbContext;

        public ProductRepository(ApiDbContext apiDbContext)
        {
            _apiDbContext = apiDbContext;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _apiDbContext.Products
                .ToListAsync();
        }
    
        public async Task<int> PostProductAsync(Product products)
        {
            await _apiDbContext.Products.AddRangeAsync(products);
            return await _apiDbContext.SaveChangesAsync();
        }

        public async Task<Product> PutProductAsync(Product product)
        {
            _apiDbContext.Products.Update(product);
            await _apiDbContext.SaveChangesAsync();
            return product;
        }

        public async Task<int> RemoveProductAsync(int[] productIds)
        {
            IEnumerable<Product> productsDeletion = await _apiDbContext
                .Products.Where(w => productIds.Contains(w.ProductId))
                .ToListAsync();

            _apiDbContext.Products.RemoveRange(productsDeletion);
            return await _apiDbContext.SaveChangesAsync();
        }
    }
}
