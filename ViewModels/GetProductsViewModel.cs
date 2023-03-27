using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sicat_Kayle_Bernard___Net_Developer.ViewModels
{
    public class GetProductsViewModel
    {
        public int ProductId { get; set; }
        public double Price { get; set; }
        public decimal FinalPrice { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
    }
}
