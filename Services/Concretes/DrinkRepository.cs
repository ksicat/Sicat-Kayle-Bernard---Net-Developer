using Microsoft.EntityFrameworkCore;
using Sicat_Kayle_Bernard___Net_Developer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sicat_Kayle_Bernard___Net_Developer.Services.Concretes
{
    public class DrinkRepository : IDrinkRepository
    {
        private readonly ApiDbContext _apiDbContext;
        public DrinkRepository(ApiDbContext apiDbContext)
        {
            _apiDbContext = apiDbContext;
        }
        public async Task<List<Drink>> GetDrinksAsync()
        {
            return await _apiDbContext.Drinks.ToListAsync();
        }
        public async Task<List<Drink>> GetDrinksAsync(int[] ids)
        {
            return await _apiDbContext.Drinks.Where(w => ids.Any(a=> w.DrinkId == a)).ToListAsync();
        }
        public async Task<Drink> PostDrinkAsync(Drink drink)
        {
             _apiDbContext.Drinks.AddRange(drink);
            await _apiDbContext.SaveChangesAsync();
            return drink;
        }
        public async Task<Drink> PutDrinkAsync(Drink drink)
        {
            _apiDbContext.Drinks.Update(drink);
            await _apiDbContext.SaveChangesAsync();
            return drink;
        }
        public async Task<int> RemoveDrinkAsync(int Id)
        {
            _apiDbContext.Drinks.Remove(_apiDbContext.Drinks.FirstOrDefault(x => x.DrinkId == Id));
            return await _apiDbContext.SaveChangesAsync(); 
        }
    }
}
