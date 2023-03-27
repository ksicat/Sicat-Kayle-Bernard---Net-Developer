using Sicat_Kayle_Bernard___Net_Developer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sicat_Kayle_Bernard___Net_Developer.Services
{
   public interface IFoodRepository
    {
       Task<List<Food>> GetFoodsAsync();
       Task<List<Food>> GetFoodsAsync(int[] ids);
       Task<Food> PostFoodAsync(Food food);
       Task<Food> PutFoodAsync(Food food);
       Task<int> RemoveFoodAsync(int Id);
    }
}
