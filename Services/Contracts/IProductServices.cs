using Sicat_Kayle_Bernard___Net_Developer.Models;
using Sicat_Kayle_Bernard___Net_Developer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Sicat_Kayle_Bernard___Net_Developer.ViewModels.AppSettings;

namespace Sicat_Kayle_Bernard___Net_Developer.Services.Contracts
{
    public interface IProductServices
    {
        Task<IEnumerable<Product>> InsertProductsServices(ProductsViewModel productViewModel);
        Task<IEnumerable<GetProductsViewModel>> GetProducts(TypeTax typeTax, decimal between, decimal to);
    }
}
