using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sicat_Kayle_Bernard___Net_Developer.ViewModels
{
    public class AppSettings
    {
        public  TypeTax TypeTax { get; set; }
    }
    public class TypeTax
    {
        public decimal Drink { get; set; }
        public decimal Food { get; set; }
        public decimal Clothing { get; set; }
    }
}
