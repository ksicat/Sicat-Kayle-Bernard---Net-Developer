using Sicat_Kayle_Bernard___Net_Developer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sicat_Kayle_Bernard___Net_Developer.Services
{
   public interface IDrinkRepository
    {
       Task<List<Drink>> GetDrinksAsync();
       Task<List<Drink>> GetDrinksAsync(int[] ids);
       Task<Drink> PostDrinkAsync(Drink food);
       Task<Drink> PutDrinkAsync(Drink food);
       Task<int> RemoveDrinkAsync(int Id);
    }
}
