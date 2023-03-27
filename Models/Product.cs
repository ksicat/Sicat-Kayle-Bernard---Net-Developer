using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sicat_Kayle_Bernard___Net_Developer.Models
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductId { get; set; }
        public int ClothingId { get; set; }
        public int DrinkId { get; set; }
        public int FoodId { get; set; }
        public string Category { get; set; }
    }
}
