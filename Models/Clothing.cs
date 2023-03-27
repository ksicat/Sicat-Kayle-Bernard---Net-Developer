using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sicat_Kayle_Bernard___Net_Developer.Models
{
    public class Clothing
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ClothingId { get; set; }
        public double Price { get; set; }
        public  int Quantity { get; set; }
        public string Description { get; set; }
        public float Weight { get; set; }
    }
}
