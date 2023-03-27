
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sicat_Kayle_Bernard___Net_Developer.Models
{
    public class Food
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FoodId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public float Weight { get; set; } 
    }
}
